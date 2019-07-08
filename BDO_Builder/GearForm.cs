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
        readonly CharacterState cs = new CharacterState();

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
            cs.cdp = Convert.ToInt32(cDP_n.Text);
            cs.cap = Convert.ToInt32(cAP_n.Text);
            cs.caap = Convert.ToInt32(cAAP_n.Text);
            Sclass_lbl.Text = sclass;
            Class_pic.BackgroundImage = cimg;
            if (sclass == "Shai") { AW_btn.Visible = false; SAW_btn.Visible = false; }
            ////////// Edit ComboBox
            this.SelectGear_cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.SelectGear_cb.AutoCompleteSource = AutoCompleteSource.ListItems;
            //////////
        }

        private void LoadBelts() //Belt
        {
            var sql = @"select * from Belts";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.DataSource = ds.Tables[0];
            SelectGear_cb.DisplayMember = "Name";
            SelectGear_cb.ValueMember = "Id";           
        }

        private void LoadNeck() //Neck
        {
            var sql = @"select * from Neck";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.DataSource = ds.Tables[0];
            SelectGear_cb.DisplayMember = "Name";
            SelectGear_cb.ValueMember = "Id";
        }

        private void DpLvl_cb_CheckedChanged(object sender, EventArgs e)
        {
            int lvlDP = 1;
            if (dpLvl_cb.Checked == true)
            {                
                cDP_n.Text = Convert.ToString(cs.cdp+lvlDP);
            }
            else
            { 
                cDP_n.Text = Convert.ToString(cs.cdp-lvlDP);
            }
            cs.cdp = Convert.ToInt32(cDP_n.Text);
        }

        private void ApLvl_cb_CheckedChanged(object sender, EventArgs e)
        {
            int lvlAP = 1;
            int lvlAAP = 1;
            if (apLvl_cb.Checked == true)
            {
                cAP_n.Text = Convert.ToString(cs.cap + lvlAP);
                cAAP_n.Text = Convert.ToString(cs.caap + lvlAAP);
            }
            else
            {
                cAP_n.Text = Convert.ToString(cs.cap - lvlAP);
                cAAP_n.Text = Convert.ToString(cs.caap - lvlAAP);
            }
            cs.cap = Convert.ToInt32(cAP_n.Text);
            cs.caap = Convert.ToInt32(cAAP_n.Text);
        }

        private void Book_cb_CheckedChanged(object sender, EventArgs e)
        {
            int BookAP = 1;
            int BookAAP = 1;
            int BookDP = 1;
            if (Book_cb.Checked == true)
            {
                cDP_n.Text = Convert.ToString(cs.cdp + BookDP);
                cAAP_n.Text = Convert.ToString(cs.caap + BookAAP);
                cAP_n.Text = Convert.ToString(cs.cap + BookAP);
            }
            else
            {
                cDP_n.Text = Convert.ToString(cs.cdp - BookDP);
                cAAP_n.Text = Convert.ToString(cs.caap - BookAAP);
                cAP_n.Text = Convert.ToString(cs.cap - BookAP);
            }
            cs.cap = Convert.ToInt32(cAP_n.Text);
            cs.caap = Convert.ToInt32(cAAP_n.Text);
            cs.cdp = Convert.ToInt32(cDP_n.Text);
        }

        private void Belt_btn_Click(object sender, EventArgs e)
        {
            cs.sgn = 1;
            LoadBelts();
        }
        private void Necklace_btn_Click(object sender, EventArgs e)
        {
            cs.sgn = 2;
            LoadNeck();
        }

        private void SelectedGear_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
          SqlCommand cmd = Base_Connect.Connection.CreateCommand();
          cmd.CommandType = CommandType.Text;
            if (cs.sgn == 1)
            {
                cmd.CommandText = "select * from Belts where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    iAP_n.Text = dr["AP"].ToString();
                    iDP_n.Text = dr["DP"].ToString();
                    iEvas_n.Text = dr["Evasion"].ToString();
                    iAcc_n.Text = dr["Accuracy"].ToString();
                    iRes_n.Text = dr["AllResist"].ToString();
                    iDR_n.Text = dr["DR"].ToString();
                    iHP_n.Text = dr["MaxHP"].ToString();
                    iWeight_n.Text = dr["Weight"].ToString();
                }
                cs.Type = "Belts";
                Item_Icon_Load(cs.Type,SelectGear_cb.SelectedIndex);
                cs.BeltState(Convert.ToInt32(iAP_n.Text), Convert.ToInt32(iDP_n.Text), Convert.ToInt32(iAcc_n.Text), Convert.ToInt32(iEvas_n.Text), Convert.ToInt32(iRes_n.Text), Convert.ToInt32(iDR_n.Text),Convert.ToInt32(iHP_n.Text), Convert.ToInt32(iWeight_n.Text));
                cAP_n.Text = Convert.ToString(cs.cap);
                cAAP_n.Text = Convert.ToString(cs.caap);
                cDP_n.Text = Convert.ToString(cs.cdp);
                cEvas_n.Text = Convert.ToString(cs.cev);
                cAcc_n.Text = Convert.ToString(cs.cacc);
                cSSFR_n.Text = Convert.ToString(cs.cRes1);
                cKBR_n.Text = Convert.ToString(cs.cRes2);
                cGrapR_n.Text = Convert.ToString(cs.cRes3);
                cKFR_n.Text = Convert.ToString(cs.cRes4);
                cDR_n.Text = Convert.ToString(cs.cDR);
                Weight_n.Text = Convert.ToString(cs.cWeight);
                cHP_n.Text = Convert.ToString(cs.cMaxHP);
            }
            if (cs.sgn == 2)
            {
                cmd.CommandText = "select * from Neck where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    iAP_n.Text = dr["AP"].ToString();
                    iDP_n.Text = dr["DP"].ToString();
                    iEvas_n.Text = dr["Evasion"].ToString();
                    iAcc_n.Text = dr["Accuracy"].ToString();
                    iRes_n.Text = dr["AllRes"].ToString();
                    iDR_n.Text = dr["DR"].ToString();
                    iSSFR_n.Text = dr["SSFRes"].ToString();
                    iKBR_n.Text = dr["KBRes"].ToString();
                    iGrapR_n.Text = dr["GrapRes"].ToString();
                    iKFR_n.Text = dr["KFRes"].ToString();
                    iHP_n.Text = dr["MaxHP"].ToString();
                }
                cs.Type = "Neck";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                cs.NeckState(Convert.ToInt32(iAP_n.Text), Convert.ToInt32(iDP_n.Text), Convert.ToInt32(iAcc_n.Text), Convert.ToInt32(iEvas_n.Text), Convert.ToInt32(iRes_n.Text), Convert.ToInt32(iDR_n.Text), Convert.ToInt32(iSSFR_n.Text), Convert.ToInt32(iKBR_n.Text), Convert.ToInt32(iGrapR_n.Text), Convert.ToInt32(iKFR_n.Text), Convert.ToInt32(iHP_n.Text));
                cAP_n.Text = Convert.ToString(cs.cap);
                cAAP_n.Text = Convert.ToString(cs.caap);
                cDP_n.Text = Convert.ToString(cs.cdp);
                cEvas_n.Text = Convert.ToString(cs.cev);
                cAcc_n.Text = Convert.ToString(cs.cacc);
                cSSFR_n.Text = Convert.ToString(cs.cRes1);
                cKBR_n.Text = Convert.ToString(cs.cRes2);
                cGrapR_n.Text = Convert.ToString(cs.cRes3);
                cKFR_n.Text = Convert.ToString(cs.cRes4);
                cDR_n.Text = Convert.ToString(cs.cDR);
                cHP_n.Text = Convert.ToString(cs.cMaxHP);
            }
        }     
    }
}
