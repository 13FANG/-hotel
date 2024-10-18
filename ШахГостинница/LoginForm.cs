using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ШахГостинница
{
    public partial class LoginForm : Form
    {
        private static string connectionString = "Data Source=adclg1;Initial Catalog=ШазбазянHotel;Integrated Security=True;Encrypt=False";
        SqlConnection MyConnection = new SqlConnection(connectionString);
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Инициализация формы, если необходимо
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string fullName = FullNameTB.Text;
            string password = paswordTB.Text;

            if (ValidateUser(fullName, password, out string role))
            {
                if (role == "Admin")
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                }
                else if (role == "Employee")
                {
                    EmployeeForm employeeForm = new EmployeeForm();
                    employeeForm.Show();
                }
                else
                {
                    MessageBox.Show("Неизвестная роль пользователя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Hide(); // Скрыть текущую форму
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ValidateUser(string fullName, string password, out string position)
        {
            position = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Position FROM Employees WHERE FullName = @FullName AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        position = reader["Position"].ToString(); // Получаем значение из столбца Position
                        return true;
                    }
                }
            }

            return false;
        }

        private void toBookingBtn_Click(object sender, EventArgs e)
        {
            BookingForm bookingForm = new BookingForm();
            bookingForm.Show();
            this.Hide(); // Скрыть текущую форму
        }
    }
}