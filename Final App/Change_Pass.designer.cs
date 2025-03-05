namespace WindowsFormsApp3
{
    partial class Change_Pass
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
            this.label1 = new System.Windows.Forms.Label();
            this.tname = new System.Windows.Forms.TextBox();
            this.tnew = new System.Windows.Forms.TextBox();
            this.tdes = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tcofnew = new System.Windows.Forms.TextBox();
            this.told = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(176, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Change Password";
            // 
            // tname
            // 
            this.tname.Location = new System.Drawing.Point(131, 76);
            this.tname.Name = "tname";
            this.tname.Size = new System.Drawing.Size(100, 20);
            this.tname.TabIndex = 26;
            // 
            // tnew
            // 
            this.tnew.Location = new System.Drawing.Point(215, 206);
            this.tnew.Name = "tnew";
            this.tnew.Size = new System.Drawing.Size(100, 20);
            this.tnew.TabIndex = 24;
            // 
            // tdes
            // 
            this.tdes.Location = new System.Drawing.Point(276, 76);
            this.tdes.Name = "tdes";
            this.tdes.Size = new System.Drawing.Size(100, 20);
            this.tdes.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(228, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Change";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Employee name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "New Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(231, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Old Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Confirm Password";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tcofnew
            // 
            this.tcofnew.Location = new System.Drawing.Point(215, 267);
            this.tcofnew.Name = "tcofnew";
            this.tcofnew.Size = new System.Drawing.Size(100, 20);
            this.tcofnew.TabIndex = 25;
            this.tcofnew.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // told
            // 
            this.told.Location = new System.Drawing.Point(215, 148);
            this.told.Name = "told";
            this.told.Size = new System.Drawing.Size(100, 20);
            this.told.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(300, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Designation";
            // 
            // Change_Pass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(531, 328);
            this.Controls.Add(this.told);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tname);
            this.Controls.Add(this.tcofnew);
            this.Controls.Add(this.tnew);
            this.Controls.Add(this.tdes);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "Change_Pass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change_Pass";
            this.Load += new System.EventHandler(this.Change_Pass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tname;
        private System.Windows.Forms.TextBox tnew;
        private System.Windows.Forms.TextBox tdes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tcofnew;
        private System.Windows.Forms.TextBox told;
        private System.Windows.Forms.Label label7;
    }
}