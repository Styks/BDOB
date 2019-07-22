using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BDO_Builder
{
    public partial class TimerForm : Form
    {
        public TimerForm()
        {
            InitializeComponent();
        }

        public int FTS; //Food timer stop check
        public int PTS; //Potion timer stop check
        public int sF; //Food sec
        public int mF; //Food min
        public int sP; //Potion sec
        public int mP; //Potion min

        private void TimerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) Application.Exit();
        }

        private void Food_Start_Click(object sender, EventArgs e) //Food
        {
            if (Cron_rb.Checked == true)
            {
                sF = 3;
                mF = 120;
            }
            if (Other_rb.Checked == true)
            {
                sF = 3;
                mF = 30;
            }
            if (TestF_rb.Checked == true) //Test
            {
                sF = 5;
                mF = 0;
            }
            Timer_Food.Start();
            Food_Start.Enabled = false;
            Food_panel.Enabled = false;
        }

        private void Food_Pause_Click(object sender, EventArgs e) //Food
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

        private void Timer_Food_Tick(object sender, EventArgs e) //Food
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
                    sF = 3;
                    mF = 120;
                }
                if (Other_rb.Checked == true)
                {
                    sF = 3;
                    mF = 30;
                }
                if (TestF_rb.Checked == true) //Test
                {
                    sF = 5;
                    mF = 0;
                }
            }
            if (mF == 0 && sF == 0)
            {
                //Play Sound
                //SystemSounds.Exclamation.Play();
                SoundPlayer player = new SoundPlayer();
                player.Stream = Properties.Resources.Sound_1;
                player.Play();
            }
            M_food_n.Text = mF.ToString();
            S_food_n.Text = sF.ToString();
            FTS = 0;
        }

        private void Potion_Start_Click(object sender, EventArgs e) //Potion
        {
            if (p15_rb.Checked == true)
            {
                sP = 3;
                mP = 15;
            }
            if (p10_rb.Checked == true)
            {
                sP = 3;
                mP = 10;
            }
            if (p8_rb.Checked == true)
            {
                sP = 3;
                mP = 8;
            }
            if (p5_rb.Checked == true)
            {
                sP = 3;
                mP = 5;
            }
            if (TestP_rb.Checked == true) //Test
            {
                sP = 5;
                mP = 0;
            }
            Timer_Potion.Start();
            Potion_Start.Enabled = false;
            Potion_panel.Enabled = false;
        }

        private void Potion_Pause_Click(object sender, EventArgs e) //Potion
        {
            if (PTS == 1)
            {
                Timer_Potion.Start();
                Potion_Start.Enabled = false;
                Potion_panel.Enabled = false;
            }
            if (PTS == 0)
            {
                Timer_Potion.Stop();
                PTS = 1;
                Potion_Start.Enabled = true;
                Potion_panel.Enabled = true;
            }
        }

        private void Timer_Potion_Tick(object sender, EventArgs e) //Potion
        {
            sP--;
            if (sP == -1)
            {
                mP--;
                sP = 59;
            }
            if (mP == -1 && sP == 59)
            {
                if (p15_rb.Checked == true)
                {
                    sP = 3;
                    mP = 15;
                }
                if (p10_rb.Checked == true)
                {
                    sP = 3;
                    mP = 10;
                }
                if (p8_rb.Checked == true)
                {
                    sP = 3;
                    mP = 8;
                }
                if (p5_rb.Checked == true)
                {
                    sP = 3;
                    mP = 5;
                }
                if (TestP_rb.Checked == true) //Test
                {
                    sP = 5;
                    mP = 0;
                }
            }
            if (mP == 0 && sP == 0)
            {
                //Play Sound
                SystemSounds.Beep.Play();
                //SoundPlayer player = new SoundPlayer();
                //player.Stream = Properties.Resources.Sound_2;
                //player.Play();
            }
            M_potion_n.Text = mP.ToString();
            S_potion_n.Text = sP.ToString();
            PTS = 0;
        }

        private void TopMostON_btn_Click(object sender, EventArgs e)
        {
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.Gray;
            TransparencyKey = Color.Gray;
            Back_btn.Visible = false;
            Info_btn.Visible = false;
            //Food_Start.Visible = false;
            Food_Pause.Visible = false;
            Food_panel.Visible = false;
            //Potion_Start.Visible = false;
            Potion_Pause.Visible = false;
            Potion_panel.Visible = false;
            TopMostON_btn.Visible = false;
            TopMostOFF_btn.Visible = true;
        }

        private void TopMostOFF_btn_Click(object sender, EventArgs e)
        {
            TopMost = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            BackColor = Color.White;
            TransparencyKey = Color.Empty;
            Back_btn.Visible = true;
            Info_btn.Visible = true;
            //Food_Start.Visible = true;
            Food_Pause.Visible = true;
            Food_panel.Visible = true;
            //Potion_Start.Visible = true;
            Potion_Pause.Visible = true;
            Potion_panel.Visible = true;
            TopMostON_btn.Visible = true;
            TopMostOFF_btn.Visible = false;
        }
    }
}

