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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        string sclass = "Select class";  

        private void GearForm_btn_Click(object sender, EventArgs e)
        {
            GearForm gf = new GearForm();
            gf.sclass = sclass;
            Hide();
            if (gf.ShowDialog() == DialogResult.Cancel)
            {
                Show();
                gf.Close();
            }           
        }

        private void Warrior_btn_Click(object sender, EventArgs e)
        {
            sclass = "Warrior";
            Sclass_lbl.Text = sclass;
        }

        private void Sorceress_btn_Click(object sender, EventArgs e)
        {
            sclass = "Sorceress";
            Sclass_lbl.Text = sclass;
        }

        private void Berserker_btn_Click(object sender, EventArgs e)
        {
            sclass = "Berserker";
            Sclass_lbl.Text = sclass;
        }

        private void Ranger_btn_Click(object sender, EventArgs e)
        {
            sclass = "Ranger";
            Sclass_lbl.Text = sclass;
        }

        private void Tamer_btn_Click(object sender, EventArgs e)
        {
            sclass = "Tamer";
            Sclass_lbl.Text = sclass;
        }

        private void Valkyrie_btn_Click(object sender, EventArgs e)
        {
            sclass = "Valkyrie";
            Sclass_lbl.Text = sclass;
        }

        private void Musa_btn_Click(object sender, EventArgs e)
        {
            sclass = "Musa";
            Sclass_lbl.Text = sclass;
        }

        private void Maehwa_btn_Click(object sender, EventArgs e)
        {
            sclass = "Maehwa";
            Sclass_lbl.Text = sclass;
        }

        private void Witch_btn_Click(object sender, EventArgs e)
        {
            sclass = "Witch";
            Sclass_lbl.Text = sclass;
        }

        private void Wizard_btn_Click(object sender, EventArgs e)
        {
            sclass = "Wizard";
            Sclass_lbl.Text = sclass;
        }

        private void Kunoichi_btn_Click(object sender, EventArgs e)
        {
            sclass = "Kunoichi";
            Sclass_lbl.Text = sclass;
        }

        private void Class_Ninja_btn_Click(object sender, EventArgs e)
        {
            sclass = "Ninja";
            Sclass_lbl.Text = sclass;
        }

        private void DK_btn_Click(object sender, EventArgs e)
        {
            sclass = "Dark Knight";
            Sclass_lbl.Text = sclass;
        }

        private void Striker_btn_Click(object sender, EventArgs e)
        {
            sclass = "Striker";
            Sclass_lbl.Text = sclass;
        }

        private void Mystic_btn_Click(object sender, EventArgs e)
        {
            sclass = "Mystic";
            Sclass_lbl.Text = sclass;
        }

        private void Lahn_btn_Click(object sender, EventArgs e)
        {
            sclass = "Lahn";
            Sclass_lbl.Text = sclass;
        }

        private void Archer_btn_Click(object sender, EventArgs e)
        {
            sclass = "Archer";
            Sclass_lbl.Text = sclass;
        }

        private void Shai_btn_Click(object sender, EventArgs e)
        {
            sclass = "Shai";
            Sclass_lbl.Text = sclass;
        }
    }
}