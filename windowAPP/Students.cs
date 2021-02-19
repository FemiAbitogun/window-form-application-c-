using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel.Application;
using MySql.Data.MySqlClient;

namespace windowAPP
{
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
        }

        MySqlDataAdapter adapter;

        private void Booking_Load(object sender, EventArgs e)
        {
            
            showStudents();
            dataGridView1.Columns[0].Visible = false;
        }



        private void showStudents()
        {
           
            try
            {
                using (MySqlConnection connection = new MySqlConnection(@"Server=localhost; Database=students_db;Uid=root;Pwd=root"))
                {
                    connection.Open();
                    adapter = new MySqlDataAdapter("getAllStudent", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                   System.Data.DataTable table = new System.Data.DataTable();
                   
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            Home_Admin home = new Home_Admin();
            home.Show();
            this.Hide();
        }




    }
}
