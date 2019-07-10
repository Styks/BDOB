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
        public int beltEnchLvl = 1; // Belt's enchant level
        public bool beltEnch;

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
        public int neckEnchLvl = 1; // Neck's enchant level
        public bool neckEnch;

        readonly SqlCommand cmd = Base_Connect.Connection.CreateCommand();
        

        public void BeltState(int AP, int DP, int Acc, int Ev, int Res, int DR, int HP, int Wg,int Ench)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Belts where Id='" + beltId.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            if (beltEnch == true & beltEnchLvl >= 1)
            {
                cap -= beltap + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["APsh"]);
                caap -= beltap + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["APsh"]);
                cdp -= beltdp + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["DPsh"]);
                cev -= beltev + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Evsh"]);
                cacc -= beltacc + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Accsh"]);
                cRes1 -= beltResis + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Ressh"]);
                cRes2 -= beltResis + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Ressh"]);
                cRes3 -= beltResis + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Ressh"]);
                cRes4 -= beltResis + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Ressh"]);
                cDR -= beltDR + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["DRsh"]);
                cMaxHP -= beltHP + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["HPsh"]);
                cWeight -= beltWeight + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Wgsh"]);


                beltap = AP;
                beltdp = DP;
                beltacc = Acc;
                beltev = Ev;
                beltResis = Res;
                beltDR = DR;
                beltHP = HP;
                beltWeight = Wg;
                beltEnchLvl = Ench;

                cap += beltap + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["APsh"]);
                caap += beltap + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["APsh"]);
                cdp += beltdp + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["DPsh"]);
                cev += beltev + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Evsh"]);
                cacc += beltacc + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Accsh"]);
                cRes1 += beltResis + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Ressh"]);
                cRes2 += beltResis + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Ressh"]);
                cRes3 += beltResis + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Ressh"]);
                cRes4 += beltResis + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Ressh"]);
                cDR += beltDR + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["DRsh"]);
                cMaxHP += beltHP + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["HPsh"]);
                cWeight += beltWeight + beltEnchLvl * Convert.ToInt32(dt.Rows[0]["Wgsh"]);
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


                beltap = AP;
                beltdp = DP;
                beltacc = Acc;
                beltev = Ev;
                beltResis = Res;
                beltDR = DR;
                beltHP = HP;
                beltWeight = Wg;
                beltEnchLvl = Ench;

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

        public void NeckState(int AP, int DP, int Acc, int Ev, int AllRes, int DR, int SSF, int KB, int Grap, int KF, int HP, int Ench)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Neck where Id='" + neckId.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (neckEnch == true & neckEnchLvl >= 1)
            {
                cap -= neckap + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["APSh"]);
                caap -= neckap + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["APSh"]);
                cdp -= neckdp + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["DPSh"]);
                cev -= neckev + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["EvSh"]);
                cacc -= neckacc + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["AccuracySh"]);
                cRes1 -= neckSSF + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["SSFSh"]);
                cRes2 -= neckKB + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["KBSh"]);
                cRes3 -= neckG + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["GrapSh"]);
                cRes4 -= neckKF + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["KFSh"]);
                cDR -= neckDR + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["DRSh"]);
                cRes1 -= neckAllRes + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["AllResSh"]);
                cRes2 -= neckAllRes + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["AllResSh"]);
                cRes3 -= neckAllRes + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["AllResSh"]);
                cRes4 -= neckAllRes + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["AllResSh"]);


                neckap = AP;
                neckdp = DP;
                neckacc = Acc;
                neckev = Ev;
                neckAllRes = AllRes;
                neckDR = DR;
                neckSSF = SSF;
                neckKB = KB;
                neckG = Grap;
                neckKF = KF;
                neckHP = HP;
                neckEnchLvl = Ench;

                cap += neckap + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["APSh"]);
                caap += neckap + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["APSh"]);
                cdp += neckdp + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["DPSh"]);
                cev += neckev + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["EvSh"]);
                cacc += neckacc + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["AccuracySh"]);
                cRes1 += neckSSF + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["SSFSh"]);
                cRes2 += neckKB + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["KBSh"]);
                cRes3 += neckG + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["GrapSh"]);
                cRes4 += neckKF + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["KFSh"]);
                cDR += neckDR + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["DRSh"]);
                cRes1 += neckAllRes + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["AllResSh"]);
                cRes2 += neckAllRes + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["AllResSh"]);
                cRes3 += neckAllRes + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["AllResSh"]);
                cRes4 += neckAllRes + neckEnchLvl * Convert.ToInt32(dt.Rows[0]["AllResSh"]);
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

                neckap = AP;
                neckdp = DP;
                neckacc = Acc;
                neckev = Ev;
                neckAllRes = AllRes;
                neckDR = DR;
                neckSSF = SSF;
                neckKB = KB;
                neckG = Grap;
                neckKF = KF;
                neckHP = HP;
                neckEnchLvl = Ench;

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
