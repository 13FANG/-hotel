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
    public partial class BookingForm : Form
    {
        private static string connectionString = @"Data Source=adclg1;Initial Catalog=ШазбазянHotel;Integrated Security=True;Encrypt=False";
        SqlConnection MyConnection = new SqlConnection(connectionString);

        public BookingForm()
        {
            InitializeComponent();
        }

        private void BookingForm_Load(object sender, EventArgs e)
        {
            // Инициализация формы, если необходимо
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string fullName = fullnameTB.Text;
            string passportData = passportDataTB.Text;
            string phone = phoneTB.Text;
            string email = emailTB.Text;
            int roomID = int.Parse(roomIDTB.Text); // предположим, что ввод всегда корректен
            DateTime startDate = DateTime.Parse(inTB.Text); // тоже предполагаем, что корректен
            DateTime endDate = DateTime.Parse(outTB.Text);

            if (ValidateRoom(roomID) && ValidateCustomer(fullName, passportData))
            {
                AddCustomer(fullName, passportData, phone, email);
                CreateBooking(fullName, roomID, startDate, endDate);
                UpdateRoomStatus(roomID, "Занят");
                MessageBox.Show("Бронирование успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка: Проверьте данные или доступность комнаты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ValidateRoom(int roomID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Status FROM Rooms WHERE RoomID = @RoomID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoomID", roomID);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string status = reader["Status"].ToString();
                        return status == "Свободен"; // Комната должна быть "Свободен" для бронирования
                    }
                }
            }

            return false;
        }

        public bool ValidateCustomer(string fullName, string passportData)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT CustomerID FROM Customers WHERE FullName = @FullName AND PassportData = @PassportData";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@PassportData", passportData);

                    SqlDataReader reader = command.ExecuteReader();
                    return !reader.Read(); // Если такого клиента нет, то всё в порядке
                }
            }
        }

        public void AddCustomer(string fullName, string passportData, string phone, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Customers (FullName, PassportData, Phone, Email) VALUES (@FullName, @PassportData, @Phone, @Email)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@PassportData", passportData);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", email);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateBooking(string fullName, int roomID, DateTime startDate, DateTime endDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    INSERT INTO Bookings (CustomerID, RoomID, StartDate, EndDate, Status)
                    VALUES ((SELECT CustomerID FROM Customers WHERE FullName = @FullName), @RoomID, @StartDate, @EndDate, 'Подтверждено')";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@RoomID", roomID);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateRoomStatus(int roomID, string newStatus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Rooms SET Status = @Status WHERE RoomID = @RoomID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", newStatus);
                    command.Parameters.AddWithValue("@RoomID", roomID);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
