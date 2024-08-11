


namespace cs99_winform_app
{
    partial class FrmLogin
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
            BtnSignup = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // BtnSignup
            // 
            BtnSignup.Location = new Point(295, 12);
            BtnSignup.Name = "BtnSignup";
            BtnSignup.Size = new Size(45, 38);
            BtnSignup.TabIndex = 0;
            BtnSignup.Text = "S";
            BtnSignup.UseVisualStyleBackColor = true;
            BtnSignup.Click += BtnSignup_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("나눔고딕 ExtraBold", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.Location = new Point(85, 24);
            label1.Name = "label1";
            label1.Size = new Size(165, 26);
            label1.TabIndex = 1;
            label1.Text = "Login window";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 493);
            Controls.Add(label1);
            Controls.Add(BtnSignup);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Activated += FrmLogin_Activated;
            FormClosed += this.FrmLogin_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Button BtnSignup;
        private Label label1;
    }
}
