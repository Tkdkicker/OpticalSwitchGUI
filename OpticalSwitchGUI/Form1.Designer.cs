
namespace OpticalSwitchGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.UpBtn = new System.Windows.Forms.Button();
            this.DownBtn = new System.Windows.Forms.Button();
            this.ChannelNumberLbl = new System.Windows.Forms.Label();
            this.CurrentChannelLbl = new System.Windows.Forms.Label();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.SwitchesLstBx = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // UpBtn
            // 
            this.UpBtn.Enabled = false;
            this.UpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpBtn.Location = new System.Drawing.Point(248, 95);
            this.UpBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UpBtn.Name = "UpBtn";
            this.UpBtn.Size = new System.Drawing.Size(84, 53);
            this.UpBtn.TabIndex = 0;
            this.UpBtn.Text = "Up";
            this.UpBtn.UseVisualStyleBackColor = true;
            this.UpBtn.Click += new System.EventHandler(this.UpBtn_Click);
            // 
            // DownBtn
            // 
            this.DownBtn.Enabled = false;
            this.DownBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownBtn.Location = new System.Drawing.Point(227, 183);
            this.DownBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DownBtn.Name = "DownBtn";
            this.DownBtn.Size = new System.Drawing.Size(127, 57);
            this.DownBtn.TabIndex = 1;
            this.DownBtn.Tag = "";
            this.DownBtn.Text = "Down";
            this.DownBtn.UseVisualStyleBackColor = true;
            this.DownBtn.Click += new System.EventHandler(this.DownBtn_Click);
            // 
            // ChannelNumberLbl
            // 
            this.ChannelNumberLbl.AutoSize = true;
            this.ChannelNumberLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChannelNumberLbl.Location = new System.Drawing.Point(411, 110);
            this.ChannelNumberLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ChannelNumberLbl.Name = "ChannelNumberLbl";
            this.ChannelNumberLbl.Size = new System.Drawing.Size(114, 58);
            this.ChannelNumberLbl.TabIndex = 2;
            this.ChannelNumberLbl.Text = "Channel\r\nNumber";
            // 
            // CurrentChannelLbl
            // 
            this.CurrentChannelLbl.AutoSize = true;
            this.CurrentChannelLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentChannelLbl.Location = new System.Drawing.Point(415, 198);
            this.CurrentChannelLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentChannelLbl.Name = "CurrentChannelLbl";
            this.CurrentChannelLbl.Size = new System.Drawing.Size(115, 31);
            this.CurrentChannelLbl.TabIndex = 3;
            this.CurrentChannelLbl.Text = "Channel";
            this.CurrentChannelLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLbl.Location = new System.Drawing.Point(169, 23);
            this.StatusLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(176, 29);
            this.StatusLbl.TabIndex = 4;
            this.StatusLbl.Text = "Not connected";
            this.StatusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SwitchesLstBx
            // 
            this.SwitchesLstBx.BackColor = System.Drawing.SystemColors.Window;
            this.SwitchesLstBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SwitchesLstBx.FormattingEnabled = true;
            this.SwitchesLstBx.ItemHeight = 38;
            this.SwitchesLstBx.Items.AddRange(new object[] {
            "Test",
            "TX",
            "RX",
            "KM IN",
            "KM OUT"});
            this.SwitchesLstBx.Location = new System.Drawing.Point(28, 95);
            this.SwitchesLstBx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SwitchesLstBx.Name = "SwitchesLstBx";
            this.SwitchesLstBx.Size = new System.Drawing.Size(159, 156);
            this.SwitchesLstBx.TabIndex = 9;
            this.SwitchesLstBx.SelectedIndexChanged += new System.EventHandler(this.SwitchesLstBx_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 287);
            this.Controls.Add(this.SwitchesLstBx);
            this.Controls.Add(this.StatusLbl);
            this.Controls.Add(this.CurrentChannelLbl);
            this.Controls.Add(this.ChannelNumberLbl);
            this.Controls.Add(this.DownBtn);
            this.Controls.Add(this.UpBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Optical Switch for Module Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UpBtn;
        private System.Windows.Forms.Button DownBtn;
        private System.Windows.Forms.Label ChannelNumberLbl;
        private System.Windows.Forms.Label CurrentChannelLbl;
        private System.Windows.Forms.Label StatusLbl;
        private System.Windows.Forms.ListBox SwitchesLstBx;
    }
}

