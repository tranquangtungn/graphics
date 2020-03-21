using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint2
{
    class CElip : CRect
    {
        public CElip() : base()
        {

            loaiHinh = 3;
        }

        public CElip(Color myColor, int sizePen, DashStyle myDashStyle)
            : base(myColor, sizePen, myDashStyle)
        {
            loaiHinh = 3;
        }

        public override void Ve(Graphics g)
        {
            Pen pen = new Pen(myColor, sizePen) { DashStyle = myDashStyle };
            g.DrawEllipse(pen, VeHCN(diemBatDau, diemKetThuc));
            pen.Dispose();
        }

        public override void VeKhung(Graphics g)
        {
            base.VeKhung(g);
            Pen p = new Pen(Color.Black, 1)
            {
                DashStyle = DashStyle.Dash,
                DashPattern = new float[] { 7, 7, 7, 7 }
            };
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawRectangle(p, VeHCN(diemBatDau, diemKetThuc));
            p.Dispose();
        }
    }
}
