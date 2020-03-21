using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint2
{
    class HinhVe
    {
        public int sizePen;
        public Color myColor;
        public DashStyle myDashStyle;
        protected Brush myBrush;
        protected Pen myPen;
        public Point diemBatDau;
        public Point diemKetThuc;
        public bool diChuyen;
        public bool thayDoiKichThuoc;
        protected int soDiemDieuKhien;
        public Region khuVuc;
        protected Point viTriChuot;
        protected int viTriChuotSoVoiHinhVe;
        protected GraphicsPath graphicsPath;
        public int loaiHinh;
        public bool isSelected = false;
        public bool veXong = false;
        public int soDinh = 0;
        public HinhVe()
        {
            this.myColor = Color.Black;
            this.sizePen = 1;
            this.myDashStyle = DashStyle.Solid;
        }
        public HinhVe(Color myColor, int sizePen, DashStyle myDashStyle)
        {
            this.myColor = myColor;
            this.sizePen = sizePen;
            this.myDashStyle = myDashStyle;
        }
        #region Phương thức
        // hoán đổi điểm bắt đầu và kết thúc
        public virtual void ThayDoi()
        {
            if (diemBatDau.X > diemKetThuc.X)
            {
                int tam = diemKetThuc.X;
                diemKetThuc.X = diemBatDau.X;
                diemBatDau.X = tam;
            }
            if (diemBatDau.Y > diemKetThuc.Y)
            {
                int tam = diemKetThuc.Y;
                diemKetThuc.Y = diemBatDau.Y;
                diemBatDau.Y = tam;
            }
        }

        // Vẽ
        public virtual void Ve(Graphics g)
        {
        }

        // Tạo điểm điều khiển
        protected virtual Point DiemDieuKhien(int viTriDiemDieuKhien)
        {
            return new Point(0, 0);
        }

        // Tạo HCN quanh điểm điều khiển (8 chấm vuông)
        protected virtual Rectangle VeChamVuong(int viTriDiemDieuKhien)
        {
            Point point = DiemDieuKhien(viTriDiemDieuKhien);
            return new Rectangle(point.X - 5, point.Y - 5, 10, 10);
        }
        protected virtual Rectangle VeChamVuong(int viTriDiemDieuKhien, int doRongHCN)
        {
            Point point = DiemDieuKhien(viTriDiemDieuKhien);
            return new Rectangle(point.X - doRongHCN / 2, point.Y - doRongHCN / 2, doRongHCN, doRongHCN);
        }
        protected virtual Rectangle VeHCN(Point p1, Point p2)
        {
            Point diemGoc = new Point();
            Size kichThuoc = new Size(Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
            int viTri = GocPhanTu(p1, p2);
            switch (viTri)
            {
                case 1:
                    {
                        diemGoc.X = p1.X;
                        diemGoc.Y = p2.Y;
                    }
                    break;
                case 2:
                    {
                        diemGoc = p2;
                    }
                    break;
                case 3:
                    {
                        diemGoc.X = p2.X;
                        diemGoc.Y = p1.Y;
                    }
                    break;
                default:
                    {
                        diemGoc = p1;
                    }
                    break;
            }
            return new Rectangle(diemGoc, kichThuoc);
        }
        public virtual void VeKhung(Graphics g)
        {
            for (int i = 1; i <= soDiemDieuKhien; i++)
            {
                Pen pen = new Pen(Color.Black, 1);
                g.FillRectangle(new SolidBrush(Color.White), VeChamVuong(i, 10));   //tô chấm vuông
                g.DrawRectangle(pen, VeChamVuong(i, 5));
                pen.Dispose();
            }
        }

        public virtual void VeHCNDiemDieuKhien(Graphics g, int doDamNet)
        {

            for (int i = 1; i <= soDiemDieuKhien; i++)
            {
                Pen pen = new Pen(Color.Black, doDamNet);
                g.DrawRectangle(pen, VeChamVuong(i, 5));
                g.FillRectangle(Brushes.White, VeChamVuong(i, 4));
                pen.Dispose();
            }

        }
        // Kiểm tra xem 1 điểm có thuộc khu vực chiếm giữ đối tượng này hay không
        protected virtual bool KiemTraThuoc(Point point)
        {
            if (khuVuc.IsVisible(point) == true)
                return true;
            return false;
        }
        public bool soSanh(Point diemBatDau, Point DiemKetThuc)
        {
            Rectangle rect1 = new Rectangle(new Point(diemBatDau.X-5,diemBatDau.Y-5), new Size(10, 10));
            Rectangle rect2 = new Rectangle(new Point(diemKetThuc.X-5,diemKetThuc.Y-5), new Size(10, 10));
            Rectangle rect3 = Rectangle.Intersect(rect1, rect2);
            if (rect3.IsEmpty)
                return false;
            return true;

        }
        // Kiểm tra vị trí tương đối của 1 điểm và 1 đối tượng
        // - 1 : Nằm ngoài đối tượng
        // =0   : Trong đối tượng
        // >= 1 : Điểm điều khiển 
        public virtual int KiemTraViTri(Point point)
        {
            for (int i = 1; i <= soDiemDieuKhien; i++)
            {
                if (VeChamVuong(i).Contains(point) == true)
                    //điểm đó nằm trên hình chữ nhật bao quanh
                    //1 điểm điều khiển (8 chấm vuông nhỏ)
                    return i;
            }
            if (KiemTraThuoc(point) == true)    // điểm đó thuộc khu vực bên trong hình bao quanh
                return 0;
            return -1;  //điểm và hình tách biệt nhau
        }

        // Xác định lại điểm Start và End khi Click vào 1 điểm điều khiển
        protected virtual void ThayDoiDiem(int viTriDiemDieuKhien)
        {
        }

        // Di chuyển đối tượng khi move = true
        public virtual void DiChuyen(int deltaX, int deltaY)
        {
            diemBatDau.X += deltaX;
            diemBatDau.Y += deltaY;
            diemKetThuc.X += deltaX;
            diemKetThuc.Y += deltaY;
        }

        // Thay đổi kích thước đối tượng khi biết điểm điều khiển và điển đến, resize = true
        protected virtual void ThayDoiKichThuoc(int viTriDiemDieuKhien, Point point)
        {
        }
        //vị trí tương tối của điểm p1 so với p2
        protected int GocPhanTu(Point p1, Point p2)
        {
            if (p1.X <= p2.X && p1.Y >= p2.Y)
                return 1;
            if (p1.X > p2.X && p1.Y > p2.Y)
                return 2;
            if (p1.X >= p2.X && p1.Y <= p2.Y)
                return 3;
            return 4;
        }
        // Sự kiện chuột
        public virtual void Mouse_Down(MouseEventArgs e)
        {
        }
        public virtual void Mouse_Move(MouseEventArgs e)
        {

        }
        public virtual void Mouse_Up(Object sender)
        {

        }

        #endregion
    }
}
