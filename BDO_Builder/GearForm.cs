using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace BDO_Builder
{
    public partial class GearForm : Form
    {

        public string sclass;
        public Image cimg;

        public GearForm()
        {
            InitializeComponent();
        }
  
        private void GearForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) Application.Exit();
        }

        private void GearForm_Load(object sender, EventArgs e)
        {
            Sclass_lbl.Text = sclass;
            Class_pic.BackgroundImage = cimg;
            if (sclass == "Shai") { AW_btn.Visible = false; SAW_btn.Visible = false; }
            LoadItems();
        }

        private void LoadItems()
        {
            //пишем SQL по отбору данных по услугам, сортируем по названию
            var sql = @"select * from Belts";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
            conn.Open();

                // Создаем объект DataAdapter
            var da = new SqlDataAdapter(sql, conn.ConnectionString);
                // Создаем объект Dataset
                DataSet ds = new DataSet();
                // Заполняем Dataset
                da.Fill(ds);
                // Отображаем данные
                dgvGear.DataSource = ds.Tables[0];
            

        }


        private void DgvGear_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
