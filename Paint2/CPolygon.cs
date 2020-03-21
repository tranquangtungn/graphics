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
    class CPolygon : CLine
    {
        List<Point> listPoint = new List<Point>();
        public CPolygon()
        {
            soDiemDieuKhien = soDinh;
            loaiHinh = 5;
        }
        public CPolygon(Color myColor, int sizePen, DashStyle myDashStyle)
            : base(myColor, sizePen, myDashStyle)
        {
            soDiemDieuKhien = soDinh;
            loaiHinh = 5;
        }

        public override void DiChuyen(int deltaX, int deltaY)
        {
            if (veXong)
            {
                for (int i = 0; i < listPoint.Count; i++)
                {
                    listPoint[i] = new Point(
                        listPoint[i].X + deltaX,
                        listPoint[i].Y + deltaY);
                }
            }
        }

        public override int KiemTraViTri(Point point)
        {
            return base.KiemTraViTri(point);
        }

        public override void Mouse_Down(MouseEventArgs e)
        {
            viTriChuotSoVoiHinhVe = KiemTraViTri(e.Location);
            if (viTriChuotSoVoiHinhVe > 0)
            {
                if (viTriChuotSoVoiHinhVe == 1 && veXong == false)
                {
                    veXong = true;
                }
                else
                    thayDoiKichThuoc = true;
            }
            else if (viTriChuotSoVoiHinhVe == 0 && veXong)
            {
                diChuyen = true;
                viTriChuot = e.Location;
            }
            else
            {
                listPoint.Add(e.Location);
                soDinh++;
                soDiemDieuKhien = listPoint.Count;
                if (soDinh == 1)
                {
                    diemBatDau = listPoint[0];
                    //diemKetThuc.X = e.X; diemKetThuc.Y = e.Y - 1;
                }
                else
                    diemKetThuc = e.Location;
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

        public override void Mouse_Up(object sender)
        {
            if (veXong)
            {
                graphicsPath = new GraphicsPath();
                Pen pen = new Pen(myColor, sizePen) { DashStyle = myDashStyle };
                //graphicsPath.AddRectangle(VeHCN(diemBatDau, diemKetThuc));
                graphicsPath.AddPolygon(listPoint.ToArray());
                graphicsPath.Widen(pen);
                khuVuc = new Region(graphicsPath);
                diChuyen = false;
                thayDoiKichThuoc = false;
                viTriChuotSoVoiHinhVe = -1;
            }
        }

        public override void ThayDoi()
        {
            base.ThayDoi();
        }

        public override void Ve(Graphics g)
        {
            Pen pen = new Pen(myColor, sizePen) { DashStyle = myDashStyle };
            if (veXong)
            {
                g.DrawPolygon(pen, listPoint.ToArray());
            }
            else
            {
                if (listPoint.Count >= 2)
                    g.DrawLines(pen, listPoint.ToArray());
                g.DrawLine(pen, listPoint.Last(), diemKetThuc);
            }
            pen.Dispose();
        }

        public override void VeHCNDiemDieuKhien(Graphics g, int doDamNet)
        {
            base.VeHCNDiemDieuKhien(g, doDamNet);
        }

        public override void VeKhung(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.Black, 1);
            //for (int i = 1; i <= listPoint.Count - 1; i++)
            //{
            //    g.FillRectangle(new SolidBrush(Color.White), VeChamVuong(i, 6));
            //    g.DrawRectangle(pen, VeChamVuong(i, 3));
            //}
            foreach (var item in listPoint)
            {
                Point p = new Point();
                p.X = item.X - 5;
                p.Y = item.Y - 5;
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(p, new Size(10, 10)));
                p.X = item.X - 3;
                p.Y = item.Y - 3;
                g.DrawRectangle(pen, new Rectangle(p, new Size(6, 6)));
            }

            if (veXong)
            {
                Pen p = new Pen(Color.Black, 1)
                {
                    DashStyle = DashStyle.Dash,
                    DashPattern = new float[] { 7, 7, 7, 7 }
                };
                g.DrawRectangle(p, VeHCN(listPoint));
                p.Dispose();
            }
            pen.Dispose();
        }

        protected override Point DiemDieuKhien(int viTriDiemDieuKhien)
        {
            return listPoint[viTriDiemDieuKhien - 1];
        }

        protected override bool KiemTraThuoc(Point point)
        {
            return base.KiemTraThuoc(point);
        }

        protected override void ThayDoiDiem(int viTriDiemDieuKhien)
        {
        }

        protected override void ThayDoiKichThuoc(int viTriDiemDieuKhien, Point newPoint)
        {
            listPoint[viTriDiemDieuKhien - 1] = newPoint;
        }

        protected override Rectangle VeChamVuong(int viTriDiemDieuKhien)
        {
            return base.VeChamVuong(viTriDiemDieuKhien);
        }

        protected override Rectangle VeChamVuong(int viTriDiemDieuKhien, int doRongHCN)
        {
            return base.VeChamVuong(viTriDiemDieuKhien, doRongHCN);
        }

        protected override Rectangle VeHCN(Point p1, Point p2)
        {
            return base.VeHCN(p1, p2);
        }
        Rectangle VeHCN(List<Point> listPoint)
        {
            int diemGocX = listPoint.Min(item => item.X);
            int diemGocY = listPoint.Min(item => item.Y);
            int w = listPoint.Max(item => item.X) - diemGocX;
            int h = listPoint.Max(item => item.Y) - diemGocY;
            return new Rectangle(diemGocX, diemGocY, w, h);
        }

    }
}
