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
    public class CharacterState
    {
        public string Type; // Item type
        public int sgn; //Selected Gear(Item)
        //public bool iEnch; //Item can or can't be enchanted
        
        // Character stats
        public int cdp; // DP
        public int cap; // AP
        public int caap; // AAP
        public int cev;// Evasion
        public int cacc;//Accuracy
        public int cRes1 = 20;// Resists: Stun/Stiffness/Freezing
        public int cRes2 = 20;// Resists: Knockdown/Bound
        public int cRes3 = 20;// Resists: Grapple
        public int cRes4 = 20;// Resists: Knockback/Floating
        public int cDR; // Damage Reduction
        public int cMaxHP; // Max HP
        public int cWeight; // Weight
        public int cMaxMP;// Max MP
        public int cMaxST;// Max stamina
        public int chev; // Hiden evasion
        public int chdr; // hiden damage reduction
        public int cAtkSpeed;
        public int cCastSpeed;
        public int cmvs; // Movement speed 
        public int ccr; // Critical Rate
        public int chap; // Hidden AP
        public int chpr; // HP Recovery
        public int cluck; // Luck
        public int ceda; //Extra damage all
        public int cedh; //Extra damage humans

        //BossSetBonus Check (SetBonus = 1)
        public int b_sb; //Set Bonus
        public int b_asb; //Armour
        public int b_hsb; //Helm
        public int b_bsb; //Boots
        public int b_gsb; //Gloves

        //LemoriaSetBonus Check (SetBonus = 2)
        public int l_sb;
        public int l_asb;
        public int l_hsb;
        public int l_bsb;
        public int l_gsb;

        //AkumSetBonus Check (SetBonus = 3)
        public int a_sb;
        public int a_asb;
        public int a_hsb;
        public int a_bsb;
        public int a_gsb;

        //GrunilSetBonus Check  (SetBonus = 4)
        public int gr_sb;
        public int gr_asb;
        public int gr_hsb;
        public int gr_bsb;
        public int gr_gsb;

        //TaritasSetBonus Check  (SetBonus = 5)
        public int tr_sb;
        public int tr_asb;
        public int tr_hsb;
        public int tr_bsb;
        public int tr_gsb;
        
        //RocabaSetBonus Check  (SetBonus = 6)
        public int rc_sb;
        public int rc_asb;
        public int rc_hsb;
        public int rc_bsb;
        public int rc_gsb;

        //AgerianSetBonus Check  (SetBonus = 7)
        public int ag_sb;
        public int ag_asb;
        public int ag_hsb;
        public int ag_bsb;
        public int ag_gsb;

        //ZerethSetBonus Check  (SetBonus = 8)
        public int zr_sb;
        public int zr_asb;
        public int zr_hsb;
        public int zr_bsb;
        public int zr_gsb;

        //TalisSetBonus Check  (SetBonus = 9)
        public int tl_sb;
        public int tl_asb;
        public int tl_hsb;
        public int tl_bsb;
        public int tl_gsb;

        //Strength "" of Heve SetBonus Check (SetBonus = 10)
        public int sh_sb;
        public int sh_asb;
        public int sh_hsb;
        public int sh_bsb;
        public int sh_gsb;

        //Hercules' Might SetBonus Check  (SB = 11)
        public int hm_sb;
        public int hm_asb;
        public int hm_hsb;
        public int hm_bsb;
        public int hm_gsb;

        //Luck "" of Fortuna SetBonus Check  (SB = 12)
        public int lf_sb;
        public int lf_asb;
        public int lf_hsb;
        public int lf_bsb;
        public int lf_gsb;

        // Belt stats
        public int beltap; //Betl AP
        public int beltev; // Belt Evasion
        public int beltacc;//Belt Accuracy
        public int beltdp; //Belt DP
        public int beltResis; // Belt Resists
        public int beltDR; //Belt DR
        public int beltHP; //Belt MaxHP
        public int beltWeight;//Belt Weight
        public int beltId = 0; // Current belt Id
        public int beltEnchLvl = 0; // Belt's enchant level
        public bool beltEnch; 
        public int beltDefap; //Betl default AP
        public int beltDefev; // Belt default Evasion
        public int beltDefacc;//Belt default Accuracy
        public int beltDefdp; //Belt default DP
        public int beltDefResis; // Belt default Resists
        public int beltDefDR; //Belt default DR
        public int beltDefHP; //Belt default MaxHP
        public int beltDefWeight;//Belt default Weight

        // Neck stats
        public int neckap; //Neck AP
        public int neckev; // Neck Evasion
        public int neckacc;//Neck Accuracy
        public int neckdp; //Neck DP
        public int neckAllRes; //Neck Resists
        public int neckDR; //Neck DR
        public int neckSSF; //Neck Resists: Stun/Stiffness/Freezing
        public int neckKB; //Neck Resists: Knockdown/Bound
        public int neckG; //Neck Resists: Grapple
        public int neckKF; //Neck Resists: Knockback/Floating
        public int neckHP; //Neck Max HP
        public int neckId = 0; //Current neck Id
        public int neckEnchLvl = 0; // Neck's enchant level
        public bool neckEnch;
        public int neckDefap; //Neck AP
        public int neckDefev; // Neck Evasion
        public int neckDefacc;//Neck Accuracy
        public int neckDefdp; //Neck DP
        public int neckDefAllRes; //Neck Resists
        public int neckDefDR; //Neck DR
        public int neckDefSSF; //Neck Resists: Stun/Stiffness/Freezing
        public int neckDefKB; //Neck Resists: Knockdown/Bound
        public int neckDefG; //Neck Resists: Grapple
        public int neckDefKF; //Neck Resists: Knockback/Floating
        public int neckDefHP; //Neck Max HP

        //First Ring stats
        public int ring1ap; //Ring AP
        public int ring1ev; // Ring Evasion
        public int ring1acc;//Ring Accuracy
        public int ring1dp; //Ring DP
        public int ring1DR; //Ring DR
        public int ring1HP; //Ring Max HP
        public int ring1MP; //Ring Max MP
        public int ring1ST; //Ring Max stamina
        public int ring1Id = 0; // Current ring Id
        public int ring1EnchLvl = 0; // Ring's enchant level
        public bool ring1Ench;
        public int ring1Defap; //Ring default AP
        public int ring1Defev; // Ring default Evasion
        public int ring1Defacc;//Ring default Accuracy
        public int ring1Defdp; //Ring default DP
        public int ring1DefDR; //Ring default DR
        public int ring1DefHP; //Ring default Max HP
        public int ring1DefMP; //Ring default Max MP
        public int ring1DefST; //Ring default Max stamina


        //Second Ring stats
        public int ring2ap; //Ring AP
        public int ring2ev; // Ring Evasion
        public int ring2acc;//Ring Accuracy
        public int ring2dp; //Ring DP
        public int ring2DR; //Ring DR
        public int ring2HP; //Ring Max HP
        public int ring2MP; //Ring Max MP
        public int ring2ST; //Ring Max stamina
        public int ring2Id = 0; // Current ring Id
        public int ring2EnchLvl = 0; // Ring's enchant level
        public bool ring2Ench;
        public int ring2Defap; //Ring default AP
        public int ring2Defev; // Ring default Evasion
        public int ring2Defacc;//Ring default Accuracy
        public int ring2Defdp; //Ring default DP
        public int ring2DefDR; //Ring default DR
        public int ring2DefHP; //Ring default Max HP
        public int ring2DefMP; //Ring default Max MP
        public int ring2DefST; //Ring default Max stamina


        //First earring stats
        public int ear1ap; //Earring AP
        public int ear1ev; // Earring Evasion
        public int ear1acc;//Earring Accuracy
        public int ear1dp; //Earring DP
        public int ear1DR; //Earring DR
        public int ear1HP; //Earring Max HP
        public int ear1MP; //Earring Max MP
        public int ear1ST; //Earring Max stamina
        public int ear1Id = 0; // Current earring Id
        public int ear1EnchLvl = 0; // Earring's enchant level
        public bool ear1Ench;
        public int ear1Defap; //Earring default AP
        public int ear1Defev; // Earring default Evasion
        public int ear1Defacc;//Earring default Accuracy
        public int ear1Defdp; //Earring default DP
        public int ear1DefDR; //Earring default DR
        public int ear1DefHP; //Earring default Max HP
        public int ear1DefMP; //Earring default Max MP
        public int ear1DefST; //Earring default Max stamina

        //Second earring stats
        public int ear2ap; //Earring AP
        public int ear2ev; // Earring Evasion
        public int ear2acc;//Earring Accuracy
        public int ear2dp; //Earring DP
        public int ear2DR; //Earring DR
        public int ear2HP; //Earring Max HP
        public int ear2MP; //Earring Max MP
        public int ear2ST; //Earring Max stamina
        public int ear2Id = 0; // Current earring Id
        public int ear2EnchLvl = 0; // Earring's enchant level
        public bool ear2Ench;
        public int ear2Defap; //Earring default AP
        public int ear2Defev; // Earring default Evasion
        public int ear2Defacc;//Earring default Accuracy
        public int ear2Defdp; //Earring default DP
        public int ear2DefDR; //Earring default DR
        public int ear2DefHP; //Earring default Max HP
        public int ear2DefMP; //Earring default Max MP
        public int ear2DefST; //Earring default Max stamina


        //Armor stats
        public int armdp;// Armor DP
        public int armev;// Armor evasion
        public int armhev;// Armor hiden evasion
        public int armdr;// Armor damage reduction
        public int armhdr;// Armor hiden damage reduction
        public int armHP;
        public int armMP;
        public bool armEnch;
        public int armId = 0; // Current armor Id
        public int armEnchLvl = 0; // Armor's enchant level
        public bool armIsBoss;// Armor is boss item or not
        public int armDefdp; // Armor default DP 
        public int armDefev;// Armor default evasion 
        public int armDefhev;// Armor default hiden evasion 
        public int armDefdr;// Armor default damage reduction 
        public int armDefhdr;// Armor default hiden damage reduction 
        public int armDefHP;
        public int armDefMP;
        public int armSSFRes;
        public int armDefSSFRes;
        public int armWeight;
        public int armDefWeight;
        public int armAcc;
        public int armDefAcc;
        public int armSB; //set bonus

        //Helmet stats
        public int heldp;// Helmet DP
        public int helev;// Helmet evasion
        public int helhev;// Helmet hiden evasion
        public int heldr;// Helmet damage reduction
        public int helhdr;// Helmet hiden damage reduction
        public int helHP;
        public int helSSFRes;
        public int helKFRes;
        public int helKBRes;
        public int helGrapleRes;
        public bool helEnch;
        public int helId = 0; // Current Helmet Id
        public int helEnchLvl = 0; // Helmet's enchant level
        public bool helIsBoss;// Helmet is boss item or not
        public int helDefdp; // Helmet default DP 
        public int helDefev;// Helmet default evasion 
        public int helDefhev;// Helmet default hiden evasion 
        public int helDefdr;// Helmet default damage reduction 
        public int helDefhdr;// Helmet default hiden damage reduction 
        public int helDefHP;
        public int helSSFDefRes;
        public int helKFDefRes;
        public int helKBDefRes;
        public int helGrapleDefRes;
        public int helWeight;
        public int helDefWeight;
        public int helST;
        public int helDefST;
        public int helSB; // set bonus

        //Gloves stats
        public int glovdp;// Gloves DP
        public int glovacc;// Gloves acc
        public int glovev;// Gloves evasion
        public int glovhev;// Gloves hiden evasion
        public int glovdr;// Gloves damage reduction
        public int glovhdr;// Gloves hiden damage reduction
        public bool glovEnch;
        public int glovId = 0; // Current Gloves Id
        public int glovEnchLvl = 0; // Gloves's enchant level
        public bool glovIsBoss;// Gloves is boss item or not
        public int glovDefdp; // Gloves default DP
        public int glovDefacc;// Gloves acc
        public int glovDefev;// Gloves default evasion 
        public int glovDefhev;// Gloves default hiden evasion 
        public int glovDefdr;// Gloves default damage reduction 
        public int glovDefhdr;// Gloves default hiden damage reduction 
        public int glovSB; // set bonus
        public int glovAtkSpeed;
        public int glovDefAtkSpeed;
        public int glovCastSpeed;
        public int glovDefCastSpeed;
        public int glovCrit;
        public int glovDefCrit;
        public int glovWeight;
        public int glovDefWeight;
        public int glovGrapleRes;
        public int glovDefGrapleRes;

        //Shoes stats
        public int shdp;// Shoes DP
        public int shev;// Shoes evasion
        public int shhev;// Shoes hiden evasion
        public int shdr;// Shoes damage reduction
        public int shhdr;// Shoes hiden damage reduction
        public bool shEnch;
        public int shId = 0; // Current Shoes Id
        public int shEnchLvl = 0; // Shoes's enchant level
        public bool shIsBoss;// Shoes is boss item or not
        public int shDefdp; // Shoes default DP
        public int shDefev;// Shoes default evasion 
        public int shDefhev;// Shoes default hiden evasion 
        public int shDefdr;// Shoes default damage reduction 
        public int shDefhdr;// Shoes default hiden damage reduction
        public int shSB; //Set bonus

        public int shMvs;
        public int shDefMvs;

        public int shKBRes;
        public int shDefKBRes;

        public int shMaxST;
        public int shDefMaxST;

        public int shWeight;
        public int shDefWeight;


        readonly SqlCommand cmd = Base_Connect.Connection.CreateCommand();
        

        public void BeltState()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Belts where Id='" + beltId.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (beltEnch == true & beltEnchLvl >= 1)
            {
                cap -= beltap;
                caap -= beltap;
                cdp -= beltdp;
                cev -= beltev;
                cacc -= beltacc;
                cRes1 -= beltResis;
                cRes2 -= beltResis;
                cRes3 -= beltResis;
                cRes4 -= beltResis;
                cDR -= beltDR;
                cMaxHP -= beltHP;
                cWeight -= beltWeight;



                beltap = beltDefap + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["APsh"]);
                beltdp = beltDefdp + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["DPsh"]);
                beltacc = beltDefacc + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Accsh"]);
                beltev = beltDefev + beltEnchLvl* Convert.ToInt32(dt.Rows[0]["Evsh"]);
                beltResis = beltDefResis + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Ressh"]);
                beltDR = beltDefDR + beltEnchLvl* Convert.ToInt32(dt.Rows[0]["DRsh"]);
                beltHP = beltDefHP + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["HPsh"]);
                beltWeight = beltDefWeight + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Wgsh"]);

                cap += beltap ;
                caap += beltap ;
                cdp += beltdp;
                cev += beltev;
                cacc += beltacc;
                cRes1 += beltResis;
                cRes2 += beltResis;
                cRes3 += beltResis;
                cRes4 += beltResis ;
                cDR += beltDR;
                cMaxHP += beltHP;
                cWeight += beltWeight;
            }

            else
            {
                cap -= beltap;
                caap -= beltap;
                cdp -= beltdp;
                cev -= beltev;
                cacc -= beltacc;
                cRes1 -= beltResis;
                cRes2 -= beltResis;
                cRes3 -= beltResis;
                cRes4 -= beltResis;
                cDR -= beltDR;
                cMaxHP -= beltHP;
                cWeight -= beltWeight;


                beltap = beltDefap;
                beltdp = beltDefdp;
                beltacc = beltDefacc;
                beltev = beltDefev;
                beltResis = beltDefResis;
                beltDR = beltDefDR;
                beltHP = beltDefHP;
                beltWeight = beltDefWeight;

                cap += beltap;
                caap += beltap;
                cdp += beltdp;
                cev += beltev;
                cacc += beltacc;
                cRes1 += beltResis;
                cRes2 += beltResis;
                cRes3 += beltResis;
                cRes4 += beltResis;
                cDR += beltDR;
                cMaxHP += beltHP;
                cWeight += beltWeight;
            }
        }

        public void NeckState()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Neck where Id='" + neckId.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (neckEnch == true & neckEnchLvl >= 1)
            {
                cap -= neckap;
                caap -= neckap;
                cdp -= neckdp;
                cev -= neckev ;
                cacc -= neckacc;
                cRes1 -= neckSSF ;
                cRes2 -= neckKB ;
                cRes3 -= neckG ;
                cRes4 -= neckKF ;
                cDR -= neckDR ;
                cMaxHP -= neckHP;
                cRes1 -= neckAllRes ;
                cRes2 -= neckAllRes ;
                cRes3 -= neckAllRes ;
                cRes4 -= neckAllRes ;


                neckap = neckDefap + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["APSh"]);
                neckdp = neckDefdp + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["DPSh"]);
                neckacc = neckDefacc + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["AccuracySh"]);
                neckev = neckDefev + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["EvSh"]);
                neckAllRes = neckDefAllRes + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["AllResSh"]);
                neckDR = neckDefDR + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["DRSh"]);
                neckSSF = neckDefSSF + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["SSFSh"]);
                neckKB = neckDefKB + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["KBSh"]);
                neckG = neckDefG + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["GrapSh"]);
                neckKF = neckDefKF + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["KFSh"]);
                neckHP = neckDefHP;

                cap += neckap;
                caap += neckap;
                cdp += neckdp;
                cev += neckev;
                cacc += neckacc;
                cRes1 += neckSSF;
                cRes2 += neckKB;
                cRes3 += neckG;
                cRes4 += neckKF;
                cDR += neckDR;
                cRes1 += neckAllRes;
                cRes2 += neckAllRes;
                cRes3 += neckAllRes;
                cRes4 += neckAllRes;
                cMaxHP += neckHP;
            }

            else
            {
                cap -= neckap;
                caap -= neckap;
                cdp -= neckdp;
                cev -= neckev;
                cacc -= neckacc;
                cRes1 -= neckSSF;
                cRes2 -= neckKB;
                cRes3 -= neckG;
                cRes4 -= neckKF;
                cDR -= neckDR;
                cRes1 -= neckAllRes;
                cRes2 -= neckAllRes;
                cRes3 -= neckAllRes;
                cRes4 -= neckAllRes;
                cMaxHP -= neckHP;

                neckap = neckDefap;
                neckdp = neckDefdp;
                neckacc = neckDefacc;
                neckev = neckDefev;
                neckAllRes = neckDefAllRes;
                neckDR = neckDefDR;
                neckSSF = neckDefSSF;
                neckKB = neckDefKB;
                neckG = neckDefG;
                neckKF = neckDefKF;
                neckHP = neckDefHP;

                cap += neckap;
                caap += neckap;
                cdp += neckdp;
                cev += neckev;
                cacc += neckacc;
                cRes1 += neckSSF;
                cRes2 += neckKB;
                cRes3 += neckG;
                cRes4 += neckKF;
                cDR += neckDR;
                cRes1 += neckAllRes;
                cRes2 += neckAllRes;
                cRes3 += neckAllRes;
                cRes4 += neckAllRes;
                cMaxHP += neckHP;
            }
        }

        public void Ring1State()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Rings where Id='" + ring1Id.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (ring1Ench == true & ring1EnchLvl >= 1)
            {
                cap -= ring1ap;
                caap -= ring1ap;
                cdp -= ring1dp;
                cev -= ring1ev;
                cacc -= ring1acc;
                cDR -= ring1DR;
                cMaxHP -= ring1HP;
                cMaxMP -= ring1MP;
                cMaxST -= ring1ST;

                    ring1ap = ring1Defap + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["APsh"]);
                    ring1dp = ring1Defdp + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["DPsh"]);
                    ring1acc = ring1Defacc + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["Accsh"]);
                    ring1ev = ring1Defev + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["Evsh"]);
                    ring1DR = ring1DefDR + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["DRsh"]);
                    ring1HP = ring1DefHP + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["HPsh"]);
                    ring1MP = ring1DefHP + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["MPsh"]);
                    ring1ST = ring1DefHP + ring1EnchLvl * Convert.ToInt32(dt.Rows[0]["STsh"]);


                cap += ring1ap;
                caap += ring1ap;
                cdp += ring1dp;
                cev += ring1ev;
                cacc += ring1acc;
                cDR += ring1DR;
                cMaxHP += ring1HP;
                cMaxMP += ring1MP;
                cMaxST += ring1ST;
            }

            else
            {
                cap -= ring1ap;
                caap -= ring1ap;
                cdp -= ring1dp;
                cev -= ring1ev;
                cacc -= ring1acc;
                cDR -= ring1DR;
                cMaxHP -= ring1HP;
                cMaxMP -= ring1MP;
                cMaxST -= ring1ST;


                ring1ap = ring1Defap;
                ring1dp = ring1Defdp;
                ring1acc = ring1Defacc;
                ring1ev = ring1Defev;
                ring1DR = ring1DefDR;
                ring1HP = ring1DefHP;
                ring1MP = ring1DefHP;
                ring1ST = ring1DefHP;

                cap += ring1ap;
                caap += ring1ap;
                cdp += ring1dp;
                cev += ring1ev;
                cacc += ring1acc;
                cDR += ring1DR;
                cMaxHP += ring1HP;
                cMaxMP += ring1MP;
                cMaxST += ring1ST;
            }
        }

        public void Ring2State()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Rings where Id='" + ring2Id.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (ring2Ench == true & ring2EnchLvl >= 1)
            {
                cap -= ring2ap;
                caap -= ring2ap;
                cdp -= ring2dp;
                cev -= ring2ev;
                cacc -= ring2acc;
                cDR -= ring2DR;
                cMaxHP -= ring2HP;
                cMaxMP -= ring2MP;
                cMaxST -= ring2ST;

                ring2ap = ring2Defap + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["APsh"]);
                ring2dp = ring2Defdp + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["DPsh"]);
                ring2acc = ring2Defacc + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["Accsh"]);
                ring2ev = ring2Defev + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["Evsh"]);
                ring2DR = ring2DefDR + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["DRsh"]);
                ring2HP = ring2DefHP + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["HPsh"]);
                ring2MP = ring2DefHP + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["MPsh"]);
                ring2ST = ring2DefHP + ring2EnchLvl * Convert.ToInt32(dt.Rows[0]["STsh"]);


                cap += ring2ap;
                caap += ring2ap;
                cdp += ring2dp;
                cev += ring2ev;
                cacc += ring2acc;
                cDR += ring2DR;
                cMaxHP += ring2HP;
                cMaxMP += ring2MP;
                cMaxST += ring2ST;
            }

            else
            {
                cap -= ring2ap;
                caap -= ring2ap;
                cdp -= ring2dp;
                cev -= ring2ev;
                cacc -= ring2acc;
                cDR -= ring2DR;
                cMaxHP -= ring2HP;
                cMaxMP -= ring2MP;
                cMaxST -= ring2ST;


                ring2ap = ring2Defap;
                ring2dp = ring2Defdp;
                ring2acc = ring2Defacc;
                ring2ev = ring2Defev;
                ring2DR = ring2DefDR;
                ring2HP = ring2DefHP;
                ring2MP = ring2DefHP;
                ring2ST = ring2DefHP;

                cap += ring2ap;
                caap += ring2ap;
                cdp += ring2dp;
                cev += ring2ev;
                cacc += ring2acc;
                cDR += ring2DR;
                cMaxHP += ring2HP;
                cMaxMP += ring2MP;
                cMaxST += ring2ST;
            }
        }

        public void Earring1State()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Earrings where Id='" + ear1Id.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (ear1Ench == true & ear1EnchLvl >= 1)
            {
                cap -= ear1ap;
                caap -= ear1ap;
                cdp -= ear1dp;
                cev -= ear1ev;
                cacc -= ear1acc;
                cDR -= ear1DR;
                cMaxHP -= ear1HP;
                cMaxMP -= ear1MP;
                cMaxST -= ear1ST;

                ear1ap = ear1Defap + ear1EnchLvl * Convert.ToInt32(dt.Rows[0]["APsh"]);
                ear1dp = ear1Defdp + ear1EnchLvl * Convert.ToInt32(dt.Rows[0]["DPsh"]);
                ear1acc = ear1Defacc + ear1EnchLvl * Convert.ToInt32(dt.Rows[0]["Accsh"]);
                ear1ev = ear1Defev + ear1EnchLvl * Convert.ToInt32(dt.Rows[0]["Evsh"]);
                ear1DR = ear1DefDR + ear1EnchLvl * Convert.ToInt32(dt.Rows[0]["DRsh"]);
                ear1HP = ear1DefHP + ear1EnchLvl * Convert.ToInt32(dt.Rows[0]["HPsh"]);
                ear1MP = ear1DefMP + ear1EnchLvl * Convert.ToInt32(dt.Rows[0]["MPsh"]);
                ear1ST = ear1DefST + ear1EnchLvl * Convert.ToInt32(dt.Rows[0]["STsh"]);


                cap += ear1ap;
                caap += ear1ap;
                cdp += ear1dp;
                cev += ear1ev;
                cacc += ear1acc;
                cDR += ear1DR;
                cMaxHP += ear1HP;
                cMaxMP += ear1MP;
                cMaxST += ear1ST;
            }

            else
            {
                cap -= ear1ap;
                caap -= ear1ap;
                cdp -= ear1dp;
                cev -= ear1ev;
                cacc -= ear1acc;
                cDR -= ear1DR;
                cMaxHP -= ear1HP;
                cMaxMP -= ear1MP;
                cMaxST -= ear1ST;


                ear1ap = ear1Defap;
                ear1dp = ear1Defdp;
                ear1acc = ear1Defacc;
                ear1ev = ear1Defev;
                ear1DR = ear1DefDR;
                ear1HP = ear1DefHP;
                ear1MP = ear1DefMP;
                ear1ST = ear1DefST;

                cap += ear1ap;
                caap += ear1ap;
                cdp += ear1dp;
                cev += ear1ev;
                cacc += ear1acc;
                cDR += ear1DR;
                cMaxHP += ear1HP;
                cMaxMP += ear1MP;
                cMaxST += ear1ST;
            }
        }

        public void Earring2State()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Earrings where Id='" + ear2Id.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (ear2Ench == true & ear2EnchLvl >= 1)
            {
                cap -= ear2ap;
                caap -= ear2ap;
                cdp -= ear2dp;
                cev -= ear2ev;
                cacc -= ear2acc;
                cDR -= ear2DR;
                cMaxHP -= ear2HP;
                cMaxMP -= ear2MP;
                cMaxST -= ear2ST;

                ear2ap = ear2Defap + ear2EnchLvl * Convert.ToInt32(dt.Rows[0]["APsh"]);
                ear2dp = ear2Defdp + ear2EnchLvl * Convert.ToInt32(dt.Rows[0]["DPsh"]);
                ear2acc = ear2Defacc + ear2EnchLvl * Convert.ToInt32(dt.Rows[0]["Accsh"]);
                ear2ev = ear2Defev + ear2EnchLvl * Convert.ToInt32(dt.Rows[0]["Evsh"]);
                ear2DR = ear2DefDR + ear2EnchLvl * Convert.ToInt32(dt.Rows[0]["DRsh"]);
                ear2HP = ear2DefHP + ear2EnchLvl * Convert.ToInt32(dt.Rows[0]["HPsh"]);
                ear2MP = ear2DefHP + ear2EnchLvl * Convert.ToInt32(dt.Rows[0]["MPsh"]);
                ear2ST = ear2DefHP + ear2EnchLvl * Convert.ToInt32(dt.Rows[0]["STsh"]);


                cap += ear2ap;
                caap += ear2ap;
                cdp += ear2dp;
                cev += ear2ev;
                cacc += ear2acc;
                cDR += ear2DR;
                cMaxHP += ear2HP;
                cMaxMP += ear2MP;
                cMaxST += ear2ST;
            }

            else
            {
                cap -= ear2ap;
                caap -= ear2ap;
                cdp -= ear2dp;
                cev -= ear2ev;
                cacc -= ear2acc;
                cDR -= ear2DR;
                cMaxHP -= ear2HP;
                cMaxMP -= ear2MP;
                cMaxST -= ear2ST;


                ear2ap = ear2Defap;
                ear2dp = ear2Defdp;
                ear2acc = ear2Defacc;
                ear2ev = ear2Defev;
                ear2DR = ear2DefDR;
                ear2HP = ear2DefHP;
                ear2MP = ear2DefHP;
                ear2ST = ear2DefHP;

                cap += ear2ap;
                caap += ear2ap;
                cdp += ear2dp;
                cev += ear2ev;
                cacc += ear2acc;
                cDR += ear2DR;
                cMaxHP += ear2HP;
                cMaxMP += ear2MP;
                cMaxST += ear2ST;
            }
        }

        public void ArmorState()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Armors where Id='" + armId.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (armEnch == true & armIsBoss == true | armId ==23)
            {
                if(armEnchLvl >= 1 & armEnchLvl <= 5)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;

                    armdp = armDefdp + armEnchLvl * 3;
                    armev = armDefev + armEnchLvl * 1;
                    armhev = armDefhev + armEnchLvl * 3;
                    armdr = armDefdr + armEnchLvl * 2;
                    armhdr = armDefhdr + armEnchLvl * 0;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                }

                if (armEnchLvl >= 6 & armEnchLvl <= 15)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;

                    armdp = armDefdp + 15 + (armEnchLvl - 5) * 4;
                    armev = armDefev + 5 + (armEnchLvl - 5) * 2;
                    armhev = armDefhev + 15 + (armEnchLvl - 5) * 6;
                    armdr = armDefdr + armEnchLvl * 2;
                    armhdr = armDefhdr;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                }

                if (armEnchLvl >= 16 & armEnchLvl <= 17)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;

                    armdp = armDefdp + 55 +(armEnchLvl-15) * 5;
                    armev = armDefev + 25+ (armEnchLvl - 15) * 2;
                    armhev = armDefhev + 75+ (armEnchLvl - 15) * 6;
                    armdr = armDefdr + 30 +(armEnchLvl - 15) * 3;
                    armhdr = armDefhdr + (armEnchLvl - 15) * 1;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                }

                if (armEnchLvl == 18)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;

                    armdp = armDefdp + 73;
                    armev = armDefev + 31;
                    armhev = armDefhev + 93;
                    armdr = armDefdr + 42;
                    armhdr = armDefhdr + 4;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                }

                if (armEnchLvl == 19)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;

                    armdp = armDefdp + 78;
                    armev = armDefev + 33;
                    armhev = armDefhev + 99;
                    armdr = armDefdr + 45;
                    armhdr = armDefhdr + 8;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                }

                if (armEnchLvl == 20)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;

                    armdp = armDefdp + 83;
                    armev = armDefev + 35;
                    armhev = armDefhev + 105;
                    armdr = armDefdr + 48;
                    armhdr = armDefhdr + 14;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                }
            }

            else if(armEnch == true & armIsBoss == false)
            {
                if (armEnchLvl == 1)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;
                    cWeight -= armWeight;


                    //DP
                    if (armId == 10 | armId == 19) armdp = armDefdp + 3;
                    else armdp = armDefdp +  4;
                    //EV
                    armev = armDefev + 1;
                    //HEV
                    if (armId == 9 | armId == 13 | armId == 16 | armId == 24 | armId == 34 | armId == 35 | armId == 15 | armId == 33) armhev = armDefhev + 7;
                    else armhev = armDefhev + 3;
                    //DR
                    if (armId == 10 | armId == 19) armdr = armDefdr + armEnchLvl * 2;
                    else armdr = armDefdr + 3;
                    //HDR
                    armhdr = armDefhdr;

                    armWeight = armDefWeight;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                    cWeight += armWeight;

                }

                if (armEnchLvl >= 2 & armEnchLvl <= 3)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;
                    cWeight -= armWeight;


                    //DP
                    if (armId == 10 | armId == 19) armdp = armDefdp + armEnchLvl * 3;
                    else armdp = armDefdp + 4 + (armEnchLvl-1) * 3;
                    //EV
                    armev = armDefev +armEnchLvl * 1;
                    //HEV
                    if(armId == 9 | armId == 13 | armId == 16 | armId == 24 | armId == 34 | armId == 35 | armId == 15 | armId == 33)
                    {
                        if(armEnchLvl == 2) armhev = armDefhev + 9;
                        else if (armEnchLvl == 3) armhev = armDefhev + 12;
                    } //Agerian, Taritas
                    else armhev = armDefhev + armEnchLvl * 3;
                    //DR
                    if (armId == 10 | armId == 19) armdr = armDefdr + armEnchLvl * 2;
                    else armdr = armDefdr +3 +(armEnchLvl-1) * 2;
                    //HDR
                    armhdr = armDefhdr;
                    armWeight = armDefWeight;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                    cWeight += armWeight;

                }

                if (armEnchLvl >= 4 & armEnchLvl <= 5)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;
                    cWeight -= armWeight;

                    //DP
                    if (armId == 10 | armId == 19 ) armdp = armDefdp + armEnchLvl * 3;
                    else armdp = armDefdp + 10 + (armEnchLvl - 3) * 2;
                    //EV
                    armev = armDefev + armEnchLvl * 1;
                    //HEV
                    if(armId == 9 | armId == 13 | armId == 16 | armId == 24 | armId == 34 | armId == 35 | armId == 15 | armId == 33)
                    {
                        if(armEnchLvl == 4) armhev = armDefhev + 14;
                        else if (armEnchLvl == 5) armhev = armDefhev + 17;
                    } //Agerian, Taritas
                    else armhev = armDefhev + armEnchLvl * 3;
                    //DR
                    if (armId == 10 | armId == 19) armdr = armDefdr + armEnchLvl * 2;
                    else armdr = armDefdr + 7 + (armEnchLvl - 3) * 1;
                    //HDR
                    armhdr = armDefhdr;
                    armWeight = armDefWeight;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                    cWeight += armWeight;

                }

                if (armEnchLvl >= 6 & armEnchLvl <= 15)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;
                    cWeight -= armWeight;

                    //DP
                    if (armId == 10 | armId == 19) armdp = armDefdp + 15 + (armEnchLvl - 5) * 4;
                    else armdp = armDefdp + 14 + (armEnchLvl - 5) * 3;

                    //EV
                    if (armId == 10 | armId == 19) armev = armDefev + 5 + (armEnchLvl - 5) * 2;
                    else armev = armDefev + armEnchLvl * 1;

                    //HEV
                    if(armId == 10 | armId == 19) 
                    {
                        if (armEnchLvl <= 10) armhev = armDefhev + 15 + (armEnchLvl - 5) * 6;
                        else if (armEnchLvl == 11) armhev = armDefhev + 50;
                        else if (armEnchLvl >= 12) armhev = armDefhev + 50 + (armEnchLvl - 11) * 6;
                    } //Akum
                    else if(armId == 9| armId == 13 | armId == 16 | armId == 24 | armId == 34 | armId == 35 | armId == 15 | armId == 33)
                    {
                        if(armEnchLvl ==6) armhev = armDefhev + 21;
                        else if (armEnchLvl == 7) armhev = armDefhev + 24;
                        else if (armEnchLvl == 8) armhev = armDefhev + 28;
                        else if (armEnchLvl == 9) armhev = armDefhev + 31;
                        else if (armEnchLvl >= 10) armhev = armDefhev + 31 + (armEnchLvl - 9) * 3;
                    } //Agerian, Taritas
                    else armhev = armDefhev + armEnchLvl * 3;

                    //DR
                    if (armId == 10 | armId == 19) armdr = armDefdr + armEnchLvl * 2;
                    else armdr = armDefdr + 9 + (armEnchLvl - 5) * 2;

                    //HDR
                    if (armId == 10 & armEnchLvl >= 11 | armId == 19 & armEnchLvl >= 11) armhdr = armDefhdr + (armEnchLvl-10) * 1;
                    else armhdr = armDefhdr;
                    armWeight = armDefWeight;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                    cWeight += armWeight;

                }

                if (armEnchLvl == 16)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;
                    cWeight -= armWeight;

                    //DR
                    if (armId == 10 | armId == 19) armdp = armDefdp + 15 + (armEnchLvl - 5) * 4;
                    else armdp = armDefdp + 49;
                    //Ev
                    if (armId == 10 | armId == 19) armev = armDefev + 5 + (armEnchLvl - 5) * 2;
                    else armev = armDefev + 17;

                    //Hev
                    if (armId == 10 | armId == 19) armhev = armDefhev + 79; //Akum
                    else if (armId == 9 | armId == 13 | armId == 16 | armId == 24 | armId == 34 | armId == 35 | armId == 15 | armId == 33) armhev = armDefhev + 55; //Agerian, Taritas, Zereth
                    else armhev = armDefhev + 55;
                    //DR
                    if (armId == 10 | armId == 19) armdr = armDefdr + armEnchLvl * 2;
                    else armdr = armDefdr + 32;
                    //HDR
                    if (armId == 10 | armId == 19) armhdr = armDefhdr + (armEnchLvl - 10) * 1;
                    else armhdr = armDefhdr + 1;
                    armWeight = armDefWeight;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                    cWeight += armWeight;

                }

                if (armEnchLvl == 17)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;
                    cWeight -= armWeight;

                    //DP
                    if (armId == 10 | armId == 19) armdp = armDefdp + 15 + (armEnchLvl - 5) * 4;
                    else armdp = armDefdp + 54;
                    //EV
                    if (armId == 10 | armId == 19) armev = armDefev + 5 + (armEnchLvl - 5) * 2;
                    else armev = armDefev + 19;
                    //HEV
                    if (armId == 10 | armId == 19) armhev = armDefhev + 79 + (armEnchLvl - 16) * 6;
                    else if (armId == 9 | armId == 13 | armId == 16 | armId == 24 | armId == 34 | armId == 35 | armId == 15 | armId == 33) armhev = armDefhev + 61;
                    else armhev = armDefhev + 61;
                    //DR
                    if (armId == 10 | armId == 19) armdr = armDefdr + armEnchLvl * 2;
                    else armdr = armDefdr + 35;
                    //HDR
                    if (armId == 10 | armId == 19) armhdr = armDefhdr + (armEnchLvl - 10) * 1;
                    else armhdr = armDefhdr + 2;
                    armWeight = armDefWeight;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                    cWeight += armWeight;

                }

                if (armEnchLvl == 18)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;
                    cWeight -= armWeight;

                    //DP
                    if (armId == 10 | armId == 19) armdp = armDefdp + 70;
                    else armdp = armDefdp + 62;
                    //EV
                    if (armId == 10 | armId == 19) armev = armDefev + 5 + (armEnchLvl - 5) * 2;
                    else armev = armDefev + 21;
                    //HEV
                    if (armId == 10 | armId == 19) armhev = armDefhev + 79 + (armEnchLvl - 16) * 6;
                    else if (armId == 9 | armId == 13 | armId == 16 | armId == 24 | armId == 34 | armId == 35 | armId == 15 | armId == 33) armhev = armDefhev + 67;
                    else armhev = armDefhev + 67;
                    //DR
                    if (armId == 10 | armId == 19) armdr = armDefdr + (armEnchLvl-1) * 2 + 5;
                    else  if (armId == 9 | armId == 24) armdr = armDefdr + 41;
                    else armdr = armDefdr + 41;
                    //HDR
                    if (armId == 10 | armId == 19) armhdr = armDefhdr + 9;
                    else armhdr = armDefhdr + 3;
                    armWeight = armDefWeight;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                    cWeight += armWeight;

                }

                if (armEnchLvl >= 19 & armEnchLvl <= 20)
                {

                    cdp -= armdp;
                    cev -= armev;
                    chev -= armhev;
                    cDR -= armdr;
                    chdr -= armhdr;
                    cMaxHP -= armHP;
                    cMaxMP -= armMP;
                    cWeight -= armWeight;

                    //DP
                    if (armId == 10 | armId == 19) armdp = armDefdp + 70 + (armEnchLvl-18) * 4;
                    else armdp = armDefdp + 62 + (armEnchLvl-18)  * 5;
                    //EV
                    if (armId == 10 | armId == 19) armev = armDefev + 5 + (armEnchLvl - 5) * 2;
                    else armev = armDefev + 21 + (armEnchLvl - 18) * 2;
                    //HEV
                    if (armId == 10 | armId == 19) armhev = armDefhev + 79 + (armEnchLvl - 16) * 6;
                    else if (armId == 9 | armId == 13 | armId == 16 | armId == 24 | armId == 34 | armId == 35 | armId == 15 | armId == 33) armhev = armDefhev + 67 + (armEnchLvl -18) * 6;
                    else armhev = armDefhev + 67+ (armEnchLvl - 18) * 6;
                    //DR
                    if (armId == 10 | armId == 19) armdr = armDefdr + 39 + (armEnchLvl-18) * 2;
                    else if (armId == 9 | armId == 24) armdr = armDefdr + 41 + (armEnchLvl - 18) * 3;
                    else armdr = armDefdr + 41+ (armEnchLvl - 18) * 3;
                    //HDR
                    if (armId == 10 | armId == 19) armhdr = armDefhdr + 9+(armEnchLvl - 18) * 2;
                    else armhdr = armDefhdr + 3+ (armEnchLvl - 18) * 1;
                    armWeight = armDefWeight;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                    cWeight += armWeight;

                }
            }

            if (armEnch == false | armEnch == true & armEnchLvl == 0)
            {

                cdp -= armdp;
                cev -= armev;
                chev -= armhev;
                cDR -= armdr;
                chdr -= armhdr;
                cMaxHP -= armHP;
                cMaxMP -= armMP;
                cRes1 -= armSSFRes;
                cWeight -= armWeight;
                cacc -= armAcc;


                armdp = armDefdp;
                armev = armDefev;
                armhev = armDefhev;
                armdr = armDefdr;
                armhdr = armDefhdr;
                armHP = armDefHP;
                armMP = armDefHP;
                armWeight = armDefWeight;
                armAcc = armDefAcc;



                cdp += armdp;
                cev += armev;
                chev += armhev;
                cDR += armdr;
                chdr += armhdr;
                cMaxHP += armHP;
                cMaxMP += armMP;
                cRes1 += armSSFRes;
                cWeight += armWeight;
                cacc += armAcc;

            }
        }

        public void HelmetState()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Helmets where Id='" + helId.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (helEnch == true & helIsBoss == true | armId == 21)
            {
                if (helEnchLvl >= 1 & helEnchLvl <= 15)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    heldp = helDefdp + helEnchLvl * 3;
                    helev = helDefev + helEnchLvl * 1;
                    helhev = helDefhev + helEnchLvl * 2;
                    heldr = helDefdr + helEnchLvl * 2;
                    helhdr = helDefhdr + helEnchLvl * 0;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl == 16)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    heldp = helDefdp + 50;
                    helev = helDefev + 17;
                    helhev = helDefhev + 38;
                    heldr = helDefdr + 33;
                    helhdr = helDefhdr + 1;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl == 17)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    heldp = helDefdp + 55;
                    helev = helDefev + 19;
                    helhev = helDefhev + 42;
                    heldr = helDefdr + 36;
                    if (helId == 0) helhdr = helDefhdr + 2;
                    else helhdr = helDefhdr + 1;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl == 18)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    heldp = helDefdp + 63;
                    helev = helDefev + 21;
                    helhev = helDefhev + 46;
                    heldr = helDefdr + 42;
                    if (helId == 0) helhdr = helDefhdr + 4;
                    else helhdr = helDefhdr + 6;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl == 19)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    heldp = helDefdp + 68;
                    helev = helDefev + 23;
                    helhev = helDefhev + 50;
                    heldr = helDefdr + 45;
                    if (helId == 0) helhdr = helDefhdr + 8;
                    else helhdr = helDefhdr + 11;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;

                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl == 20)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    heldp = helDefdp + 73;
                    helev = helDefev + 25;
                    helhev = helDefhev + 54;
                    heldr = helDefdr + 48;
                    if (helId == 0) helhdr = helDefhdr + 14;
                    else helhdr = helDefhdr + 17;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

            }

            else if (helEnch == true & helIsBoss == false)
            {
                if (helEnchLvl >= 1 & helEnchLvl <=2)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    if (helId == 9 | helId == 19)
                    {
                        if (helEnchLvl == 1) heldp = helDefdp + 2;
                        else heldp = helDefdp + 5;
                    }
                    else heldp = helDefdp + helEnchLvl * 3;

                    helev = helDefev + helEnchLvl * 1;

                    if(helId == 8 | helId == 13 | helId == 14  | helId == 15 | helId == 24 | helId == 31 | helId == 32 | helId == 33)
                    {
                        if (helEnchLvl == 1) helhev = helDefhev + 7;
                        else helhev = helDefhev + 9;
                    }
                    else if(helId == 9 | helId == 19) helhev = helDefev + helEnchLvl * 2;
                    else helhev = helDefhev + helEnchLvl * 3;

                    if (helId == 9 | helId == 19)
                    {
                        if (helEnchLvl == 1) heldr = helDefdr + 1;
                        else heldr = helDefdr + 3;
                    }
                    else heldr = helDefdr + helEnchLvl * 2;

                    helhdr = helDefhdr;

                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl >= 3 & helEnchLvl <= 5)
                {
                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    if (helId == 9 | helId == 19) heldp = helDefdp + 2 + (helEnchLvl-2) *3;
                    else heldp = helDefdp + 6 + (helEnchLvl - 2) * 3;
                    helev = helDefev + helEnchLvl * 1;

                    if (helId == 8 | helId == 13 | helId == 14 | helId == 15 | helId == 24 | helId == 31 | helId == 32 | helId == 33)
                    {
                        if (helEnchLvl == 3) helhev = helDefhev + 10;
                        else if (helEnchLvl == 4) helhev = helDefhev + 12;
                        else helhev = helDefhev + 15;
                    }
                    else if (helId == 9 | helId == 19) helhev = helDefev + helEnchLvl * 2;
                    else helhev = helDefhev + helEnchLvl * 3;

                    if (helId == 9 | helId == 19) heldr = helDefdr + 1 + (helEnchLvl-1) * 2 ;
                    else heldr = helDefdr + 4 + (helEnchLvl - 2) * 2;

                    helhdr = helDefhdr;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;

                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl >= 6 & helEnchLvl <= 15)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    if (helId == 9 | helId == 19) heldp = helDefdp + 14 + (helEnchLvl - 5) * 3;
                    else heldp = helDefdp + 12 + (helEnchLvl - 5) * 3;

                    helev = helDefev + helEnchLvl * 1;

                    if (helId == 8 | helId == 13 | helId == 14 | helId == 15 | helId == 24 | helId == 31 | helId == 32 | helId == 33)
                    {
                        if (helEnchLvl == 6) helhev = helDefhev + 21;
                        else if (helEnchLvl == 7) helhev = helDefhev + 24;
                        else if (helEnchLvl == 8) helhev = helDefhev + 28;
                        else if (helEnchLvl == 9) helhev = helDefhev + 31;
                        else if (helEnchLvl >= 10) helhev = helDefhev + 31 + (helEnchLvl - 9) * 3;
                    }
                    else if (helId == 9 | helId == 19) helhev = helDefev + helEnchLvl * 2;
                    else helhev = helDefhev + helEnchLvl * 3;

                    if (helId == 9 | helId == 19) heldr = helDefdr + 1 + (helEnchLvl - 1) * 2;
                    else heldr = helDefdr + 7 + (helEnchLvl - 5) * 2;

                    if (helId == 9 | helId == 19)
                    {
                        if (helEnchLvl >= 11) helhdr = helDefhdr + (helEnchLvl - 10) * 2;
                        else helhdr = helDefhdr;
                    }
                    else helhdr = helDefhdr;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;

                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl == 16)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    if (helId == 9 | helId == 19) heldp = helDefdp + 48;
                    else heldp = helDefdp + 47 ;

                    helev = helDefev + 17;

                    if (helId == 8 | helId == 13 | helId == 14 | helId == 15 | helId == 24 | helId == 31 | helId == 32 | helId == 33) helhev = helDefhev + 55;
                    else if (helId == 9 | helId == 19) helhev = helDefev + 36;
                    else helhev = helDefhev + 55;

                    if (helId == 9 | helId == 19) heldr = helDefdr + 31;
                    else heldr = helDefdr + 30;

                    if (helId == 9 | helId == 19) helhdr = helDefhdr + (helEnchLvl - 10) * 2;
                    else helhdr = helDefhdr + 1;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;

                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl == 17)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    if (helId == 9 | helId == 19) heldp = helDefdp + 52;
                    else heldp = helDefdp + 52;
                    helev = helDefev + 19;
                    if (helId == 8 | helId == 13 | helId == 14 | helId == 15 | helId == 24 | helId == 31 | helId == 32 | helId == 33) helhev = helDefhev + 61;
                    else if (helId == 9 | helId == 19) helhev = helDefev + 40;
                    else helhev = helDefhev + 61;
                    if (helId == 9 | helId == 19) heldr = helDefdr + 33;
                    else heldr = helDefdr + 33;
                    if (helId == 9 | helId == 19) helhdr = helDefhdr + (helEnchLvl - 10) * 2;
                    else helhdr = helDefhdr + 2;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;

                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl == 18)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    if (helId == 9 | helId == 19) heldp = helDefdp + 59;
                    else heldp = helDefdp + 60;
                    helev = helDefev + 21;
                    if (helId == 8 | helId == 13 | helId == 14 | helId == 15 | helId == 24 | helId == 31 | helId == 32 | helId == 33) helhev = helDefhev + 67;
                    else if (helId == 9 | helId == 19) helhev = helDefev + 44;
                    else helhev = helDefhev + 67;
                    if (helId == 9 | helId == 19) heldr = helDefdr + 38;
                    else heldr = helDefdr + 39;
                    if (helId == 9 | helId == 19) helhdr = helDefhdr + (helEnchLvl - 10) * 2;
                    else helhdr = helDefhdr + 3;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;

                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }

                if (helEnchLvl >= 19 & helEnchLvl <= 20)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helSSFRes;
                    cRes2 -= helKBRes;
                    cRes3 -= helGrapleRes;
                    cRes4 -= helKFRes;

                    if (helId == 9 | helId == 19) heldp = helDefdp + 59 + (helEnchLvl - 18) * 4;
                    else heldp = helDefdp + 60 + (helEnchLvl - 18) * 5;
                    helev = helDefev + 21 + (helEnchLvl - 18) * 2;
                    if (helId == 8 | helId == 13 | helId == 14 | helId == 15 | helId == 24 | helId == 31 | helId == 32 | helId == 33) helhev = helDefhev + 67 + (helEnchLvl - 18) * 6;
                    else if (helId == 9 | helId == 19) helhev = helDefev + 44 + (helEnchLvl - 18) * 4;
                    else helhev = helDefhev + 67 + (helEnchLvl - 18) * 6;

                    if (helId == 9 | helId == 19) heldr = helDefdr + 38 + (helEnchLvl - 18) * 2;
                    else heldr = helDefdr + 39 + (helEnchLvl - 18) * 3;

                    if (helId == 9 | helId == 19) helhdr = helDefhdr + (helEnchLvl - 10) * 2;
                    else helhdr = helDefhdr + 3 + (helEnchLvl - 18) * 1;
                    helSSFRes = helSSFDefRes;
                    helKBRes = helKBDefRes;
                    helGrapleRes = helGrapleDefRes;
                    helKFRes = helKFDefRes;

                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helSSFRes;
                    cRes2 += helKBRes;
                    cRes3 += helGrapleRes;
                    cRes4 += helKFRes;
                }
            }

            if (helEnch == false | helEnch == true & helEnchLvl == 0)
            {

                cdp -= heldp;
                cev -= helev;
                chev -= helhev;
                cDR -= heldr;
                chdr -= helhdr;
                cMaxHP -= helHP;
                cRes1 -= helSSFRes;
                cRes2 -= helKBRes;
                cRes3 -= helGrapleRes;
                cRes4 -= helKFRes;
                cWeight -= helWeight;
                cMaxST -= helST;




                heldp = helDefdp;
                helev = helDefev;
                helhev = helDefhev;
                heldr = helDefdr;
                helhdr = helDefhdr;
                helHP = helDefHP;
                helSSFRes = helSSFDefRes;
                helKBRes = helKBDefRes;
                helGrapleRes = helGrapleDefRes;
                helKFRes = helKFDefRes;
                helWeight = helDefWeight;
                helST = helDefST;

                cdp += heldp;
                cev += helev;
                chev += helhev;
                cDR += heldr;
                chdr += helhdr;
                cMaxHP += helHP;
                cRes1 += helSSFRes;
                cRes2 += helKBRes;
                cRes3 += helGrapleRes;
                cRes4 += helKFRes;
                cWeight += helWeight;
                cMaxST -= helST;
            }
        }

        public void GlovesState()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Gloves where Id='" + glovId.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (glovEnch == true & glovIsBoss == true | glovId == 21 & glovEnchLvl >=1 )
            {
                if (glovEnchLvl >= 1 & glovEnchLvl <= 5)
                {

                    cdp -= glovdp;
                    cacc -= glovacc;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    glovdp = glovDefdp + glovEnchLvl * 2;
                    if (glovId == 0 ) glovacc = glovDefacc + glovEnchLvl * 2;
                    else if (glovId == 21) glovacc = glovDefacc + glovEnchLvl * 1;
                    else glovacc = glovDefacc;
                    glovev = glovDefev + glovEnchLvl * 1;
                    glovhev = glovDefhev + glovEnchLvl * 3;
                    glovdr = glovDefdr + glovEnchLvl * 1;
                    if(glovId == 21) glovhdr = glovDefhdr + 5;
                    else glovhdr = glovDefhdr;

                    cdp += glovdp;
                    cacc += glovacc;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

                if (glovEnchLvl >= 6 & glovEnchLvl <= 15)
                {

                    cdp -= glovdp;
                    cacc -= glovacc;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    glovdp = glovDefdp + glovEnchLvl * 2;
                    if (glovId == 0) glovacc = glovDefacc + glovEnchLvl * 2;
                    else if (glovId == 21)
                    {
                        if (glovEnchLvl >= 15) glovacc = glovDefacc + 14 + (glovEnchLvl - 14) * 2;
                        else glovacc = glovDefacc + glovEnchLvl * 1;
                    }
                    else glovacc = glovDefacc + (glovEnchLvl-5) * 1;
                    glovev = glovDefev + glovEnchLvl * 1;
                    glovhev = glovDefhev + glovEnchLvl * 3;
                    glovdr = glovDefdr + glovEnchLvl * 1;
                    if (glovId == 21) glovhdr = glovDefhdr + 5;
                    else glovhdr = glovDefhdr;

                    cdp += glovdp;
                    cacc += glovacc;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

                if (glovEnchLvl == 16 )
                {

                    cdp -= glovdp;
                    cacc -= glovacc;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    glovdp = glovDefdp + 35;

                    if (glovId == 0) glovacc = glovDefacc + glovEnchLvl * 2;
                    else if (glovId == 21) glovacc = glovDefacc + 14 + (glovEnchLvl - 14) * 2;
                    else glovacc = glovDefacc + (glovEnchLvl - 5) * 1;

                    if (glovId == 0 | glovId == 21) glovev = glovDefev +17;
                    else  glovev = glovDefev + 18;

                    if (glovId == 0 | glovId == 21) glovhev = 54;
                    else glovhev = 61;

                    if (glovId == 0) glovdr = 19;
                    else if (glovId == 21) glovdr = 18;
                    else glovdr = 18;

                    if (glovId == 21) glovhdr = glovDefhdr + 6;
                    else glovhdr = glovDefhdr + 1;

                    cdp += glovdp;
                    cacc += glovacc;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

                if (glovEnchLvl == 17)
                {

                    cdp -= glovdp;
                    cacc -= glovacc;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    glovdp = glovDefdp + 40;

                    if (glovId == 0) glovacc = glovDefacc + glovEnchLvl * 2;
                    else if (glovId == 21) glovacc = glovDefacc + 14 + (glovEnchLvl - 14) * 2;
                    else glovacc = glovDefacc + (glovEnchLvl - 5) * 1;

                    if (glovId == 0 | glovId == 21) glovev = 20;
                    else glovev = glovDefev + 22;

                    if (glovId == 0 | glovId == 21) glovhev = 60;
                    else glovhev = 70;

                    if (glovId == 0) glovdr = 22;
                    else if (glovId == 21) glovdr = 21;
                    else glovdr = 20;

                    if (glovId == 0) glovhdr = 7;
                    else if (glovId == 21) glovhdr = glovDefhdr + 7;
                    else glovhdr = 8;

                    cdp += glovdp;
                    cacc += glovacc;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

                if (glovEnchLvl == 18)
                {

                    cdp -= glovdp;
                    cacc -= glovacc;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    glovdp = glovDefdp + 48;

                    if (glovId == 0 ) glovacc = glovDefacc + glovEnchLvl * 2;
                    else if (glovId == 21) glovacc = glovDefacc + 14 + (glovEnchLvl - 14) * 2;
                    else glovacc = glovDefacc + (glovEnchLvl - 5) * 1;

                    if (glovId == 0 | glovId == 21) glovev = 22;
                    else glovev = glovDefev +25;

                    if (glovId == 0 | glovId == 21) glovhev = 66;
                    else glovhev = 79;

                    if (glovId == 0 | glovId == 21) glovdr = 28;
                    else if (glovId == 21) glovdr = 27;
                    else glovdr = 25;

                    if (glovId == 0) glovhdr = 9;
                    else if (glovId == 21) glovhdr = glovDefhdr + 9;
                    else glovhdr = 11;

                    cdp += glovdp;
                    cacc += glovacc;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

                if (glovEnchLvl == 19)
                {

                    cdp -= glovdp;
                    cacc -= glovacc;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    if (glovId == 0) glovdp = 55;
                    else if (glovId == 21) glovdp = 54;
                    else glovdp = 56;

                    if (glovId == 0) glovacc = glovDefacc + glovEnchLvl * 2;
                    else if (glovId == 21) glovacc = glovDefacc + 14 + (glovEnchLvl - 14) * 2;
                    else glovacc = glovDefacc + (glovEnchLvl - 5) * 1;

                    if (glovId == 0 | glovId == 21) glovev = 24;
                    else glovev = glovDefev + 29;

                    if (glovId == 0 | glovId == 21) glovhev = 72;
                    else glovhev = 91;

                    if (glovId == 0 ) glovdr = 31;
                    else if (glovId == 21) glovdr = 30;
                    else glovdr = 27;

                    if (glovId == 0 | glovId == 21) glovhdr = 13;
                    else if (glovId == 21) glovhdr = glovDefhdr + 13;
                    else glovhdr = 14;

                    cdp += glovdp;
                    cacc += glovacc;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

                if (glovEnchLvl == 20)
                {

                    cdp -= glovdp;
                    cacc -= glovacc;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    if (glovId == 0) glovdp = 60;
                    else if (glovId == 21) glovdp = 59;
                    else glovdp = 62;

                    if (glovId == 0) glovacc = glovDefacc + glovEnchLvl * 2;
                    else if (glovId == 21) glovacc = glovDefacc + 14 + (glovEnchLvl - 14) * 2;
                    else glovacc = glovDefacc + (glovEnchLvl - 5) * 1;

                    if (glovId == 0 | glovId == 21) glovev = 26;
                    else glovev = glovDefev + 33;

                    if (glovId == 0 | glovId == 21) glovhev = 78;
                    else glovhev = 103;

                    if (glovId == 0 ) glovdr = 34;
                    else if (glovId == 21) glovdr = 33;
                    else glovdr = 29;

                    if (glovId == 0) glovhdr = 19;
                    else if (glovId == 21) glovhdr = glovDefhdr + 19;
                    else glovhdr = 17;

                    cdp += glovdp;
                    cacc += glovacc;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

            }

            else if (glovEnch == true & glovIsBoss == false)
            {
                if (glovEnchLvl >= 1 & glovEnchLvl <= 15)
                {

                    cdp -= glovdp;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;
                    cacc -= glovacc;
                    cAtkSpeed -= glovAtkSpeed;
                    cCastSpeed -= glovCastSpeed;
                    ccr -= glovCrit;
                    cWeight -= glovWeight;
                    cRes3 -= glovGrapleRes;


                    glovdp = glovDefdp + glovEnchLvl * 2;
                    if(glovId == 9 | glovId == 19)
                    {
                        if (glovEnchLvl <= 5) glovacc = glovDefacc;
                        else if (glovEnchLvl >= 6 & glovEnchLvl <= 10) glovacc = glovDefacc + 3;
                        else if (glovEnchLvl >= 11) glovacc = glovDefacc + 3 + (glovEnchLvl - 10) * 2;
                    }
                    glovev = glovDefev + glovEnchLvl * 1;
                    if(glovId == 8 | glovId == 13 | glovId == 14 | glovId == 15 | glovId == 24 | glovId == 31 | glovId == 32 | glovId == 33)
                    {
                        if (glovEnchLvl == 1) glovhev = glovDefhev + 7;
                        else if (glovEnchLvl == 2) glovhev = glovDefhev + 9;
                        else if (glovEnchLvl == 3) glovhev = glovDefhev + 12;
                        else if (glovEnchLvl == 4) glovhev = glovDefhev + 15;
                        else if (glovEnchLvl == 5) glovhev = glovDefhev + 18;
                        else if (glovEnchLvl == 6) glovhev = glovDefhev + 22;
                        else if (glovEnchLvl == 7) glovhev = glovDefhev + 25;
                        else if (glovEnchLvl == 8) glovhev = glovDefhev + 29;
                        else glovhev = glovDefhev + 29 + (glovEnchLvl-8) * 3;
                    }
                     else if (glovId == 9| glovId == 19)
                     {
                        if (glovEnchLvl <= 10) glovhev = glovDefhev + glovEnchLvl * 2;
                        else if (glovEnchLvl == 11) glovhev = glovDefhev + 23;
                        else glovhev = glovDefhev + 23 + (glovEnchLvl - 11) * 2;
                     }
                    else glovhev = glovDefhev + glovEnchLvl * 3;
                    glovdr = glovDefdr + glovEnchLvl * 1;
                    if(glovId == 9| glovId == 19)
                    {
                        if (glovEnchLvl <= 5) glovhdr = glovDefhdr;
                        else glovhdr = glovDefhdr + 3;
                    }
                    else glovhdr = glovDefhdr;
                    glovAtkSpeed = glovDefAtkSpeed;
                    glovCastSpeed = glovDefCastSpeed;
                    glovCrit = glovDefCrit;
                    glovWeight = glovDefWeight;
                    glovGrapleRes = glovDefGrapleRes;



                    cdp += glovdp;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                    cacc += glovacc;
                    cAtkSpeed += glovAtkSpeed;
                    cCastSpeed += glovCastSpeed;
                    ccr += glovCrit;
                    cWeight += glovWeight;
                    cRes3 += glovGrapleRes;
                }

                if (glovEnchLvl == 16)
                {

                    cdp -= glovdp;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;
                    cacc -= glovacc;
                    cAtkSpeed -= glovAtkSpeed;
                    cCastSpeed -= glovCastSpeed;
                    ccr -= glovCrit;
                    cWeight -= glovWeight;
                    cRes3 -= glovGrapleRes;

                    glovdp = glovDefdp + (glovEnchLvl -1) * 2 + 5;
                    if (glovId == 9 | glovId == 19) glovacc = glovDefacc + 16;
                    glovev = glovDefev + (glovEnchLvl-1) * 1 + 2;
                    if (glovId == 8 | glovId == 13 | glovId == 14 | glovId == 15 | glovId == 24 | glovId == 31 | glovId == 32 | glovId == 33) glovhev = glovDefhev + 55;
                    else if (glovId == 9 | glovId == 19) glovhev = glovDefhev + 39;
                    else glovhev = glovDefhev + (glovEnchLvl - 1) * 3 + 10;
                    glovdr = glovDefdr + (glovEnchLvl - 1) * 1 + 3;
                    if (glovId == 9 | glovId == 19) glovhdr = glovDefhdr + 4;
                    else glovhdr = glovDefhdr + 1;
                    glovAtkSpeed = glovDefAtkSpeed;
                    glovCastSpeed = glovDefCastSpeed;
                    glovCrit = glovDefCrit;
                    glovWeight = glovDefWeight;
                    glovGrapleRes = glovDefGrapleRes;

                    cdp += glovdp;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                    cacc += glovacc;
                    cAtkSpeed += glovAtkSpeed;
                    cCastSpeed += glovCastSpeed;
                    ccr += glovCrit;
                    cWeight += glovWeight;
                    cRes3 += glovGrapleRes;
                }

                if (glovEnchLvl ==17)
                {

                    cdp -= glovdp;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;
                    cacc -= glovacc;
                    cAtkSpeed -= glovAtkSpeed;
                    cCastSpeed -= glovCastSpeed;
                    ccr -= glovCrit;
                    cWeight -= glovWeight;
                    cRes3 -= glovGrapleRes;

                    glovdp = glovDefdp + 40;
                    if (glovId == 9 | glovId == 19) glovacc = glovDefacc + 19;
                    glovev = glovDefev + 19;
                    if (glovId == 8 | glovId == 13 | glovId == 14 | glovId == 15 | glovId == 24 | glovId == 31 | glovId == 32 | glovId == 33) glovhev = glovDefhev + 61;
                    else if (glovId == 9 | glovId == 19) glovhev = glovDefhev + 45;
                    else glovhev = glovDefhev + 61;
                    glovdr = glovDefdr + 19;
                    if (glovId == 9 | glovId == 19) glovhdr = glovDefhdr + 5;
                    else glovhdr = glovDefhdr+2;
                    glovAtkSpeed = glovDefAtkSpeed;
                    glovCastSpeed = glovDefCastSpeed;
                    glovCrit = glovDefCrit;
                    glovWeight = glovDefWeight;
                    glovGrapleRes = glovDefGrapleRes;

                    cdp += glovdp;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                    cacc += glovacc;
                    cAtkSpeed += glovAtkSpeed;
                    cCastSpeed += glovCastSpeed;
                    ccr += glovCrit;
                    cWeight += glovWeight;
                    cRes3 += glovGrapleRes;
                }

                if (glovEnchLvl == 18)
                {

                    cdp -= glovdp;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;
                    cacc -= glovacc;
                    cAtkSpeed -= glovAtkSpeed;
                    cCastSpeed -= glovCastSpeed;
                    ccr -= glovCrit;
                    cWeight -= glovWeight;
                    cRes3 -= glovGrapleRes;

                    glovdp = glovDefdp + 48;
                    if (glovId == 9 | glovId == 19) glovacc = glovDefacc + 22;
                    glovev = glovDefev + 21;
                    if (glovId == 8 | glovId == 13 | glovId == 14 | glovId == 15 | glovId == 24 | glovId == 31 | glovId == 32 | glovId == 33) glovhev = glovDefhev + 67;
                    else if (glovId == 9 | glovId == 19) glovhev = glovDefhev + 51;
                    else glovhev = glovDefhev + 67;
                    glovdr = glovDefdr + 27;
                    if (glovId == 9 | glovId == 19) glovhdr = glovDefhdr + 6;
                    else glovhdr = glovDefhdr + 3;
                    glovAtkSpeed = glovDefAtkSpeed;
                    glovCastSpeed = glovDefCastSpeed;
                    glovCrit = glovDefCrit;
                    glovWeight = glovDefWeight;
                    glovGrapleRes = glovDefGrapleRes;

                    cdp += glovdp;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                    cacc += glovacc;
                    cAtkSpeed += glovAtkSpeed;
                    cCastSpeed += glovCastSpeed;
                    ccr += glovCrit;
                    cWeight += glovWeight;
                    cRes3 += glovGrapleRes;
                }

                if (glovEnchLvl >= 19 & glovEnchLvl <= 20)
                {

                    cdp -= glovdp;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;
                    cacc -= glovacc;
                    cAtkSpeed -= glovAtkSpeed;
                    cCastSpeed -= glovCastSpeed;
                    ccr -= glovCrit;
                    cWeight -= glovWeight;
                    cRes3 -= glovGrapleRes;

                    glovdp = glovDefdp + 48 + (glovEnchLvl-18) * 5;
                    if (glovId == 9 | glovId == 19) glovacc = glovDefacc + 22 + (glovEnchLvl -18) * 3;
                    glovev = glovDefev + 21 + (glovEnchLvl - 18) * 2;
                    if (glovId == 8 | glovId == 13 | glovId == 14 | glovId == 15 | glovId == 24 | glovId == 31 | glovId == 32 | glovId == 33) glovhev = glovDefhev + 67 + (glovEnchLvl-18) * 6;
                    else if (glovId == 9 | glovId == 19) glovhev = glovDefhev + 51 + (glovEnchLvl-18) * 6;
                    else glovhev = glovDefhev + 67 + (glovEnchLvl - 18)*6;
                    glovdr = glovDefdr + 27 + (glovEnchLvl - 18) * 3;
                    if (glovId == 9 | glovId == 19) glovhdr = glovDefhdr + 6 + (glovEnchLvl-18) * 1;
                    else glovhdr = glovDefhdr + 3 + (glovEnchLvl - 18)*1;
                    glovAtkSpeed = glovDefAtkSpeed;
                    glovCastSpeed = glovDefCastSpeed;
                    glovCrit = glovDefCrit;
                    glovWeight = glovDefWeight;
                    glovGrapleRes = glovDefGrapleRes;

                    cdp += glovdp;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                    cacc += glovacc;
                    cAtkSpeed += glovAtkSpeed;
                    cCastSpeed += glovCastSpeed;
                    ccr += glovCrit;
                    cWeight += glovWeight;
                    cRes3 += glovGrapleRes;
                }

                
            }

            if (glovEnch == false | glovEnch == true & glovEnchLvl == 0)
            {

                cdp -= glovdp;
                cacc -= glovacc;
                cev -= glovev;
                chev -= glovhev;
                cDR -= glovdr;
                chdr -= glovhdr;
                cacc -= glovacc;
                cAtkSpeed -= glovAtkSpeed;
                cCastSpeed -= glovCastSpeed;
                ccr -= glovCrit;
                cWeight -= glovWeight;
                cRes3 -= glovGrapleRes;


                glovdp = glovDefdp;
                glovacc = glovDefacc;
                glovev = glovDefev;
                glovhev = glovDefhev;
                glovdr = glovDefdr;
                glovhdr = glovDefhdr;
                glovAtkSpeed = glovDefAtkSpeed;
                glovCastSpeed = glovDefCastSpeed;
                glovCrit = glovDefCrit;
                glovWeight = glovDefWeight;
                glovGrapleRes = glovDefGrapleRes;

                cdp += glovdp;
                cev += glovev;
                chev += glovhev;
                cDR += glovdr;
                chdr += glovhdr;
                cacc += glovacc;
                cAtkSpeed += glovAtkSpeed;
                cCastSpeed += glovCastSpeed;
                ccr += glovCrit;
                cWeight += glovWeight;
                cRes3 += glovGrapleRes;


            }
        }

        public void ShoesState()
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Shoes where Id='" + shId.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (shEnch == true & shIsBoss == true | shId == 25)
            {

                if (shEnchLvl >= 1 & shEnchLvl <= 15)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;

                    shdp = shDefdp + shEnchLvl * 3;
                    shev = shDefev + shEnchLvl * 2;
                    if (shId == 0 | shId == 25) shhev = shDefhev + shEnchLvl * 4;
                    else shhev = shDefev + shEnchLvl * 2;

                    shdr = shDefdr + shEnchLvl * 1;

                    if (shId == 0 | shId == 25) shhdr = shDefhdr;
                    else if (shId == 1 & shEnchLvl <= 5) shhdr = shDefhdr + shEnchLvl * 1;
                    else shhdr = shDefhdr + 5 + (shEnchLvl - 5) * 2;

                    shMvs = shDefMvs;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;

                }

                if (shEnchLvl == 16)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;

                    shdp = shDefdp + 50;


                    shev = shDefev + shEnchLvl * 2;

                    if (shId == 0) shhev = shDefhev + 68;
                    else if (shId == 25) shhev = shDefhev + 67;
                    else shhev = shDefhev + 34;

                    shdr = shDefdr + 18;

                    if (shId == 0 | shId == 25) shhdr = shDefhdr+1;
                    else shhdr = shDefhdr + 28;
                    shMvs = shDefMvs;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;
                }

                if (shEnchLvl == 17)
                {
                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;

                    shdp = shDefdp + 55;

                    shev = shDefev + shEnchLvl * 2;

                    if (shId == 0 ) shhev = shDefhev + 72;
                    else if (shId == 25) shhev = shDefhev + 71;
                    else shhev = shDefhev + 36;

                    shdr = shDefdr + 21;

                    if (shId == 0 | shId == 25) shhdr = shDefhdr + 2;
                    else shhdr = shDefhdr + 31;
                    shMvs = shDefMvs;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;

                }

                if (shEnchLvl == 18)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;

                    shdp = shDefdp + 63;

                    shev = shDefev + shEnchLvl * 2;

                    if (shId == 0) shhev = shDefhev + 76;
                    else if (shId == 25) shhev = shDefhev + 75;
                    else shhev = shDefhev + 38;

                    shdr = shDefdr + 27;


                    if (shId == 0 | shId == 25) shhdr = shDefhdr + 4;
                    else shhdr = shDefhdr + 34;
                    shMvs = shDefMvs;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;

                }

                if (shEnchLvl == 19)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;

                    shdp = shDefdp + 68;

                    shev = shDefev + shEnchLvl * 2;

                    if (shId == 0 ) shhev = shDefhev + 80;
                    else if (shId == 25) shhev = shDefhev + 79;
                    else shhev = shDefhev + 40;

                    shdr = shDefdr + 30;

                    if (shId == 0 | shId == 25) shhdr = shDefhdr + 8;
                    else shhdr = shDefhdr + 37;
                    shMvs = shDefMvs;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;

                }

                if (shEnchLvl == 20)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;

                    shdp = shDefdp + 73;

                    shev = shDefev + shEnchLvl * 2;

                    if (shId == 0) shhev = shDefhev + 84;
                    else if (shId == 25) shhev = shDefhev + 83;
                    else shhev = shDefhev + 42;

                    shdr = shDefdr + 33;

                    if (shId == 0 | shId == 25) shhdr = shDefhdr + 14;
                    else shhdr = shDefhdr + 40;
                    shMvs = shDefMvs;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;

                }

            }

            if (shEnch == true & shIsBoss == false)
            {
                if (shEnchLvl >= 1 & shEnchLvl <= 15)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;
                    cRes2 -= shKBRes;
                    cMaxST -= shMaxST;
                    cWeight -= shWeight;

                    if(shId == 11 | shId == 23)
                    {
                        if (shEnchLvl <= 5) shdp = shDefdp + shEnchLvl * 2;
                        else shdp = shDefdp + 10 + (shEnchLvl - 5) * 3;
                    }
                    else shdp = shDefdp + shEnchLvl * 2;

                    if(shId == 11 | shId == 23)
                    {
                        if (shEnchLvl <= 5) shev = shDefev + shEnchLvl * 1;
                        else shev = shDefev + 5 + (shEnchLvl - 5) * 2;
                    }
                    else shev = shDefev + shEnchLvl * 1;

                    if (shId == 10 | shId == 15 | shId == 16 | shId == 17 | shId == 28 | shId == 35 | shId == 36 | shId == 37)
                    {
                        if (shEnchLvl == 1) shhev = shDefhev + 7;
                        else if (shEnchLvl == 2) shhev = shDefhev + 9;
                        else if (shEnchLvl == 3) shhev = shDefhev + 12;
                        else if (shEnchLvl == 4) shhev = shDefhev + 15;
                        else if (shEnchLvl == 5) shhev = shDefhev + 18;
                        else if (shEnchLvl == 6) shhev = shDefhev + 22;
                        else if (shEnchLvl == 7) shhev = shDefhev + 25;
                        else if (shEnchLvl == 8) shhev = shDefhev + 29;
                        else shhev = shDefhev + 29 + (shEnchLvl - 8) * 3;
                    }
                    else if (shId == 11 | shId == 23)
                    {
                        if (shEnchLvl <= 5) shhev = shDefhev + shEnchLvl * 2;
                        else shhev = shDefhev + 10 + (shEnchLvl - 5) * 4;
                    }
                    else shhev = shDefhev + shEnchLvl * 3;

                    shdr = shDefdr + shEnchLvl * 1;
                    if(shId == 11 | shId == 23)
                    {
                        if (shEnchLvl <= 10) shhdr = shDefhdr;
                        else shhdr = shDefhdr + (shEnchLvl - 10) * 1;
                    }
                    else shhdr = shDefhdr;

                    shMvs = shDefMvs;
                    shKBRes = shDefKBRes;
                    shMaxST = shDefMaxST;
                    shWeight = shDefWeight;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;
                    cRes2 += shKBRes;
                    cMaxST += shMaxST;
                    cWeight += shWeight;
                }

                if (shEnchLvl == 16)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;
                    cRes2 -= shKBRes;
                    cMaxST -= shMaxST;
                    cWeight -= shWeight;

                    if (shId == 11 | shId == 23) shdp = shDefdp + 45;
                    else shdp = shDefdp + (shEnchLvl - 1) * 2 + 5;

                    if (shId == 11 | shId == 23) shev = shDefev + 27;
                    else shev = shDefev + (shEnchLvl - 1) * 1 + 2;

                    if (shId == 10 | shId == 15 | shId == 16 | shId == 17 | shId == 28 | shId == 35 | shId == 36 | shId == 37) shhev = shDefhev + 55;
                    else if (shId == 11 | shId == 23) shhev = shDefhev + 57;
                    else shhev = shDefhev + (shEnchLvl - 1) * 3 + 10;

                    shdr = shDefdr + (shEnchLvl - 1) * 1 + 3;
                    if (shId == 11 | shId == 23) shhdr = shDefhdr + 6;
                    else shhdr = shDefhdr + 1;

                    shMvs = shDefMvs;
                    shKBRes = shDefKBRes;
                    shMaxST = shDefMaxST;
                    shWeight = shDefWeight;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;
                    cRes2 += shKBRes;
                    cMaxST += shMaxST;
                    cWeight += shWeight;
                }

                if (shEnchLvl == 17)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;
                    cRes2 -= shKBRes;
                    cMaxST -= shMaxST;
                    cWeight -= shWeight;

                    if (shId == 11 | shId == 23) shdp = shDefdp + 50;
                    else shdp = shDefdp + 40;

                    if (shId == 11 | shId == 23) shev = shDefev + 29;
                    else shev = shDefev + 19;

                    if (shId == 10 | shId == 15 | shId == 16 | shId == 17 | shId == 28 | shId == 35 | shId == 36 | shId == 37) shhev = shDefhev + 61;
                    else if (shId == 11 | shId == 23) shhev = shDefhev + 63;
                    else shhev = shDefhev + 61;

                    shdr = shDefdr + 19;

                    if (shId == 11 | shId == 23) shhdr = shDefhdr + 7;
                    else shhdr = shDefhdr + 2;

                    shMvs = shDefMvs;
                    shKBRes = shDefKBRes;
                    shMaxST = shDefMaxST;
                    shWeight = shDefWeight;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;
                    cRes2 += shKBRes;
                    cMaxST += shMaxST;
                    cWeight += shWeight;
                }

                if (shEnchLvl == 18)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;
                    cRes2 -= shKBRes;
                    cMaxST -= shMaxST;
                    cWeight -= shWeight;

                    if (shId == 11 | shId == 23) shdp = shDefdp + 58;
                    else shdp = shDefdp + 48;

                    if (shId == 11 | shId == 23) shev = shDefev + 31;
                    else shev = shDefev + 21;

                    if (shId == 10 | shId == 15 | shId == 16 | shId == 17 | shId == 28 | shId == 35 | shId == 36 | shId == 37) shhev = shDefhev + 67;
                    else if (shId == 11 | shId == 23) shhev = shDefhev + 69;
                    else shhev = shDefhev + 67;

                    shdr = shDefdr + 27;

                    if (shId == 11 | shId == 23) shhdr = shDefhdr + 8;
                    else shhdr = shDefhdr + 3;

                    shMvs = shDefMvs;
                    shKBRes = shDefKBRes;
                    shMaxST = shDefMaxST;
                    shWeight = shDefWeight;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;
                    cRes2 += shKBRes;
                    cMaxST += shMaxST;
                    cWeight += shWeight;
                }

                if (shEnchLvl >= 19 & shEnchLvl <= 20)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;
                    cmvs -= shMvs;
                    cRes2 -= shKBRes;
                    cMaxST -= shMaxST;
                    cWeight -= shWeight;

                    if (shId == 11 | shId == 23) shdp = shDefdp + 58 + (shEnchLvl- 18) * 5;
                    else shdp = shDefdp + 48 + (shEnchLvl - 18) * 5;

                    if (shId == 11 | shId == 23) shev = shDefev + 31 + (shEnchLvl - 18) * 2;
                    else shev = shDefev + 21 + (shEnchLvl - 18) * 2;

                    if (shId == 10 | shId == 15 | shId == 16 | shId == 17 | shId == 28 | shId == 35 | shId == 36 | shId == 37) shhev = shDefhev + 67 + (shEnchLvl - 18) * 6;
                    else if (shId == 11 | shId == 23) shhev = shDefhev + 69 + (shEnchLvl - 18) * 6;
                    else shhev = shDefhev + 67 + (shEnchLvl - 18) * 6;

                    shdr = shDefdr + 27 + (shEnchLvl - 18) * 3;

                    if (shId == 11 | shId == 23) shhdr = shDefhdr + 8 +(shEnchLvl - 18) * 1;
                    else shhdr = shDefhdr + 3 + (shEnchLvl - 18) * 1;

                    shMvs = shDefMvs;
                    shKBRes = shDefKBRes;
                    shMaxST = shDefMaxST;
                    shWeight = shDefWeight;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                    cmvs += shMvs;
                    cRes2 += shKBRes;
                    cMaxST += shMaxST;
                    cWeight += shWeight;
                }


            }

            if (shEnch == false | shEnch == true & shEnchLvl == 0)
            {

                cdp -= shdp;
                cev -= shev;
                chev -= shhev;
                cDR -= shdr;
                chdr -= shhdr;
                cmvs -= shMvs;
                cRes2 -= shKBRes;
                cMaxST -= shMaxST;
                cWeight -= shWeight;



                shdp = shDefdp;
                shev = shDefev;
                shhev = shDefhev;
                shdr = shDefdr;
                shhdr = shDefhdr;
                shMvs = shDefMvs;
                shKBRes = shDefKBRes;
                shMaxST = shDefMaxST;
                shWeight = shDefWeight;

                cdp += shdp;
                cev += shev;
                chev += shhev;
                cDR += shdr;
                chdr += shhdr;
                cmvs += shMvs;
                cRes2 += shKBRes;
                cMaxST += shMaxST;
                cWeight += shWeight;

            }
        }

        public void BossSetBonusCheck()
        {
            b_sb = b_sb - b_asb; // Boss (1)
            b_sb = b_sb - b_hsb;
            b_sb = b_sb - b_bsb;
            b_sb = b_sb - b_gsb;
            l_sb = l_sb - l_asb; // Lemoria (2)
            l_sb = l_sb - l_hsb;
            l_sb = l_sb - l_bsb;
            l_sb = l_sb - l_gsb;
            a_sb = a_sb - a_asb; // Akum (3)
            a_sb = a_sb - a_hsb;
            a_sb = a_sb - a_bsb;
            a_sb = a_sb - a_gsb;
            gr_sb = gr_sb - gr_asb; // Grunil (4)
            gr_sb = gr_sb - gr_hsb;
            gr_sb = gr_sb - gr_bsb;
            gr_sb = gr_sb - gr_gsb;
            tr_sb = tr_sb - tr_asb; // Taritas (5)
            tr_sb = tr_sb - tr_hsb;
            tr_sb = tr_sb - tr_bsb;
            tr_sb = tr_sb - tr_gsb;
            rc_sb = rc_sb - rc_asb; // Rocaba (6)
            rc_sb = rc_sb - rc_hsb;
            rc_sb = rc_sb - rc_bsb;
            rc_sb = rc_sb - rc_gsb;
            ag_sb = ag_sb - ag_asb; // Agerian (7)
            ag_sb = ag_sb - ag_hsb;
            ag_sb = ag_sb - ag_bsb;
            ag_sb = ag_sb - ag_gsb;
            zr_sb = zr_sb - zr_asb; // Zereth (8)
            zr_sb = zr_sb - zr_hsb;
            zr_sb = zr_sb - zr_bsb;
            zr_sb = zr_sb - zr_gsb;
            tl_sb = tl_sb - tl_asb; // Talis (9)
            tl_sb = tl_sb - tl_hsb;
            tl_sb = tl_sb - tl_bsb;
            tl_sb = tl_sb - tl_gsb;
            sh_sb = sh_sb - sh_asb; // SH (10)
            sh_sb = sh_sb - sh_hsb;
            sh_sb = sh_sb - sh_bsb;
            sh_sb = sh_sb - sh_gsb;
            hm_sb = hm_sb - hm_asb; // HM (11)
            hm_sb = hm_sb - hm_hsb;
            hm_sb = hm_sb - hm_bsb;
            hm_sb = hm_sb - hm_gsb;
            lf_sb = lf_sb - lf_asb; // LF (12)
            lf_sb = lf_sb - lf_hsb;
            lf_sb = lf_sb - lf_bsb;
            lf_sb = lf_sb - lf_gsb;

            // Boss
            if (armSB == 1) { b_asb = 1; }
            if (armSB != 1 && b_asb > 0) { b_asb = b_asb - 1; }
            if (helSB == 1) { b_hsb = 1; }
            if (helSB != 1 && b_hsb > 0) { b_hsb = b_hsb - 1; }
            if (shSB == 1) { b_bsb = 1; }
            if (shSB != 1 && b_bsb > 0) { b_bsb = b_bsb - 1; }
            if (glovSB == 1) { b_gsb = 1; }
            if (glovSB != 1 && b_gsb > 0) { b_gsb = b_gsb - 1; }
            // Lemoria
            if (armSB == 2) { l_asb = 1; }
            if (armSB != 2 && l_asb > 0) { l_asb = l_asb - 1; }
            if (helSB == 2) { l_hsb = 1; }
            if (helSB != 2 && l_hsb > 0) { l_hsb = l_hsb - 1; }
            if (shSB == 2) { l_bsb = 1; }
            if (shSB != 2 && l_bsb > 0) { l_bsb = l_bsb - 1; }
            if (glovSB == 2) { l_gsb = 1; }
            if (glovSB != 2 && l_gsb > 0) { l_gsb = l_gsb - 1; }
            // Akum
            if (armSB == 3) { a_asb = 1; }
            if (armSB != 3 && a_asb > 0) { a_asb = a_asb - 1; }
            if (helSB == 3) { a_hsb = 1; }
            if (helSB != 3 && a_hsb > 0) { a_hsb = a_hsb - 1; }
            if (shSB == 3) { a_bsb = 1; }
            if (shSB != 3 && a_bsb > 0) { a_bsb = a_bsb - 1; }
            if (glovSB == 3) { a_gsb = 1; }
            if (glovSB != 3 && a_gsb > 0) { a_gsb = a_gsb - 1; }
            // Grunil
            if (armSB == 4) { gr_asb = 1; }
            if (armSB != 4 && gr_asb > 0) { gr_asb = gr_asb - 1; }
            if (helSB == 4) { gr_hsb = 1; }
            if (helSB != 4 && gr_hsb > 0) { gr_hsb = gr_hsb - 1; }
            if (shSB == 4) { gr_bsb = 1; }
            if (shSB != 4 && gr_bsb > 0) { gr_bsb = gr_bsb - 1; }
            if (glovSB == 4) { gr_gsb = 1; }
            if (glovSB != 4 && gr_gsb > 0) { gr_gsb = gr_gsb - 1; }
            // Taritas
            if (armSB == 5) { tr_asb = 1; }
            if (armSB != 5 && tr_asb > 0) { tr_asb = tr_asb - 1; }
            if (helSB == 5) { tr_hsb = 1; }
            if (helSB != 5 && tr_hsb > 0) { tr_hsb = tr_hsb - 1; }
            if (shSB == 5) { tr_bsb = 1; }
            if (shSB != 5 && tr_bsb > 0) { tr_bsb = tr_bsb - 1; }
            if (glovSB == 5) { tr_gsb = 1; }
            if (glovSB != 5 && tr_gsb > 0) { tr_gsb = tr_gsb - 1; }
            // Rocaba
            if (armSB == 6) { rc_asb = 1; }
            if (armSB != 6 && rc_asb > 0) { rc_asb = rc_asb - 1; }
            if (helSB == 6) { rc_hsb = 1; }
            if (helSB != 6 && rc_hsb > 0) { rc_hsb = rc_hsb - 1; }
            if (shSB == 6) { rc_bsb = 1; }
            if (shSB != 6 && rc_bsb > 0) { rc_bsb = rc_bsb - 1; }
            if (glovSB == 6) { rc_gsb = 1; }
            if (glovSB != 6 && rc_gsb > 0) { rc_gsb = rc_gsb - 1; }
            // Agerian
            if (armSB == 7) { ag_asb = 1; }
            if (armSB != 7 && ag_asb > 0) { ag_asb = ag_asb - 1; }
            if (helSB == 7) { ag_hsb = 1; }
            if (helSB != 7 && ag_hsb > 0) { ag_hsb = ag_hsb - 1; }
            if (shSB == 7) { ag_bsb = 1; }
            if (shSB != 7 && ag_bsb > 0) { ag_bsb = ag_bsb - 1; }
            if (glovSB == 7) { ag_gsb = 1; }
            if (glovSB != 7 && ag_gsb > 0) { ag_gsb = ag_gsb - 1; }
            // Zereth
            if (armSB == 8) { zr_asb = 1; }
            if (armSB != 8 && zr_asb > 0) { zr_asb = zr_asb - 1; }
            if (helSB == 8) { zr_hsb = 1; }
            if (helSB != 8 && zr_hsb > 0) { zr_hsb = zr_hsb - 1; }
            if (shSB == 8) { zr_bsb = 1; }
            if (shSB != 8 && zr_bsb > 0) { zr_bsb = zr_bsb - 1; }
            if (glovSB == 8) { zr_gsb = 1; }
            if (glovSB != 8 && zr_gsb > 0) { zr_gsb = zr_gsb - 1; }
            // Talis
            if (armSB == 9) { tl_asb = 1; }
            if (armSB != 9 && tl_asb > 0) { tl_asb = tl_asb - 1; }
            if (helSB == 9) { tl_hsb = 1; }
            if (helSB != 9 && tl_hsb > 0) { tl_hsb = tl_hsb - 1; }
            if (shSB == 9) { tl_bsb = 1; }
            if (shSB != 9 && tl_bsb > 0) { tl_bsb = tl_bsb - 1; }
            if (glovSB == 9) { tl_gsb = 1; }
            if (glovSB != 9 && tl_gsb > 0) { tl_gsb = tl_gsb - 1; }
            // SH
            if (armSB == 10) { sh_asb = 1; }
            if (armSB != 10 && sh_asb > 0) { sh_asb = sh_asb - 1; }
            if (helSB == 10) { sh_hsb = 1; }
            if (helSB != 10 && sh_hsb > 0) { sh_hsb = sh_hsb - 1; }
            if (shSB == 10) { sh_bsb = 1; }
            if (shSB != 10 && sh_bsb > 0) { sh_bsb = sh_bsb - 1; }
            if (glovSB == 10) { sh_gsb = 1; }
            if (glovSB != 10 && sh_gsb > 0) { sh_gsb = sh_gsb - 1; }
            // HM
            if (armSB == 11) { hm_asb = 1; }
            if (armSB != 11 && hm_asb > 0) { hm_asb = hm_asb - 1; }
            if (helSB == 11) { hm_hsb = 1; }
            if (helSB != 11 && hm_hsb > 0) { hm_hsb = hm_hsb - 1; }
            if (shSB == 11) { hm_bsb = 1; }
            if (shSB != 11 && hm_bsb > 0) { hm_bsb = hm_bsb - 1; }
            if (glovSB == 11) { hm_gsb = 1; }
            if (glovSB != 11 && hm_gsb > 0) { hm_gsb = hm_gsb - 1; }
            // LF
            if (armSB == 12) { lf_asb = 1; }
            if (armSB != 12 && lf_asb > 0) { lf_asb = lf_asb - 1; }
            if (helSB == 12) { lf_hsb = 1; }
            if (helSB != 12 && lf_hsb > 0) { lf_hsb = lf_hsb - 1; }
            if (shSB == 12) { lf_bsb = 1; }
            if (shSB != 12 && lf_bsb > 0) { lf_bsb = lf_bsb - 1; }
            if (glovSB == 12) { lf_gsb = 1; }
            if (glovSB != 12 && lf_gsb > 0) { lf_gsb = lf_gsb - 1; }

            b_sb = b_sb + b_asb; // Boss
            b_sb = b_sb + b_hsb;
            b_sb = b_sb + b_bsb;
            b_sb = b_sb + b_gsb;
            l_sb = l_sb + l_asb; // Lemoria
            l_sb = l_sb + l_hsb;
            l_sb = l_sb + l_bsb;
            l_sb = l_sb + l_gsb;
            a_sb = a_sb + a_asb; // Akum
            a_sb = a_sb + a_hsb;
            a_sb = a_sb + a_bsb;
            a_sb = a_sb + a_gsb;
            gr_sb = gr_sb + gr_asb; // Grunil
            gr_sb = gr_sb + gr_hsb;
            gr_sb = gr_sb + gr_bsb;
            gr_sb = gr_sb + gr_gsb;
            tr_sb = tr_sb + tr_asb; // Taritas
            tr_sb = tr_sb + tr_hsb;
            tr_sb = tr_sb + tr_bsb;
            tr_sb = tr_sb + tr_gsb;
            rc_sb = rc_sb + rc_asb; // Rocaba
            rc_sb = rc_sb + rc_hsb;
            rc_sb = rc_sb + rc_bsb;
            rc_sb = rc_sb + rc_gsb;
            ag_sb = ag_sb + ag_asb; // Agerian
            ag_sb = ag_sb + ag_hsb;
            ag_sb = ag_sb + ag_bsb;
            ag_sb = ag_sb + ag_gsb;
            zr_sb = zr_sb + zr_asb; // Zereth
            zr_sb = zr_sb + zr_hsb;
            zr_sb = zr_sb + zr_bsb;
            zr_sb = zr_sb + zr_gsb;
            tl_sb = tl_sb + tl_asb; // Talis
            tl_sb = tl_sb + tl_hsb;
            tl_sb = tl_sb + tl_bsb;
            tl_sb = tl_sb + tl_gsb;
            sh_sb = sh_sb + sh_asb; // SH
            sh_sb = sh_sb + sh_hsb;
            sh_sb = sh_sb + sh_bsb;
            sh_sb = sh_sb + sh_gsb;
            hm_sb = hm_sb + hm_asb; // HM
            hm_sb = hm_sb + hm_hsb;
            hm_sb = hm_sb + hm_bsb;
            hm_sb = hm_sb + hm_gsb;
            lf_sb = lf_sb + lf_asb; // LF
            lf_sb = lf_sb + lf_hsb;
            lf_sb = lf_sb + lf_bsb;
            lf_sb = lf_sb + lf_gsb;

        }

    }
}
