using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLSinhVienVaLopHoc
{
    public partial class LopHocForm : Form
    {
        // THAY ĐỔI CHUỖI KẾT NỐI GIỐNG VỚI MAINFORM CỦA BẠN
        string connectionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLSinhVienVaLopHocDB;Integrated Security=True";

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

        private void LoadData(string query = "SELECT * FROM LopHoc")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvLopHoc.AutoGenerateColumns = false;
                    dgvLopHoc.Columns["colMaLop"].DataPropertyName = "MaLop";
                    dgvLopHoc.Columns["colTenLop"].DataPropertyName = "TenLop";
                    dgvLopHoc.Columns["colKhoa"].DataPropertyName = "Khoa";

                    dgvLopHoc.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtKhoa.Clear();
            txtTimKiem.Clear();
            txtMaLop.Focus();
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLop.Text) || string.IsNullOrEmpty(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã lớp và Tên lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "INSERT INTO LopHoc (MaLop, TenLop, Khoa) VALUES (@MaLop, @TenLop, @Khoa)";
            ExecuteQuery(query, "Thêm lớp học thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLop.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp học cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "UPDATE LopHoc SET TenLop=@TenLop, Khoa=@Khoa WHERE MaLop=@MaLop";
            ExecuteQuery(query, "Cập nhật lớp học thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLop.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp học cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa lớp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "DELETE FROM LopHoc WHERE MaLop=@MaLop";
                ExecuteQuery(query, "Xóa lớp học thành công!");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            string query = $"SELECT * FROM LopHoc WHERE MaLop LIKE N'%{keyword}%' OR TenLop LIKE N'%{keyword}%'";
            LoadData(query);
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

        private void ExecuteQuery(string query, string successMessage)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                    cmd.Parameters.AddWithValue("@TenLop", txtTenLop.Text);
                    cmd.Parameters.AddWithValue("@Khoa", txtKhoa.Text);

                    try
                    {
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show(successMessage, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}