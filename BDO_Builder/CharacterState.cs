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
        public int cdp; //DP
        public int cap; //AP
        public int caap; //AAP
        public int cev;// Evasion
        public int cacc;//Accuracy
        public int cRes1 = 20;// Resists: Stun/Stiffness/Freezing
        public int cRes2 = 20;// Resists: Knockdown/Bound
        public int cRes3 = 20;// Resists: Grapple
        public int cRes4 = 20;// Resists: Knockback/Floating
        public int cDR; //Damage Reduction
        public int cMaxHP; // Max HP
        public int cWeight; // Weight
        public int cMaxMP;// Max MP
        public int cMaxST;// Max stamina
        public int chev; // Hiden evasion
        public int chdr; // hiden damage reduction

        //SetBonus Check
        public int sb; //Set Bonus
        public int asb; //Armour
        public int hsb; //Helm
        public int bsb; //Boots
        public int gsb; //Gloves

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

        //Helmet stats
        public int heldp;// Helmet DP
        public int helev;// Helmet evasion
        public int helhev;// Helmet hiden evasion
        public int heldr;// Helmet damage reduction
        public int helhdr;// Helmet hiden damage reduction
        public int helHP;
        public int helRes;
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
        public int helDefRes;

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


            if (armEnch == true & armIsBoss == true)
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

                    armdp = 79;
                    armev = 36;
                    armhev = 108;
                    armdr = 43;
                    armhdr = 14;


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

                    armdp = 84;
                    armev = 38;
                    armhev = 114;
                    armdr = 46;
                    armhdr = 18;


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

                    armdp = 89;
                    armev = 40;
                    armhev = 120;
                    armdr = 49;
                    armhdr = 24;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
                }
            }

            if(armEnch == true & armIsBoss == false)
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

                    armdp = armDefdp +  4;
                    armev = armDefev + 1;
                    armhev = armDefhev + 3;
                    armdr = armDefdr + 3;
                    armhdr = armDefhdr;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
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

                    armdp = armDefdp + 4 + (armEnchLvl-1) * 3;
                    armev = armDefev +armEnchLvl * 1;
                    armhev = armDefhev + armEnchLvl * 3;
                    armdr = armDefdr +3 +(armEnchLvl-1) * 2;
                    armhdr = armDefhdr;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
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

                    armdp = armDefdp + 10 + (armEnchLvl - 3) * 3;
                    armev = armDefev + armEnchLvl * 1;
                    armhev = armDefhev + armEnchLvl * 3;
                    armdr = armDefdr + 7 + (armEnchLvl - 3) * 2;
                    armhdr = armDefhdr;


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

                    armdp = armDefdp + 14 + (armEnchLvl - 5) * 3;
                    armev = armDefev + armEnchLvl * 1;
                    armhev = armDefhev + armEnchLvl * 3;
                    armdr = armDefdr + 9 + (armEnchLvl - 5) * 2;
                    armhdr = armDefhdr;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
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

                    armdp = armDefdp + 49;
                    armev = armDefev + 17;
                    armhev = armDefhev + 55;
                    armdr = armDefdr + 32;
                    armhdr = armDefhdr + 1;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
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

                    armdp = armDefdp + 54;
                    armev = armDefev + 19;
                    armhev = armDefhev + 51;
                    armdr = armDefdr + 35;
                    armhdr = armDefhdr + 2;


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

                    armdp = armDefdp + 62;
                    armev = armDefev + 21;
                    armhev = armDefhev + 67;
                    armdr = armDefdr + 41;
                    armhdr = armDefhdr + 3;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
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

                    armdp = armDefdp + 62 + (armEnchLvl-18)  * 5;
                    armev = armDefev + 21 + (armEnchLvl - 18) * 2;
                    armhev = armDefhev + 67+ (armEnchLvl - 18) * 6;
                    armdr = armDefdr + 41+ (armEnchLvl - 18) * 3;
                    armhdr = armDefhdr + 3+ (armEnchLvl - 18) * 1;


                    cdp += armdp;
                    cev += armev;
                    chev += armhev;
                    cDR += armdr;
                    chdr += armhdr;
                    cMaxHP += armHP;
                    cMaxMP += armMP;
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


                armdp = armDefdp;
                armev = armDefev;
                armhev = armDefhev;
                armdr = armDefdr;
                armhdr = armDefhdr;
                armHP = armDefHP;
                armMP = armDefHP;


                cdp += armdp;
                cev += armev;
                chev += armhev;
                cDR += armdr;
                chdr += armhdr;
                cMaxHP += armHP;
                cMaxMP += armMP;
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


            if (helEnch == true & helIsBoss == true)
            {
                if (helEnchLvl >= 1 & helEnchLvl <= 15)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helRes;
                    cRes2 -= helRes;
                    cRes3 -= helRes;
                    cRes4 -= helRes;

                    heldp = helDefdp + helEnchLvl * 3;
                    helev = helDefev + helEnchLvl * 1;
                    helhev = helDefhev + helEnchLvl * 2;
                    heldr = helDefdr + helEnchLvl * 2;
                    helhdr = helDefhdr + helEnchLvl * 0;
                    helRes = helDefRes;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helRes;
                    cRes2 += helRes;
                    cRes3 += helRes;
                    cRes4 += helRes;
                }

                if (helEnchLvl == 16)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helRes;
                    cRes2 -= helRes;
                    cRes3 -= helRes;
                    cRes4 -= helRes;

                    heldp = helDefdp + 50;
                    helev = helDefev + 17;
                    helhev = helDefhev + 38;
                    heldr = helDefdr + 33;
                    helhdr = helDefhdr + 1;
                    helRes = helDefRes;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helRes;
                    cRes2 += helRes;
                    cRes3 += helRes;
                    cRes4 += helRes;
                }

                if (helEnchLvl == 17)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helRes;
                    cRes2 -= helRes;
                    cRes3 -= helRes;
                    cRes4 -= helRes;

                    heldp = helDefdp + 55;
                    helev = helDefev + 19;
                    helhev = helDefhev + 42;
                    heldr = helDefdr + 36;
                    if (helId == 0) helhdr = helDefhdr + 2;
                    else helhdr = helDefhdr + 1;
                    helRes = helDefRes;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helRes;
                    cRes2 += helRes;
                    cRes3 += helRes;
                    cRes4 += helRes;
                }

                if (helEnchLvl == 18)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helRes;
                    cRes2 -= helRes;
                    cRes3 -= helRes;
                    cRes4 -= helRes;

                    heldp = helDefdp + 63;
                    helev = helDefev + 21;
                    helhev = helDefhev + 46;
                    heldr = helDefdr + 42;
                    if (helId == 0) helhdr = helDefhdr + 4;
                    else helhdr = helDefhdr + 6;
                    helRes = helDefRes;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helRes;
                    cRes2 += helRes;
                    cRes3 += helRes;
                    cRes4 += helRes;
                }

                if (helEnchLvl == 19)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helRes;
                    cRes2 -= helRes;
                    cRes3 -= helRes;
                    cRes4 -= helRes;

                    heldp = helDefdp + 68;
                    helev = helDefev + 23;
                    helhev = helDefhev + 50;
                    heldr = helDefdr + 45;
                    if (helId == 0) helhdr = helDefhdr + 8;
                    else helhdr = helDefhdr + 11;
                    helRes = helDefRes;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helRes;
                    cRes2 += helRes;
                    cRes3 += helRes;
                    cRes4 += helRes;
                }

                if (helEnchLvl == 20)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;
                    cRes1 -= helRes;
                    cRes2 -= helRes;
                    cRes3 -= helRes;
                    cRes4 -= helRes;

                    heldp = helDefdp + 73;
                    helev = helDefev + 25;
                    helhev = helDefhev + 54;
                    heldr = helDefdr + 48;
                    if (helId == 0) helhdr = helDefhdr + 14;
                    else helhdr = helDefhdr + 17;
                    helRes = helDefRes;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                    cRes1 += helRes;
                    cRes2 += helRes;
                    cRes3 += helRes;
                    cRes4 += helRes;
                }

            }

            if (helEnch == true & helIsBoss == false)
            {
                if (helEnchLvl >= 1 & helEnchLvl <=2)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;

                    heldp = helDefdp + helEnchLvl * 3;
                    helev = helDefev + helEnchLvl * 1;
                    helhev = helDefhev + helEnchLvl * 3;
                    heldr = helDefdr + helEnchLvl * 2;
                    helhdr = helDefhdr;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                }

                if (helEnchLvl >= 3 & helEnchLvl <= 5)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;

                    heldp = helDefdp + 6 + (helEnchLvl - 2) * 3;
                    helev = helDefev + helEnchLvl * 1;
                    helhev = helDefhev + helEnchLvl * 3;
                    heldr = helDefdr + 4 + (helEnchLvl - 2) * 2;
                    helhdr = helDefhdr;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                }

                if (helEnchLvl >= 6 & helEnchLvl <= 15)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;

                    heldp = helDefdp + 12 + (helEnchLvl - 5) * 3;
                    helev = helDefev + helEnchLvl * 1;
                    helhev = helDefhev + helEnchLvl * 3;
                    heldr = helDefdr + 7 + (helEnchLvl - 5) * 2;
                    helhdr = helDefhdr;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                }

                if (helEnchLvl == 16)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;

                    heldp = helDefdp + 47 ;
                    helev = helDefev + 17;
                    helhev = helDefhev + 55;
                    heldr = helDefdr + 30;
                    helhdr = helDefhdr + 1;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                }

                if (helEnchLvl == 17)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;

                    heldp = helDefdp + 52;
                    helev = helDefev + 19;
                    helhev = helDefhev + 61;
                    heldr = helDefdr + 33;
                    helhdr = helDefhdr + 2;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                }

                if (helEnchLvl == 18)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;

                    heldp = helDefdp + 60;
                    helev = helDefev + 21;
                    helhev = helDefhev + 67;
                    heldr = helDefdr + 39;
                    helhdr = helDefhdr + 3;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
                }

                if (helEnchLvl >= 19 & helEnchLvl <= 20)
                {

                    cdp -= heldp;
                    cev -= helev;
                    chev -= helhev;
                    cDR -= heldr;
                    chdr -= helhdr;
                    cMaxHP -= helHP;

                    heldp = helDefdp + 60 + (helEnchLvl - 18) * 5;
                    helev = helDefev + 21 + (helEnchLvl - 18) * 2;
                    helhev = helDefhev + 67 + (helEnchLvl - 18) * 6;
                    heldr = helDefdr + 39 + (helEnchLvl - 18) * 3;
                    helhdr = helDefhdr + 3 + (helEnchLvl - 18) * 1;


                    cdp += heldp;
                    cev += helev;
                    chev += helhev;
                    cDR += heldr;
                    chdr += helhdr;
                    cMaxHP += helHP;
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
                cRes1 -= helRes;
                cRes2 -= helRes;
                cRes3 -= helRes;
                cRes4 -= helRes;



                heldp = helDefdp;
                helev = helDefev;
                helhev = helDefhev;
                heldr = helDefdr;
                helhdr = helDefhdr;
                helHP = helDefHP;
                helRes = helDefRes;


                cdp += heldp;
                cev += helev;
                chev += helhev;
                cDR += heldr;
                chdr += helhdr;
                cMaxHP += helHP;
                cRes1 += helRes;
                cRes2 += helRes;
                cRes3 += helRes;
                cRes4 += helRes;

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


            if (glovEnch == true & glovIsBoss == true)
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
                    if (glovId == 0) glovacc = glovDefacc + glovEnchLvl * 2;
                    else glovacc = glovDefacc;
                    glovev = glovDefev + glovEnchLvl * 1;
                    glovhev = glovDefhev + glovEnchLvl * 3;
                    glovdr = glovDefdr + glovEnchLvl * 1;
                    glovhdr = glovDefhdr;

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
                    else glovacc = glovDefacc + (glovEnchLvl-5) * 1;
                    glovev = glovDefev + glovEnchLvl * 1;
                    glovhev = glovDefhev + glovEnchLvl * 3;
                    glovdr = glovDefdr + glovEnchLvl * 1;
                    glovhdr = glovDefhdr;

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
                    else glovacc = glovDefacc + (glovEnchLvl - 5) * 1;

                    if (glovId == 0) glovev = glovDefev +17;
                    else  glovev = glovDefev + 18;

                    if (glovId == 0) glovhev = 54;
                    else glovhev = 61;

                    if (glovId == 0) glovdr = 19;
                    else glovdr = 18;

                    glovhdr = glovDefhdr + 1;

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
                    else glovacc = glovDefacc + (glovEnchLvl - 5) * 1;

                    if (glovId == 0) glovev = 20;
                    else glovev = glovDefev + 22;

                    if (glovId == 0) glovhev = 60;
                    else glovhev = 70;

                    if (glovId == 0) glovdr = 22;
                    else glovdr = 20;

                    if (glovId == 0) glovhdr = 7;
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

                    if (glovId == 0) glovacc = glovDefacc + glovEnchLvl * 2;
                    else glovacc = glovDefacc + (glovEnchLvl - 5) * 1;

                    if (glovId == 0) glovev = 22;
                    else glovev = glovDefev +25;

                    if (glovId == 0) glovhev = 66;
                    else glovhev = 79;

                    if (glovId == 0) glovdr = 28;
                    else glovdr = 25;

                    if (glovId == 0) glovhdr = 9;
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
                    else glovdp = 56;

                    if (glovId == 0) glovacc = glovDefacc + glovEnchLvl * 2;
                    else glovacc = glovDefacc + (glovEnchLvl - 5) * 1;

                    if (glovId == 0) glovev = 24;
                    else glovev = glovDefev + 29;

                    if (glovId == 0) glovhev = 72;
                    else glovhev = 91;

                    if (glovId == 0) glovdr = 31;
                    else glovdr = 27;

                    if (glovId == 0) glovhdr = 13;
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
                    else glovdp = 62;

                    if (glovId == 0) glovacc = glovDefacc + glovEnchLvl * 2;
                    else glovacc = glovDefacc + (glovEnchLvl - 5) * 1;

                    if (glovId == 0) glovev = 26;
                    else glovev = glovDefev + 33;

                    if (glovId == 0) glovhev = 78;
                    else glovhev = 103;

                    if (glovId == 0) glovdr = 34;
                    else glovdr = 29;

                    if (glovId == 0) glovhdr = 19;
                    else glovhdr = 17;

                    cdp += glovdp;
                    cacc += glovacc;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

            }

            if (glovEnch == true & glovIsBoss == false)
            {
                if (glovEnchLvl >= 1 & glovEnchLvl <= 15)
                {

                    cdp -= glovdp;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    glovdp = glovDefdp + glovEnchLvl * 2;
                    glovev = glovDefev + glovEnchLvl * 1;
                    glovhev = glovDefhev + glovEnchLvl * 3;
                    glovdr = glovDefdr + glovEnchLvl * 1;
                    glovhdr = glovDefhdr;


                    cdp += glovdp;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

                if (glovEnchLvl == 16)
                {

                    cdp -= glovdp;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    glovdp = glovDefdp + (glovEnchLvl -1) * 2 + 5;
                    glovev = glovDefev + (glovEnchLvl-1) * 1 + 2;
                    glovhev = glovDefhev + (glovEnchLvl-1) * 3 + 10;
                    glovdr = glovDefdr + (glovEnchLvl - 1) * 1 + 3;
                    glovhdr = glovDefhdr + 1;


                    cdp += glovdp;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

                if (glovEnchLvl ==17)
                {

                    cdp -= glovdp;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    glovdp = glovDefdp + 40;
                    glovev = glovDefev + 19;
                    glovhev = glovDefhev + 61;
                    glovdr = glovDefdr + 19;
                    glovhdr = glovDefhdr+2;


                    cdp += glovdp;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

                if (glovEnchLvl == 18)
                {

                    cdp -= glovdp;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    glovdp = glovDefdp + 48;
                    glovev = glovDefev + 21;
                    glovhev = glovDefhev + 67;
                    glovdr = glovDefdr + 27;
                    glovhdr = glovDefhdr + 3;


                    cdp += glovdp;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
                }

                if (glovEnchLvl >= 19 & glovEnchLvl <= 20)
                {

                    cdp -= glovdp;
                    cev -= glovev;
                    chev -= glovhev;
                    cDR -= glovdr;
                    chdr -= glovhdr;

                    glovdp = glovDefdp + 48 + (glovEnchLvl-18) * 5;
                    glovev = glovDefev + 21 + (glovEnchLvl - 18) * 2;
                    glovhev = glovDefhev + 67 + (glovEnchLvl - 18)*6;
                    glovdr = glovDefdr + 27 + (glovEnchLvl - 18) * 3;
                    glovhdr = glovDefhdr + 3 + (glovEnchLvl - 18)*1;


                    cdp += glovdp;
                    cev += glovev;
                    chev += glovhev;
                    cDR += glovdr;
                    chdr += glovhdr;
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




                glovdp = glovDefdp;
                glovacc = glovDefacc;
                glovev = glovDefev;
                glovhev = glovDefhev;
                glovdr = glovDefdr;
                glovhdr = glovDefhdr;


                cdp += glovdp;
                cacc += glovacc;
                cev += glovev;
                chev += glovhev;
                cDR += glovdr;
                chdr += glovhdr;


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


            if (shEnch == true & shIsBoss == true)
            {

                if (shEnchLvl >= 1 & shEnchLvl <= 15)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;

                    shdp = shDefdp + shEnchLvl * 3;
                    shev = shDefev + shEnchLvl * 2;
                    if (shId == 0) shhev = shDefhev + shEnchLvl * 4;
                    else shhev = shDefev + shEnchLvl * 2;

                    shdr = shDefdr + shEnchLvl * 1;

                    if (shId == 0) shhdr = shDefhdr;
                    else if (shId == 1 & shEnchLvl <= 5) shhdr = shDefhdr + shEnchLvl * 1;
                    else shhdr = shDefhdr + 5 + (shEnchLvl - 5) * 2;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                }

                if (shEnchLvl == 16)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;

                    shdp = shDefdp + 50;


                    shev = shDefev + shEnchLvl * 2;

                    if (shId == 0) shhev = shDefhev + 68;
                    else shhev = shDefhev + 34;

                    shdr = shDefdr + 18;

                    if (shId == 0) shhdr = 1;
                    else shhdr = shDefhdr + 28;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                }

                if (shEnchLvl == 17)
                {
                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;

                    shdp = shDefdp + 55;

                    shev = shDefev + shEnchLvl * 2;

                    if (shId == 0) shhev = shDefhev + 72;
                    else shhev = shDefhev + 36;

                    shdr = shDefdr + 21;

                    if (shId == 0) shhdr = 2;
                    else shhdr = shDefhdr + 31;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                }

                if (shEnchLvl == 18)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;

                    shdp = shDefdp + 63;

                    shev = shDefev + shEnchLvl * 2;

                    if (shId == 0) shhev = shDefhev + 76;
                    else shhev = shDefhev + 38;

                    shdr = shDefdr + 27;


                    if (shId == 0) shhdr = 4;
                    else shhdr = shDefhdr + 34;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                }

                if (shEnchLvl == 19)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;

                    shdp = shDefdp + 68;

                    shev = shDefev + shEnchLvl * 2;

                    if (shId == 0) shhev = shDefhev + 80;
                    else shhev = shDefhev + 40;

                    shdr = shDefdr + 30;

                    if (shId == 0) shhdr = 8;
                    else shhdr = shDefhdr + 37;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                }

                if (shEnchLvl == 20)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;

                    shdp = shDefdp + 73;

                    shev = shDefev + shEnchLvl * 2;

                    if (shId == 0) shhev = shDefhev + 84;
                    else shhev = shDefhev + 42;

                    shdr = shDefdr + 33;

                    if (shId == 0) shhdr = 14;
                    else shhdr = shDefhdr + 40;

                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
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

                    shdp = shDefdp + shEnchLvl * 2;
                    shev = shDefev + shEnchLvl * 1;
                    shhev = shDefhev + shEnchLvl * 3;
                    shdr = shDefdr + shEnchLvl * 1;
                    shhdr = shDefhdr;


                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                }

                if (shEnchLvl == 16)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;

                    shdp = shDefdp + (shEnchLvl - 1) * 2 + 5;
                    shev = shDefev + (shEnchLvl - 1) * 1 + 2;
                    shhev = shDefhev + (shEnchLvl - 1) * 3 + 10;
                    shdr = shDefdr + (shEnchLvl - 1) * 1 + 3;
                    shhdr = shDefhdr + 1;


                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                }

                if (shEnchLvl == 17)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;

                    shdp = shDefdp + 40;
                    shev = shDefev + 19;
                    shhev = shDefhev + 61;
                    shdr = shDefdr + 19;
                    shhdr = shDefhdr + 2;


                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                }

                if (shEnchLvl == 18)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;

                    shdp = shDefdp + 48;
                    shev = shDefev + 21;
                    shhev = shDefhev + 67;
                    shdr = shDefdr + 27;
                    shhdr = shDefhdr + 3;


                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                }

                if (shEnchLvl >= 19 & shEnchLvl <= 20)
                {

                    cdp -= shdp;
                    cev -= shev;
                    chev -= shhev;
                    cDR -= shdr;
                    chdr -= shhdr;

                    shdp = shDefdp + 48 + (shEnchLvl - 18) * 5;
                    shev = shDefev + 21 + (shEnchLvl - 18) * 2;
                    shhev = shDefhev + 67 + (shEnchLvl - 18) * 6;
                    shdr = shDefdr + 27 + (shEnchLvl - 18) * 3;
                    shhdr = shDefhdr + 3 + (shEnchLvl - 18) * 1;


                    cdp += shdp;
                    cev += shev;
                    chev += shhev;
                    cDR += shdr;
                    chdr += shhdr;
                }


            }

            if (shEnch == false | shEnch == true & shEnchLvl == 0)
            {

                cdp -= shdp;
                cev -= shev;
                chev -= shhev;
                cDR -= shdr;
                chdr -= shhdr;




                shdp = shDefdp;
                shev = shDefev;
                shhev = shDefhev;
                shdr = shDefdr;
                shhdr = shDefhdr;


                cdp += shdp;
                cev += shev;
                chev += shhev;
                cDR += shdr;
                chdr += shhdr;


            }
        }

        public void SetBonusCheck()
        {
            sb = sb - asb;
            sb = sb - hsb;

            if (armIsBoss == true) { asb = 1; }
            if (armIsBoss == false && asb > 0) { asb = asb - 1; }

            if (helIsBoss == true) { hsb = 1; }
            if (helIsBoss == false && hsb > 0) { hsb = hsb - 1; }


            sb = sb + asb;
            sb = sb + hsb;
        }

        
    }
}
