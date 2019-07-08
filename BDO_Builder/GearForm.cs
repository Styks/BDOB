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
            test = 10;
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
            Item_Icon_Load("Belts",0);

            SelectGear_cb.SelectedIndex = test; ////
        }

        private void LoadNeck() //Belt
        {
            var sql = @"select * from Neck";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.DataSource = ds.Tables[0];
            SelectGear_cb.DisplayMember = "Name";
            SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Neck", 0);
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

        private void Necklace_btn_Click(object sender, EventArgs e)
        {
            cs.sgn = 2;
            LoadNeck();
        }


        private void Belt_btn_Click(object sender, EventArgs e)
        {
            sgn = 1;
            LoadBelts();
            cs.sgn = 1;
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
                    beltAP_n.Text = dr["AP"].ToString();
                    beltDP_n.Text = dr["DP"].ToString();
                    beltEv_n.Text = dr["Evasion"].ToString();
                    beltAcc_n.Text = dr["Accuracy"].ToString();
                    Res_n.Text = dr["AllResist"].ToString();
                    Belt_dr.Text = dr["DR"].ToString();
                    HP_n.Text = dr["MaxHP"].ToString();
                    Weig_n.Text = dr["Weight"].ToString();

                }
                cs.Type = "Belts";
                Item_Icon_Load(cs.Type,SelectGear_cb.SelectedIndex);
                cs.BeltState(Convert.ToInt32(beltAP_n.Text), Convert.ToInt32(beltDP_n.Text), Convert.ToInt32(beltAcc_n.Text), Convert.ToInt32(beltEv_n.Text), Convert.ToInt32(Res_n.Text), Convert.ToInt32(Belt_dr.Text),Convert.ToInt32(HP_n.Text), Convert.ToInt32(Weig_n.Text));
                cAP_n.Text = Convert.ToString(cs.cap);
                cAAP_n.Text = Convert.ToString(cs.caap);
                cDP_n.Text = Convert.ToString(cs.cdp);
                Evas_n.Text = Convert.ToString(cs.cev);
                Acc_n.Text = Convert.ToString(cs.cacc);
                SSFR_n.Text = Convert.ToString(cs.cRes1);
                KBR_n.Text = Convert.ToString(cs.cRes2);
                GrapR_n.Text = Convert.ToString(cs.cRes3);
                KFR_n.Text = Convert.ToString(cs.cRes4);
                DR_n.Text = Convert.ToString(cs.cDR);
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
                    beltAP_n.Text = dr["AP"].ToString();
                    beltDP_n.Text = dr["DP"].ToString();
                    beltEv_n.Text = dr["Evasion"].ToString();
                    beltAcc_n.Text = dr["Accuracy"].ToString();
                    Res_n.Text = dr["AllRes"].ToString();
                    Belt_dr.Text = dr["DR"].ToString();
                    SSF_n.Text = dr["SSFRes"].ToString();
                    KB_n.Text = dr["KBRes"].ToString();
                    G_n.Text = dr["GrapRes"].ToString();
                    KF_n.Text = dr["KFRes"].ToString();
                    HP_n.Text = dr["MaxHP"].ToString();
                }
                cs.Type = "Neck";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                cs.NeckState(Convert.ToInt32(beltAP_n.Text), Convert.ToInt32(beltDP_n.Text), Convert.ToInt32(beltAcc_n.Text), Convert.ToInt32(beltEv_n.Text), Convert.ToInt32(Res_n.Text), Convert.ToInt32(Belt_dr.Text), Convert.ToInt32(SSF_n.Text), Convert.ToInt32(KB_n.Text), Convert.ToInt32(G_n.Text), Convert.ToInt32(KF_n.Text), Convert.ToInt32(HP_n.Text));
                cAP_n.Text = Convert.ToString(cs.cap);
                cAAP_n.Text = Convert.ToString(cs.caap);
                cDP_n.Text = Convert.ToString(cs.cdp);
                Evas_n.Text = Convert.ToString(cs.cev);
                Acc_n.Text = Convert.ToString(cs.cacc);
                SSFR_n.Text = Convert.ToString(cs.cRes1);
                KBR_n.Text = Convert.ToString(cs.cRes2);
                GrapR_n.Text = Convert.ToString(cs.cRes3);
                KFR_n.Text = Convert.ToString(cs.cRes4);
                DR_n.Text = Convert.ToString(cs.cDR);
                cHP_n.Text = Convert.ToString(cs.cMaxHP);
            }

        }

        
    }
}
