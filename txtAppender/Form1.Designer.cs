namespace txtAppender
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_start = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_file1 = new System.Windows.Forms.Button();
            this.lbl_file1 = new System.Windows.Forms.Label();
            this.btn_file2 = new System.Windows.Forms.Button();
            this.lbl_file2 = new System.Windows.Forms.Label();
            this.btn_output = new System.Windows.Forms.Button();
            this.lbl_output = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_currnent_file1 = new System.Windows.Forms.Label();
            this.lbl_current_file2 = new System.Windows.Forms.Label();
            this.lbl_current_output = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(140, 197);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(283, 73);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.startButtonClick);
            // 
            // btn_file1
            // 
            this.btn_file1.Location = new System.Drawing.Point(23, 128);
            this.btn_file1.Name = "btn_file1";
            this.btn_file1.Size = new System.Drawing.Size(148, 23);
            this.btn_file1.TabIndex = 3;
            this.btn_file1.Text = "Select file 1";
            this.btn_file1.UseVisualStyleBackColor = true;
            this.btn_file1.Click += new System.EventHandler(this.btn_file1_Click);
            // 
            // lbl_file1
            // 
            this.lbl_file1.AutoSize = true;
            this.lbl_file1.Location = new System.Drawing.Point(20, 104);
            this.lbl_file1.Name = "lbl_file1";
            this.lbl_file1.Size = new System.Drawing.Size(65, 13);
            this.lbl_file1.TabIndex = 4;
            this.lbl_file1.Text = "not selected";
            // 
            // btn_file2
            // 
            this.btn_file2.Location = new System.Drawing.Point(210, 129);
            this.btn_file2.Name = "btn_file2";
            this.btn_file2.Size = new System.Drawing.Size(139, 23);
            this.btn_file2.TabIndex = 5;
            this.btn_file2.Text = "Select File 2";
            this.btn_file2.UseVisualStyleBackColor = true;
            this.btn_file2.Click += new System.EventHandler(this.btn_file2_Click);
            // 
            // lbl_file2
            // 
            this.lbl_file2.AutoSize = true;
            this.lbl_file2.Location = new System.Drawing.Point(207, 104);
            this.lbl_file2.Name = "lbl_file2";
            this.lbl_file2.Size = new System.Drawing.Size(65, 13);
            this.lbl_file2.TabIndex = 6;
            this.lbl_file2.Text = "not selected";
            // 
            // btn_output
            // 
            this.btn_output.Location = new System.Drawing.Point(389, 129);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(155, 23);
            this.btn_output.TabIndex = 7;
            this.btn_output.Text = "Select output file";
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // lbl_output
            // 
            this.lbl_output.AutoSize = true;
            this.lbl_output.Location = new System.Drawing.Point(386, 104);
            this.lbl_output.Name = "lbl_output";
            this.lbl_output.Size = new System.Drawing.Size(65, 13);
            this.lbl_output.TabIndex = 8;
            this.lbl_output.Text = "not selected";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(175, 9);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(229, 24);
            this.lbl_name.TabIndex = 9;
            this.lbl_name.Text = "Ultimate 2 txt file appender";
            // 
            // lbl_currnent_file1
            // 
            this.lbl_currnent_file1.AutoSize = true;
            this.lbl_currnent_file1.Location = new System.Drawing.Point(23, 78);
            this.lbl_currnent_file1.Name = "lbl_currnent_file1";
            this.lbl_currnent_file1.Size = new System.Drawing.Size(66, 13);
            this.lbl_currnent_file1.TabIndex = 12;
            this.lbl_currnent_file1.Text = "Current file 1";
            // 
            // lbl_current_file2
            // 
            this.lbl_current_file2.AutoSize = true;
            this.lbl_current_file2.Location = new System.Drawing.Point(210, 78);
            this.lbl_current_file2.Name = "lbl_current_file2";
            this.lbl_current_file2.Size = new System.Drawing.Size(66, 13);
            this.lbl_current_file2.TabIndex = 13;
            this.lbl_current_file2.Text = "Current file 2";
            // 
            // lbl_current_output
            // 
            this.lbl_current_output.AutoSize = true;
            this.lbl_current_output.Location = new System.Drawing.Point(386, 78);
            this.lbl_current_output.Name = "lbl_current_output";
            this.lbl_current_output.Size = new System.Drawing.Size(87, 13);
            this.lbl_current_output.TabIndex = 14;
            this.lbl_current_output.Text = "Curent output file";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 315);
            this.Controls.Add(this.lbl_current_output);
            this.Controls.Add(this.lbl_current_file2);
            this.Controls.Add(this.lbl_currnent_file1);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.lbl_output);
            this.Controls.Add(this.btn_output);
            this.Controls.Add(this.lbl_file2);
            this.Controls.Add(this.btn_file2);
            this.Controls.Add(this.lbl_file1);
            this.Controls.Add(this.btn_file1);
            this.Controls.Add(this.btn_start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_file1;
        private System.Windows.Forms.Label lbl_file1;
        private System.Windows.Forms.Button btn_file2;
        private System.Windows.Forms.Label lbl_file2;
        private System.Windows.Forms.Button btn_output;
        private System.Windows.Forms.Label lbl_output;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_currnent_file1;
        private System.Windows.Forms.Label lbl_current_file2;
        private System.Windows.Forms.Label lbl_current_output;
    }
}

