namespace BDO_Builder
{
    partial class TimerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerForm));
            this.Food_name_lbl = new System.Windows.Forms.Label();
            this.Potion_name_lbl = new System.Windows.Forms.Label();
            this.M_food_n = new System.Windows.Forms.Label();
            this.S_food_n = new System.Windows.Forms.Label();
            this.M_potion_n = new System.Windows.Forms.Label();
            this.S_potion_n = new System.Windows.Forms.Label();
            this.Timer_Food = new System.Windows.Forms.Timer(this.components);
            this.Timer_Potion = new System.Windows.Forms.Timer(this.components);
            this.Food_Start = new System.Windows.Forms.Button();
            this.Back_btn = new System.Windows.Forms.Button();
            this.Cron_rb = new System.Windows.Forms.RadioButton();
            this.Food_panel = new System.Windows.Forms.Panel();
            this.TestF_rb = new System.Windows.Forms.RadioButton();
            this.Other_rb = new System.Windows.Forms.RadioButton();
            this.Food_Pause = new System.Windows.Forms.Button();
            this.Potion_panel = new System.Windows.Forms.Panel();
            this.TestP_rb = new System.Windows.Forms.RadioButton();
            this.p10_rb = new System.Windows.Forms.RadioButton();
            this.p5_rb = new System.Windows.Forms.RadioButton();
            this.p8_rb = new System.Windows.Forms.RadioButton();
            this.p15_rb = new System.Windows.Forms.RadioButton();
            this.Potion_Pause = new System.Windows.Forms.Button();
            this.Potion_Start = new System.Windows.Forms.Button();
            this.foodr_lbl = new System.Windows.Forms.Label();
            this.potionr_lbl = new System.Windows.Forms.Label();
            this.Info_btn = new System.Windows.Forms.Button();
            this.TopMostON_btn = new System.Windows.Forms.Button();
            this.TopMostOFF_btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Food_panel.SuspendLayout();
            this.Potion_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Food_name_lbl
            // 
            this.Food_name_lbl.AutoSize = true;
            this.Food_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.Food_name_lbl.Location = new System.Drawing.Point(21, 22);
            this.Food_name_lbl.Name = "Food_name_lbl";
            this.Food_name_lbl.Size = new System.Drawing.Size(46, 20);
            this.Food_name_lbl.TabIndex = 0;
            this.Food_name_lbl.Text = "Food";
            // 
            // Potion_name_lbl
            // 
            this.Potion_name_lbl.AutoSize = true;
            this.Potion_name_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.Potion_name_lbl.Location = new System.Drawing.Point(20, 153);
            this.Potion_name_lbl.Name = "Potion_name_lbl";
            this.Potion_name_lbl.Size = new System.Drawing.Size(56, 20);
            this.Potion_name_lbl.TabIndex = 1;
            this.Potion_name_lbl.Text = "Potion";
            // 
            // M_food_n
            // 
            this.M_food_n.AutoSize = true;
            this.M_food_n.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.M_food_n.Location = new System.Drawing.Point(85, 22);
            this.M_food_n.Name = "M_food_n";
            this.M_food_n.Size = new System.Drawing.Size(36, 20);
            this.M_food_n.TabIndex = 2;
            this.M_food_n.Text = "000";
            // 
            // S_food_n
            // 
            this.S_food_n.AutoSize = true;
            this.S_food_n.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.S_food_n.Location = new System.Drawing.Point(126, 22);
            this.S_food_n.Name = "S_food_n";
            this.S_food_n.Size = new System.Drawing.Size(27, 20);
            this.S_food_n.TabIndex = 3;
            this.S_food_n.Text = "00";
            // 
            // M_potion_n
            // 
            this.M_potion_n.AutoSize = true;
            this.M_potion_n.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.M_potion_n.Location = new System.Drawing.Point(94, 153);
            this.M_potion_n.Name = "M_potion_n";
            this.M_potion_n.Size = new System.Drawing.Size(27, 20);
            this.M_potion_n.TabIndex = 4;
            this.M_potion_n.Text = "00";
            // 
            // S_potion_n
            // 
            this.S_potion_n.AutoSize = true;
            this.S_potion_n.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.S_potion_n.Location = new System.Drawing.Point(126, 153);
            this.S_potion_n.Name = "S_potion_n";
            this.S_potion_n.Size = new System.Drawing.Size(27, 20);
            this.S_potion_n.TabIndex = 5;
            this.S_potion_n.Text = "00";
            // 
            // Timer_Food
            // 
            this.Timer_Food.Interval = 1000;
            this.Timer_Food.Tick += new System.EventHandler(this.Timer_Food_Tick);
            // 
            // Timer_Potion
            // 
            this.Timer_Potion.Interval = 1000;
            this.Timer_Potion.Tick += new System.EventHandler(this.Timer_Potion_Tick);
            // 
            // Food_Start
            // 
            this.Food_Start.Location = new System.Drawing.Point(88, 52);
            this.Food_Start.Name = "Food_Start";
            this.Food_Start.Size = new System.Drawing.Size(61, 23);
            this.Food_Start.TabIndex = 6;
            this.Food_Start.Text = "Start";
            this.Food_Start.UseVisualStyleBackColor = true;
            this.Food_Start.Click += new System.EventHandler(this.Food_Start_Click);
            // 
            // Back_btn
            // 
            this.Back_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Back_btn.Location = new System.Drawing.Point(213, 12);
            this.Back_btn.Name = "Back_btn";
            this.Back_btn.Size = new System.Drawing.Size(75, 23);
            this.Back_btn.TabIndex = 7;
            this.Back_btn.Text = "Back";
            this.Back_btn.UseVisualStyleBackColor = true;
            // 
            // Cron_rb
            // 
            this.Cron_rb.AutoSize = true;
            this.Cron_rb.Checked = true;
            this.Cron_rb.Location = new System.Drawing.Point(3, 3);
            this.Cron_rb.Name = "Cron_rb";
            this.Cron_rb.Size = new System.Drawing.Size(47, 17);
            this.Cron_rb.TabIndex = 8;
            this.Cron_rb.TabStop = true;
            this.Cron_rb.Text = "Cron";
            this.Cron_rb.UseVisualStyleBackColor = true;
            // 
            // Food_panel
            // 
            this.Food_panel.Controls.Add(this.TestF_rb);
            this.Food_panel.Controls.Add(this.Other_rb);
            this.Food_panel.Controls.Add(this.Cron_rb);
            this.Food_panel.Location = new System.Drawing.Point(22, 52);
            this.Food_panel.Name = "Food_panel";
            this.Food_panel.Size = new System.Drawing.Size(60, 72);
            this.Food_panel.TabIndex = 9;
            // 
            // TestF_rb
            // 
            this.TestF_rb.AutoSize = true;
            this.TestF_rb.Location = new System.Drawing.Point(3, 49);
            this.TestF_rb.Name = "TestF_rb";
            this.TestF_rb.Size = new System.Drawing.Size(53, 17);
            this.TestF_rb.TabIndex = 11;
            this.TestF_rb.Text = "TEST";
            this.TestF_rb.UseVisualStyleBackColor = true;
            // 
            // Other_rb
            // 
            this.Other_rb.AutoSize = true;
            this.Other_rb.Location = new System.Drawing.Point(3, 26);
            this.Other_rb.Name = "Other_rb";
            this.Other_rb.Size = new System.Drawing.Size(51, 17);
            this.Other_rb.TabIndex = 10;
            this.Other_rb.Text = "Other";
            this.Other_rb.UseVisualStyleBackColor = true;
            // 
            // Food_Pause
            // 
            this.Food_Pause.Location = new System.Drawing.Point(89, 78);
            this.Food_Pause.Name = "Food_Pause";
            this.Food_Pause.Size = new System.Drawing.Size(61, 23);
            this.Food_Pause.TabIndex = 10;
            this.Food_Pause.Text = "Pause";
            this.Food_Pause.UseVisualStyleBackColor = true;
            this.Food_Pause.Click += new System.EventHandler(this.Food_Pause_Click);
            // 
            // Potion_panel
            // 
            this.Potion_panel.Controls.Add(this.TestP_rb);
            this.Potion_panel.Controls.Add(this.p10_rb);
            this.Potion_panel.Controls.Add(this.p5_rb);
            this.Potion_panel.Controls.Add(this.p8_rb);
            this.Potion_panel.Controls.Add(this.p15_rb);
            this.Potion_panel.Location = new System.Drawing.Point(24, 182);
            this.Potion_panel.Name = "Potion_panel";
            this.Potion_panel.Size = new System.Drawing.Size(60, 117);
            this.Potion_panel.TabIndex = 11;
            // 
            // TestP_rb
            // 
            this.TestP_rb.AutoSize = true;
            this.TestP_rb.Location = new System.Drawing.Point(3, 95);
            this.TestP_rb.Name = "TestP_rb";
            this.TestP_rb.Size = new System.Drawing.Size(53, 17);
            this.TestP_rb.TabIndex = 14;
            this.TestP_rb.Text = "TEST";
            this.TestP_rb.UseVisualStyleBackColor = true;
            // 
            // p10_rb
            // 
            this.p10_rb.AutoSize = true;
            this.p10_rb.Location = new System.Drawing.Point(3, 26);
            this.p10_rb.Name = "p10_rb";
            this.p10_rb.Size = new System.Drawing.Size(56, 17);
            this.p10_rb.TabIndex = 12;
            this.p10_rb.Text = "10 min";
            this.p10_rb.UseVisualStyleBackColor = true;
            // 
            // p5_rb
            // 
            this.p5_rb.AutoSize = true;
            this.p5_rb.Location = new System.Drawing.Point(3, 72);
            this.p5_rb.Name = "p5_rb";
            this.p5_rb.Size = new System.Drawing.Size(50, 17);
            this.p5_rb.TabIndex = 11;
            this.p5_rb.Text = "5 min";
            this.p5_rb.UseVisualStyleBackColor = true;
            // 
            // p8_rb
            // 
            this.p8_rb.AutoSize = true;
            this.p8_rb.Location = new System.Drawing.Point(3, 49);
            this.p8_rb.Name = "p8_rb";
            this.p8_rb.Size = new System.Drawing.Size(50, 17);
            this.p8_rb.TabIndex = 10;
            this.p8_rb.Text = "8 min";
            this.p8_rb.UseVisualStyleBackColor = true;
            // 
            // p15_rb
            // 
            this.p15_rb.AutoSize = true;
            this.p15_rb.Checked = true;
            this.p15_rb.Location = new System.Drawing.Point(3, 3);
            this.p15_rb.Name = "p15_rb";
            this.p15_rb.Size = new System.Drawing.Size(56, 17);
            this.p15_rb.TabIndex = 8;
            this.p15_rb.TabStop = true;
            this.p15_rb.Text = "15 min";
            this.p15_rb.UseVisualStyleBackColor = true;
            // 
            // Potion_Pause
            // 
            this.Potion_Pause.Location = new System.Drawing.Point(92, 208);
            this.Potion_Pause.Name = "Potion_Pause";
            this.Potion_Pause.Size = new System.Drawing.Size(61, 23);
            this.Potion_Pause.TabIndex = 13;
            this.Potion_Pause.Text = "Pause";
            this.Potion_Pause.UseVisualStyleBackColor = true;
            this.Potion_Pause.Click += new System.EventHandler(this.Potion_Pause_Click);
            // 
            // Potion_Start
            // 
            this.Potion_Start.Location = new System.Drawing.Point(91, 182);
            this.Potion_Start.Name = "Potion_Start";
            this.Potion_Start.Size = new System.Drawing.Size(61, 23);
            this.Potion_Start.TabIndex = 12;
            this.Potion_Start.Text = "Start";
            this.Potion_Start.UseVisualStyleBackColor = true;
            this.Potion_Start.Click += new System.EventHandler(this.Potion_Start_Click);
            // 
            // foodr_lbl
            // 
            this.foodr_lbl.AutoSize = true;
            this.foodr_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.foodr_lbl.Location = new System.Drawing.Point(116, 21);
            this.foodr_lbl.Name = "foodr_lbl";
            this.foodr_lbl.Size = new System.Drawing.Size(14, 20);
            this.foodr_lbl.TabIndex = 14;
            this.foodr_lbl.Text = ":";
            // 
            // potionr_lbl
            // 
            this.potionr_lbl.AutoSize = true;
            this.potionr_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.potionr_lbl.Location = new System.Drawing.Point(116, 152);
            this.potionr_lbl.Name = "potionr_lbl";
            this.potionr_lbl.Size = new System.Drawing.Size(14, 20);
            this.potionr_lbl.TabIndex = 15;
            this.potionr_lbl.Text = ":";
            // 
            // Info_btn
            // 
            this.Info_btn.Location = new System.Drawing.Point(212, 41);
            this.Info_btn.Name = "Info_btn";
            this.Info_btn.Size = new System.Drawing.Size(75, 23);
            this.Info_btn.TabIndex = 16;
            this.Info_btn.Text = "Info";
            this.Info_btn.UseVisualStyleBackColor = true;
            this.Info_btn.Click += new System.EventHandler(this.Info_btn_Click);
            // 
            // TopMostON_btn
            // 
            this.TopMostON_btn.Location = new System.Drawing.Point(206, 264);
            this.TopMostON_btn.Name = "TopMostON_btn";
            this.TopMostON_btn.Size = new System.Drawing.Size(81, 23);
            this.TopMostON_btn.TabIndex = 17;
            this.TopMostON_btn.Text = "TopMostON";
            this.TopMostON_btn.UseVisualStyleBackColor = true;
            this.TopMostON_btn.Click += new System.EventHandler(this.TopMostON_btn_Click);
            // 
            // TopMostOFF_btn
            // 
            this.TopMostOFF_btn.Location = new System.Drawing.Point(206, 293);
            this.TopMostOFF_btn.Name = "TopMostOFF_btn";
            this.TopMostOFF_btn.Size = new System.Drawing.Size(81, 23);
            this.TopMostOFF_btn.TabIndex = 18;
            this.TopMostOFF_btn.Text = "TopMostOFF";
            this.TopMostOFF_btn.UseVisualStyleBackColor = true;
            this.TopMostOFF_btn.Visible = false;
            this.TopMostOFF_btn.Click += new System.EventHandler(this.TopMostOFF_btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(318, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 304);
            this.textBox1.TabIndex = 19;
            this.textBox1.Text = "NumLock 1 - TopMostOn\r\nNumLock 2 - TopMostOff";
            // 
            // TimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(299, 328);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TopMostOFF_btn);
            this.Controls.Add(this.TopMostON_btn);
            this.Controls.Add(this.Info_btn);
            this.Controls.Add(this.potionr_lbl);
            this.Controls.Add(this.foodr_lbl);
            this.Controls.Add(this.Potion_Pause);
            this.Controls.Add(this.Potion_Start);
            this.Controls.Add(this.Potion_panel);
            this.Controls.Add(this.Food_Pause);
            this.Controls.Add(this.Food_panel);
            this.Controls.Add(this.Back_btn);
            this.Controls.Add(this.Food_Start);
            this.Controls.Add(this.S_potion_n);
            this.Controls.Add(this.M_potion_n);
            this.Controls.Add(this.S_food_n);
            this.Controls.Add(this.M_food_n);
            this.Controls.Add(this.Potion_name_lbl);
            this.Controls.Add(this.Food_name_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimerForm";
            this.Text = "Buff Timer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TimerForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimerForm_KeyDown);
            this.Food_panel.ResumeLayout(false);
            this.Food_panel.PerformLayout();
            this.Potion_panel.ResumeLayout(false);
            this.Potion_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Food_name_lbl;
        private System.Windows.Forms.Label Potion_name_lbl;
        private System.Windows.Forms.Label M_food_n;
        private System.Windows.Forms.Label S_food_n;
        private System.Windows.Forms.Label M_potion_n;
        private System.Windows.Forms.Label S_potion_n;
        private System.Windows.Forms.Timer Timer_Food;
        private System.Windows.Forms.Timer Timer_Potion;
        private System.Windows.Forms.Button Food_Start;
        private System.Windows.Forms.Button Back_btn;
        private System.Windows.Forms.RadioButton Cron_rb;
        private System.Windows.Forms.Panel Food_panel;
        private System.Windows.Forms.RadioButton Other_rb;
        private System.Windows.Forms.Button Food_Pause;
        private System.Windows.Forms.RadioButton TestF_rb;
        private System.Windows.Forms.Panel Potion_panel;
        private System.Windows.Forms.RadioButton p10_rb;
        private System.Windows.Forms.RadioButton p5_rb;
        private System.Windows.Forms.RadioButton p8_rb;
        private System.Windows.Forms.RadioButton p15_rb;
        private System.Windows.Forms.Button Potion_Pause;
        private System.Windows.Forms.Button Potion_Start;
        private System.Windows.Forms.RadioButton TestP_rb;
        private System.Windows.Forms.Label foodr_lbl;
        private System.Windows.Forms.Label potionr_lbl;
        private System.Windows.Forms.Button Info_btn;
        private System.Windows.Forms.Button TopMostON_btn;
        private System.Windows.Forms.Button TopMostOFF_btn;
        private System.Windows.Forms.TextBox textBox1;
    }
}