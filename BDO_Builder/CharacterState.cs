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

        public void BeltState(int AP, int DP, int Acc, int Ev, int Res, int DR, int HP, int Wg)
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

        public void NeckState(int AP, int DP, int Acc, int Ev, int AllRes, int DR, int SSF, int KB, int Grap, int KF, int HP)
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
