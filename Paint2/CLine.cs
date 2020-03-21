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
    class CLine : HinhVe
    {
        public CLine() : base()
        {
            soDiemDieuKhien = 2;
            diemBatDau.X = 0; diemBatDau.Y = 0;
            diemKetThuc.X = 0; diemKetThuc.Y = 1;
            Pen pen = new Pen(myColor, sizePen) { DashStyle = myDashStyle };
            graphicsPath = new GraphicsPath();
            graphicsPath.AddRectangle(new Rectangle(0, 0, 0, 1));
            graphicsPath.Widen(pen);
            khuVuc = new Region(new Rectangle(0, 0, 0, 1));
            khuVuc.Union(graphicsPath);
            loaiHinh = 1;
        }

        public CLine(Color myColor, int sizePen, DashStyle myDashStyle)
            : base(myColor, sizePen, myDashStyle)
        {
            soDiemDieuKhien = 2;
            diemBatDau.X = 0; diemBatDau.Y = 0;
            diemKetThuc.X = 0; diemKetThuc.Y = 1;
            Pen pen = new Pen(myColor, sizePen) { DashStyle = myDashStyle };
            graphicsPath = new GraphicsPath();
            graphicsPath.AddRectangle(new Rectangle(0, 0, 0, 1));
            graphicsPath.Widen(pen);
            khuVuc = new Region(new Rectangle(0, 0, 0, 1));
            khuVuc.Union(graphicsPath);
            loaiHinh = 1;
        }

        public override void Ve(Graphics g)
        {
            Pen pen = new Pen(myColor, sizePen) { DashStyle = myDashStyle };
            g.DrawLine(pen, diemBatDau, diemKetThuc);
            pen.Dispose();
        }

        // Tạo điểm điều khiển
        protected override Point DiemDieuKhien(int viTriDiemDieuKhien)
        {
            if (viTriDiemDieuKhien == 1)
                return diemBatDau;
            return diemKetThuc;
        }

        // Thay đổi điểm Start, End khi Click vào 1 điểm điều khiển
        protected override void ThayDoiDiem(int viTriDiemDieuKhien)
        {
            if (viTriDiemDieuKhien == 1)
            {
                Point point = diemBatDau;
                diemBatDau = diemKetThuc;
                diemKetThuc = point;
            }
        }

        // Di chuyển đối tượng khi biết 1 điểm điều khiển và điểm đến
        protected override void ThayDoiKichThuoc(int viTriDiemDieuKhien, Point point)
        {
            diemKetThuc = point;
        }
        //
        public override void VeKhung(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 1);
            // SolidBrush brush = new SolidBrush(Color.White);
            for (int i = 1; i <= soDiemDieuKhien; i++)
            {
                g.FillRectangle(new SolidBrush(Color.White), VeChamVuong(i, 6));
                g.DrawRectangle(pen, VeChamVuong(i, 3));
            }
            pen.Dispose();
        }
        // Sự kiện chuột
        public override void Mouse_Down(MouseEventArgs e)
        {
            viTriChuotSoVoiHinhVe = KiemTraViTri(e.Location);
            if (viTriChuotSoVoiHinhVe > 0)
            {
                thayDoiKichThuoc = true;
                ThayDoiDiem(viTriChuotSoVoiHinhVe);
            }
            else if (viTriChuotSoVoiHinhVe == 0)
            {
                diChuyen = true;
                viTriChuot = e.Location;
            }
            else
            {
                diemBatDau = e.Location;
                diemKetThuc.X = e.X; diemKetThuc.Y = e.Y - 1;
            }
        }

        public override void Mouse_Move(MouseEventArgs e)
        {
            if (thayDoiKichThuoc == true)
            {
                ThayDoiKichThuoc(viTriChuotSoVoiHinhVe, e.Location);
            }
            else if (diChuyen == true)
            {
                int deltaX = e.X - viTriChuot.X;
                int deltaY = e.Y - viTriChuot.Y;
                viTriChuot = e.Location;
                DiChuyen(deltaX, deltaY);
            }
            else
            {
                diemKetThuc = e.Location;
            }
        }

        public override void Mouse_Up(Object sender)
        {
            graphicsPath = new GraphicsPath();
            Pen pen = new Pen(myColor, sizePen) { DashStyle = myDashStyle };
            graphicsPath.AddLine(diemBatDau, diemKetThuc);
            pen.Width = sizePen + 20;
            graphicsPath.Widen(pen);

            //tạo vùng chọn cho line
            GraphicsPath gp = new GraphicsPath();
            khuVuc = new Region(gp);
            khuVuc.Union(graphicsPath);
            diChuyen = false;
            thayDoiKichThuoc = false;
            viTriChuotSoVoiHinhVe = -1;
        }
    }
}
