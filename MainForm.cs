using System;
using System.Windows.Forms;

namespace QLSinhVienVaLopHoc
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadMockData(); // Gọi hàm thêm dữ liệu giả khi mở Form
        }

        // Hàm tạo sẵn một vài dữ liệu giả để Form trông đẹp hơn khi nộp bài
        private void LoadMockData()
        {
            dgvSinhVien.Rows.Add("0022568", "quanTD", "Nam", "11/03/2005", "IT01");
            dgvSinhVien.Rows.Add("0022569", "Nguyễn Văn A", "Nam", "15/05/2005", "IT02");
            dgvSinhVien.Rows.Add("0022570", "Trần Thị B", "Nữ", "20/10/2005", "IT01");
            dgvSinhVien.Rows.Add("0022571", "Lê Văn C", "Nam", "01/02/2005", "IT03");
        }
    }
}