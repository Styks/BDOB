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
            cSSFR_n.Text = Convert.ToString(cs.cRes1) + "%";
            cKBR_n.Text = Convert.ToString(cs.cRes2) + "%";
            cGrapR_n.Text = Convert.ToString(cs.cRes3) + "%";
            cKFR_n.Text = Convert.ToString(cs.cRes4) + "%";
            cDR_n.Text = Convert.ToString(cs.cDR);
            cHP_n.Text = Convert.ToString(cs.cMaxHP);
            cMP_n.Text = Convert.ToString(cs.cMaxMP);
            cStamina_n.Text = Convert.ToString(cs.cMaxST);
            Weight_n.Text = Convert.ToString(cs.cWeight);
            cHDR_n.Text = Convert.ToString(cs.chdr);
            cHE_n.Text = Convert.ToString(cs.chev);
            cMvS_n.Text = Convert.ToString(cs.cmvs);
            cCR_n.Text = Convert.ToString(cs.ccr);
            cHAP_n.Text = Convert.ToString(cs.chap);
            cAtkSpeed_n.Text = Convert.ToString(cs.cAtkSpeed);
            cCastSpeed_n.Text = Convert.ToString(cs.cCastSpeed);
            cHPR_n.Text = Convert.ToString(cs.chpr);
            cMPR_n.Text = Convert.ToString(cs.cmpr);
            cLuck_n.Text = Convert.ToString(cs.cluck);
            cEDA_n.Text = Convert.ToString(cs.ceda);
            cEDH_n.Text = Convert.ToString(cs.cedh);
            cEAPa_n.Text = Convert.ToString(cs.ceapa);
            cExtraDamKama_n.Text = Convert.ToString(cs.cedKama);
            cADtDemiH_n.Text = Convert.ToString(cs.cADtDemiH);
            cEDtAExcHumanAndDemi_n.Text = Convert.ToString(cs.cADtoAllWithExcept);
            cBidding_n.Text = Convert.ToString(cs.cBidding) + "%";
            cSpiritRage_n.Text = Convert.ToString(cs.cSpiritRage) + "%";
            cEDtoBack_n.Text = Convert.ToString(cs.cEDtoBack) + "%";
        }

        private void ItemStatClear()
        {
            iAP_n.Text = "0"; //AP
            iDP_n.Text = "0"; //DP
            iEvas_n.Text = "0"; //Evasion
            iAcc_n.Text = "0"; //Accuracy
            iRes_n.Text = "0%"; //All Resists
            iDR_n.Text = "0"; // Damage Reduction
            iHP_n.Text = "0"; // Max HP
            iWeight_n.Text = "0"; // Max Weight
            iMP_n.Text = "0"; //Max MP
            iST_n.Text = "0"; //Max stamina
            iSSFR_n.Text = "0%"; // SSF Resist
            iKBR_n.Text = "0%"; // KB Resist
            iGrapR_n.Text = "0%"; // Graple Resist
            iKFR_n.Text = "0%"; //KF Resist
            iHEV_n.Text = "0"; //Hiden Evasion
            iHDR_n.Text = "0"; //Hiden Damage Reduction
            iAtkSpeed_n.Text = "0"; // Attack speed
            iCastSpeed_n.Text = "0"; //Cast speed
            iMVS_n.Text = "0"; // Movement speed
            iCrit_n.Text = "0"; // Critical rate
            iExtraDamKama_n.Text = "0"; //Extra Damage to Kamasylvians
            iEDtA_n.Text = "0"; // Extra Damage to All Species
            iEAPa_n.Text = "0"; // Extra AP against monters
            iMPR_n.Text = "0"; // MP Recovery
            iHPR_n.Text = "0"; // HP Recovery
            iLuck_n.Text = "0"; // Luck
            iEDH_n.Text = "0"; //Extra damage to Humans
            iADtDemiH_n.Text = "0"; // Additional damage to Demihumans
            iEDtAExcHumanAndDemi_n.Text = "0"; //Extra damage to All Species Except Humans and Demihumans
            iSpiritRage_n.Text = "0%"; // Black Spirit's Rage
            iBidding_n.Text = "0%"; //Marketplace Bidding Success Rate
            iEDtoBack_n.Text = "0%"; // Extra damage to back
        }

        //Item load procedurs
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

        private void LoadGloves() // Gloves
        {
            SelectGear_cb.SelectedIndexChanged -= SelectedGear_cb_SelectedIndexChanged;
            var sql = @"select * from Gloves";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.DataSource = ds.Tables[0];
            SelectGear_cb.DisplayMember = "Name";
            SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Gloves", cs.glovId);
            SelectGear_cb.SelectedIndexChanged += SelectedGear_cb_SelectedIndexChanged;
            SelectGear_cb.SelectedIndex = cs.glovId;
            LoadItemEnch_cb();
        }

        private void LoadShoes() // Shoes
        {
            SelectGear_cb.SelectedIndexChanged -= SelectedGear_cb_SelectedIndexChanged;
            var sql = @"select * from Shoes";
            var da = new SqlDataAdapter(sql, Base_Connect.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SelectGear_cb.DataSource = ds.Tables[0];
            SelectGear_cb.DisplayMember = "Name";
            SelectGear_cb.ValueMember = "Id";
            Item_Icon_Load("Shoes", cs.shId);
            SelectGear_cb.SelectedIndexChanged += SelectedGear_cb_SelectedIndexChanged;
            SelectGear_cb.SelectedIndex = cs.shId;
            LoadItemEnch_cb();
        }

        //Books
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

        //Item buttons
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

        private void Gloves_btn_Click(object sender, EventArgs e)
        {
            ItemStatClear();
            cs.sgn = 9;
            LoadGloves();
        }

        private void Boots_btn_Click(object sender, EventArgs e)
        {
            ItemStatClear();
            cs.sgn = 10;
            LoadShoes();
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
                    cs.beltDefSpiritRage = Convert.ToInt32(dr["BlackSpirit"]);
                    cs.beltDefAPagainst = Convert.ToInt32(dr["ApAgainst"]);
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
                iSpiritRage_n.Text = Convert.ToString(cs.beltSpiritRage) + "%";
                iEAPa_n.Text = cs.beltAPagaingst.ToString();

                cs.beltId = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.beltId.ToString();
            } //Belt
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
                    cs.neckDefSpiritRage = Convert.ToInt32(dr["BlackSpirit"]);
                    cs.neckDefAPagainst = Convert.ToInt32(dr["ApAgainst"]);
                    cs.neckDefKamaDamage = Convert.ToInt32(dr["KamaDamage"]);
                    cs.neckDefBackDamage = Convert.ToInt32(dr["BackDamage"]);

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
                iRes_n.Text = cs.neckAllRes.ToString() + "%";
                iDR_n.Text = cs.neckDR.ToString();
                iSSFR_n.Text = cs.neckSSF.ToString() + "%";
                iKBR_n.Text = cs.neckKB.ToString() + "%";
                iGrapR_n.Text = cs.neckG.ToString() + "%";
                iKFR_n.Text = cs.neckKF.ToString() + "%";
                iHP_n.Text = cs.neckHP.ToString();
                iSpiritRage_n.Text = Convert.ToString(cs.neckSpiritRage) + "%";
                iEAPa_n.Text = cs.neckAPagaingst.ToString();
                iExtraDamKama_n.Text = cs.neckKamaDamage.ToString();
                iEDtoBack_n.Text = cs.neckBackDamage.ToString() + "%";

                cs.neckId = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.neckId.ToString();
            } //Necklace
             
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
                    cs.ring1DefMP = Convert.ToInt32(dr["MaxMP"]);
                    cs.ring1DefST = Convert.ToInt32(dr["MaxST"]);
                    cs.ring1Ench = Convert.ToBoolean(dr["Ench"]);
                    cs.ring1DefHEv = Convert.ToInt32(dr["HEv"]);
                    cs.ring1DefAPagainst = Convert.ToInt32(dr["ApAgainst"]);
                    cs.ring1DefKamaDamage = Convert.ToInt32(dr["KamaDamage"]);
                    cs.ring1DefDamageHumans = Convert.ToInt32(dr["HumanDamage"]);
                    cs.ring1DefDamageDemihumans = Convert.ToInt32(dr["DemiHumanDamage"]);
                    cs.ring1DefDamageAllExcept = Convert.ToInt32(dr["DamAllExHuman"]);
                    cs.ring1DefBidding = Convert.ToInt32(dr["MarketBidding"]);
                    cs.ring1DefSpiritRage = Convert.ToInt32(dr["BlackSpirit"]);
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
                iHEV_n.Text = cs.ring1HEv.ToString();
                iEAPa_n.Text = cs.ring1APagaingst.ToString();
                iExtraDamKama_n.Text = cs.ring1KamaDamage.ToString();
                iEDH_n.Text = cs.ring1DamageHumans.ToString();
                iADtDemiH_n.Text = cs.ring1DamageDemihumans.ToString();
                iEDtAExcHumanAndDemi_n.Text = Convert.ToString(cs.ring1DamageAllExcept);
                iBidding_n.Text = Convert.ToString(cs.ring1Bidding) + "%";
                iSpiritRage_n.Text = Convert.ToString(cs.ring1SpiritRage) + "%";

                cs.ring1Id = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.ring1Id.ToString();
            } //Ring1

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
                    cs.ring2DefMP = Convert.ToInt32(dr["MaxMP"]);
                    cs.ring2DefST = Convert.ToInt32(dr["MaxST"]);
                    cs.ring2Ench = Convert.ToBoolean(dr["Ench"]);
                    cs.ring2DefHEv = Convert.ToInt32(dr["HEv"]);
                    cs.ring2DefAPagainst = Convert.ToInt32(dr["ApAgainst"]);
                    cs.ring2DefKamaDamage = Convert.ToInt32(dr["KamaDamage"]);
                    cs.ring2DefDamageHumans = Convert.ToInt32(dr["HumanDamage"]);
                    cs.ring2DefDamageDemihumans = Convert.ToInt32(dr["DemiHumanDamage"]);
                    cs.ring2DefDamageAllExcept = Convert.ToInt32(dr["DamAllExHuman"]);
                    cs.ring2DefBidding = Convert.ToInt32(dr["MarketBidding"]);
                    cs.ring2DefSpiritRage = Convert.ToInt32(dr["BlackSpirit"]);

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
                iHEV_n.Text = cs.ring2HEv.ToString();
                iEAPa_n.Text = cs.ring2APagaingst.ToString();
                iExtraDamKama_n.Text = cs.ring2KamaDamage.ToString();
                iEDH_n.Text = cs.ring2DamageHumans.ToString();
                iADtDemiH_n.Text = cs.ring2DamageDemihumans.ToString();
                iEDtAExcHumanAndDemi_n.Text = Convert.ToString(cs.ring2DamageAllExcept);
                iBidding_n.Text = Convert.ToString(cs.ring2Bidding) + "%";
                iSpiritRage_n.Text = Convert.ToString(cs.ring2SpiritRage) + "%";

                cs.ring2Id = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.ring2Id.ToString();
            }//Ring 2


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
                    cs.ear1DefMP = Convert.ToInt32(dr["MaxMP"]);
                    cs.ear1DefST = Convert.ToInt32(dr["MaxST"]);
                    cs.ear1Ench = Convert.ToBoolean(dr["Ench"]);
                    cs.ear1DefSpiritRage = Convert.ToInt32(dr["BlackSpirit"]);
                    cs.ear1DefAPagainst = Convert.ToInt32(dr["ApAgainst"]);
                    cs.ear1DefKamaDamage = Convert.ToInt32(dr["KamaDamage"]);
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
                iSpiritRage_n.Text = Convert.ToString(cs.ear1SpiritRage) + "%";
                iEAPa_n.Text = cs.ear1APagaingst.ToString();
                iExtraDamKama_n.Text = cs.ear1KamaDamage.ToString();

                cs.ear1Id = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.ear1Id.ToString();
            } //Earring 1

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
                    cs.ear2DefMP = Convert.ToInt32(dr["MaxMP"]);
                    cs.ear2DefST = Convert.ToInt32(dr["MaxST"]);
                    cs.ear2Ench = Convert.ToBoolean(dr["Ench"]);
                    cs.ear2DefSpiritRage = Convert.ToInt32(dr["BlackSpirit"]);
                    cs.ear2DefAPagainst = Convert.ToInt32(dr["ApAgainst"]);
                    cs.ear2DefKamaDamage = Convert.ToInt32(dr["KamaDamage"]);
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
                iSpiritRage_n.Text = Convert.ToString(cs.ear2SpiritRage) + "%";
                iEAPa_n.Text = cs.ear2APagaingst.ToString();
                iExtraDamKama_n.Text = cs.ear2KamaDamage.ToString();

                cs.ear2Id = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.ear2Id.ToString();
            } //Earring 2

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
                    cs.armDefSSFRes = Convert.ToInt32(dr["SSFRes"]);
                    cs.armDefWeight = Convert.ToInt32(dr["WeightLimit"]);
                    cs.armDefAcc = Convert.ToInt32(dr["Accuracy"]);
                    cs.armSB = Convert.ToInt32(dr["SetBonus"]);
                    cs.armDefHPRecovery = Convert.ToInt32(dr["HPRecovery"]);
                    cs.armDefMPRecovery = Convert.ToInt32(dr["MPRecovery"]);
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
                iHEV_n.Text = cs.armhev.ToString();
                iDR_n.Text = cs.armdr.ToString();
                iHDR_n.Text = cs.armhdr.ToString();
                iHP_n.Text = cs.armHP.ToString();
                iMP_n.Text = cs.armMP.ToString();
                iSSFR_n.Text = cs.armSSFRes.ToString() + "%";
                iWeight_n.Text = cs.armWeight.ToString();
                iAcc_n.Text = cs.armAcc.ToString();
                iHPR_n.Text = cs.armHPRecovery.ToString();
                iMPR_n.Text = cs.armMPRecovery.ToString(); 

                cs.armId = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.armId.ToString();
            } //Armor


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
                    cs.helSSFDefRes = Convert.ToInt32(dr["SSFREs"]);
                    cs.helKFDefRes = Convert.ToInt32(dr["KFRes"]);
                    cs.helGrapleDefRes = Convert.ToInt32(dr["KBREs"]);
                    cs.helKBDefRes = Convert.ToInt32(dr["GrapleRes"]);
                    cs.helDefWeight = Convert.ToInt32(dr["WeightLimit"]);
                    cs.helEnch = Convert.ToBoolean(dr["Ench"]);
                    cs.helIsBoss = Convert.ToBoolean(dr["IsBossItem"]);
                    cs.helSB = Convert.ToInt32(dr["SetBonus"]);
                    cs.helDefST = Convert.ToInt32(dr["MaxStamina"]);
                    cs.helDefHPRecovery =Convert.ToInt32(dr["HPRecovery"]);
                    cs.helDefLuck = Convert.ToInt32(dr["Luck"]);
                }

                LoadItemEnch_cb();

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
                iSSFR_n.Text = cs.helSSFRes.ToString() + "%";
                iKBR_n.Text = cs.helKBRes.ToString() + "%";
                iGrapR_n.Text = cs.helGrapleRes.ToString() + "%";
                iKFR_n.Text = cs.helKFRes.ToString() + "%";
                iST_n.Text = cs.helST.ToString();
                iWeight_n.Text = cs.helWeight.ToString();
                iHPR_n.Text = cs.helHPRecovery.ToString();
                iLuck_n.Text = cs.helLuck.ToString();

                cs.helId = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.helId.ToString();
            } //Helmet

            if (cs.sgn == 9)
            {
                cmd.CommandText = "select * from Gloves where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.glovDefdp = Convert.ToInt32(dr["DP"]);
                    cs.glovDefacc = Convert.ToInt32(dr["Accuracy"]);
                    cs.glovDefev = Convert.ToInt32(dr["Evasion"]);
                    cs.glovDefhev = Convert.ToInt32(dr["HEvasion"]);
                    cs.glovDefdr = Convert.ToInt32(dr["DR"]);
                    cs.glovDefhdr = Convert.ToInt32(dr["HDR"]);
                    cs.glovEnch = Convert.ToBoolean(dr["Ench"]);
                    cs.glovIsBoss = Convert.ToBoolean(dr["IsBossItem"]);
                    cs.glovSB = Convert.ToInt32(dr["SetBonus"]);
                    cs.glovDefAtkSpeed = Convert.ToInt32(dr["AttackSpeed"]);
                    cs.glovDefCastSpeed = Convert.ToInt32(dr["CastSpeed"]);
                    cs.glovDefWeight = Convert.ToInt32(dr["WeightLimit"]);
                    cs.glovDefCrit = Convert.ToInt32(dr["CriticalHit"]);
                    cs.glovDefGrapleRes = Convert.ToInt32(dr["GrapleRes"]);
                    cs.glovDefDamage = Convert.ToInt32(dr["DamageToAll"]);
                }

                LoadItemEnch_cb();

                cs.Type = "Gloves";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                Gloves_btn.BackgroundImage = Item_image.Image;
                cs.GlovesState();

                if (cs.glovEnch == true && SelectGear_cb.SelectedIndex == cs.glovId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.glovEnchLvl = TempEnchLvl; }
                if (cs.glovEnch == true && SelectGear_cb.SelectedIndex != cs.glovId) { ItemEnch_cb.SelectedIndex = 0; cs.glovEnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.glovEnch == false) { cs.glovEnchLvl = 0; }


                iDP_n.Text = cs.glovdp.ToString();
                iEvas_n.Text = cs.glovev.ToString();
                iHEV_n.Text = cs.glovhev.ToString();
                iDR_n.Text = cs.glovdr.ToString();
                iHDR_n.Text = cs.glovhdr.ToString();
                iAcc_n.Text = cs.glovacc.ToString();
                iGrapR_n.Text = cs.glovGrapleRes.ToString() + "%";
                iAtkSpeed_n.Text = cs.glovAtkSpeed.ToString();
                iCastSpeed_n.Text = cs.glovCastSpeed.ToString();
                iCrit_n.Text = cs.glovCrit.ToString();
                iWeight_n.Text = cs.glovWeight.ToString();
                iEDtA_n.Text = cs.glovDamage.ToString();

                cs.glovId = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.glovId.ToString();
            } //Gloves

            if (cs.sgn == 10)
            {
                cmd.CommandText = "select * from Shoes where Id='" + SelectGear_cb.SelectedIndex.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cs.shDefdp = Convert.ToInt32(dr["DP"]);
                    cs.shDefev = Convert.ToInt32(dr["Evasion"]);
                    cs.shDefhev = Convert.ToInt32(dr["HEvasion"]);
                    cs.shDefdr = Convert.ToInt32(dr["DR"]);
                    cs.shDefhdr = Convert.ToInt32(dr["HDR"]);
                    cs.shEnch = Convert.ToBoolean(dr["Ench"]);
                    cs.shIsBoss = Convert.ToBoolean(dr["IsBossItem"]);
                    cs.shSB = Convert.ToInt32(dr["SetBonus"]);
                    cs.shDefMvs = Convert.ToInt32(dr["MovmmentSp"]);
                    cs.shDefKBRes = Convert.ToInt32(dr["KBRes"]);
                    cs.shDefMaxST = Convert.ToInt32(dr["MaxStamina"]);
                    cs.shDefWeight = Convert.ToInt32(dr["WeightLimit"]);


                }

                LoadItemEnch_cb();

                cs.Type = "Shoes";
                Item_Icon_Load(cs.Type, SelectGear_cb.SelectedIndex);
                Boots_btn.BackgroundImage = Item_image.Image;
                cs.ShoesState();

                if (cs.shEnch == true && SelectGear_cb.SelectedIndex == cs.shId) { TempEnchLvl = ItemEnch_cb.SelectedIndex; cs.shEnchLvl = TempEnchLvl; }
                if (cs.shEnch == true && SelectGear_cb.SelectedIndex != cs.shId) { ItemEnch_cb.SelectedIndex = 0; cs.shEnchLvl = 0; TempEnchLvl = 0; }
                else if (cs.shEnch == false) { cs.shEnchLvl = 0; }


                iDP_n.Text = cs.shdp.ToString();
                iEvas_n.Text = cs.shev.ToString();
                iHEV_n.Text = cs.shhev.ToString();
                iDR_n.Text = cs.shdr.ToString();
                iHDR_n.Text = cs.shhdr.ToString();
                iKBR_n.Text = cs.shKBRes.ToString();
                iMVS_n.Text = cs.shMvs.ToString();
                iST_n.Text = cs.shMaxST.ToString();
                iWeight_n.Text = cs.shWeight.ToString();

                cs.shId = SelectGear_cb.SelectedIndex;
                textBox1.Text = cs.shId.ToString();
            } //Shoes

            //SetBonus
            cs.BossSetBonusCheck();
            bsb_lbl.Text = cs.b_sb.ToString();
            lsb_lbl.Text = cs.l_sb.ToString();
            asb_lbl.Text = cs.a_sb.ToString();
            cs.BossSetBonus();

            FillCharacterState();
        }

        private void LoadItemEnch_cb()
        {
            if (cs.sgn == 1 & cs.beltEnch == true | cs.sgn == 2 & cs.neckEnch == true | cs.sgn == 3 & cs.ring1Ench == true |
                cs.sgn == 4 & cs.ring2Ench == true | cs.sgn == 5 & cs.ear1Ench == true | cs.sgn == 6 & cs.ear2Ench == true)
            {
                ItemEnch_cb.SelectedIndexChanged -= ItemEnch_cb_SelectedIndexChanged;
                ItemEnch_cb.Visible = true; Ench_lbl.Visible = true;
                string[] EnchAccessories = { "0", "1", "2", "3", "4", "5" };
                ItemEnch_cb.DataSource = EnchAccessories;
                ItemEnch_cb.SelectedIndexChanged += ItemEnch_cb_SelectedIndexChanged;
                if (cs.sgn == 1) ItemEnch_cb.SelectedIndex = cs.beltEnchLvl;
                else if (cs.sgn == 2) ItemEnch_cb.SelectedIndex = cs.neckEnchLvl;
                else if (cs.sgn == 3) ItemEnch_cb.SelectedIndex = cs.ring1EnchLvl;
                else if (cs.sgn == 4) ItemEnch_cb.SelectedIndex = cs.ring2EnchLvl;
                else if (cs.sgn == 5) ItemEnch_cb.SelectedIndex = cs.ear1EnchLvl;
                else if (cs.sgn == 6) ItemEnch_cb.SelectedIndex = cs.ear2EnchLvl;
            } //For accesories

            else if (cs.sgn == 7 & cs.armEnch == true | cs.sgn == 8 & cs.helEnch == true | cs.sgn == 9 & cs.glovEnch == true | cs.sgn ==10 & cs.shEnch ==true)
            {
                ItemEnch_cb.SelectedIndexChanged -= ItemEnch_cb_SelectedIndexChanged;
                ItemEnch_cb.Visible = true; Ench_lbl.Visible = true;
                string[] EnchArmor = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "I", "II", "III", "IV", "V" };
                ItemEnch_cb.DataSource = EnchArmor;
                ItemEnch_cb.SelectedIndexChanged += ItemEnch_cb_SelectedIndexChanged;
                if (cs.sgn == 7) ItemEnch_cb.SelectedIndex = cs.armEnchLvl;
                if (cs.sgn == 8) ItemEnch_cb.SelectedIndex = cs.helEnchLvl;
                if (cs.sgn == 9) ItemEnch_cb.SelectedIndex = cs.glovEnchLvl;
                if (cs.sgn == 10) ItemEnch_cb.SelectedIndex = cs.shEnchLvl;


            } //For armor

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
                iSpiritRage_n.Text = Convert.ToString(cs.beltSpiritRage) + "%";
                iEAPa_n.Text = cs.beltAPagaingst.ToString();
                FillCharacterState();

            } //Belt

            else if (cs.sgn == 2)
            {
                cs.neckEnchLvl = ItemEnch_cb.SelectedIndex;
                cs.NeckState();

                iAP_n.Text = cs.neckap.ToString();
                iDP_n.Text = cs.neckdp.ToString();
                iEvas_n.Text = cs.neckev.ToString();
                iAcc_n.Text = cs.neckacc.ToString();
                iRes_n.Text = cs.neckAllRes.ToString() + "%";
                iDR_n.Text = cs.neckDR.ToString();
                iSSFR_n.Text = cs.neckSSF.ToString() + "%";
                iKBR_n.Text = cs.neckKB.ToString() + "%";
                iGrapR_n.Text = cs.neckG.ToString() + "%";
                iKFR_n.Text = cs.neckKF.ToString() + "%";
                iHP_n.Text = cs.neckHP.ToString();
                iSpiritRage_n.Text = Convert.ToString(cs.neckSpiritRage) + "%";
                iEAPa_n.Text = cs.neckAPagaingst.ToString();
                iExtraDamKama_n.Text = cs.neckKamaDamage.ToString();
                iEDtoBack_n.Text = cs.neckBackDamage.ToString() + "%";
                FillCharacterState();

            } //Neck

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
                iEDH_n.Text = cs.ring1DamageHumans.ToString();
                iADtDemiH_n.Text = cs.ring1DamageDemihumans.ToString();
                iEDtAExcHumanAndDemi_n.Text = cs.ring1DamageAllExcept.ToString();
                iEAPa_n.Text = cs.ring1APagaingst.ToString();
                iBidding_n.Text = Convert.ToString(cs.ring1Bidding) + "%";
                iSpiritRage_n.Text = Convert.ToString(cs.ring1SpiritRage) + "%";

                FillCharacterState();
            } // Ring1

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
                iEDH_n.Text = cs.ring2DamageHumans.ToString();
                iADtDemiH_n.Text = cs.ring2DamageDemihumans.ToString();
                iEDtAExcHumanAndDemi_n.Text = cs.ring2DamageAllExcept.ToString();
                iEAPa_n.Text = cs.ring2APagaingst.ToString();
                iBidding_n.Text = Convert.ToString(cs.ring2Bidding) + "%";
                iSpiritRage_n.Text = Convert.ToString(cs.ring2SpiritRage) + "%";

                FillCharacterState();
            } //Ring2

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
                iSpiritRage_n.Text = Convert.ToString(cs.ear1SpiritRage) + "%";
                iEAPa_n.Text = cs.ear1APagaingst.ToString();
                iExtraDamKama_n.Text = cs.ear1KamaDamage.ToString();

                FillCharacterState();
            } //Earring 1

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
                iSpiritRage_n.Text = Convert.ToString(cs.ear2SpiritRage) + "%";
                iEAPa_n.Text = cs.ear2APagaingst.ToString();
                iExtraDamKama_n.Text = cs.ear2KamaDamage.ToString();

                FillCharacterState();
            } //Earring 2

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
                iSSFR_n.Text = cs.armSSFRes.ToString() + "%";
                iWeight_n.Text = cs.armWeight.ToString();
                iAcc_n.Text = cs.armAcc.ToString();
                iHPR_n.Text = cs.armHPRecovery.ToString();
                iMPR_n.Text = cs.armMPRecovery.ToString();

                FillCharacterState();
            } // Armor

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
                iSSFR_n.Text = cs.helSSFRes.ToString() + "%";
                iKBR_n.Text = cs.helKBRes.ToString() + "%";
                iGrapR_n.Text = cs.helGrapleRes.ToString() + "%";
                iKFR_n.Text = cs.helKFRes.ToString() + "%";
                iST_n.Text = cs.helWeight.ToString();
                iHPR_n.Text = cs.helHPRecovery.ToString();
                iLuck_n.Text = cs.helLuck.ToString();

                FillCharacterState();
            } // Helmet

            else if (cs.sgn == 9)
            {
                cs.glovEnchLvl = ItemEnch_cb.SelectedIndex;
                cs.GlovesState();

                iDP_n.Text = cs.glovdp.ToString();
                iAcc_n.Text = cs.glovacc.ToString();
                iEvas_n.Text = cs.glovev.ToString();
                iHEV_n.Text = cs.glovhev.ToString();
                iDR_n.Text = cs.glovdr.ToString();
                iHDR_n.Text = cs.glovhdr.ToString();
                iGrapR_n.Text = cs.glovGrapleRes.ToString() + "%";
                iAtkSpeed_n.Text = cs.glovAtkSpeed.ToString();
                iCastSpeed_n.Text = cs.glovCastSpeed.ToString();
                iCrit_n.Text = cs.glovCrit.ToString();
                iWeight_n.Text = cs.glovWeight.ToString();
                iEDtA_n.Text = cs.glovDamage.ToString();


                FillCharacterState();
            } //Gloves

            else if (cs.sgn == 10)
            {
                cs.shEnchLvl = ItemEnch_cb.SelectedIndex;
                cs.ShoesState();

                iDP_n.Text = cs.shdp.ToString();
                iEvas_n.Text = cs.shev.ToString();
                iHEV_n.Text = cs.shhev.ToString();
                iDR_n.Text = cs.shdr.ToString();
                iHDR_n.Text = cs.shhdr.ToString();
                iKBR_n.Text = cs.shKBRes.ToString();
                iMVS_n.Text = cs.shMvs.ToString();
                iST_n.Text = cs.shMaxST.ToString();
                iWeight_n.Text = cs.shWeight.ToString();



                FillCharacterState();
            } //Shoes

        }

    }
}
