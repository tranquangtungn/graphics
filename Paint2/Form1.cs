using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint2
{
    public partial class Form1 : Form
    {
        ColorDialog colorDialog = new ColorDialog() { FullOpen = true };
        int[] listSizePen = Enumerable.Range(1, 100).ToArray();
        List<HinhVe> listHinh = new List<HinhVe>();
        HinhVe hinhHienTai = new HinhVe();
        int idHinhHienTai;
        int viTriHinhHienTaiTrongListHinh;
        Color mauVe;
        int doDamNet;
        DashStyle kieuButVe;
        bool isMoving = false;
        bool isSelected = true; //ở chế độ chọn hay chế độ vẽ
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        //khởi tạo
        private void Init()
        {
            plDraw.SetDoubleBuffered();
            cbBoxStyle.DataSource =
                Enum.GetValues(typeof(DashStyle))
            .Cast<DashStyle>()
            .Where(p => p != DashStyle.Custom)
            .ToArray<DashStyle>();
            cbBoxStyle.SelectedIndex = 0;
            cbBoxSize.DataSource = listSizePen;
            cbBoxSize.SelectedIndex = 4;
            rbMouse.Select();

            mauVe = btnColor.BackColor;
            doDamNet = Int32.Parse(cbBoxSize.SelectedValue.ToString());
            kieuButVe = (DashStyle)(cbBoxStyle.SelectedItem);
        }
        private void cbBoxStyle_DrawItem(object sender, DrawItemEventArgs e)
        {
            Pen pen1 = new Pen(Color.Black, 3);
            ComboBox comboBox = sender as ComboBox;
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawLine(new Pen(Color.OrangeRed, 3) { DashStyle = (DashStyle)cbBoxStyle.Items[e.Index] },
                e.Bounds.Left, e.Bounds.Top + 10,
                e.Bounds.Right, e.Bounds.Top + 10);


        }
        private void cbBoxStyle_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 20;
            e.ItemWidth = 500;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            plDraw.Controls.Clear();
            listHinh.Clear();
            plDraw.Refresh();
        }
        private void btnColor_Click(object sender, EventArgs e)
        {
            DialogResult colorResult = colorDialog.ShowDialog();
            if (colorResult == DialogResult.OK)
            {
                btnColor.BackColor = colorDialog.Color;
                mauVe = btnColor.BackColor;
                if (hinhHienTai != null)
                    hinhHienTai.myColor = mauVe;
                plDraw.Refresh();
                if (hinhHienTai != null)
                    hinhHienTai.VeKhung(plDraw.CreateGraphics());
            }
        }

        private void plDraw_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in listHinh)
            {
                item.Ve(e.Graphics);
            }
        }

        private int GocPhanTu(Point p1, Point p2)
        {
            if (p1.X <= p2.X && p1.Y >= p2.Y)
                return 1;
            if (p1.X > p2.X && p1.Y > p2.Y)
                return 2;
            if (p1.X >= p2.X && p1.Y <= p2.Y)
                return 3;
            return 4;
        }
        private int LayLoaiHinh()
        {
            if (rbLine.Checked)
                return 1;
            if (rbBezier.Checked)
                return 2;
            if (rbEclipse.Checked)
                return 3;
            if (rbRectangle.Checked)
                return 4;
            if (rbPolygon.Checked)
                return 5;
            return -1;
        }
        HinhVe LayHinhVeHienTai(int IDHinhAnhHienTai)
        {
            switch (IDHinhAnhHienTai)
            {
                case 1: return new CLine(mauVe, doDamNet, kieuButVe);
                case 2: return new CBerzier(mauVe, doDamNet, kieuButVe);
                case 3: return new CElip(mauVe, doDamNet, kieuButVe);
                case 4: return new CRect(mauVe, doDamNet, kieuButVe);
                case 5: return new CPolygon(mauVe, doDamNet, kieuButVe);
                default: return null;//giá trị -1 
            }

        }

        private void cbBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            doDamNet = Int32.Parse(cbBoxSize.SelectedValue.ToString());
            if (hinhHienTai != null)
                hinhHienTai.sizePen = doDamNet;
            plDraw.Refresh();
            if (hinhHienTai != null)
                hinhHienTai.VeKhung(plDraw.CreateGraphics());
        }

        private void cbBoxStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            kieuButVe = (DashStyle)(cbBoxStyle.SelectedItem);
            if (hinhHienTai != null)
                hinhHienTai.myDashStyle = kieuButVe;

            plDraw.Refresh();
            if (hinhHienTai != null)
                hinhHienTai.VeKhung(plDraw.CreateGraphics());
        }

        private void rbMouse_CheckedChanged(object sender, EventArgs e)
        {
            isSelected = true;
            hinhHienTai = null;
            isMoving = false;
            idHinhHienTai = -1;
            plDraw.Refresh();
        }
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            isSelected = false;
            hinhHienTai = null;
            isMoving = false;
            //idHinhHienTai = -1;
            plDraw.Refresh();
        }

        #region Sự kiện chuột


        private void plDraw_MouseDown(object sender, MouseEventArgs e)
        {
            plDraw.Refresh();
            if (e.Button == MouseButtons.Left)
            {
                //chọn hình để di chuyển or thay đổi kích thước
                if (isSelected)
                {
                    for (int i = listHinh.Count - 1; i >= 0; i--)
                    {
                        int vt = (listHinh[i].KiemTraViTri(e.Location));
                        if (vt >= 0)
                        {
                            hinhHienTai = listHinh[i];
                            idHinhHienTai = listHinh[i].loaiHinh;
                            viTriHinhHienTaiTrongListHinh = i;
                            hinhHienTai.VeKhung(plDraw.CreateGraphics());
                            hinhHienTai.isSelected = true;
                            //chuột nằm trong hình
                            if (vt == 0)
                            {
                                hinhHienTai.diChuyen = true;
                                hinhHienTai.thayDoiKichThuoc = false;
                            }
                            //chuột nằm ngay điểm điều khiển
                            else
                            {
                                hinhHienTai.diChuyen = false;
                                hinhHienTai.thayDoiKichThuoc = true;
                            }
                            break;
                        }
                    }
                    //nếu chuột nằm bên ngoài hình mà click chọn thì reset hình đang vẽ
                    if (hinhHienTai == null
                    || hinhHienTai.KiemTraViTri(e.Location) == -1)
                    {
                        idHinhHienTai = -1;
                        viTriHinhHienTaiTrongListHinh = -1;
                    }
                    //chọn dc hình dã vẽ
                    if (hinhHienTai != null)
                    {
                        hinhHienTai.Mouse_Down(e);
                        hinhHienTai.VeKhung(plDraw.CreateGraphics());
                        if (viTriHinhHienTaiTrongListHinh >= 0)
                            listHinh[viTriHinhHienTaiTrongListHinh] = hinhHienTai;
                    }
                }
                //vẽ hình thì qua sự kiện mouse down của hình
                else
                {
                    //hình hiện tại chưa có thì get loại hình để vẽ
                    if (hinhHienTai == null
                    ||
                    (hinhHienTai.KiemTraViTri(e.Location) == -1 &&
                    hinhHienTai != null && hinhHienTai.loaiHinh != 5))
                    {
                        idHinhHienTai = LayLoaiHinh();
                        hinhHienTai = LayHinhVeHienTai(idHinhHienTai);
                        viTriHinhHienTaiTrongListHinh = -1;
                    }
                    //vẽ hình hiện tại
                    if (hinhHienTai != null)
                    {
                        if (hinhHienTai.loaiHinh == 5 &&
                            hinhHienTai.veXong == false &&
                            hinhHienTai.soSanh(hinhHienTai.diemBatDau, hinhHienTai.diemKetThuc) &&
                            hinhHienTai.soDinh >= 3)
                        {
                            hinhHienTai.veXong = true;
                        }
                        if (!hinhHienTai.veXong)
                        {
                            hinhHienTai.Mouse_Down(e);
                            hinhHienTai.VeKhung(plDraw.CreateGraphics());
                            if (viTriHinhHienTaiTrongListHinh < 0)
                            {
                                listHinh.Add(hinhHienTai);
                                viTriHinhHienTaiTrongListHinh = listHinh.Count - 1;
                            }
                            else
                            {
                                listHinh[viTriHinhHienTaiTrongListHinh] = hinhHienTai;
                            }
                        }
                        else
                        {
                            if (hinhHienTai.loaiHinh == 5)
                            {
                                hinhHienTai.Mouse_Down(e);
                                hinhHienTai.VeKhung(plDraw.CreateGraphics());
                            }
                        }
                    }
                }
            }
            //nếu bấm nút khác là vẽ xong hình đang vẽ
            else
            {

                {
                    hinhHienTai = null;
                    viTriHinhHienTaiTrongListHinh = -1;
                    if (rbMouse.Checked)
                        idHinhHienTai = -1;
                    Cursor = Cursors.Default;
                    plDraw.Refresh();
                }
            }
        }
        private void plDraw_MouseMove(object sender, MouseEventArgs e)
        {

            //thay đổi hình chuột khi rê qua hình vẽ
            if (hinhHienTai != null)
            {
                if (hinhHienTai.loaiHinh == 5)
                {
                    int vt = hinhHienTai.KiemTraViTri(e.Location);
                    if (vt > 0)
                        Cursor = Cursors.Cross;
                    else
                    if (vt == 0)
                        Cursor = Cursors.SizeAll;
                    else
                        Cursor = Cursors.Default;
                }
                else
                {
                    int vt = hinhHienTai.KiemTraViTri(e.Location);
                    //chuột chỉ vào điểm điều khiển
                    //=> thay đổi hình chuột
                    if (vt > 0)
                        switch (vt)
                        {
                            case 1:
                            case 8:
                                {
                                    switch (hinhHienTai.loaiHinh)
                                    {
                                        case 1:
                                        case 2:
                                            Cursor = Cursors.SizeNS;
                                            break;

                                        default:
                                            Cursor = Cursors.Cross;
                                            break;
                                    }
                                }
                                break;
                            case 2:
                                Cursor = Cursors.SizeNS;
                                break;
                            case 3:
                            case 6:
                                {
                                    if (hinhHienTai.loaiHinh == 2)
                                        Cursor = Cursors.SizeNS;
                                    else
                                        Cursor = Cursors.Cross;
                                }
                                break;
                            case 4:
                                if (hinhHienTai.loaiHinh == 2)
                                    Cursor = Cursors.SizeNS;
                                else
                                    Cursor = Cursors.SizeWE;
                                break;
                            case 5:
                                Cursor = Cursors.SizeWE;
                                break;
                            case 7:
                                Cursor = Cursors.SizeNS;
                                break;
                        }
                    else
                    //chuột nằm trong hình => chuột hình mũi tên 4 hướng
                    if (vt == 0)
                        Cursor = Cursors.SizeAll;
                    //còn lại thì mặc định
                    else
                        Cursor = Cursors.Default;
                }
            }
            //nhấn chuột trái và kéo
            if (hinhHienTai != null && hinhHienTai.loaiHinh != 5)
            {
                if (e.Button == MouseButtons.Left)
                {
                    //nếu hinhhientai != null thì thay đổi hình
                    if (hinhHienTai != null)
                    {
                        hinhHienTai.Mouse_Move(e);
                        plDraw.Refresh();
                        hinhHienTai.VeKhung(plDraw.CreateGraphics());
                    }
                    else
                    {
                        plDraw.Refresh();
                        //rbMouse.Checked = false;
                    }
                    if (viTriHinhHienTaiTrongListHinh >= 0)
                        listHinh[viTriHinhHienTaiTrongListHinh] = hinhHienTai;
                }
            }
            else
            {
                if (hinhHienTai != null && hinhHienTai.loaiHinh == 5)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        //nếu hinhhientai != null thì thay đổi hình
                        if (hinhHienTai != null)
                        {
                            hinhHienTai.Mouse_Move(e);
                            plDraw.Refresh();
                            hinhHienTai.VeKhung(plDraw.CreateGraphics());
                        }
                        else
                        {
                            plDraw.Refresh();
                            //rbMouse.Checked = false;
                        }
                        if (viTriHinhHienTaiTrongListHinh >= 0)
                            listHinh[viTriHinhHienTaiTrongListHinh] = hinhHienTai;
                    }
                    else
                    {
                        hinhHienTai.diemKetThuc = e.Location;
                        plDraw.Refresh();
                        hinhHienTai.VeKhung(plDraw.CreateGraphics());
                    }
                }
            }
            //if (hinhHienTai != null)
            //    lblTest.Text = "id hình đang chọn: " + idHinhHienTai + " "
            //           + ", isMoving: " + isMoving.ToString() + " " +
            //           e.Location + " " + hinhHienTai.thayDoiKichThuoc + " " + hinhHienTai.diChuyen;
            //else
            //    lblTest.Text = "id hình đang chọn: " + idHinhHienTai + " "
            //           + ", isMoving: " + isMoving.ToString() + " " +
            //           e.Location;
            if (hinhHienTai != null)
            {
                Console.WriteLine("DK: " + hinhHienTai.soSanh(hinhHienTai.diemBatDau, hinhHienTai.diemKetThuc));
                Console.WriteLine(hinhHienTai.diemBatDau + "||" + hinhHienTai.diemKetThuc);
            }

            //Console.WriteLine(listHinh.Count.ToString());
            //foreach (var item in listHinh)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("______________________________________");

        }
        private void plDraw_MouseUp(object sender, MouseEventArgs e)
        {
            //if (hinhHienTai != null && hinhHienTai.loaiHinh == 0 && isMoving == false)
            //{
            //    listHinh.RemoveAt(listHinh.Count - 1);
            //    plDraw.Refresh();

            //    hinhHienTai = null;
            //}
            if (hinhHienTai != null && isMoving == false)
            {
                //listHinh.Add(hinhHienTai);
                hinhHienTai.Mouse_Up(sender);
                hinhHienTai.VeKhung(plDraw.CreateGraphics());
            }
            if (isMoving)
            {
                hinhHienTai.Mouse_Up(sender);
                plDraw.Refresh();
                hinhHienTai.VeKhung(plDraw.CreateGraphics());
                isMoving = false;
                idHinhHienTai = -1;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
