using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint2
{
    class CBerzier : CElip
    {
        Point diem2 = new Point(), diem3 = new Point();
        bool chinhSua = false;
        public CBerzier() : base()
        {
            soDiemDieuKhien = 4;
            loaiHinh = 2;
            diem2 = diemBatDau;
            diem3 = diemKetThuc;
        }

        public CBerzier(Color myColor, int sizePen, DashStyle myDashStyle)
            : base(myColor, sizePen, myDashStyle)
        {
            soDiemDieuKhien = 4;
            loaiHinh = 2;
            diem2 = diemBatDau;
            diem3 = diemKetThuc;
        }
        public override void Ve(Graphics g)
        {
            Pen pen = new Pen(myColor, sizePen) { DashStyle = myDashStyle };
            if (chinhSua)
                g.DrawBezier(pen, diemBatDau, diem2, diem3, diemKetThuc);
            else
                g.DrawLine(pen, diemBatDau, diemKetThuc);
            //g.DrawBezier(pen, diemBatDau, diemBatDau, diemKetThuc, diemKetThuc);
            pen.Dispose();
        }
        Rectangle VeHCN(Point diemBatDau, Point diemKetThuc, Point diem2, Point diem3)
        {
            Point diemGoc = new Point();    //điểm góc trên trái hcn
            Point diemGoc2 = new Point();   //điểm góc dưới phải hcn
            diemGoc.X = Math.Min(
                Math.Min(diemBatDau.X, diemKetThuc.X),
                Math.Min(diem2.X, diem3.X));
            diemGoc.Y = Math.Min(
                Math.Min(diemBatDau.Y, diemKetThuc.Y),
                Math.Min(diem2.Y, diem3.Y));
            diemGoc2.X = Math.Max(
                 Math.Max(diemBatDau.X, diemKetThuc.X),
                 Math.Max(diem2.X, diem3.X));
            diemGoc2.Y = Math.Max(
                Math.Max(diemBatDau.Y, diemKetThuc.Y),
                Math.Max(diem2.Y, diem3.Y));
            Size kichThuoc = new Size(Math.Abs(diemGoc.X - diemGoc2.X),
                Math.Abs(diemGoc.Y - diemGoc2.Y));

            return new Rectangle(diemGoc, kichThuoc);
        }
        public override void VeKhung(Graphics g)
        {
            if (chinhSua == false)
            {
                diem2 = DiemDieuKhien(2);
                diem3 = DiemDieuKhien(3);
            }
            Pen p = new Pen(Color.Black, 1)
            {
                DashStyle = DashStyle.Dash,
                DashPattern = new float[] { 7, 7, 7, 7 }
            };
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawRectangle(p, VeHCN(diemBatDau, diemKetThuc, diem2, diem3));
            p.Dispose();

            for (int i = 1; i <= soDiemDieuKhien; i++)
            {
                Pen pen = new Pen(Color.Black, 1);
                g.FillRectangle(new SolidBrush(Color.White), VeChamVuong(i, 10));   //tô chấm vuông
                g.DrawRectangle(pen, VeChamVuong(i, 5));
                pen.Dispose();
            }


        }
        // Tạo điểm điều khiển
        protected override Point DiemDieuKhien(int viTriDiemDieuKhien)
        {

            int xCenter = Math.Abs(diemBatDau.X - diemKetThuc.X) / 3;
            int yCenter = Math.Abs(diemBatDau.Y - diemKetThuc.Y) / 3;
            int x = 0, y = 0;
            switch (viTriDiemDieuKhien)
            {
                case 1:
                    {
                        x = diemBatDau.X;
                        y = diemBatDau.Y;
                        break;
                    }
                case 2:
                    {
                        if (chinhSua)
                        {
                            x = diem2.X;
                            y = diem2.Y;
                        }
                        else
                            switch (GocPhanTu(diemBatDau, diemKetThuc))
                            {
                                case 1:
                                    {
                                        x = diemBatDau.X + xCenter;
                                        y = diemBatDau.Y - yCenter;
                                    }
                                    break;
                                case 2:
                                    {
                                        x = diemBatDau.X - xCenter;
                                        y = diemBatDau.Y - yCenter;
                                    }
                                    break;
                                case 3:
                                    {
                                        x = diemBatDau.X - xCenter;
                                        y = diemBatDau.Y + yCenter;
                                    }
                                    break;
                                case 4:
                                    {
                                        x = diemBatDau.X + xCenter;
                                        y = diemBatDau.Y + yCenter;
                                    }
                                    break;
                            }
                        break;
                    }
                case 3:
                    {
                        if (chinhSua)
                        {
                            x = diem3.X;
                            y = diem3.Y;
                        }
                        else
                            switch (GocPhanTu(diemBatDau, diemKetThuc))
                            {
                                case 1:
                                    {
                                        x = diemKetThuc.X - xCenter;
                                        y = diemKetThuc.Y + yCenter;
                                    }
                                    break;
                                case 2:
                                    {
                                        x = diemKetThuc.X + xCenter;
                                        y = diemKetThuc.Y + yCenter;
                                    }
                                    break;
                                case 3:
                                    {
                                        x = diemKetThuc.X + xCenter;
                                        y = diemKetThuc.Y - yCenter;
                                    }
                                    break;
                                case 4:
                                    {
                                        x = diemKetThuc.X - xCenter;
                                        y = diemKetThuc.Y - yCenter;
                                    }
                                    break;
                            }
                        break;
                    }
                case 4:
                    {
                        x = diemKetThuc.X;
                        y = diemKetThuc.Y;
                        break;
                    }
            }
            return new Point(x, y);
        }
        protected void ThayDoiDiem(int viTriDiemDieuKhien, Point e)
        {
            
        }
        protected override void ThayDoiKichThuoc(int viTriDiemDieuKhien, Point newPoint)
        {
            //int deltaX = newPoint.X - viTriChuot.X;
            //int deltaY = newPoint.Y - viTriChuot.Y;
            viTriChuot = newPoint;
            switch (viTriDiemDieuKhien)
            {
                case 1:
                    diemBatDau = newPoint;
                    break;
                case 2:
                    diem2 = newPoint;
                    break;
                case 3:
                    diem3 = newPoint;
                    break;
                case 4:
                    diemKetThuc = newPoint;
                    break;
            }
        }
        public override void DiChuyen(int deltaX, int deltaY)
        {
            base.DiChuyen(deltaX, deltaY);
            diem2.X += deltaX;
            diem2.Y += deltaY;
            diem3.X += deltaX;
            diem3.Y += deltaY;
        }
        public override void Mouse_Down(MouseEventArgs e)
        {
            viTriChuotSoVoiHinhVe = KiemTraViTri(e.Location);
            //đánh dấu bắt đầu thay đổi kích thước
            if (viTriChuotSoVoiHinhVe > 0)
            {
                thayDoiKichThuoc = true;
                ThayDoiDiem(viTriChuotSoVoiHinhVe, e.Location);
                viTriChuot = e.Location;
            }
            //đánh dấu băt đầu di chuyển
            else if (viTriChuotSoVoiHinhVe == 0)
            {

                diChuyen = true;
                viTriChuot = e.Location;
            }
            //vẽ hình mới
            else
            {
                diemBatDau = e.Location;
                diemKetThuc.X = e.X; diemKetThuc.Y = e.Y - 1;
            }

            Console.WriteLine(viTriChuotSoVoiHinhVe + "");
        }
        public override void Mouse_Move(MouseEventArgs e)
        {
            base.Mouse_Move(e);
            Console.WriteLine(chinhSua + " " +
                diemBatDau + "--" + diemKetThuc + "--" +
                diem2 + "--" + diem3);
        }
        public override void Mouse_Up(object sender)
        {
            if (chinhSua == false)
            {
                chinhSua = true;
                diem2 = DiemDieuKhien(2);
                diem3 = DiemDieuKhien(3);
            }
            graphicsPath = new GraphicsPath();
            Pen pen = new Pen(myColor, sizePen) { DashStyle = myDashStyle };
            graphicsPath.AddRectangle(VeHCN(diemBatDau, diem2, diem3, diemKetThuc));
            graphicsPath.Widen(pen);
            khuVuc = new Region(VeHCN(diemBatDau, diem2, diem3, diemKetThuc));
            khuVuc.Union(graphicsPath);
            diChuyen = false;
            thayDoiKichThuoc = false;
            viTriChuotSoVoiHinhVe = -1;
            Console.WriteLine("HCN" + VeHCN(diemBatDau, diem2, diem3, diemKetThuc));
        }
    }
}
