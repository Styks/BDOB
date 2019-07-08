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

        public int beltap; //Betl AP
        public int beltev; // Belt Evasion
        public int beltacc;//Belt Accuracy
        public int beltdp; //Belt DP
        public int beltResis; // Belt Resists
        public string Type; // Item type


        public void BeltState(int AP, int DP, int Acc, int Ev, int Res)
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
            beltap = AP;
            beltdp = DP;
            beltacc = Acc;
            beltev = Ev;
            beltResis = Res;
            cap += beltap;
            caap += beltap;
            cdp += beltdp;
            cev += beltev;
            cacc += beltacc;
            cRes1 += beltResis;
            cRes2 += beltResis;
            cRes3 += beltResis;
            cRes4 += beltResis;

        }

    }
}
