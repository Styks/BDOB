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
        public int cdp;
        public int cap;
        public int caap;


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
            cdp = Convert.ToInt32(cDP_n.Text);
            cap = Convert.ToInt32(cAP_n.Text);
            caap = Convert.ToInt32(cAAP_n.Text);
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

        private void DpLvl_cb_CheckedChanged(object sender, EventArgs e)
        {
            int lvlDP = 1;
            if (dpLvl_cb.Checked == true)
            {                
                cDP_n.Text = Convert.ToString(cdp+lvlDP);
                cdp = Convert.ToInt32(cDP_n.Text);
            }
            else
            { 
                cDP_n.Text = Convert.ToString(cdp-lvlDP);
                cdp = Convert.ToInt32(cDP_n.Text);
            }
        }

        private void ApLvl_cb_CheckedChanged(object sender, EventArgs e)
        {
            int lvlAP = 1;
            int lvlAAP = 1;
            if (apLvl_cb.Checked == true)
            {
                cAP_n.Text = Convert.ToString(cap + lvlAP);
                cAAP_n.Text = Convert.ToString(caap + lvlAAP);
                cap = Convert.ToInt32(cAP_n.Text);
                caap = Convert.ToInt32(cAAP_n.Text);
            }
            else
            {
                cAP_n.Text = Convert.ToString(cap - lvlAP);
                cAAP_n.Text = Convert.ToString(caap - lvlAAP);
                cap = Convert.ToInt32(cAP_n.Text);
                caap = Convert.ToInt32(cAAP_n.Text);
            }
        }

        private void Book_cb_CheckedChanged(object sender, EventArgs e)
        {
            int BookAP = 1;
            int BookAAP = 1;
            int BookDP = 1;
            if (Book_cb.Checked == true)
            {
                cDP_n.Text = Convert.ToString(cdp + BookDP);
                cAAP_n.Text = Convert.ToString(caap + BookAAP);
                cAP_n.Text = Convert.ToString(cap + BookAP);
                cap = Convert.ToInt32(cAP_n.Text);
                caap = Convert.ToInt32(cAAP_n.Text);
                cdp = Convert.ToInt32(cDP_n.Text);
            }
            else
            {
                cDP_n.Text = Convert.ToString(cdp - BookDP);
                cAAP_n.Text = Convert.ToString(caap - BookAAP);
                cAP_n.Text = Convert.ToString(cap - BookAP);
                cap = Convert.ToInt32(cAP_n.Text);
                caap = Convert.ToInt32(cAAP_n.Text);
                cdp = Convert.ToInt32(cDP_n.Text);
            }
        }
    }
}
