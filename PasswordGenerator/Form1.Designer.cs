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
            this.label_separatorTop = new System.Windows.Forms.Label();
            this.radioButton_default = new System.Windows.Forms.RadioButton();
            this.groupBox_default = new System.Windows.Forms.GroupBox();
            this.checkBox_complex = new System.Windows.Forms.CheckBox();
            this.label_complexLength = new System.Windows.Forms.Label();
            this.numericUpDown_complexLength = new System.Windows.Forms.NumericUpDown();
            this.checkBox_random = new System.Windows.Forms.CheckBox();
            this.radioButton_dictionary = new System.Windows.Forms.RadioButton();
            this.groupBox_dictionary = new System.Windows.Forms.GroupBox();
            this.label_minWordLength = new System.Windows.Forms.Label();
            this.numericUpDown_minWordLength = new System.Windows.Forms.NumericUpDown();
            this.label_maxWordLength = new System.Windows.Forms.Label();
            this.numericUpDown_maxWordLength = new System.Windows.Forms.NumericUpDown();
            this.label_wordCount = new System.Windows.Forms.Label();
            this.numericUpDown_wordCount = new System.Windows.Forms.NumericUpDown();
            this.label_separatorBottom = new System.Windows.Forms.Label();
            this.checkBox_specialChar = new System.Windows.Forms.CheckBox();
            this.checkBox_mangle = new System.Windows.Forms.CheckBox();
            this.label_batchCount = new System.Windows.Forms.Label();
            this.numericUpDown_batchCount = new System.Windows.Forms.NumericUpDown();
            this.groupBox_default.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_complexLength)).BeginInit();
            this.groupBox_dictionary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minWordLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_maxWordLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_wordCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_batchCount)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Generate
            // 
            this.button_Generate.Location = new System.Drawing.Point(12, 12);
            this.button_Generate.Name = "button_Generate";
            this.button_Generate.Size = new System.Drawing.Size(75, 70);
            this.button_Generate.TabIndex = 0;
            this.button_Generate.Text = "Generate";
            this.button_Generate.UseVisualStyleBackColor = true;
            this.button_Generate.Click += new System.EventHandler(this.button_Generate_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 15);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(179, 83);
            this.textBox1.TabIndex = 1;
            // 
            // button_copy
            // 
            this.button_copy.Location = new System.Drawing.Point(93, 104);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(179, 20);
            this.button_copy.TabIndex = 2;
            this.button_copy.Text = "Copy to clipboard";
            this.button_copy.UseVisualStyleBackColor = true;
            this.button_copy.Click += new System.EventHandler(this.Button_copy_Click);
            // 
            // label_separatorTop
            // 
            this.label_separatorTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_separatorTop.Location = new System.Drawing.Point(12, 134);
            this.label_separatorTop.Name = "label_separatorTop";
            this.label_separatorTop.Size = new System.Drawing.Size(260, 2);
            this.label_separatorTop.TabIndex = 5;
            // 
            // radioButton_default
            // 
            this.radioButton_default.AutoSize = true;
            this.radioButton_default.Location = new System.Drawing.Point(12, 146);
            this.radioButton_default.Name = "radioButton_default";
            this.radioButton_default.Size = new System.Drawing.Size(59, 17);
            this.radioButton_default.TabIndex = 6;
            this.radioButton_default.Text = "Default";
            this.radioButton_default.UseVisualStyleBackColor = true;
            // 
            // groupBox_default
            // 
            this.groupBox_default.Controls.Add(this.checkBox_complex);
            this.groupBox_default.Controls.Add(this.label_complexLength);
            this.groupBox_default.Controls.Add(this.numericUpDown_complexLength);
            this.groupBox_default.Controls.Add(this.checkBox_random);
            this.groupBox_default.Location = new System.Drawing.Point(25, 169);
            this.groupBox_default.Name = "groupBox_default";
            this.groupBox_default.Size = new System.Drawing.Size(232, 95);
            this.groupBox_default.TabIndex = 7;
            this.groupBox_default.TabStop = false;
            // 
            // checkBox_complex
            // 
            this.checkBox_complex.AutoSize = true;
            this.checkBox_complex.Location = new System.Drawing.Point(10, 20);
            this.checkBox_complex.Name = "checkBox_complex";
            this.checkBox_complex.Size = new System.Drawing.Size(125, 17);
            this.checkBox_complex.TabIndex = 0;
            this.checkBox_complex.Text = "Increased complexity";
            this.checkBox_complex.UseVisualStyleBackColor = true;
            this.checkBox_complex.CheckedChanged += new System.EventHandler(this.checkBox_complex_CheckedChanged);
            // 
            // label_complexLength
            // 
            this.label_complexLength.AutoSize = true;
            this.label_complexLength.Location = new System.Drawing.Point(28, 44);
            this.label_complexLength.Name = "label_complexLength";
            this.label_complexLength.Size = new System.Drawing.Size(88, 13);
            this.label_complexLength.TabIndex = 1;
            this.label_complexLength.Text = "Character length:";
            // 
            // numericUpDown_complexLength
            // 
            this.numericUpDown_complexLength.Location = new System.Drawing.Point(140, 41);
            this.numericUpDown_complexLength.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDown_complexLength.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown_complexLength.Name = "numericUpDown_complexLength";
            this.numericUpDown_complexLength.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_complexLength.TabIndex = 2;
            this.numericUpDown_complexLength.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // checkBox_random
            // 
            this.checkBox_random.AutoSize = true;
            this.checkBox_random.Location = new System.Drawing.Point(10, 68);
            this.checkBox_random.Name = "checkBox_random";
            this.checkBox_random.Size = new System.Drawing.Size(88, 17);
            this.checkBox_random.TabIndex = 3;
            this.checkBox_random.Text = "More random";
            this.checkBox_random.UseVisualStyleBackColor = true;
            // 
            // radioButton_dictionary
            // 
            this.radioButton_dictionary.AutoSize = true;
            this.radioButton_dictionary.Checked = true;
            this.radioButton_dictionary.Location = new System.Drawing.Point(12, 271);
            this.radioButton_dictionary.Name = "radioButton_dictionary";
            this.radioButton_dictionary.Size = new System.Drawing.Size(94, 17);
            this.radioButton_dictionary.TabIndex = 8;
            this.radioButton_dictionary.TabStop = true;
            this.radioButton_dictionary.Text = "Use Dictionary";
            this.radioButton_dictionary.UseVisualStyleBackColor = true;
            this.radioButton_dictionary.CheckedChanged += new System.EventHandler(this.radioButton_dictionary_CheckedChanged);
            // 
            // groupBox_dictionary
            // 
            this.groupBox_dictionary.Controls.Add(this.label_minWordLength);
            this.groupBox_dictionary.Controls.Add(this.numericUpDown_minWordLength);
            this.groupBox_dictionary.Controls.Add(this.label_maxWordLength);
            this.groupBox_dictionary.Controls.Add(this.numericUpDown_maxWordLength);
            this.groupBox_dictionary.Controls.Add(this.label_wordCount);
            this.groupBox_dictionary.Controls.Add(this.numericUpDown_wordCount);
            this.groupBox_dictionary.Location = new System.Drawing.Point(25, 294);
            this.groupBox_dictionary.Name = "groupBox_dictionary";
            this.groupBox_dictionary.Size = new System.Drawing.Size(232, 98);
            this.groupBox_dictionary.TabIndex = 9;
            this.groupBox_dictionary.TabStop = false;
            // 
            // label_minWordLength
            // 
            this.label_minWordLength.AutoSize = true;
            this.label_minWordLength.Location = new System.Drawing.Point(10, 20);
            this.label_minWordLength.Name = "label_minWordLength";
            this.label_minWordLength.Size = new System.Drawing.Size(85, 13);
            this.label_minWordLength.TabIndex = 0;
            this.label_minWordLength.Text = "Min word length:";
            // 
            // numericUpDown_minWordLength
            // 
            this.numericUpDown_minWordLength.Location = new System.Drawing.Point(110, 17);
            this.numericUpDown_minWordLength.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown_minWordLength.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown_minWordLength.Name = "numericUpDown_minWordLength";
            this.numericUpDown_minWordLength.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_minWordLength.TabIndex = 1;
            this.numericUpDown_minWordLength.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown_minWordLength.ValueChanged += new System.EventHandler(this.numericUpDown_minWordLength_ValueChanged);
            // 
            // label_maxWordLength
            // 
            this.label_maxWordLength.AutoSize = true;
            this.label_maxWordLength.Location = new System.Drawing.Point(10, 44);
            this.label_maxWordLength.Name = "label_maxWordLength";
            this.label_maxWordLength.Size = new System.Drawing.Size(88, 13);
            this.label_maxWordLength.TabIndex = 2;
            this.label_maxWordLength.Text = "Max word length:";
            // 
            // numericUpDown_maxWordLength
            // 
            this.numericUpDown_maxWordLength.Location = new System.Drawing.Point(110, 41);
            this.numericUpDown_maxWordLength.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown_maxWordLength.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown_maxWordLength.Name = "numericUpDown_maxWordLength";
            this.numericUpDown_maxWordLength.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_maxWordLength.TabIndex = 3;
            this.numericUpDown_maxWordLength.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDown_maxWordLength.ValueChanged += new System.EventHandler(this.numericUpDown_maxWordLength_ValueChanged);
            //
            // label_wordCount
            //
            this.label_wordCount.AutoSize = true;
            this.label_wordCount.Location = new System.Drawing.Point(10, 68);
            this.label_wordCount.Name = "label_wordCount";
            this.label_wordCount.Size = new System.Drawing.Size(93, 13);
            this.label_wordCount.TabIndex = 4;
            this.label_wordCount.Text = "Number of words:";
            //
            // numericUpDown_wordCount
            //
            this.numericUpDown_wordCount.Location = new System.Drawing.Point(110, 65);
            this.numericUpDown_wordCount.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_wordCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_wordCount.Name = "numericUpDown_wordCount";
            this.numericUpDown_wordCount.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_wordCount.TabIndex = 5;
            this.numericUpDown_wordCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            //
            // label_separatorBottom
            // 
            this.label_separatorBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_separatorBottom.Location = new System.Drawing.Point(12, 399);
            this.label_separatorBottom.Name = "label_separatorBottom";
            this.label_separatorBottom.Size = new System.Drawing.Size(260, 2);
            this.label_separatorBottom.TabIndex = 10;
            // 
            // checkBox_specialChar
            // 
            this.checkBox_specialChar.AutoSize = true;
            this.checkBox_specialChar.Location = new System.Drawing.Point(25, 407);
            this.checkBox_specialChar.Name = "checkBox_specialChar";
            this.checkBox_specialChar.Size = new System.Drawing.Size(145, 17);
            this.checkBox_specialChar.TabIndex = 11;
            this.checkBox_specialChar.Text = "Include special character";
            this.checkBox_specialChar.UseVisualStyleBackColor = true;
            // 
            // checkBox_mangle
            // 
            this.checkBox_mangle.AutoSize = true;
            this.checkBox_mangle.Location = new System.Drawing.Point(25, 430);
            this.checkBox_mangle.Name = "checkBox_mangle";
            this.checkBox_mangle.Size = new System.Drawing.Size(118, 17);
            this.checkBox_mangle.TabIndex = 12;
            this.checkBox_mangle.Text = "Mangle (M@NGL3)";
            this.checkBox_mangle.UseVisualStyleBackColor = true;
            // 
            // label_batchCount
            // 
            this.label_batchCount.AutoSize = true;
            this.label_batchCount.Location = new System.Drawing.Point(12, 88);
            this.label_batchCount.Name = "label_batchCount";
            this.label_batchCount.Size = new System.Drawing.Size(68, 13);
            this.label_batchCount.TabIndex = 3;
            this.label_batchCount.Text = "Batch count:";
            // 
            // numericUpDown_batchCount
            // 
            this.numericUpDown_batchCount.Location = new System.Drawing.Point(25, 104);
            this.numericUpDown_batchCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_batchCount.Name = "numericUpDown_batchCount";
            this.numericUpDown_batchCount.Size = new System.Drawing.Size(46, 20);
            this.numericUpDown_batchCount.TabIndex = 4;
            this.numericUpDown_batchCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AcceptButton = this.button_Generate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 459);
            this.Controls.Add(this.checkBox_mangle);
            this.Controls.Add(this.checkBox_specialChar);
            this.Controls.Add(this.label_separatorBottom);
            this.Controls.Add(this.groupBox_dictionary);
            this.Controls.Add(this.numericUpDown_batchCount);
            this.Controls.Add(this.label_batchCount);
            this.Controls.Add(this.radioButton_dictionary);
            this.Controls.Add(this.groupBox_default);
            this.Controls.Add(this.radioButton_default);
            this.Controls.Add(this.label_separatorTop);
            this.Controls.Add(this.button_copy);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_Generate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Password Generator";
            this.groupBox_default.ResumeLayout(false);
            this.groupBox_default.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_complexLength)).EndInit();
            this.groupBox_dictionary.ResumeLayout(false);
            this.groupBox_dictionary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minWordLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_maxWordLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_wordCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_batchCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Generate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_copy;
        private System.Windows.Forms.Label label_separatorTop;
        private System.Windows.Forms.RadioButton radioButton_default;
        private System.Windows.Forms.GroupBox groupBox_default;
        private System.Windows.Forms.CheckBox checkBox_complex;
        private System.Windows.Forms.Label label_complexLength;
        private System.Windows.Forms.NumericUpDown numericUpDown_complexLength;
        private System.Windows.Forms.CheckBox checkBox_random;
        private System.Windows.Forms.RadioButton radioButton_dictionary;
        private System.Windows.Forms.GroupBox groupBox_dictionary;
        private System.Windows.Forms.Label label_minWordLength;
        private System.Windows.Forms.NumericUpDown numericUpDown_minWordLength;
        private System.Windows.Forms.Label label_maxWordLength;
        private System.Windows.Forms.NumericUpDown numericUpDown_maxWordLength;
        private System.Windows.Forms.Label label_wordCount;
        private System.Windows.Forms.NumericUpDown numericUpDown_wordCount;
        private System.Windows.Forms.Label label_separatorBottom;
        private System.Windows.Forms.CheckBox checkBox_specialChar;
        private System.Windows.Forms.CheckBox checkBox_mangle;
        private System.Windows.Forms.Label label_batchCount;
        private System.Windows.Forms.NumericUpDown numericUpDown_batchCount;
    }
}
