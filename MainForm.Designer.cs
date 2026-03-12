namespace QLSinhVienVaLopHoc
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtLop = new System.Windows.Forms.TextBox();
            this.lblLop = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.colMaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.grpThongTin.SuspendLayout();
            this.grpTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.SuspendLayout();
            
            // grpThongTin
            this.grpThongTin.Controls.Add(this.btnLamMoi);
            this.grpThongTin.Controls.Add(this.btnXoa);
            this.grpThongTin.Controls.Add(this.btnSua);
            this.grpThongTin.Controls.Add(this.btnThem);
            this.grpThongTin.Controls.Add(this.txtLop);
            this.grpThongTin.Controls.Add(this.lblLop);
            this.grpThongTin.Controls.Add(this.cboGioiTinh);
            this.grpThongTin.Controls.Add(this.lblGioiTinh);
            this.grpThongTin.Controls.Add(this.dtpNgaySinh);
            this.grpThongTin.Controls.Add(this.lblNgaySinh);
            this.grpThongTin.Controls.Add(this.txtHoTen);
            this.grpThongTin.Controls.Add(this.lblHoTen);
            this.grpThongTin.Controls.Add(this.txtMaSV);
            this.grpThongTin.Controls.Add(this.lblMaSV);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(350, 550);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin sinh viên";
            
            // lblMaSV
            this.lblMaSV.AutoSize = true; this.lblMaSV.Location = new System.Drawing.Point(20, 40); this.lblMaSV.Name = "lblMaSV"; this.lblMaSV.Text = "Mã sinh viên:";
            // txtMaSV
            this.txtMaSV.Location = new System.Drawing.Point(23, 60); this.txtMaSV.Name = "txtMaSV"; this.txtMaSV.Size = new System.Drawing.Size(300, 22);
            // lblHoTen
            this.lblHoTen.AutoSize = true; this.lblHoTen.Location = new System.Drawing.Point(20, 100); this.lblHoTen.Name = "lblHoTen"; this.lblHoTen.Text = "Họ và tên:";
            // txtHoTen
            this.txtHoTen.Location = new System.Drawing.Point(23, 120); this.txtHoTen.Name = "txtHoTen"; this.txtHoTen.Size = new System.Drawing.Size(300, 22);
            // lblNgaySinh
            this.lblNgaySinh.AutoSize = true; this.lblNgaySinh.Location = new System.Drawing.Point(20, 160); this.lblNgaySinh.Name = "lblNgaySinh"; this.lblNgaySinh.Text = "Ngày sinh:";
            // dtpNgaySinh
            this.dtpNgaySinh.Location = new System.Drawing.Point(23, 180); this.dtpNgaySinh.Name = "dtpNgaySinh"; this.dtpNgaySinh.Size = new System.Drawing.Size(300, 22); this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // lblGioiTinh
            this.lblGioiTinh.AutoSize = true; this.lblGioiTinh.Location = new System.Drawing.Point(20, 220); this.lblGioiTinh.Name = "lblGioiTinh"; this.lblGioiTinh.Text = "Giới tính:";
            // cboGioiTinh
            this.cboGioiTinh.Location = new System.Drawing.Point(23, 240); this.cboGioiTinh.Name = "cboGioiTinh"; this.cboGioiTinh.Size = new System.Drawing.Size(300, 24); this.cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" }); this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // lblLop
            this.lblLop.AutoSize = true; this.lblLop.Location = new System.Drawing.Point(20, 280); this.lblLop.Name = "lblLop"; this.lblLop.Text = "Lớp:";
            // txtLop
            this.txtLop.Location = new System.Drawing.Point(23, 300); this.txtLop.Name = "txtLop"; this.txtLop.Size = new System.Drawing.Size(300, 22);
            
            // Nút bấm
            this.btnThem.Location = new System.Drawing.Point(23, 360); this.btnThem.Name = "btnThem"; this.btnThem.Size = new System.Drawing.Size(140, 40); this.btnThem.Text = "Thêm"; this.btnThem.BackColor = System.Drawing.Color.LightBlue;
            this.btnSua.Location = new System.Drawing.Point(183, 360); this.btnSua.Name = "btnSua"; this.btnSua.Size = new System.Drawing.Size(140, 40); this.btnSua.Text = "Sửa"; this.btnSua.BackColor = System.Drawing.Color.LightGreen;
            this.btnXoa.Location = new System.Drawing.Point(23, 420); this.btnXoa.Name = "btnXoa"; this.btnXoa.Size = new System.Drawing.Size(140, 40); this.btnXoa.Text = "Xóa"; this.btnXoa.BackColor = System.Drawing.Color.LightCoral;
            this.btnLamMoi.Location = new System.Drawing.Point(183, 420); this.btnLamMoi.Name = "btnLamMoi"; this.btnLamMoi.Size = new System.Drawing.Size(140, 40); this.btnLamMoi.Text = "Làm mới";

            // grpTimKiem
            this.grpTimKiem.Controls.Add(this.dgvSinhVien);
            this.grpTimKiem.Controls.Add(this.btnTim);
            this.grpTimKiem.Controls.Add(this.txtTimKiem);
            this.grpTimKiem.Location = new System.Drawing.Point(380, 12);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(600, 550);
            this.grpTimKiem.TabIndex = 1;
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "Tìm kiếm (Tên / Mã SV / Lớp)";
            
            // txtTimKiem
            this.txtTimKiem.Location = new System.Drawing.Point(20, 40); this.txtTimKiem.Name = "txtTimKiem"; this.txtTimKiem.Size = new System.Drawing.Size(400, 22);
            // btnTim
            this.btnTim.Location = new System.Drawing.Point(440, 38); this.btnTim.Name = "btnTim"; this.btnTim.Size = new System.Drawing.Size(100, 26); this.btnTim.Text = "Tìm";
            
            // dgvSinhVien
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSV, this.colHoTen, this.colGioiTinh, this.colNgaySinh, this.colLop});
            this.dgvSinhVien.Location = new System.Drawing.Point(20, 80);
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.RowHeadersWidth = 51;
            this.dgvSinhVien.Size = new System.Drawing.Size(560, 450);
            this.dgvSinhVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVien.AllowUserToAddRows = false;
            this.dgvSinhVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVien.ReadOnly = true;
            
            // Cột của dgvSinhVien
            this.colMaSV.HeaderText = "Mã SV"; this.colMaSV.Name = "colMaSV";
            this.colHoTen.HeaderText = "Họ và Tên"; this.colHoTen.Name = "colHoTen";
            this.colGioiTinh.HeaderText = "Giới Tính"; this.colGioiTinh.Name = "colGioiTinh";
            this.colNgaySinh.HeaderText = "Ngày Sinh"; this.colNgaySinh.Name = "colNgaySinh";
            this.colLop.HeaderText = "Lớp"; this.colLop.Name = "colLop";

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 580);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.grpThongTin);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Sinh Viên";
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.TextBox txtLop;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLop;
    }
}