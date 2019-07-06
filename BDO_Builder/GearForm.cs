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
using System.IO;

namespace BDO_Builder
{
    public partial class GearForm : Form
    {
        public string sclass;
        public Image cimg;
        public int sgn; //Selected Gear
        public int cdp; //DP
        public int cap; //AP
        public int caap; //AAP
        public int beltap; //Betl AP
        public int beltdp; //Belt DP
        public string Type; // Item type

        public GearForm()
        {
            InitializeComponent();
        }
        
        private void GearForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) Application.Exit();
        }

        private void Item_Icon_Load(string type, int id)
        {
            var cmd = new SqlCommand(@"select * from "+ type +" where Id ='" + id + " ' ")
            {
                Connection = Base_Connect.Connection,
                CommandType = CommandType.Text
            };

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Byte[] img;
            img = (Byte[])ds.Tables[0].Rows[0]["Icon"];
            MemoryStream ms = new MemoryStream(img);
            Item_image.Image = Image.FromStream(ms);
        }

        private void GearForm_Load(object sender, EventArgs e)
        {
            cdp = Convert.ToInt32(cDP_n.Text);
            cap = Convert.ToInt32(cAP_n.Text);
            caap = Convert.ToInt32(cAAP_n.Text);
            Sclass_lbl.Text = sclass;
            Class_pic.BackgroundImage = cimg;
            if (sclass == "Shai") { AW_btn.Visible = false; SAW_btn.Visible = false; }            
        }
                
        private void LoadBelts() //Belt
        {
            var sql = @"select * from Belts";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.DataSource = ds.Tables[0];
            SelectGear_cb.DisplayMember = "Name" ;
            SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Belts",0);
        }

        private void DpLvl_cb_CheckedChanged(object sender, EventArgs e)
        {
            int lvlDP = 1;
            if (dpLvl_cb.Checked == true)
            {                
                cDP_n.Text = Convert.ToString(cdp+lvlDP);
            }
            else
            { 
                cDP_n.Text = Convert.ToString(cdp-lvlDP);
            }
            cdp = Convert.ToInt32(cDP_n.Text);
        }

        private void ApLvl_cb_CheckedChanged(object sender, EventArgs e)
        {
            int lvlAP = 1;
            int lvlAAP = 1;
            if (apLvl_cb.Checked == true)
            {
                cAP_n.Text = Convert.ToString(cap + lvlAP);
                cAAP_n.Text = Convert.ToString(caap + lvlAAP);
            }
            else
            {
                cAP_n.Text = Convert.ToString(cap - lvlAP);
                cAAP_n.Text = Convert.ToString(caap - lvlAAP);
            }
            cap = Convert.ToInt32(cAP_n.Text);
            caap = Convert.ToInt32(cAAP_n.Text);
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
            }
            else
            {
                cDP_n.Text = Convert.ToString(cdp - BookDP);
                cAAP_n.Text = Convert.ToString(caap - BookAAP);
                cAP_n.Text = Convert.ToString(cap - BookAP);
            }
            cap = Convert.ToInt32(cAP_n.Text);
            caap = Convert.ToInt32(cAAP_n.Text);
            cdp = Convert.ToInt32(cDP_n.Text);
        }

        private void Belt_btn_Click(object sender, EventArgs e)
        {
            LoadBelts();
            sgn = 1;
        }

        private void SelectedGear_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
          SqlCommand cmd = Base_Connect.Connection.CreateCommand();
          cmd.CommandType = CommandType.Text;
            if (sgn == 1)
            {
                cmd.CommandText = "select * from Belts where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    beltAP_n.Text = dr["AP"].ToString();
                    beltDP_n.Text = dr["DP"].ToString();
                }
                Type = "Belts";

                Item_Icon_Load(Type,SelectGear_cb.SelectedIndex);
            }
            cap =- beltap;
            caap =- beltap;
            cdp =- beltdp;
            beltap = Convert.ToInt32(beltAP_n.Text);
            beltdp = Convert.ToInt32(beltDP_n.Text);
            cap =+ beltap;
            caap =+ beltap;
            cdp =+ beltdp;
            cAP_n.Text = Convert.ToString(cap);
            cAAP_n.Text = Convert.ToString(caap);
            cDP_n.Text = Convert.ToString(cdp);
        }
    }
}
