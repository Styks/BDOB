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
        public int TempEnchLvl;
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
            SelectGear_cb.SelectedIndexChanged -= SelectedGear_cb_SelectedIndexChanged;
            var sql = @"select * from Belts";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.DataSource = ds.Tables[0];
            SelectGear_cb.DisplayMember = "Name";
            SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Belts", cs.beltId);
            SelectGear_cb.SelectedIndexChanged += SelectedGear_cb_SelectedIndexChanged;
            SelectGear_cb.SelectedIndex = cs.beltId;
            LoadItemEnch_cb();

        }

        private void LoadNeck() //Neck
        {
            SelectGear_cb.SelectedIndexChanged -= SelectedGear_cb_SelectedIndexChanged;
            var sql = @"select * from Neck";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.DataSource = ds.Tables[0];
            SelectGear_cb.DisplayMember = "Name";
            SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Neck", cs.neckId);
            SelectGear_cb.SelectedIndexChanged += SelectedGear_cb_SelectedIndexChanged;
            SelectGear_cb.SelectedIndex = cs.neckId;
            LoadItemEnch_cb();
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
                    cs.beltDefap = Convert.ToInt32(dr["AP"]);
                    cs.beltDefdp = Convert.ToInt32(dr["DP"]);
                    cs.beltDefev = Convert.ToInt32(dr["Evasion"]);
                    cs.beltDefacc = Convert.ToInt32(dr["Accuracy"]);
                    cs.beltDefResis = Convert.ToInt32(dr["AllResist"]);
                    cs.beltDefDR = Convert.ToInt32(dr["DR"]);
                    cs.beltDefHP = Convert.ToInt32(dr["MaxHP"]);
                    cs.beltDefWeight = Convert.ToInt32(dr["Weight"]);
                    cs.beltEnch = Convert.ToBoolean(dr["Ench"]);
                }
                
                LoadItemEnch_cb();
                
                cs.Type = "Belts";
                Item_Icon_Load(cs.Type,SelectGear_cb.SelectedIndex);
                Belt_btn.BackgroundImage = Item_image.Image;
                cs.BeltState();


                if (cs.beltEnch == true) { TempEnchLvl = ItemEnch_cb.SelectedIndex; ItemEnch_cb.SelectedIndex = 0; cs.beltEnchLvl = TempEnchLvl;}
                else if (cs.beltEnch == false) { cs.beltEnchLvl = 0; }

                iAP_n.Text = cs.beltap.ToString();
                iDP_n.Text = cs.beltdp.ToString();
                iEvas_n.Text = cs.beltev.ToString();
                iAcc_n.Text = cs.beltacc.ToString();
                iRes_n.Text = cs.beltResis.ToString();
                iDR_n.Text = cs.beltDR.ToString();
                iHP_n.Text = cs.beltHP.ToString();
                iWeight_n.Text = cs.beltWeight.ToString();


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
                cs.beltId = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.beltId.ToString();

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
                    cs.neckDefap = Convert.ToInt32(dr["AP"]);
                    cs.neckDefdp = Convert.ToInt32(dr["DP"]);
                    cs.neckDefev = Convert.ToInt32(dr["Evasion"]);
                    cs.neckDefacc = Convert.ToInt32(dr["Accuracy"]);
                    cs.neckDefAllRes = Convert.ToInt32(dr["AllRes"]);
                    cs.neckDefDR = Convert.ToInt32(dr["DR"]);
                    cs.neckDefSSF = Convert.ToInt32(dr["SSFRes"]);
                    cs.neckDefKB = Convert.ToInt32(dr["KBRes"]);
                    cs.neckDefG = Convert.ToInt32(dr["GrapRes"]);
                    cs.neckDefKF = Convert.ToInt32(dr["KFRes"]);
                    cs.neckDefHP = Convert.ToInt32(dr["MaxHP"]);
                    cs.neckEnch = Convert.ToBoolean(dr["Ench"]);
                }
                LoadItemEnch_cb();
                
                cs.Type = "Neck";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                Necklace_btn.BackgroundImage = Item_image.Image;
                cs.NeckState();

                if (cs.neckEnch == true) { TempEnchLvl = ItemEnch_cb.SelectedIndex; ItemEnch_cb.SelectedIndex = 0; cs.neckEnchLvl = TempEnchLvl;}
                else if(cs.neckEnch == false) { cs.neckEnchLvl = 0;}

                iAP_n.Text = cs.neckap.ToString();
                iDP_n.Text = cs.neckdp.ToString();
                iEvas_n.Text = cs.neckev.ToString();
                iAcc_n.Text = cs.neckacc.ToString();
                iRes_n.Text = cs.neckAllRes.ToString();
                iDR_n.Text = cs.neckDR.ToString();
                iSSFR_n.Text = cs.neckSSF.ToString();
                iKBR_n.Text = cs.neckKB.ToString();
                iGrapR_n.Text = cs.neckG.ToString();
                iKFR_n.Text = cs.neckKF.ToString();
                iHP_n.Text = cs.neckHP.ToString();

                
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
                cs.neckId = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.neckId.ToString();
                
            }
        }


        private void LoadItemEnch_cb()
        {
            if (cs.sgn == 1 & cs.beltEnch == true| cs.sgn ==2 & cs.neckEnch == true)
            {
                ItemEnch_cb.SelectedIndexChanged -= ItemEnch_cb_SelectedIndexChanged;
                ItemEnch_cb.Visible = true; Ench_lbl.Visible = true;
                string[] Ench = {"0","1", "2", "3", "4", "5" };
                ItemEnch_cb.DataSource = Ench;
                ItemEnch_cb.SelectedIndexChanged += ItemEnch_cb_SelectedIndexChanged;
                if (cs.sgn == 1) ItemEnch_cb.SelectedIndex = cs.beltEnchLvl;
                else if (cs.sgn == 2) ItemEnch_cb.SelectedIndex = cs.neckEnchLvl;

            }
            else { ItemEnch_cb.Visible = false; Ench_lbl.Visible = false; }
        }

        private void ItemEnch_cb_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cs.sgn == 1)
            {
                cs.beltEnchLvl = ItemEnch_cb.SelectedIndex;
                cs.BeltState();

                iAP_n.Text = cs.beltap.ToString();
                iDP_n.Text = cs.beltdp.ToString();
                iEvas_n.Text = cs.beltev.ToString();
                iAcc_n.Text = cs.beltacc.ToString();
                iRes_n.Text = cs.beltResis.ToString();
                iDR_n.Text = cs.beltDR.ToString();
                iHP_n.Text = cs.beltHP.ToString();
                iWeight_n.Text = cs.beltWeight.ToString();

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

            else if (cs.sgn == 2)
            {
                cs.neckEnchLvl = ItemEnch_cb.SelectedIndex;
                cs.NeckState();

                iAP_n.Text = cs.neckap.ToString();
                iDP_n.Text = cs.neckdp.ToString();
                iEvas_n.Text = cs.neckev.ToString();
                iAcc_n.Text = cs.neckacc.ToString();
                iRes_n.Text = cs.neckAllRes.ToString();
                iDR_n.Text = cs.neckDR.ToString();
                iSSFR_n.Text = cs.neckSSF.ToString();
                iKBR_n.Text = cs.neckKB.ToString();
                iGrapR_n.Text = cs.neckG.ToString();
                iKFR_n.Text = cs.neckKF.ToString();
                iHP_n.Text = cs.neckHP.ToString();

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
