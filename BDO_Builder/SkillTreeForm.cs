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
    public partial class SkillTreeForm : Form
    {
        public SkillTreeForm()
        {
            InitializeComponent();
        }

        public string sclass;
        public Image cimg;

        private void SkillTreeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) Application.Exit();
        }

        private void SkillTreeForm_Load(object sender, EventArgs e)
        {
            Sclass_lbl.Text = sclass;
            Class_pic.BackgroundImage = cimg;
        }
    }
}
