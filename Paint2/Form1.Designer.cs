namespace Paint2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFill = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.cbBoxSize = new System.Windows.Forms.ComboBox();
            this.cbBoxStyle = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbMouse = new System.Windows.Forms.RadioButton();
            this.rbLine = new System.Windows.Forms.RadioButton();
            this.rbPolygon = new System.Windows.Forms.RadioButton();
            this.rbBezier = new System.Windows.Forms.RadioButton();
            this.rbRectangle = new System.Windows.Forms.RadioButton();
            this.rbEclipse = new System.Windows.Forms.RadioButton();
            this.plDraw = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnFill);
            this.panel1.Controls.Add(this.btnColor);
            this.panel1.Controls.Add(this.cbBoxSize);
            this.panel1.Controls.Add(this.cbBoxStyle);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rbMouse);
            this.panel1.Controls.Add(this.rbLine);
            this.panel1.Controls.Add(this.rbPolygon);
            this.panel1.Controls.Add(this.rbBezier);
            this.panel1.Controls.Add(this.rbRectangle);
            this.panel1.Controls.Add(this.rbEclipse);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1011, 32);
            this.panel1.TabIndex = 0;
            // 
            // btnFill
            // 
            this.btnFill.BackColor = System.Drawing.Color.Transparent;
            this.btnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFill.Location = new System.Drawing.Point(514, 2);
            this.btnFill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(22, 24);
            this.btnFill.TabIndex = 18;
            this.btnFill.UseVisualStyleBackColor = false;
            this.btnFill.Visible = false;
            this.btnFill.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Red;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Location = new System.Drawing.Point(487, 2);
            this.btnColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(22, 24);
            this.btnColor.TabIndex = 15;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // cbBoxSize
            // 
            this.cbBoxSize.BackColor = System.Drawing.Color.White;
            this.cbBoxSize.DropDownHeight = 150;
            this.cbBoxSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBoxSize.FormattingEnabled = true;
            this.cbBoxSize.IntegralHeight = false;
            this.cbBoxSize.Location = new System.Drawing.Point(385, 2);
            this.cbBoxSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbBoxSize.Name = "cbBoxSize";
            this.cbBoxSize.Size = new System.Drawing.Size(98, 25);
            this.cbBoxSize.TabIndex = 11;
            this.cbBoxSize.SelectedIndexChanged += new System.EventHandler(this.cbBoxSize_SelectedIndexChanged);
            // 
            // cbBoxStyle
            // 
            this.cbBoxStyle.BackColor = System.Drawing.Color.White;
            this.cbBoxStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbBoxStyle.DropDownHeight = 130;
            this.cbBoxStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBoxStyle.FormattingEnabled = true;
            this.cbBoxStyle.IntegralHeight = false;
            this.cbBoxStyle.Location = new System.Drawing.Point(237, 2);
            this.cbBoxStyle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbBoxStyle.Name = "cbBoxStyle";
            this.cbBoxStyle.Size = new System.Drawing.Size(98, 25);
            this.cbBoxStyle.TabIndex = 9;
            this.cbBoxStyle.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbBoxStyle_DrawItem);
            this.cbBoxStyle.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.cbBoxStyle_MeasureItem);
            this.cbBoxStyle.SelectedIndexChanged += new System.EventHandler(this.cbBoxStyle_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.CheckedBackColor = System.Drawing.Color.Aqua;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(2, 2);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(22, 24);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(339, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Size";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(191, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Style";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbMouse
            // 
            this.rbMouse.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbMouse.BackColor = System.Drawing.Color.Transparent;
            this.rbMouse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbMouse.BackgroundImage")));
            this.rbMouse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rbMouse.FlatAppearance.BorderSize = 0;
            this.rbMouse.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbMouse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbMouse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbMouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbMouse.Location = new System.Drawing.Point(29, 2);
            this.rbMouse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbMouse.Name = "rbMouse";
            this.rbMouse.Size = new System.Drawing.Size(22, 24);
            this.rbMouse.TabIndex = 14;
            this.rbMouse.UseVisualStyleBackColor = false;
            this.rbMouse.CheckedChanged += new System.EventHandler(this.rbMouse_CheckedChanged);
            // 
            // rbLine
            // 
            this.rbLine.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbLine.BackColor = System.Drawing.Color.Transparent;
            this.rbLine.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbLine.BackgroundImage")));
            this.rbLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rbLine.FlatAppearance.BorderSize = 0;
            this.rbLine.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbLine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbLine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbLine.Location = new System.Drawing.Point(56, 2);
            this.rbLine.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbLine.Name = "rbLine";
            this.rbLine.Size = new System.Drawing.Size(22, 24);
            this.rbLine.TabIndex = 9;
            this.rbLine.UseVisualStyleBackColor = false;
            this.rbLine.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbPolygon
            // 
            this.rbPolygon.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbPolygon.BackColor = System.Drawing.Color.Transparent;
            this.rbPolygon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbPolygon.BackgroundImage")));
            this.rbPolygon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rbPolygon.FlatAppearance.BorderSize = 0;
            this.rbPolygon.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbPolygon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbPolygon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbPolygon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbPolygon.Location = new System.Drawing.Point(164, 2);
            this.rbPolygon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbPolygon.Name = "rbPolygon";
            this.rbPolygon.Size = new System.Drawing.Size(22, 24);
            this.rbPolygon.TabIndex = 13;
            this.rbPolygon.UseVisualStyleBackColor = false;
            this.rbPolygon.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbBezier
            // 
            this.rbBezier.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbBezier.BackColor = System.Drawing.Color.Transparent;
            this.rbBezier.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbBezier.BackgroundImage")));
            this.rbBezier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rbBezier.FlatAppearance.BorderSize = 0;
            this.rbBezier.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbBezier.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbBezier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbBezier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbBezier.Location = new System.Drawing.Point(83, 2);
            this.rbBezier.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbBezier.Name = "rbBezier";
            this.rbBezier.Size = new System.Drawing.Size(22, 24);
            this.rbBezier.TabIndex = 10;
            this.rbBezier.UseVisualStyleBackColor = false;
            this.rbBezier.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbRectangle
            // 
            this.rbRectangle.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbRectangle.BackColor = System.Drawing.Color.Transparent;
            this.rbRectangle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbRectangle.BackgroundImage")));
            this.rbRectangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rbRectangle.FlatAppearance.BorderSize = 0;
            this.rbRectangle.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbRectangle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbRectangle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbRectangle.Location = new System.Drawing.Point(137, 2);
            this.rbRectangle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbRectangle.Name = "rbRectangle";
            this.rbRectangle.Size = new System.Drawing.Size(22, 24);
            this.rbRectangle.TabIndex = 12;
            this.rbRectangle.UseVisualStyleBackColor = false;
            this.rbRectangle.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbEclipse
            // 
            this.rbEclipse.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbEclipse.BackColor = System.Drawing.Color.Transparent;
            this.rbEclipse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbEclipse.BackgroundImage")));
            this.rbEclipse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rbEclipse.FlatAppearance.BorderSize = 0;
            this.rbEclipse.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbEclipse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbEclipse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbEclipse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbEclipse.Location = new System.Drawing.Point(110, 2);
            this.rbEclipse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbEclipse.Name = "rbEclipse";
            this.rbEclipse.Size = new System.Drawing.Size(22, 24);
            this.rbEclipse.TabIndex = 11;
            this.rbEclipse.UseVisualStyleBackColor = false;
            this.rbEclipse.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // plDraw
            // 
            this.plDraw.BackColor = System.Drawing.Color.White;
            this.plDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plDraw.Location = new System.Drawing.Point(0, 32);
            this.plDraw.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plDraw.Name = "plDraw";
            this.plDraw.Size = new System.Drawing.Size(1011, 554);
            this.plDraw.TabIndex = 1;
            this.plDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.plDraw_Paint);
            this.plDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.plDraw_MouseDown);
            this.plDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.plDraw_MouseMove);
            this.plDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.plDraw_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1011, 586);
            this.Controls.Add(this.plDraw);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paint";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBoxSize;
        private System.Windows.Forms.ComboBox cbBoxStyle;
        private System.Windows.Forms.RadioButton rbMouse;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.RadioButton rbPolygon;
        private System.Windows.Forms.RadioButton rbRectangle;
        private System.Windows.Forms.RadioButton rbEclipse;
        private System.Windows.Forms.RadioButton rbBezier;
        private System.Windows.Forms.RadioButton rbLine;
        private System.Windows.Forms.Panel plDraw;
        private System.Windows.Forms.Button btnFill;
    }
}

