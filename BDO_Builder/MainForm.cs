﻿using System;
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
            Image cimg = Cimg_pb.BackgroundImage;
            gf.cimg = cimg;
            Hide();
            if (gf.ShowDialog() == DialogResult.Cancel)
            {
                Show();
                gf.Close();
            }           
        }

        private void Warrior_btn_Click(object sender, EventArgs e)
        {
            Image cimg = Warrior_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Warrior";
            Sclass_lbl.Text = sclass;
        }

        private void Sorceress_btn_Click(object sender, EventArgs e)
        {
            Image cimg = Sorceress_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Sorceress";
            Sclass_lbl.Text = sclass;
        }

        private void Berserker_btn_Click(object sender, EventArgs e)
        {
            Image cimg = Berserker_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Berserker";
            Sclass_lbl.Text = sclass;
        }

        private void Ranger_btn_Click(object sender, EventArgs e)
        {
            Image cimg = Ranger_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Ranger";
            Sclass_lbl.Text = sclass;
        }

        private void Tamer_btn_Click(object sender, EventArgs e)
        {
            Image cimg = Tamer_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Tamer";
            Sclass_lbl.Text = sclass;
        }

        private void Valkyrie_btn_Click(object sender, EventArgs e)
        {
            Image cimg = Valkyrie_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Valkyrie";
            Sclass_lbl.Text = sclass;
        }

        private void Musa_btn_Click(object sender, EventArgs e)
        {
            Image cimg = Musa_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Musa";
            Sclass_lbl.Text = sclass;
        }

        private void Maehwa_btn_Click(object sender, EventArgs e)
        {
            Image cimg = Maehwa_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Maehwa";
            Sclass_lbl.Text = sclass;
        }

        private void Witch_btn_Click(object sender, EventArgs e)
        {
            Image cimg = Witch_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Witch";
            Sclass_lbl.Text = sclass;
        }

        private void Wizard_btn_Click(object sender, EventArgs e)
        {
            Image cimg = Wizard_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Wizard";
            Sclass_lbl.Text = sclass;
        }

        private void Kunoichi_btn_Click(object sender, EventArgs e)
        {
            Image cimg = Kunoichi_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Kunoichi";
            Sclass_lbl.Text = sclass;
        }

        private void Class_Ninja_btn_Click(object sender, EventArgs e)
        {
            Image cimg = Ninja_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Ninja";
            Sclass_lbl.Text = sclass;
        }

        private void DK_btn_Click(object sender, EventArgs e)
        {
            Image cimg = DK_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Dark Knight";
            Sclass_lbl.Text = sclass;
        }

        private void Striker_btn_Click(object sender, EventArgs e)
        {
            Image cimg = Striker_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Striker";
            Sclass_lbl.Text = sclass;
        }

        private void Mystic_btn_Click(object sender, EventArgs e)
        {
            Image cimg = Mystic_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Mystic";
            Sclass_lbl.Text = sclass;
        }

        private void Lahn_btn_Click(object sender, EventArgs e)
        {
            Image cimg = Lahn_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Lahn";
            Sclass_lbl.Text = sclass;
        }

        private void Archer_btn_Click(object sender, EventArgs e)
        {
            Image cimg = Archer_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Archer";
            Sclass_lbl.Text = sclass;
        }

        private void Shai_btn_Click(object sender, EventArgs e)
        {
            Image cimg = Shai_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Shai";
            Sclass_lbl.Text = sclass;
        }
    }
}