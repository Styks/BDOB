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
            this.Food_name_lbl = new System.Windows.Forms.Label();
            this.Potion_name_lbl = new System.Windows.Forms.Label();
            this.M_food_n = new System.Windows.Forms.Label();
            this.S_food_n = new System.Windows.Forms.Label();
            this.M_potion_n = new System.Windows.Forms.Label();
            this.S_potion_n = new System.Windows.Forms.Label();
            this.Timer_Food = new System.Windows.Forms.Timer(this.components);
            this.Timer_Potion_15 = new System.Windows.Forms.Timer(this.components);
            this.Food_Start = new System.Windows.Forms.Button();
            this.Back_btn = new System.Windows.Forms.Button();
            this.Cron_rb = new System.Windows.Forms.RadioButton();
            this.Food_panel = new System.Windows.Forms.Panel();
            this.Other_rb = new System.Windows.Forms.RadioButton();
            this.Food_Pause = new System.Windows.Forms.Button();
            this.Food_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Food_name_lbl
            // 
            this.Food_name_lbl.AutoSize = true;
            this.Food_name_lbl.Location = new System.Drawing.Point(44, 48);
            this.Food_name_lbl.Name = "Food_name_lbl";
            this.Food_name_lbl.Size = new System.Drawing.Size(31, 13);
            this.Food_name_lbl.TabIndex = 0;
            this.Food_name_lbl.Text = "Food";
            // 
            // Potion_name_lbl
            // 
            this.Potion_name_lbl.AutoSize = true;
            this.Potion_name_lbl.Location = new System.Drawing.Point(44, 219);
            this.Potion_name_lbl.Name = "Potion_name_lbl";
            this.Potion_name_lbl.Size = new System.Drawing.Size(37, 13);
            this.Potion_name_lbl.TabIndex = 1;
            this.Potion_name_lbl.Text = "Potion";
            // 
            // M_food_n
            // 
            this.M_food_n.AutoSize = true;
            this.M_food_n.Location = new System.Drawing.Point(129, 48);
            this.M_food_n.Name = "M_food_n";
            this.M_food_n.Size = new System.Drawing.Size(13, 13);
            this.M_food_n.TabIndex = 2;
            this.M_food_n.Text = "0";
            // 
            // S_food_n
            // 
            this.S_food_n.AutoSize = true;
            this.S_food_n.Location = new System.Drawing.Point(158, 48);
            this.S_food_n.Name = "S_food_n";
            this.S_food_n.Size = new System.Drawing.Size(13, 13);
            this.S_food_n.TabIndex = 3;
            this.S_food_n.Text = "0";
            // 
            // M_potion_n
            // 
            this.M_potion_n.AutoSize = true;
            this.M_potion_n.Location = new System.Drawing.Point(46, 265);
            this.M_potion_n.Name = "M_potion_n";
            this.M_potion_n.Size = new System.Drawing.Size(13, 13);
            this.M_potion_n.TabIndex = 4;
            this.M_potion_n.Text = "0";
            // 
            // S_potion_n
            // 
            this.S_potion_n.AutoSize = true;
            this.S_potion_n.Location = new System.Drawing.Point(111, 265);
            this.S_potion_n.Name = "S_potion_n";
            this.S_potion_n.Size = new System.Drawing.Size(13, 13);
            this.S_potion_n.TabIndex = 5;
            this.S_potion_n.Text = "0";
            // 
            // Timer_Food
            // 
            this.Timer_Food.Interval = 1000;
            this.Timer_Food.Tick += new System.EventHandler(this.Timer_Food_Tick);
            // 
            // Timer_Potion_15
            // 
            this.Timer_Potion_15.Interval = 1000;
            // 
            // Food_Start
            // 
            this.Food_Start.Location = new System.Drawing.Point(109, 73);
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
            this.Back_btn.Location = new System.Drawing.Point(543, 48);
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
            this.Food_panel.Controls.Add(this.Other_rb);
            this.Food_panel.Controls.Add(this.Cron_rb);
            this.Food_panel.Location = new System.Drawing.Point(43, 73);
            this.Food_panel.Name = "Food_panel";
            this.Food_panel.Size = new System.Drawing.Size(60, 48);
            this.Food_panel.TabIndex = 9;
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
            this.Food_Pause.Location = new System.Drawing.Point(110, 99);
            this.Food_Pause.Name = "Food_Pause";
            this.Food_Pause.Size = new System.Drawing.Size(61, 23);
            this.Food_Pause.TabIndex = 10;
            this.Food_Pause.Text = "Pause";
            this.Food_Pause.UseVisualStyleBackColor = true;
            this.Food_Pause.Click += new System.EventHandler(this.Food_Pause_Click);
            // 
            // TimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 401);
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
            this.Name = "TimerForm";
            this.Text = "Buff Timer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TimerForm_FormClosing);
            this.Food_panel.ResumeLayout(false);
            this.Food_panel.PerformLayout();
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
        private System.Windows.Forms.Timer Timer_Potion_15;
        private System.Windows.Forms.Button Food_Start;
        private System.Windows.Forms.Button Back_btn;
        private System.Windows.Forms.RadioButton Cron_rb;
        private System.Windows.Forms.Panel Food_panel;
        private System.Windows.Forms.RadioButton Other_rb;
        private System.Windows.Forms.Button Food_Pause;
    }
}