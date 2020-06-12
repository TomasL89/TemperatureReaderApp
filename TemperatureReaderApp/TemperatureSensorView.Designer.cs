namespace TemperatureLoggerApp
{
    partial class TemperatureSensor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemperatureSensor));
            this.connectionIcon = new System.Windows.Forms.PictureBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.portsDropDown = new System.Windows.Forms.ComboBox();
            this.errorSymbol = new System.Windows.Forms.PictureBox();
            this.errorMessageTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.connectionIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorSymbol)).BeginInit();
            this.SuspendLayout();
            // 
            // connectionIcon
            // 
            this.connectionIcon.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.connectionIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.connectionIcon.Image = ((System.Drawing.Image)(resources.GetObject("connectionIcon.Image")));
            this.connectionIcon.Location = new System.Drawing.Point(62, 12);
            this.connectionIcon.Name = "connectionIcon";
            this.connectionIcon.Size = new System.Drawing.Size(56, 56);
            this.connectionIcon.TabIndex = 0;
            this.connectionIcon.TabStop = false;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(289, 119);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(83, 30);
            this.ConnectButton.TabIndex = 2;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // portsDropDown
            // 
            this.portsDropDown.FormattingEnabled = true;
            this.portsDropDown.Location = new System.Drawing.Point(124, 32);
            this.portsDropDown.Name = "portsDropDown";
            this.portsDropDown.Size = new System.Drawing.Size(107, 21);
            this.portsDropDown.TabIndex = 3;
            this.portsDropDown.SelectedValueChanged += new System.EventHandler(this.portsDropDown_SelectedValueChanged);
            // 
            // errorSymbol
            // 
            this.errorSymbol.Location = new System.Drawing.Point(237, 12);
            this.errorSymbol.Name = "errorSymbol";
            this.errorSymbol.Size = new System.Drawing.Size(56, 56);
            this.errorSymbol.TabIndex = 4;
            this.errorSymbol.TabStop = false;
            // 
            // errorMessageTextBox
            // 
            this.errorMessageTextBox.Location = new System.Drawing.Point(62, 83);
            this.errorMessageTextBox.Name = "errorMessageTextBox";
            this.errorMessageTextBox.Size = new System.Drawing.Size(231, 20);
            this.errorMessageTextBox.TabIndex = 5;
            this.errorMessageTextBox.Visible = false;
            // 
            // TemperatureSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.errorMessageTextBox);
            this.Controls.Add(this.errorSymbol);
            this.Controls.Add(this.portsDropDown);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.connectionIcon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TemperatureSensor";
            this.Text = "Temperature Sensor";
            ((System.ComponentModel.ISupportInitialize)(this.connectionIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorSymbol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox connectionIcon;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.ComboBox portsDropDown;
        private System.Windows.Forms.PictureBox errorSymbol;
        private System.Windows.Forms.TextBox errorMessageTextBox;
    }
}

