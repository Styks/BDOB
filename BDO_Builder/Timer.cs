using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDO_Builder
{
    public partial class TimerForm : Form
    {
        public TimerForm()
        {
            InitializeComponent();
        }

        public int FTS;
        public int sF;
        public int mF;
        public int sP;
        public int mP;

        private void TimerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) Application.Exit();
        }
        private void Food_Start_Click(object sender, EventArgs e)
        {
            if (Cron_rb.Checked == true)
            {
                sF = 0;
                mF = 120;
            }
            if (Other_rb.Checked == true) //Test
            {
                sF = 5; //0
                mF = 0; //30
            }
            Timer_Food.Start();
            Food_Start.Enabled = false;
            Food_panel.Enabled = false;
        }

        private void Food_Pause_Click(object sender, EventArgs e)
        {
            if (FTS == 1)
            {
                Timer_Food.Start();
                Food_Start.Enabled = false;
                Food_panel.Enabled = false;
            }
            if (FTS == 0)
            {
                Timer_Food.Stop();
                FTS = 1;
                Food_Start.Enabled = true;
                Food_panel.Enabled = true;
            }
        }

        private void Timer_Food_Tick(object sender, EventArgs e)
        {
            sF--;
            if (sF == -1)
            {
                mF--;
                sF = 59;
            }
            if (mF == -1 && sF == 59)
            {
                if (Cron_rb.Checked == true)
                {
                    sF = 0;
                    mF = 120;
                }
                if (Other_rb.Checked == true) //Test
                {
                    sF = 5;
                    mF = 0;
                }
            }
            if (mF == 0 && sF == 0)
            {
                //Play Sound
            }
            M_food_n.Text = mF.ToString();
            S_food_n.Text = sF.ToString();
            FTS = 0;
        }

    }
}

