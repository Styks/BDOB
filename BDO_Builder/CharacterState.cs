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
        
        public int sgn; //Selected Gear
        public int cdp; //DP
        public int cap; //AP
        public int caap; //AAP
        public int cev;// Evasion
        public int cacc;//Accuracy
        public int cRes1 = 20;// Resists: Stun/Stiffness/Freezing
        public int cRes2 = 20;// Resists: Knockdown/Bound
        public int cRes3 = 20;// Resists: Grapple
        public int cRes4 = 20;// Resists: Knockback/Floating
        public int cDR;

        public int beltap; //Betl AP
        public int beltev; // Belt Evasion
        public int beltacc;//Belt Accuracy
        public int beltdp; //Belt DP
        public int beltResis; // Belt Resists
        public int beltDR; //Belt DR

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

        public string Type; // Item type


        public void BeltState(int AP, int DP, int Acc, int Ev, int Res, int DR)
        {
            cap -= beltap;
            caap -= beltap;
            cdp -=beltdp;
            cev -=beltev;
            cacc -=beltacc;
            cRes1 -=beltResis;
            cRes2 -=beltResis;
            cRes3 -=beltResis;
            cRes4 -=beltResis;
            cDR -= beltDR;
            beltap = AP;
            beltdp = DP;
            beltacc = Acc;
            beltev = Ev;
            beltResis = Res;
            beltDR = DR;
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
        }

        public void NeckState(int AP, int DP, int Acc, int Ev, int AllRes, int DR, int SSF, int KB, int Grap, int KF)
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

        }

    }
}
