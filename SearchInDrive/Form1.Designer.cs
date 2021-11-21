namespace SearchInDrive
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearchInC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.btnSearchInD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSearchInC
            // 
            this.btnSearchInC.Enabled = false;
            this.btnSearchInC.Location = new System.Drawing.Point(246, 181);
            this.btnSearchInC.Name = "btnSearchInC";
            this.btnSearchInC.Size = new System.Drawing.Size(107, 23);
            this.btnSearchInC.TabIndex = 0;
            this.btnSearchInC.Text = "Search in drive C:";
            this.btnSearchInC.UseVisualStyleBackColor = true;
            this.btnSearchInC.Click += new System.EventHandler(this.btnSearchInC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter the string you want to search:";
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Location = new System.Drawing.Point(246, 120);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(220, 23);
            this.txtSearchTerm.TabIndex = 2;
            this.txtSearchTerm.TextChanged += new System.EventHandler(this.txtSearchTerm_TextChanged);
            // 
            // btnSearchInD
            // 
            this.btnSearchInD.Enabled = false;
            this.btnSearchInD.Location = new System.Drawing.Point(359, 181);
            this.btnSearchInD.Name = "btnSearchInD";
            this.btnSearchInD.Size = new System.Drawing.Size(107, 23);
            this.btnSearchInD.TabIndex = 0;
            this.btnSearchInD.Text = "Search in drive D:";
            this.btnSearchInD.UseVisualStyleBackColor = true;
            this.btnSearchInD.Click += new System.EventHandler(this.btnSearchInD_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtSearchTerm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearchInD);
            this.Controls.Add(this.btnSearchInC);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSearchInC;
        private Label label1;
        private TextBox txtSearchTerm;
        private Button btnSearchInD;
    }
}