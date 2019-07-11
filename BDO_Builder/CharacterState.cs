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
    }
}
