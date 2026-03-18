using System;
using System.Linq;
using System.Windows.Forms;

namespace QLSinhVienVaLopHoc
{
    public partial class LopHocForm : Form
    {
        public LopHocForm()
        {
            InitializeComponent();

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTim.Click += btnTim_Click;
            dgvLopHoc.CellClick += dgvLopHoc_CellClick;

            LoadData();
        }

        // --- TẢI DỮ LIỆU LỚP HỌC BẰNG LINQ ---
        private void LoadData(string keyword = "")
        {
            try
            {
                using (var db = new QLSinhVienVaLopHocDataContext())
                {
                    var query = db.LopHocs.AsQueryable();

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        query = query.Where(l => l.MaLop.Contains(keyword) || l.TenLop.Contains(keyword));
                    }

                    dgvLopHoc.AutoGenerateColumns = false;

                    // BỔ SUNG MAP DỮ LIỆU ĐỂ HIỂN THỊ LÊN BẢNG
                    dgvLopHoc.Columns["colMaLop"].DataPropertyName = "MaLop";
                    dgvLopHoc.Columns["colTenLop"].DataPropertyName = "TenLop";
                    dgvLopHoc.Columns["colKhoa"].DataPropertyName = "Khoa";

                    dgvLopHoc.DataSource = query.ToList();
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
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtKhoa.Clear();
            txtTimKiem.Clear();
            txtMaLop.Focus();
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (string.IsNullOrEmpty(txtMaLop.Text) || string.IsNullOrEmpty(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã lớp và Tên lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new QLSinhVienVaLopHocDataContext())
                {
                    if (db.LopHocs.Any(l => l.MaLop == txtMaLop.Text.Trim()))
                    {
                        MessageBox.Show("Mã lớp này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    LopHoc lopNew = new LopHoc
                    {
                        MaLop = txtMaLop.Text.Trim(),
                        TenLop = txtTenLop.Text.Trim(),
                        Khoa = txtKhoa.Text.Trim()
                    };

                    db.LopHocs.InsertOnSubmit(lopNew);
                    db.SubmitChanges();

                    MessageBox.Show("Thêm lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (string.IsNullOrEmpty(txtMaLop.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp học cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new QLSinhVienVaLopHocDataContext())
                {
                    LopHoc lopEdit = db.LopHocs.SingleOrDefault(l => l.MaLop == txtMaLop.Text.Trim());
                    if (lopEdit != null)
                    {
                        lopEdit.TenLop = txtTenLop.Text.Trim();
                        lopEdit.Khoa = txtKhoa.Text.Trim();

                        db.SubmitChanges();
                        MessageBox.Show("Cập nhật lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (string.IsNullOrEmpty(txtMaLop.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp học cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa lớp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new QLSinhVienVaLopHocDataContext())
                    {
                        LopHoc lopDelete = db.LopHocs.SingleOrDefault(l => l.MaLop == txtMaLop.Text.Trim());
                        if (lopDelete != null)
                        {
                            db.LopHocs.DeleteOnSubmit(lopDelete);
                            db.SubmitChanges();

                            MessageBox.Show("Xóa lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            btnLamMoi_Click(null, null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa dữ liệu (Có thể lớp này đang chứa sinh viên): " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            LoadData(txtTimKiem.Text.Trim());
        }

        private void dgvLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLopHoc.Rows[e.RowIndex];
                txtMaLop.Text = row.Cells["colMaLop"].Value?.ToString();
                txtTenLop.Text = row.Cells["colTenLop"].Value?.ToString();
                txtKhoa.Text = row.Cells["colKhoa"].Value?.ToString();
            }
        }
    }
}