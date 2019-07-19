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

        private void FillCharacterState()
        {
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
            cMP_n.Text = Convert.ToString(cs.cMaxMP);
            cStamina_n.Text = Convert.ToString(cs.cMaxST);
            Weight_n.Text = Convert.ToString(cs.cWeight);
            cHDR_n.Text = Convert.ToString(cs.chdr);
            cHE_n.Text = Convert.ToString(cs.chev);
        }

        private void ItemStatClear()
        {
            iAP_n.Text = "0";
            iDP_n.Text = "0";
            iEvas_n.Text = "0";
            iAcc_n.Text = "0";
            iRes_n.Text = "0";
            iDR_n.Text = "0";
            iHP_n.Text = "0";
            iWeight_n.Text = "0";
            iMP_n.Text = "0";
            iST_n.Text = "0";
            iSSFR_n.Text = "0";
            iKBR_n.Text = "0";
            iGrapR_n.Text = "0";
            iKFR_n.Text = "0";
            iHEV_n.Text = "0";
            iHDR_n.Text = "0";
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

        private void Load1Ring() //First ring
        {
            SelectGear_cb.SelectedIndexChanged -= SelectedGear_cb_SelectedIndexChanged;
            var sql = @"select * from Rings";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.DataSource = ds.Tables[0];
            SelectGear_cb.DisplayMember = "Name";
            SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Rings", cs.ring1Id);
            SelectGear_cb.SelectedIndexChanged += SelectedGear_cb_SelectedIndexChanged;
            SelectGear_cb.SelectedIndex = cs.ring1Id;
            LoadItemEnch_cb();
        }

        private void Load2Ring() //Second ring
        {
            SelectGear_cb.SelectedIndexChanged -= SelectedGear_cb_SelectedIndexChanged;
            var sql = @"select * from Rings";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.DataSource = ds.Tables[0];
            SelectGear_cb.DisplayMember = "Name";
            SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Rings", cs.ring2Id);
            SelectGear_cb.SelectedIndexChanged += SelectedGear_cb_SelectedIndexChanged;
            SelectGear_cb.SelectedIndex = cs.ring2Id;
            LoadItemEnch_cb();
        }

        private void Load1Earring() //First earring
        {
            SelectGear_cb.SelectedIndexChanged -= SelectedGear_cb_SelectedIndexChanged;
            var sql = @"select * from Earrings";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.DataSource = ds.Tables[0];
            SelectGear_cb.DisplayMember = "Name";
            SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Earrings", cs.ear1Id);
            SelectGear_cb.SelectedIndexChanged += SelectedGear_cb_SelectedIndexChanged;
            SelectGear_cb.SelectedIndex = cs.ear1Id;
            LoadItemEnch_cb();
        }

        private void Load2Earring() //Second earring
        {
            SelectGear_cb.SelectedIndexChanged -= SelectedGear_cb_SelectedIndexChanged;
            var sql = @"select * from Earrings";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.DataSource = ds.Tables[0];
            SelectGear_cb.DisplayMember = "Name";
            SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Earrings", cs.ear2Id);
            SelectGear_cb.SelectedIndexChanged += SelectedGear_cb_SelectedIndexChanged;
            SelectGear_cb.SelectedIndex = cs.ear2Id;
            LoadItemEnch_cb();
        }

        private void LoadArmor() //Armor
        {
            SelectGear_cb.SelectedIndexChanged -= SelectedGear_cb_SelectedIndexChanged;
            var sql = @"select * from Armors";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.DataSource = ds.Tables[0];
            SelectGear_cb.DisplayMember = "Name";
            SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Armors", cs.armId);
            SelectGear_cb.SelectedIndexChanged += SelectedGear_cb_SelectedIndexChanged;
            SelectGear_cb.SelectedIndex = cs.armId;
            LoadItemEnch_cb();
        }

        private void LoadHelmet() // Helmet
        {
            SelectGear_cb.SelectedIndexChanged -= SelectedGear_cb_SelectedIndexChanged;
            var sql = @"select * from Helmets";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.DataSource = ds.Tables[0];
            SelectGear_cb.DisplayMember = "Name";
            SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Helmets", cs.helId);
            SelectGear_cb.SelectedIndexChanged += SelectedGear_cb_SelectedIndexChanged;
            SelectGear_cb.SelectedIndex = cs.helId;
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
           ItemStatClear();
           cs.sgn = 1;
           LoadBelts();
        }
        private void Necklace_btn_Click(object sender, EventArgs e)
        {
            ItemStatClear();
            cs.sgn = 2;
            LoadNeck();
        }

        private void Ring1_btn_Click(object sender, EventArgs e)
        {
            ItemStatClear();
            cs.sgn = 3;
            Load1Ring();
        }

        private void Ring2_btn_Click(object sender, EventArgs e)
        {
            ItemStatClear();
            cs.sgn = 4;
            Load2Ring();
        }

        private void Earring1_btn_Click(object sender, EventArgs e)
        {
            ItemStatClear();
            cs.sgn = 5;
            Load1Earring();
        }

        private void Earring2_btn_Click(object sender, EventArgs e)
        {
            ItemStatClear();
            cs.sgn = 6;
            Load2Earring();           
        }


        private void Armour_btn_Click(object sender, EventArgs e)
        {
            ItemStatClear();
            cs.sgn = 7;
            LoadArmor();
            
        }

        private void Helmet_btn_Click(object sender, EventArgs e)
        {
            ItemStatClear();
            cs.sgn = 8;
            LoadHelmet();
        }

        private void SelectedGear_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
          ItemStatClear();
          SqlCommand cmd = Base_Connect.Connection.CreateCommand();
          cmd.CommandType = CommandType.Text;
            if (cs.sgn == 1) //Belt
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
                if (cs.beltEnch == true && SelectGear_cb.SelectedIndex == cs.beltId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.beltEnchLvl = TempEnchLvl; }
                if (cs.beltEnch == true && SelectGear_cb.SelectedIndex != cs.beltId) { ItemEnch_cb.SelectedIndex = 0; cs.beltEnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.beltEnch == false) { cs.beltEnchLvl = 0; }

                iAP_n.Text = cs.beltap.ToString();
                iDP_n.Text = cs.beltdp.ToString();
                iEvas_n.Text = cs.beltev.ToString();
                iAcc_n.Text = cs.beltacc.ToString();
                iRes_n.Text = cs.beltResis.ToString();
                iDR_n.Text = cs.beltDR.ToString();
                iHP_n.Text = cs.beltHP.ToString();
                iWeight_n.Text = cs.beltWeight.ToString();


                FillCharacterState();
                cs.beltId = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.beltId.ToString();
            }
            if (cs.sgn == 2) //Neck
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

                if (cs.neckEnch == true && SelectGear_cb.SelectedIndex == cs.neckId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.neckEnchLvl = TempEnchLvl; }
                if (cs.neckEnch == true && SelectGear_cb.SelectedIndex != cs.neckId) { ItemEnch_cb.SelectedIndex = 0; cs.neckEnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.neckEnch == false) { cs.neckEnchLvl = 0; }

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


                FillCharacterState();
                cs.neckId = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.neckId.ToString();
            }

            if (cs.sgn == 3 ) //Ring 1
            {
                cmd.CommandText = "select * from Rings where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.ring1Defap = Convert.ToInt32(dr["AP"]);
                    cs.ring1Defdp = Convert.ToInt32(dr["DP"]);
                    cs.ring1Defev = Convert.ToInt32(dr["Evasion"]);
                    cs.ring1Defacc = Convert.ToInt32(dr["Accuracy"]);
                    cs.ring1DefDR = Convert.ToInt32(dr["DR"]);
                    cs.ring1DefHP = Convert.ToInt32(dr["MaxHP"]);
                    cs.ring1DefHP = Convert.ToInt32(dr["MaxMP"]);
                    cs.ring1DefHP = Convert.ToInt32(dr["MaxST"]);
                    cs.ring1Ench = Convert.ToBoolean(dr["Ench"]);
                }

                LoadItemEnch_cb();

                cs.Type = "Rings";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                Ring1_btn.BackgroundImage = Item_image.Image;
                cs.Ring1State();

                if (cs.ring1Ench == true && SelectGear_cb.SelectedIndex == cs.ring1Id) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.ring1EnchLvl = TempEnchLvl; }
                if (cs.ring1Ench == true && SelectGear_cb.SelectedIndex != cs.ring1Id) { ItemEnch_cb.SelectedIndex = 0; cs.ring1EnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.ring1Ench == false) { cs.ring1EnchLvl = 0; }
                

                iAP_n.Text = cs.ring1ap.ToString();
                iDP_n.Text = cs.ring1dp.ToString();
                iEvas_n.Text = cs.ring1ev.ToString();
                iAcc_n.Text = cs.ring1acc.ToString();
                iDR_n.Text = cs.ring1DR.ToString();
                iHP_n.Text = cs.ring1HP.ToString();
                iMP_n.Text = cs.ring1MP.ToString();
                iST_n.Text = cs.ring1ST.ToString();


                FillCharacterState();
                cs.ring1Id = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.ring1Id.ToString();
            }

            if (cs.sgn == 4) //Ring 2
            {
                cmd.CommandText = "select * from Rings where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.ring2Defap = Convert.ToInt32(dr["AP"]);
                    cs.ring2Defdp = Convert.ToInt32(dr["DP"]);
                    cs.ring2Defev = Convert.ToInt32(dr["Evasion"]);
                    cs.ring2Defacc = Convert.ToInt32(dr["Accuracy"]);
                    cs.ring2DefDR = Convert.ToInt32(dr["DR"]);
                    cs.ring2DefHP = Convert.ToInt32(dr["MaxHP"]);
                    cs.ring2DefHP = Convert.ToInt32(dr["MaxMP"]);
                    cs.ring2DefHP = Convert.ToInt32(dr["MaxST"]);
                    cs.ring2Ench = Convert.ToBoolean(dr["Ench"]);
                }

                LoadItemEnch_cb();

                cs.Type = "Rings";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                Ring2_btn.BackgroundImage = Item_image.Image;
                cs.Ring2State();

                if (cs.ring2Ench == true && SelectGear_cb.SelectedIndex == cs.ring2Id) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.ring2EnchLvl = TempEnchLvl; }
                if (cs.ring2Ench == true && SelectGear_cb.SelectedIndex != cs.ring2Id) { ItemEnch_cb.SelectedIndex = 0; cs.ring2EnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.ring2Ench == false) { cs.ring2EnchLvl = 0; }


                iAP_n.Text = cs.ring2ap.ToString();
                iDP_n.Text = cs.ring2dp.ToString();
                iEvas_n.Text = cs.ring2ev.ToString();
                iAcc_n.Text = cs.ring2acc.ToString();
                iDR_n.Text = cs.ring2DR.ToString();
                iHP_n.Text = cs.ring2HP.ToString();
                iMP_n.Text = cs.ring2MP.ToString();
                iST_n.Text = cs.ring2ST.ToString();


                FillCharacterState();

                cs.ring2Id = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.ring2Id.ToString();
            }


            if (cs.sgn == 5) //Ear1
            {
                cmd.CommandText = "select * from Earrings where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.ear1Defap = Convert.ToInt32(dr["AP"]);
                    cs.ear1Defdp = Convert.ToInt32(dr["DP"]);
                    cs.ear1Defev = Convert.ToInt32(dr["Evasion"]);
                    cs.ear1Defacc = Convert.ToInt32(dr["Accuracy"]);
                    cs.ear1DefDR = Convert.ToInt32(dr["DR"]);
                    cs.ear1DefHP = Convert.ToInt32(dr["MaxHP"]);
                    cs.ear1DefHP = Convert.ToInt32(dr["MaxMP"]);
                    cs.ear1DefHP = Convert.ToInt32(dr["MaxST"]);
                    cs.ear1Ench = Convert.ToBoolean(dr["Ench"]);
                }

                LoadItemEnch_cb();

                cs.Type = "Earrings";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                Earring1_btn.BackgroundImage = Item_image.Image;
                cs.Earring1State();

                if (cs.ear1Ench == true && SelectGear_cb.SelectedIndex == cs.ear1Id) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.ear1EnchLvl = TempEnchLvl; }
                if (cs.ear1Ench == true && SelectGear_cb.SelectedIndex != cs.ear1Id) { ItemEnch_cb.SelectedIndex = 0; cs.ear1EnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.ear1Ench == false) { cs.ear1EnchLvl = 0; }


                iAP_n.Text = cs.ear1ap.ToString();
                iDP_n.Text = cs.ear1dp.ToString();
                iEvas_n.Text = cs.ear1ev.ToString();
                iAcc_n.Text = cs.ear1acc.ToString();
                iDR_n.Text = cs.ear1DR.ToString();
                iHP_n.Text = cs.ear1HP.ToString();
                iMP_n.Text = cs.ear1MP.ToString();
                iST_n.Text = cs.ear1ST.ToString();


                FillCharacterState();

                cs.ear1Id = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.ear1Id.ToString();
            }

            if (cs.sgn == 6) //Ear2
            {
                cmd.CommandText = "select * from Earrings where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.ear2Defap = Convert.ToInt32(dr["AP"]);
                    cs.ear2Defdp = Convert.ToInt32(dr["DP"]);
                    cs.ear2Defev = Convert.ToInt32(dr["Evasion"]);
                    cs.ear2Defacc = Convert.ToInt32(dr["Accuracy"]);
                    cs.ear2DefDR = Convert.ToInt32(dr["DR"]);
                    cs.ear2DefHP = Convert.ToInt32(dr["MaxHP"]);
                    cs.ear2DefHP = Convert.ToInt32(dr["MaxMP"]);
                    cs.ear2DefHP = Convert.ToInt32(dr["MaxST"]);
                    cs.ear2Ench = Convert.ToBoolean(dr["Ench"]);
                }

                LoadItemEnch_cb();

                cs.Type = "Earrings";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                Earring2_btn.BackgroundImage = Item_image.Image;
                cs.Earring2State();

                if (cs.ear2Ench == true && SelectGear_cb.SelectedIndex == cs.ear2Id) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.ear2EnchLvl = TempEnchLvl; }
                if (cs.ear2Ench == true && SelectGear_cb.SelectedIndex != cs.ear2Id) { ItemEnch_cb.SelectedIndex = 0; cs.ear2EnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.ear2Ench == false) { cs.ear2EnchLvl = 0; }


                iAP_n.Text = cs.ear2ap.ToString();
                iDP_n.Text = cs.ear2dp.ToString();
                iEvas_n.Text = cs.ear2ev.ToString();
                iAcc_n.Text = cs.ear2acc.ToString();
                iDR_n.Text = cs.ear2DR.ToString();
                iHP_n.Text = cs.ear2HP.ToString();
                iMP_n.Text = cs.ear2MP.ToString();
                iST_n.Text = cs.ear2ST.ToString();


                FillCharacterState();
                cs.ear2Id = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.ear2Id.ToString();
            }

            if (cs.sgn == 7)
            {
                cmd.CommandText = "select * from Armors where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.armDefdp = Convert.ToInt32(dr["DP"]);
                    cs.armDefev = Convert.ToInt32(dr["Evasion"]);
                    cs.armDefhev = Convert.ToInt32(dr["HEvasion"]);
                    cs.armDefdr = Convert.ToInt32(dr["DR"]);
                    cs.armDefhdr = Convert.ToInt32(dr["HDR"]);
                    cs.armDefHP = Convert.ToInt32(dr["MaxHP"]);
                    cs.armDefMP = Convert.ToInt32(dr["MaxMP"]);
                    cs.armEnch = Convert.ToBoolean(dr["Ench"]);
                    cs.armIsBoss = Convert.ToBoolean(dr["IsBossItem"]);
                }

               LoadItemEnch_cb();

                cs.Type = "Armors";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                Armour_btn.BackgroundImage = Item_image.Image;
                cs.ArmorState();

                if (cs.armEnch == true && SelectGear_cb.SelectedIndex == cs.armId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.armEnchLvl = TempEnchLvl; }
                if (cs.armEnch == true && SelectGear_cb.SelectedIndex != cs.armId) { ItemEnch_cb.SelectedIndex = 0; cs.armEnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.armEnch == false) { cs.armEnchLvl = 0; }


                iDP_n.Text = cs.armdp.ToString();
                iEvas_n.Text = cs.armev.ToString();
                iHEV_n.Text = cs.armev.ToString();
                iDR_n.Text = cs.armdr.ToString();
                iHDR_n.Text = cs.armdr.ToString();
                iHP_n.Text = cs.armHP.ToString();
                iMP_n.Text = cs.armMP.ToString();


                FillCharacterState();
                cs.armId = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.armId.ToString();
            }


            if (cs.sgn == 8)
            {
                cmd.CommandText = "select * from Helmets where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.helDefdp = Convert.ToInt32(dr["DP"]);
                    cs.helDefev = Convert.ToInt32(dr["Evasion"]);
                    cs.helDefhev = Convert.ToInt32(dr["HEvasion"]);
                    cs.helDefdr = Convert.ToInt32(dr["DR"]);
                    cs.helDefhdr = Convert.ToInt32(dr["HDR"]);
                    cs.helDefHP = Convert.ToInt32(dr["MaxHP"]);
                    cs.helDefRes = Convert.ToInt32(dr["AllRes"]);
                    cs.helEnch = Convert.ToBoolean(dr["Ench"]);
                    cs.helIsBoss = Convert.ToBoolean(dr["IsBossItem"]);
                }

                LoadItemEnch_cb();
                cs.helId = SelectGear_cb.SelectedIndex;

                cs.Type = "Helmets";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                Helmet_btn.BackgroundImage = Item_image.Image;
                cs.HelmetState();

                if (cs.helEnch == true && SelectGear_cb.SelectedIndex == cs.helId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.helEnchLvl = TempEnchLvl; }
                if (cs.helEnch == true && SelectGear_cb.SelectedIndex != cs.helId) { ItemEnch_cb.SelectedIndex = 0; cs.helEnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.helEnch == false) { cs.helEnchLvl = 0; }


                iDP_n.Text = cs.heldp.ToString();
                iEvas_n.Text = cs.helev.ToString();
                iHEV_n.Text = cs.helhev.ToString();
                iDR_n.Text = cs.heldr.ToString();
                iHDR_n.Text = cs.helhdr.ToString();
                iHP_n.Text = cs.helHP.ToString();
                iRes_n.Text = cs.helRes.ToString();

                
                FillCharacterState();

                cs.helId = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.helId.ToString();
            }
            //SetBonus
            cs.SetBonusCheck();
            sbc_lbl.Text = cs.sb.ToString();
            if (cs.sb <= 1) { sbc1_lbl.Text = 0.ToString(); sbc2_lbl.Text = 0.ToString(); sbc3_lbl.Text = 0.ToString(); sbc4_lbl.Text = 0.ToString(); sbc5_lbl.Text = 0.ToString(); }
            if (cs.sb == 2) { sbc1_lbl.Text = 200.ToString(); sbc2_lbl.Text = 100.ToString(); }
            if (cs.sb == 3) { sbc3_lbl.Text = 200.ToString(); }
            if (cs.sb == 4) { sbc4_lbl.Text = 1.ToString(); sbc5_lbl.Text = 1.ToString(); }
        }


        private void LoadItemEnch_cb()
        {
            if (cs.sgn == 1 & cs.beltEnch == true| cs.sgn ==2 & cs.neckEnch == true| cs.sgn == 3& cs.ring1Ench == true|
                cs.sgn == 4 & cs.ring2Ench == true | cs.sgn == 5 & cs.ear1Ench == true| cs.sgn == 6 & cs.ear2Ench == true)
            {
                ItemEnch_cb.SelectedIndexChanged -= ItemEnch_cb_SelectedIndexChanged;
                ItemEnch_cb.Visible = true; Ench_lbl.Visible = true;
                string[] EnchAccessories = {"0","1", "2", "3", "4", "5" };
                ItemEnch_cb.DataSource = EnchAccessories;
                ItemEnch_cb.SelectedIndexChanged += ItemEnch_cb_SelectedIndexChanged;
                if (cs.sgn == 1) ItemEnch_cb.SelectedIndex = cs.beltEnchLvl;
                else if (cs.sgn == 2) ItemEnch_cb.SelectedIndex = cs.neckEnchLvl;
                else if (cs.sgn == 3) ItemEnch_cb.SelectedIndex = cs.ring1EnchLvl;
                else if (cs.sgn == 4) ItemEnch_cb.SelectedIndex = cs.ring2EnchLvl;
                else if (cs.sgn == 5) ItemEnch_cb.SelectedIndex = cs.ear1EnchLvl;
                else if (cs.sgn == 6) ItemEnch_cb.SelectedIndex = cs.ear2EnchLvl;
            }

            else if (cs.sgn == 7 & cs.armEnch == true| cs.sgn == 8 & cs.helEnch == true)
            {
                ItemEnch_cb.SelectedIndexChanged -= ItemEnch_cb_SelectedIndexChanged;
                ItemEnch_cb.Visible = true; Ench_lbl.Visible = true;
                string[] EnchArmor = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "I", "II", "III", "IV", "V" };
                ItemEnch_cb.DataSource = EnchArmor;
                ItemEnch_cb.SelectedIndexChanged += ItemEnch_cb_SelectedIndexChanged;
                if (cs.sgn == 7) ItemEnch_cb.SelectedIndex = cs.armEnchLvl;
                if (cs.sgn == 8) ItemEnch_cb.SelectedIndex = cs.helEnchLvl;

            }

            else { ItemEnch_cb.Visible = false; Ench_lbl.Visible = false; }
        }


        private void ItemEnch_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemStatClear();

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

                FillCharacterState();

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

                FillCharacterState();

            }

            else if (cs.sgn == 3)
            {
                cs.ring1EnchLvl = ItemEnch_cb.SelectedIndex;
                cs.Ring1State();

                iAP_n.Text = cs.ring1ap.ToString();
                iDP_n.Text = cs.ring1dp.ToString();
                iEvas_n.Text = cs.ring1ev.ToString();
                iAcc_n.Text = cs.ring1acc.ToString();
                iDR_n.Text = cs.ring1DR.ToString();
                iHP_n.Text = cs.ring1HP.ToString();
                iMP_n.Text = cs.ring1MP.ToString();
                iST_n.Text = cs.ring1ST.ToString();


                FillCharacterState();
            }

            else if (cs.sgn == 4)
            {
                cs.ring2EnchLvl = ItemEnch_cb.SelectedIndex;
                cs.Ring2State();

                iAP_n.Text = cs.ring2ap.ToString();
                iDP_n.Text = cs.ring2dp.ToString();
                iEvas_n.Text = cs.ring2ev.ToString();
                iAcc_n.Text = cs.ring2acc.ToString();
                iDR_n.Text = cs.ring2DR.ToString();
                iHP_n.Text = cs.ring2HP.ToString();
                iMP_n.Text = cs.ring2MP.ToString();
                iST_n.Text = cs.ring2ST.ToString();


                FillCharacterState();
            }

            else if (cs.sgn == 5)
            {
                cs.ear1EnchLvl = ItemEnch_cb.SelectedIndex;
                cs.Earring1State();

                iAP_n.Text = cs.ear1ap.ToString();
                iDP_n.Text = cs.ear1dp.ToString();
                iEvas_n.Text = cs.ear1ev.ToString();
                iAcc_n.Text = cs.ear1acc.ToString();
                iDR_n.Text = cs.ear1DR.ToString();
                iHP_n.Text = cs.ear1HP.ToString();
                iMP_n.Text = cs.ear1MP.ToString();
                iST_n.Text = cs.ear1ST.ToString();


                FillCharacterState();
            }

            else if (cs.sgn == 6)
            {
                cs.ear2EnchLvl = ItemEnch_cb.SelectedIndex;
                cs.Earring2State();

                iAP_n.Text = cs.ear2ap.ToString();
                iDP_n.Text = cs.ear2dp.ToString();
                iEvas_n.Text = cs.ear2ev.ToString();
                iAcc_n.Text = cs.ear2acc.ToString();
                iDR_n.Text = cs.ear2DR.ToString();
                iHP_n.Text = cs.ear2HP.ToString();
                iMP_n.Text = cs.ear2MP.ToString();
                iST_n.Text = cs.ear2ST.ToString();


                FillCharacterState();
            }

            else if (cs.sgn == 7)
            {
                cs.armEnchLvl = ItemEnch_cb.SelectedIndex;
                cs.ArmorState();

                iDP_n.Text = cs.armdp.ToString();
                iEvas_n.Text = cs.armev.ToString();
                iHEV_n.Text = cs.armhev.ToString();
                iDR_n.Text = cs.armdr.ToString();
                iHDR_n.Text = cs.armhdr.ToString();
                iHP_n.Text = cs.armHP.ToString();
                iMP_n.Text = cs.armMP.ToString();


                FillCharacterState();
            }

            else if (cs.sgn == 8)
            {
                cs.helEnchLvl = ItemEnch_cb.SelectedIndex;
                cs.HelmetState();

                iDP_n.Text = cs.heldp.ToString();
                iEvas_n.Text = cs.helev.ToString();
                iHEV_n.Text = cs.helhev.ToString();
                iDR_n.Text = cs.heldr.ToString();
                iHDR_n.Text = cs.helhdr.ToString();
                iHP_n.Text = cs.helHP.ToString();
                iRes_n.Text = cs.helRes.ToString();


                FillCharacterState();
            }
        }

        
    }
}
