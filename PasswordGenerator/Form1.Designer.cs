namespace PasswordGenerator
{
    partial class Form1
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
            this.button_Generate = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_copy = new System.Windows.Forms.Button();
            this.checkBox_specialChar = new System.Windows.Forms.CheckBox();
            this.checkBox_complex = new System.Windows.Forms.CheckBox();
            this.checkBox_random = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_Generate
            // 
            this.button_Generate.Location = new System.Drawing.Point(12, 12);
            this.button_Generate.Name = "button_Generate";
            this.button_Generate.Size = new System.Drawing.Size(75, 53);
            this.button_Generate.TabIndex = 0;
            this.button_Generate.Text = "Generate";
            this.button_Generate.UseVisualStyleBackColor = true;
            this.button_Generate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_Generate_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button_copy
            // 
            this.button_copy.Location = new System.Drawing.Point(93, 42);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(179, 23);
            this.button_copy.TabIndex = 2;
            this.button_copy.Text = "Copy to clipboard";
            this.button_copy.UseVisualStyleBackColor = true;
            this.button_copy.Click += new System.EventHandler(this.button_copy_Click);
            // 
            // checkBox_specialChar
            // 
            this.checkBox_specialChar.AutoSize = true;
            this.checkBox_specialChar.Location = new System.Drawing.Point(12, 71);
            this.checkBox_specialChar.Name = "checkBox_specialChar";
            this.checkBox_specialChar.Size = new System.Drawing.Size(145, 17);
            this.checkBox_specialChar.TabIndex = 3;
            this.checkBox_specialChar.Text = "Include special character";
            this.checkBox_specialChar.UseVisualStyleBackColor = true;
            // 
            // checkBox_complex
            // 
            this.checkBox_complex.AutoSize = true;
            this.checkBox_complex.Location = new System.Drawing.Point(12, 94);
            this.checkBox_complex.Name = "checkBox_complex";
            this.checkBox_complex.Size = new System.Drawing.Size(125, 17);
            this.checkBox_complex.TabIndex = 4;
            this.checkBox_complex.Text = "Increased complexity";
            this.checkBox_complex.UseVisualStyleBackColor = true;
            // 
            // checkBox_random
            // 
            this.checkBox_random.AutoSize = true;
            this.checkBox_random.Location = new System.Drawing.Point(12, 117);
            this.checkBox_random.Name = "checkBox_random";
            this.checkBox_random.Size = new System.Drawing.Size(88, 17);
            this.checkBox_random.TabIndex = 5;
            this.checkBox_random.Text = "More random";
            this.checkBox_random.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 140);
            this.Controls.Add(this.checkBox_random);
            this.Controls.Add(this.checkBox_complex);
            this.Controls.Add(this.checkBox_specialChar);
            this.Controls.Add(this.button_copy);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_Generate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Password Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Generate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_copy;
        private System.Windows.Forms.CheckBox checkBox_specialChar;
        private System.Windows.Forms.CheckBox checkBox_complex;
        private System.Windows.Forms.CheckBox checkBox_random;
    }
}

