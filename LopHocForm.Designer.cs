namespace QLSinhVienVaLopHoc
{
    partial class LopHocForm
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
            this.btnXemSinhVien = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtKhoa = new System.Windows.Forms.TextBox();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.lblTenLop = new System.Windows.Forms.Label();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.lblMaLop = new System.Windows.Forms.Label();
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.dgvLopHoc = new System.Windows.Forms.DataGridView();
            this.colMaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.grpThongTin.SuspendLayout();
            this.grpTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).BeginInit();
            this.SuspendLayout();

            // grpThongTin
            this.grpThongTin.Controls.Add(this.btnXemSinhVien);
            this.grpThongTin.Controls.Add(this.btnLamMoi);
            this.grpThongTin.Controls.Add(this.btnXoa);
            this.grpThongTin.Controls.Add(this.btnSua);
            this.grpThongTin.Controls.Add(this.btnThem);
            this.grpThongTin.Controls.Add(this.txtKhoa);
            this.grpThongTin.Controls.Add(this.lblKhoa);
            this.grpThongTin.Controls.Add(this.txtTenLop);
            this.grpThongTin.Controls.Add(this.lblTenLop);
            this.grpThongTin.Controls.Add(this.txtMaLop);
            this.grpThongTin.Controls.Add(this.lblMaLop);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(350, 450);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin lớp học";

            // Nút Xem danh sách Sinh viên
            this.btnXemSinhVien.BackColor = System.Drawing.Color.LightYellow;
            this.btnXemSinhVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemSinhVien.Location = new System.Drawing.Point(23, 370);
            this.btnXemSinhVien.Name = "btnXemSinhVien";
            this.btnXemSinhVien.Size = new System.Drawing.Size(300, 40);
            this.btnXemSinhVien.Text = "Xem danh sách Sinh viên";
            this.btnXemSinhVien.UseVisualStyleBackColor = false;
            this.btnXemSinhVien.Click += new System.EventHandler(this.btnXemSinhVien_Click);

            // Lables & TextBoxes
            this.lblMaLop.AutoSize = true; this.lblMaLop.Location = new System.Drawing.Point(20, 40); this.lblMaLop.Text = "Mã lớp:";
            this.txtMaLop.Location = new System.Drawing.Point(23, 60); this.txtMaLop.Size = new System.Drawing.Size(300, 22);

            this.lblTenLop.AutoSize = true; this.lblTenLop.Location = new System.Drawing.Point(20, 100); this.lblTenLop.Text = "Tên lớp:";
            this.txtTenLop.Location = new System.Drawing.Point(23, 120); this.txtTenLop.Size = new System.Drawing.Size(300, 22);

            this.lblKhoa.AutoSize = true; this.lblKhoa.Location = new System.Drawing.Point(20, 160); this.lblKhoa.Text = "Khoa / Ngành:";
            this.txtKhoa.Location = new System.Drawing.Point(23, 180); this.txtKhoa.Size = new System.Drawing.Size(300, 22);

            // Buttons
            this.btnThem.Location = new System.Drawing.Point(23, 250); this.btnThem.Size = new System.Drawing.Size(140, 40); this.btnThem.Text = "Thêm"; this.btnThem.BackColor = System.Drawing.Color.LightBlue;
            this.btnSua.Location = new System.Drawing.Point(183, 250); this.btnSua.Size = new System.Drawing.Size(140, 40); this.btnSua.Text = "Sửa"; this.btnSua.BackColor = System.Drawing.Color.LightGreen;
            this.btnXoa.Location = new System.Drawing.Point(23, 310); this.btnXoa.Size = new System.Drawing.Size(140, 40); this.btnXoa.Text = "Xóa"; this.btnXoa.BackColor = System.Drawing.Color.LightCoral;
            this.btnLamMoi.Location = new System.Drawing.Point(183, 310); this.btnLamMoi.Size = new System.Drawing.Size(140, 40); this.btnLamMoi.Text = "Làm mới";

            // grpTimKiem
            this.grpTimKiem.Controls.Add(this.dgvLopHoc);
            this.grpTimKiem.Controls.Add(this.btnTim);
            this.grpTimKiem.Controls.Add(this.txtTimKiem);
            this.grpTimKiem.Location = new System.Drawing.Point(380, 12);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(550, 450);
            this.grpTimKiem.TabIndex = 1;
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "Tìm kiếm (Mã / Tên Lớp)";

            // Search
            this.txtTimKiem.Location = new System.Drawing.Point(20, 40); this.txtTimKiem.Size = new System.Drawing.Size(350, 22);
            this.btnTim.Location = new System.Drawing.Point(390, 38); this.btnTim.Size = new System.Drawing.Size(100, 26); this.btnTim.Text = "Tìm";

            // DataGridView
            this.dgvLopHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLopHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaLop, this.colTenLop, this.colKhoa});
            this.dgvLopHoc.Location = new System.Drawing.Point(20, 80);
            this.dgvLopHoc.Size = new System.Drawing.Size(500, 350);
            this.dgvLopHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLopHoc.AllowUserToAddRows = false;
            this.dgvLopHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLopHoc.ReadOnly = true;

            // Columns
            this.colMaLop.HeaderText = "Mã Lớp"; this.colMaLop.Name = "colMaLop";
            this.colTenLop.HeaderText = "Tên Lớp"; this.colTenLop.Name = "colTenLop";
            this.colKhoa.HeaderText = "Khoa"; this.colKhoa.Name = "colKhoa";

            // LopHocForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 480);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.grpThongTin);
            this.Name = "LopHocForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Lớp Học";
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.Label lblTenLop;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.TextBox txtKhoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXemSinhVien;
        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvLopHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKhoa;
    }
}