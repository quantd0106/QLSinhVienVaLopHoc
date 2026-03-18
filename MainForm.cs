using System;
using System.Linq;
using System.Windows.Forms;

namespace QLSinhVienVaLopHoc
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTim.Click += btnTim_Click;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;

            LoadComboBoxLop();
            LoadData();
        }

        // --- TẢI DANH SÁCH LỚP VÀO COMBOBOX BẰNG LINQ ---
        private void LoadComboBoxLop()
        {
            try
            {
                using (var db = new QLSinhVienVaLopHocDataContext())
                {
                    cboLop.DataSource = db.LopHocs.ToList();
                    cboLop.DisplayMember = "MaLop";  // Hiển thị Mã Lớp
                    cboLop.ValueMember = "MaLop";    // Giá trị lưu trữ
                    cboLop.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách lớp: " + ex.Message);
            }
        }

        // --- TẢI DỮ LIỆU SINH VIÊN BẰNG LINQ ---
        private void LoadData(string keyword = "")
        {
            try
            {
                using (var db = new QLSinhVienVaLopHocDataContext())
                {
                    var query = db.SinhViens.AsQueryable();

                    // Nếu có từ khóa tìm kiếm
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        query = query.Where(sv => sv.MaSV.Contains(keyword) ||
                                                  sv.HoTen.Contains(keyword) ||
                                                  sv.Lop.Contains(keyword));
                    }

                    dgvSinhVien.AutoGenerateColumns = false;

                    // BỔ SUNG MAP DỮ LIỆU ĐỂ HIỂN THỊ LÊN BẢNG
                    dgvSinhVien.Columns["colMaSV"].DataPropertyName = "MaSV";
                    dgvSinhVien.Columns["colHoTen"].DataPropertyName = "HoTen";
                    dgvSinhVien.Columns["colGioiTinh"].DataPropertyName = "GioiTinh";
                    dgvSinhVien.Columns["colNgaySinh"].DataPropertyName = "NgaySinh";
                    dgvSinhVien.Columns["colLop"].DataPropertyName = "Lop";

                    dgvSinhVien.DataSource = query.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            txtMaSV.Clear();
            txtHoTen.Clear();
            cboGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
            cboLop.SelectedIndex = -1;
            txtTimKiem.Clear();
            txtMaSV.Focus();
            LoadData();
        }

        // --- THÊM SINH VIÊN ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (string.IsNullOrEmpty(txtMaSV.Text) || string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Mã sinh viên và Họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboLop.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn lớp học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new QLSinhVienVaLopHocDataContext())
                {
                    // Kiểm tra trùng Mã SV
                    if (db.SinhViens.Any(s => s.MaSV == txtMaSV.Text.Trim()))
                    {
                        MessageBox.Show("Mã sinh viên này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Khởi tạo Object SinhVien
                    SinhVien svNew = new SinhVien
                    {
                        MaSV = txtMaSV.Text.Trim(),
                        HoTen = txtHoTen.Text.Trim(),
                        GioiTinh = cboGioiTinh.Text,
                        NgaySinh = dtpNgaySinh.Value,
                        Lop = cboLop.SelectedValue?.ToString()
                    };

                    db.SinhViens.InsertOnSubmit(svNew); // Thêm vào bộ nhớ tạm
                    db.SubmitChanges();                 // Đẩy xuống Database

                    MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- SỬA SINH VIÊN ---
        private void btnSua_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (string.IsNullOrEmpty(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn Mã sinh viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new QLSinhVienVaLopHocDataContext())
                {
                    // Tìm sinh viên cần sửa
                    SinhVien svEdit = db.SinhViens.SingleOrDefault(s => s.MaSV == txtMaSV.Text.Trim());
                    if (svEdit != null)
                    {
                        svEdit.HoTen = txtHoTen.Text.Trim();
                        svEdit.GioiTinh = cboGioiTinh.Text;
                        svEdit.NgaySinh = dtpNgaySinh.Value;
                        svEdit.Lop = cboLop.SelectedValue?.ToString();

                        db.SubmitChanges(); // Cập nhật thay đổi
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- XÓA SINH VIÊN ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (string.IsNullOrEmpty(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new QLSinhVienVaLopHocDataContext())
                    {
                        SinhVien svDelete = db.SinhViens.SingleOrDefault(s => s.MaSV == txtMaSV.Text.Trim());
                        if (svDelete != null)
                        {
                            db.SinhViens.DeleteOnSubmit(svDelete); // Đánh dấu xóa
                            db.SubmitChanges();                    // Thực thi xóa

                            MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            btnLamMoi_Click(null, null); // Reset các ô nhập liệu
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            LoadData(txtTimKiem.Text.Trim()); // Gọi hàm LoadData và truyền từ khóa vào
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];
                txtMaSV.Text = row.Cells["colMaSV"].Value?.ToString();
                txtHoTen.Text = row.Cells["colHoTen"].Value?.ToString();
                cboGioiTinh.Text = row.Cells["colGioiTinh"].Value?.ToString();

                if (row.Cells["colNgaySinh"].Value != null && row.Cells["colNgaySinh"].Value.ToString() != "")
                {
                    dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["colNgaySinh"].Value);
                }

                if (row.Cells["colLop"].Value != null && row.Cells["colLop"].Value.ToString() != "")
                {
                    cboLop.SelectedValue = row.Cells["colLop"].Value.ToString();
                }
                else
                {
                    cboLop.SelectedIndex = -1;
                }
            }
        }
    }
}