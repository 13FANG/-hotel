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
    public partial class AdminForm : Form
    {
        private static string connectionString = @"Data Source=adclg1;Initial Catalog=ШазбазянHotel;Integrated Security=True;Encrypt=False";
        SqlConnection MyConnection = new SqlConnection(connectionString);

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // Загрузка данных в таблицы
            this.employeesTableAdapter.Fill(this.ШазбазянHotelDataSet.Employees);
            this.customersTableAdapter.Fill(this.ШазбазянHotelDataSet.Customers);
            this.invoicesTableAdapter.Fill(this.ШазбазянHotelDataSet.Invoices);
            this.bookingsTableAdapter.Fill(this.ШазбазянHotelDataSet.Bookings);
            this.roomsTableAdapter.Fill(this.ШазбазянHotelDataSet.Rooms);
        }

        private void SaveData()
        {
            try
            {
                // Сохранение изменений в БД
                this.employeesTableAdapter.Update(this.ШазбазянHotelDataSet.Employees);
                this.customersTableAdapter.Update(this.ШазбазянHotelDataSet.Customers);
                this.bookingsTableAdapter.Update(this.ШазбазянHotelDataSet.Bookings);
                this.roomsTableAdapter.Update(this.ШазбазянHotelDataSet.Rooms);
                this.invoicesTableAdapter.Update(this.ШазбазянHotelDataSet.Invoices);

                MessageBox.Show("Изменения успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик события изменения данных в строке DataGridView (сохранение изменений в БД)
        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  // Проверка на допустимую строку
            {
                SaveData();  // Автоматически сохраняем данные при завершении редактирования строки
            }
        }

        // Добавляем контекстное меню для удаления строк
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Удалить", DeleteRow));

                int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[currentMouseOverRow].Selected = true;
                    m.Show(dataGridView1, new Point(e.X, e.Y));
                }
            }
        }

        private void DeleteRow(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(row.Index);
                }
                SaveData();  // Сохраняем изменения после удаления
            }
        }
    }
}
