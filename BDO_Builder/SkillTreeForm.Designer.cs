namespace BDO_Builder
{
    partial class SkillTreeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkillTreeForm));
            this.Back_btn = new System.Windows.Forms.Button();
            this.Sclass_lbl = new System.Windows.Forms.Label();
            this.Class_pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Class_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // Back_btn
            // 
            this.Back_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Back_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Back_btn.Location = new System.Drawing.Point(992, 12);
            this.Back_btn.Name = "Back_btn";
            this.Back_btn.Size = new System.Drawing.Size(75, 23);
            this.Back_btn.TabIndex = 0;
            this.Back_btn.Text = "Back";
            this.Back_btn.UseVisualStyleBackColor = true;
            // 
            // Sclass_lbl
            // 
            this.Sclass_lbl.Location = new System.Drawing.Point(13, 85);
            this.Sclass_lbl.Name = "Sclass_lbl";
            this.Sclass_lbl.Size = new System.Drawing.Size(70, 15);
            this.Sclass_lbl.TabIndex = 1;
            this.Sclass_lbl.Text = "None";
            this.Sclass_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Class_pic
            // 
            this.Class_pic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Class_pic.BackgroundImage")));
            this.Class_pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Class_pic.Location = new System.Drawing.Point(12, 12);
            this.Class_pic.Name = "Class_pic";
            this.Class_pic.Size = new System.Drawing.Size(70, 70);
            this.Class_pic.TabIndex = 2;
            this.Class_pic.TabStop = false;
            // 
            // SkillTreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1079, 629);
            this.Controls.Add(this.Class_pic);
            this.Controls.Add(this.Sclass_lbl);
            this.Controls.Add(this.Back_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SkillTreeForm";
            this.Text = "Skill Tree";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SkillTreeForm_FormClosing);
            this.Load += new System.EventHandler(this.SkillTreeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Class_pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Back_btn;
        private System.Windows.Forms.Label Sclass_lbl;
        private System.Windows.Forms.PictureBox Class_pic;
    }
}