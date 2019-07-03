namespace BDO_Builder
{
    partial class GearForm
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
            this.Back_btn = new System.Windows.Forms.Button();
            this.Sclass_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Back_btn
            // 
            this.Back_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Back_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Back_btn.Location = new System.Drawing.Point(713, 12);
            this.Back_btn.Name = "Back_btn";
            this.Back_btn.Size = new System.Drawing.Size(75, 23);
            this.Back_btn.TabIndex = 0;
            this.Back_btn.Text = "Back";
            this.Back_btn.UseVisualStyleBackColor = true;
            // 
            // Sclass_lbl
            // 
            this.Sclass_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Sclass_lbl.AutoSize = true;
            this.Sclass_lbl.Location = new System.Drawing.Point(732, 47);
            this.Sclass_lbl.Name = "Sclass_lbl";
            this.Sclass_lbl.Size = new System.Drawing.Size(32, 13);
            this.Sclass_lbl.TabIndex = 1;
            this.Sclass_lbl.Text = "Class";
            // 
            // GearForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Sclass_lbl);
            this.Controls.Add(this.Back_btn);
            this.Name = "GearForm";
            this.Text = "GearForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GearForm_FormClosing);
            this.Load += new System.EventHandler(this.GearForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Back_btn;
        private System.Windows.Forms.Label Sclass_lbl;
    }
}