using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using ШахГостинница;

namespace UnitTestШАХ
{
    [TestClass]
    public class UnitTest1
    {
        private static string connectionString = "Data Source=adclg1;Initial Catalog=ШазбазянHotel;Integrated Security=True;Encrypt=False";

        [TestMethod]
        public void Test_AddCustomer_ValidInput_ShouldAddCustomer()
        {
            // Arrange
            string fullName = "Тестовый Клиент " + Guid.NewGuid().ToString(); // Уникальное имя для каждого теста
            string passportData = "1234567890";
            string phone = "+79260000000";
            string email = "test@test.com";

            var bookingForm = new BookingForm();

            // Act
            bookingForm.AddCustomer(fullName, passportData, phone, email);

            // Assert
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Customers WHERE FullName = @FullName AND PassportData = @PassportData";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@PassportData", passportData);

                int result = (int)cmd.ExecuteScalar();
                Assert.AreEqual(1, result);
            }
        }

        [TestMethod]
        public void Test_ValidateRoom_RoomAvailable_ShouldReturnTrue()
        {
            // Arrange
            int roomID;
            var bookingForm = new BookingForm();

            // Добавляем новую комнату
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertRoomQuery = "INSERT INTO Rooms (RoomType, Price, Status) OUTPUT INSERTED.RoomID VALUES ('Standard', 100.00, 'Свободен')";
                SqlCommand cmd = new SqlCommand(insertRoomQuery, connection);
                roomID = (int)cmd.ExecuteScalar();
            }

            // Act
            bool result = bookingForm.ValidateRoom(roomID);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_ValidateRoom_RoomNotAvailable_ShouldReturnFalse()
        {
            // Arrange
            int roomID;
            var bookingForm = new BookingForm();

            // Добавляем новую комнату и сразу занимаем её
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertRoomQuery = "INSERT INTO Rooms (RoomType, Price, Status) OUTPUT INSERTED.RoomID VALUES ('Standard', 100.00, 'Занят')";
                SqlCommand cmd = new SqlCommand(insertRoomQuery, connection);
                roomID = (int)cmd.ExecuteScalar();
            }

            // Act
            bool result = bookingForm.ValidateRoom(roomID);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_CreateBooking_ValidInput_ShouldCreateBooking()
        {
            // Arrange
            string fullName = "Тестовый Клиент " + Guid.NewGuid().ToString();
            int roomID;
            DateTime startDate = new DateTime(2024, 10, 01);
            DateTime endDate = new DateTime(2024, 10, 10);

            var bookingForm = new BookingForm();

            // Добавляем нового клиента
            bookingForm.AddCustomer(fullName, "1234567890", "+79260000000", "test@test.com");

            // Добавля м новую комнату
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertRoomQuery = "INSERT INTO Rooms (RoomType, Price, Status) OUTPUT INSERTED.RoomID VALUES ('Standard', 100.00, 'Свободен')";
                SqlCommand cmd = new SqlCommand(insertRoomQuery, connection);
                roomID = (int)cmd.ExecuteScalar();
            }

            // Act
            bookingForm.CreateBooking(fullName, roomID, startDate, endDate);

            // Assert
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Bookings WHERE CustomerID = (SELECT CustomerID FROM Customers WHERE FullName = @FullName) AND RoomID = @RoomID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@RoomID", roomID);

                int result = (int)cmd.ExecuteScalar();
                Assert.AreEqual(1, result);
            }
        }

        [TestMethod]
        public void Test_UpdateRoomStatus_ValidStatus_ShouldUpdateRoom()
        {
            // Arrange
            int roomID;
            var bookingForm = new BookingForm();

            // Добавляем новую комнату
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertRoomQuery = "INSERT INTO Rooms (RoomType, Price, Status) OUTPUT INSERTED.RoomID VALUES ('Standard', 100.00, 'Занят')";
                SqlCommand cmd = new SqlCommand(insertRoomQuery, connection);
                roomID = (int)cmd.ExecuteScalar();
            }

            // Act
            bookingForm.UpdateRoomStatus(roomID, "Свободен");

            // Assert
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Status FROM Rooms WHERE RoomID = @RoomID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@RoomID", roomID);

                string status = cmd.ExecuteScalar().ToString();
                Assert.AreEqual("Свободен", status);
            }
        }

        [TestMethod]
        public void Test_ValidateUser_ValidCredentials_ShouldReturnTrue()
        {
            // Arrange
            string fullName = "Админ " + Guid.NewGuid().ToString();
            string password = "admin123";

            var loginForm = new LoginForm();

            // Добавляем нового пользователя
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertUserQuery = "INSERT INTO Employees (FullName, Position, Salary, Password) VALUES (@FullName, 'Admin', 50000, @Password)";
                SqlCommand cmd = new SqlCommand(insertUserQuery, connection);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.ExecuteNonQuery();
            }

            // Act
            bool isValid = loginForm.ValidateUser(fullName, password, out string role);

            // Assert
            Assert.IsTrue(isValid);
            Assert.AreEqual("Admin", role);
        }

        [TestMethod]
        public void Test_ValidateUser_InvalidCredentials_ShouldReturnFalse()
        {
            // Arrange
            string fullName = "Неизвестный";
            string password = "wrongpassword";

            var loginForm = new LoginForm();

            // Act
            bool isValid = loginForm.ValidateUser(fullName, password, out string role);

            // Assert
            Assert.IsFalse(isValid);
        }
        [TestMethod]
        public void Test_ValidateCustomer_NewCustomer_ShouldReturnTrue()
        {
            // Arrange
            string fullName = "Новый Клиент " + Guid.NewGuid().ToString();
            string passportData = "9876543210";
            var bookingForm = new BookingForm();

            // Act
            bool result = bookingForm.ValidateCustomer(fullName, passportData);

            // Assert
            Assert.IsTrue(result, "Новый клиент должен быть валидным");
        }

        [TestMethod]
        public void Test_ValidateCustomer_ExistingCustomer_ShouldReturnFalse()
        {
            // Arrange
            string fullName = "Существующий Клиент " + Guid.NewGuid().ToString();
            string passportData = "1122334455";
            var bookingForm = new BookingForm();

            // Добавляем клиента в базу данных
            bookingForm.AddCustomer(fullName, passportData, "+79991112233", "existing@test.com");

            // Act
            bool result = bookingForm.ValidateCustomer(fullName, passportData);

            // Assert
            Assert.IsFalse(result, "Существующий клиент не должен проходить валидацию как новый");
        }

        [TestMethod]
        public void Test_UpdateRoomStatus_AnyStatus_ShouldUpdateStatus()
        {
            // Arrange
            int roomID;
            string initialStatus = "Свободен";
            string newStatus = "Недопустимый статус";
            var bookingForm = new BookingForm();

            // Добавляем новую комнату
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertRoomQuery = "INSERT INTO Rooms (RoomType, Price, Status) OUTPUT INSERTED.RoomID VALUES ('Standard', 100.00, @InitialStatus)";
                SqlCommand cmd = new SqlCommand(insertRoomQuery, connection);
                cmd.Parameters.AddWithValue("@InitialStatus", initialStatus);
                roomID = (int)cmd.ExecuteScalar();
            }

            // Act
            bookingForm.UpdateRoomStatus(roomID, newStatus);

            // Assert
            string actualStatus = GetRoomStatus(roomID);
            Assert.AreEqual(newStatus, actualStatus, "Статус комнаты должен обновиться на любое переданное значение");
        }

        // Вспомогательный метод для получения текущего статуса комнаты
        private string GetRoomStatus(int roomID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Status FROM Rooms WHERE RoomID = @RoomID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@RoomID", roomID);
                return (string)cmd.ExecuteScalar();
            }
        }
    }
}