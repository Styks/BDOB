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


        string sclass = "None";
        string chWeapon = "None";
        string chSubWeapon = "None";
        Image cimg;

        private void GearForm_btn_Click(object sender, EventArgs e)
        {
            GearForm gf = new GearForm
            {
                sclass = sclass, chWeapon = chWeapon , chSubWeapon = chSubWeapon
            };
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
            cimg = Warrior_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Warrior";
            Sclass_lbl.Text = sclass;
            chWeapon = "Longsword";
            chSubWeapon = "Shield";

        }

        private void Sorceress_btn_Click(object sender, EventArgs e)
        {
            cimg = Sorceress_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Sorceress";
            Sclass_lbl.Text = sclass;
            chWeapon = "Amulet";
            chSubWeapon = "Talisman";

        }

        private void Berserker_btn_Click(object sender, EventArgs e)
        {
            cimg = Berserker_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Berserker";
            Sclass_lbl.Text = sclass;
            chWeapon = "Axe";
            chSubWeapon = "Ornamental Knot";

        }

        private void Ranger_btn_Click(object sender, EventArgs e)
        {
            cimg = Ranger_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Ranger";
            Sclass_lbl.Text = sclass;
            chWeapon = "Longbow";
            chSubWeapon = "Dagger";
        }

        private void Tamer_btn_Click(object sender, EventArgs e)
        {
            cimg = Tamer_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Tamer";
            Sclass_lbl.Text = sclass;
            chWeapon = "Shortsword";
            chSubWeapon = "Trinket";

        }

        private void Valkyrie_btn_Click(object sender, EventArgs e)
        {
            cimg = Valkyrie_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Valkyrie";
            Sclass_lbl.Text = sclass;
            chWeapon = "Longsword";
            chSubWeapon = "Shield";
        }

        private void Musa_btn_Click(object sender, EventArgs e)
        {
            cimg = Musa_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Musa";
            Sclass_lbl.Text = sclass;
            chWeapon = "Blade";
            chSubWeapon = "Horn Bow";

        }

        private void Maehwa_btn_Click(object sender, EventArgs e)
        {
            cimg = Maehwa_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Maehwa";
            Sclass_lbl.Text = sclass;
            chWeapon = "Blade";
            chSubWeapon = "Horn Bow";
        }

        private void Witch_btn_Click(object sender, EventArgs e)
        {
            cimg = Witch_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Witch";
            Sclass_lbl.Text = sclass;
            chWeapon = "Staff";
            chSubWeapon = "Dagger";


        }

        private void Wizard_btn_Click(object sender, EventArgs e)
        {
            cimg = Wizard_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Wizard";
            Sclass_lbl.Text = sclass;
            chWeapon = "Staff";
            chSubWeapon = "Dagger";

        }

        private void Kunoichi_btn_Click(object sender, EventArgs e)
        {
            cimg = Kunoichi_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Kunoichi";
            Sclass_lbl.Text = sclass;
            chWeapon = "Shortsword";
            chSubWeapon = "Kunai and Shuriken";

        }

        private void Class_Ninja_btn_Click(object sender, EventArgs e)
        {
            cimg = Ninja_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Ninja";
            Sclass_lbl.Text = sclass;
            chWeapon = "Shortsword";
            chSubWeapon = "Kunai and Shuriken";
        }

        private void DK_btn_Click(object sender, EventArgs e)
        {
            cimg = DK_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Dark Knight";
            Sclass_lbl.Text = sclass;
            chWeapon = "Kriegmesser";
            chSubWeapon = "Ornamental Knot";
        }

        private void Striker_btn_Click(object sender, EventArgs e)
        {
            cimg = Striker_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Striker";
            Sclass_lbl.Text = sclass;
            chWeapon = "Gauntlet";
            chSubWeapon = "Vambrace";
        }

        private void Mystic_btn_Click(object sender, EventArgs e)
        {
            cimg = Mystic_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Mystic";
            Sclass_lbl.Text = sclass;
            chWeapon = "Gauntlet";
            chSubWeapon = "Vambrace";
        }

        private void Lahn_btn_Click(object sender, EventArgs e)
        {
            cimg = Lahn_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Lahn";
            Sclass_lbl.Text = sclass;
            chWeapon = "Crescent Pendulum";
            chSubWeapon = "Noble Sword";
        }

        private void Archer_btn_Click(object sender, EventArgs e)
        {
            cimg = Archer_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Archer";
            Sclass_lbl.Text = sclass;
            chWeapon = "Crossbow";
            chSubWeapon = "Ra'ghon";

        }

        private void Shai_btn_Click(object sender, EventArgs e)
        {
            cimg = Shai_btn.BackgroundImage;
            Cimg_pb.BackgroundImage = cimg;
            sclass = "Shai";
            Sclass_lbl.Text = sclass;
            chWeapon = "Florang";
            chSubWeapon = "Vitclari";
        }

        private void SkillTreeForm_btn_Click(object sender, EventArgs e)
        {
            SkillTreeForm stf = new SkillTreeForm
            {
                sclass = sclass
            };
            Image cimg = Cimg_pb.BackgroundImage;
            stf.cimg = cimg;
            Hide();
            if (stf.ShowDialog() == DialogResult.Cancel)
            {
                Show();
                stf.Close();
            }
        }

        private void BuffTimerForm_btn_Click(object sender, EventArgs e)
        {
            TimerForm tf = new TimerForm
            {

            };

            Hide();
            if (tf.ShowDialog() == DialogResult.Cancel)
            {
                Show();
                tf.Close();
            }
        }
    }
}