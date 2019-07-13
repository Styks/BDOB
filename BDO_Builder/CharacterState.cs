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

    }
}
