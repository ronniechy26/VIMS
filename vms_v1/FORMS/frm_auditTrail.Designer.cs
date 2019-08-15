namespace vms_v1.FORMS
{
    partial class frm_auditTrail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_auditTrail));
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnsearch = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.dgv_logs = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSort = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnRealtime = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnStop = new Bunifu.Framework.UI.BunifuFlatButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_logs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(248, 46);
            this.bunifuCustomLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(45, 21);
            this.bunifuCustomLabel1.TabIndex = 13;
            this.bunifuCustomLabel1.Text = "Logs";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.btnsearch);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Location = new System.Drawing.Point(-10, -1);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(630, 25);
            this.panel2.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(496, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 21);
            this.button2.TabIndex = 313;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.Color.Transparent;
            this.btnsearch.FlatAppearance.BorderSize = 3;
            this.btnsearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnsearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.ForeColor = System.Drawing.Color.White;
            this.btnsearch.Location = new System.Drawing.Point(-107, 174);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(33, 24);
            this.btnsearch.TabIndex = 302;
            this.btnsearch.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(472, 2);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(22, 21);
            this.button4.TabIndex = 314;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel2;
            this.bunifuDragControl1.Vertical = true;
            // 
            // dgv_logs
            // 
            this.dgv_logs.AllowUserToAddRows = false;
            this.dgv_logs.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_logs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_logs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_logs.BackgroundColor = System.Drawing.Color.White;
            this.dgv_logs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_logs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_logs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_logs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_logs.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_logs.DoubleBuffered = true;
            this.dgv_logs.EnableHeadersVisualStyles = false;
            this.dgv_logs.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv_logs.HeaderBgColor = System.Drawing.Color.LightSkyBlue;
            this.dgv_logs.HeaderForeColor = System.Drawing.Color.White;
            this.dgv_logs.Location = new System.Drawing.Point(9, 229);
            this.dgv_logs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv_logs.Name = "dgv_logs";
            this.dgv_logs.ReadOnly = true;
            this.dgv_logs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_logs.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_logs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_logs.RowTemplate.Height = 24;
            this.dgv_logs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_logs.Size = new System.Drawing.Size(497, 449);
            this.dgv_logs.TabIndex = 303;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(185, 29);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 304;
            this.pictureBox1.TabStop = false;
            // 
            // txtTo
            // 
            this.txtTo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTo.Location = new System.Drawing.Point(20, 95);
            this.txtTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTo.Multiline = true;
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(162, 23);
            this.txtTo.TabIndex = 311;
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel6.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(4, 19);
            this.bunifuCustomLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(36, 15);
            this.bunifuCustomLabel6.TabIndex = 307;
            this.bunifuCustomLabel6.Text = "From";
            // 
            // dtTo
            // 
            this.dtTo.CalendarFont = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTo.CustomFormat = "yyyy-MM-dd";
            this.dtTo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(20, 95);
            this.dtTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(192, 23);
            this.dtTo.TabIndex = 309;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.CalendarFont = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrom.CustomFormat = "yyyy-MM-dd";
            this.dtFrom.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(22, 41);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(192, 23);
            this.dtFrom.TabIndex = 305;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel5.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(4, 73);
            this.bunifuCustomLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(26, 15);
            this.bunifuCustomLabel5.TabIndex = 310;
            this.bunifuCustomLabel5.Text = "To :";
            // 
            // txtFrom
            // 
            this.txtFrom.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrom.Location = new System.Drawing.Point(22, 41);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFrom.Multiline = true;
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(162, 23);
            this.txtFrom.TabIndex = 306;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSort);
            this.groupBox2.Controls.Add(this.btnRealtime);
            this.groupBox2.Controls.Add(this.bunifuCustomLabel6);
            this.groupBox2.Controls.Add(this.txtFrom);
            this.groupBox2.Controls.Add(this.bunifuCustomLabel5);
            this.groupBox2.Controls.Add(this.txtTo);
            this.groupBox2.Controls.Add(this.dtFrom);
            this.groupBox2.Controls.Add(this.dtTo);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(9, 94);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(497, 130);
            this.groupBox2.TabIndex = 312;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search ";
            // 
            // btnSort
            // 
            this.btnSort.Activecolor = System.Drawing.Color.SeaGreen;
            this.btnSort.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSort.BorderRadius = 0;
            this.btnSort.ButtonText = "Search";
            this.btnSort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSort.DisabledColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSort.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSort.ForeColor = System.Drawing.Color.Black;
            this.btnSort.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSort.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnSort.Iconimage")));
            this.btnSort.Iconimage_right = null;
            this.btnSort.Iconimage_right_Selected = null;
            this.btnSort.Iconimage_Selected = null;
            this.btnSort.IconMarginLeft = 0;
            this.btnSort.IconMarginRight = 0;
            this.btnSort.IconRightVisible = true;
            this.btnSort.IconRightZoom = 0D;
            this.btnSort.IconVisible = true;
            this.btnSort.IconZoom = 90D;
            this.btnSort.IsTab = false;
            this.btnSort.Location = new System.Drawing.Point(242, 49);
            this.btnSort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSort.Name = "btnSort";
            this.btnSort.Normalcolor = System.Drawing.Color.SeaGreen;
            this.btnSort.OnHovercolor = System.Drawing.Color.DeepSkyBlue;
            this.btnSort.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSort.selected = false;
            this.btnSort.Size = new System.Drawing.Size(95, 41);
            this.btnSort.TabIndex = 321;
            this.btnSort.Text = "Search";
            this.btnSort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSort.Textcolor = System.Drawing.Color.White;
            this.btnSort.TextFont = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnRealtime
            // 
            this.btnRealtime.Activecolor = System.Drawing.Color.Orange;
            this.btnRealtime.BackColor = System.Drawing.Color.SkyBlue;
            this.btnRealtime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRealtime.BorderRadius = 0;
            this.btnRealtime.ButtonText = "Real time";
            this.btnRealtime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRealtime.DisabledColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnRealtime.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRealtime.ForeColor = System.Drawing.Color.Black;
            this.btnRealtime.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRealtime.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnRealtime.Iconimage")));
            this.btnRealtime.Iconimage_right = null;
            this.btnRealtime.Iconimage_right_Selected = null;
            this.btnRealtime.Iconimage_Selected = null;
            this.btnRealtime.IconMarginLeft = 0;
            this.btnRealtime.IconMarginRight = 0;
            this.btnRealtime.IconRightVisible = true;
            this.btnRealtime.IconRightZoom = 0D;
            this.btnRealtime.IconVisible = true;
            this.btnRealtime.IconZoom = 90D;
            this.btnRealtime.IsTab = false;
            this.btnRealtime.Location = new System.Drawing.Point(371, 49);
            this.btnRealtime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRealtime.Name = "btnRealtime";
            this.btnRealtime.Normalcolor = System.Drawing.Color.SkyBlue;
            this.btnRealtime.OnHovercolor = System.Drawing.Color.DeepSkyBlue;
            this.btnRealtime.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRealtime.selected = false;
            this.btnRealtime.Size = new System.Drawing.Size(100, 41);
            this.btnRealtime.TabIndex = 320;
            this.btnRealtime.Text = "Real time";
            this.btnRealtime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRealtime.Textcolor = System.Drawing.Color.White;
            this.btnRealtime.TextFont = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRealtime.Click += new System.EventHandler(this.btnRealtime_Click);
            // 
            // btnStop
            // 
            this.btnStop.Activecolor = System.Drawing.Color.Orange;
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStop.BorderRadius = 0;
            this.btnStop.ButtonText = "STOP";
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.DisabledColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.Black;
            this.btnStop.Iconcolor = System.Drawing.Color.Transparent;
            this.btnStop.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnStop.Iconimage")));
            this.btnStop.Iconimage_right = null;
            this.btnStop.Iconimage_right_Selected = null;
            this.btnStop.Iconimage_Selected = null;
            this.btnStop.IconMarginLeft = 0;
            this.btnStop.IconMarginRight = 0;
            this.btnStop.IconRightVisible = true;
            this.btnStop.IconRightZoom = 0D;
            this.btnStop.IconVisible = true;
            this.btnStop.IconZoom = 90D;
            this.btnStop.IsTab = false;
            this.btnStop.Location = new System.Drawing.Point(371, 49);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnStop.OnHovercolor = System.Drawing.Color.DeepSkyBlue;
            this.btnStop.OnHoverTextColor = System.Drawing.Color.White;
            this.btnStop.selected = false;
            this.btnStop.Size = new System.Drawing.Size(100, 41);
            this.btnStop.TabIndex = 322;
            this.btnStop.Text = "STOP";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStop.Textcolor = System.Drawing.Color.White;
            this.btnStop.TextFont = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frm_auditTrail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(515, 690);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgv_logs);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frm_auditTrail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIMS@pnvsca";
            this.Load += new System.EventHandler(this.frm_auditTrail_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_logs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        internal System.Windows.Forms.Button btnsearch;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgv_logs;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox txtTo;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
        public System.Windows.Forms.DateTimePicker dtTo;
        public System.Windows.Forms.DateTimePicker dtFrom;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        public System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        public Bunifu.Framework.UI.BunifuFlatButton btnSort;
        public Bunifu.Framework.UI.BunifuFlatButton btnRealtime;
        public Bunifu.Framework.UI.BunifuFlatButton btnStop;
        private System.Windows.Forms.Timer timer1;
    }
}
