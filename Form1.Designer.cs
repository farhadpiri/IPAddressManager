using System;

namespace IPAddressManager
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
            this.lblDnsAddress = new System.Windows.Forms.Label();
            this.lblSavedDnsAddresses = new System.Windows.Forms.Label();
            this.cmbPreferredDns = new System.Windows.Forms.ComboBox();
            this.cmbAlternateDns = new System.Windows.Forms.ComboBox();
            this.btnAddDns = new System.Windows.Forms.Button();
            this.btnEditDns = new System.Windows.Forms.Button();
            this.btnRemoveDns = new System.Windows.Forms.Button();
            this.btnClearDns = new System.Windows.Forms.Button();
            this.btnSetDns = new System.Windows.Forms.Button();
            this.listBoxDns = new System.Windows.Forms.ListBox();
            this.ipAddressControl = new IPAddressManager.IPAddressControl();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPresets = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDnsAddress
            // 
            this.lblDnsAddress.AutoSize = true;
            this.lblDnsAddress.Location = new System.Drawing.Point(23, 17);
            this.lblDnsAddress.Name = "lblDnsAddress";
            this.lblDnsAddress.Size = new System.Drawing.Size(90, 15);
            this.lblDnsAddress.TabIndex = 0;
            this.lblDnsAddress.Text = "DSN Addresse:";
            // 
            // lblSavedDnsAddresses
            // 
            this.lblSavedDnsAddresses.AutoSize = true;
            this.lblSavedDnsAddresses.Location = new System.Drawing.Point(23, 47);
            this.lblSavedDnsAddresses.Name = "lblSavedDnsAddresses";
            this.lblSavedDnsAddresses.Size = new System.Drawing.Size(129, 15);
            this.lblSavedDnsAddresses.TabIndex = 1;
            this.lblSavedDnsAddresses.Text = "Saved Dns Addresses:";
            // 
            // cmbPreferredDns
            // 
            this.cmbPreferredDns.FormattingEnabled = true;
            this.cmbPreferredDns.Location = new System.Drawing.Point(109, 184);
            this.cmbPreferredDns.Name = "cmbPreferredDns";
            this.cmbPreferredDns.Size = new System.Drawing.Size(121, 21);
            this.cmbPreferredDns.TabIndex = 2;
            // 
            // cmbAlternateDns
            // 
            this.cmbAlternateDns.FormattingEnabled = true;
            this.cmbAlternateDns.Location = new System.Drawing.Point(109, 211);
            this.cmbAlternateDns.Name = "cmbAlternateDns";
            this.cmbAlternateDns.Size = new System.Drawing.Size(121, 21);
            this.cmbAlternateDns.TabIndex = 3;
            // 
            // btnAddDns
            // 
            this.btnAddDns.Location = new System.Drawing.Point(265, 12);
            this.btnAddDns.Name = "btnAddDns";
            this.btnAddDns.Size = new System.Drawing.Size(75, 23);
            this.btnAddDns.TabIndex = 5;
            this.btnAddDns.Text = "Add";
            this.btnAddDns.UseVisualStyleBackColor = true;
            this.btnAddDns.Click += new System.EventHandler(this.btnAddDns_Click);
            // 
            // btnEditDns
            // 
            this.btnEditDns.Location = new System.Drawing.Point(274, 70);
            this.btnEditDns.Name = "btnEditDns";
            this.btnEditDns.Size = new System.Drawing.Size(75, 23);
            this.btnEditDns.TabIndex = 6;
            this.btnEditDns.Text = "Edit";
            this.btnEditDns.UseVisualStyleBackColor = true;
            this.btnEditDns.Click += new System.EventHandler(this.btnEditDns_Click);
            // 
            // btnRemoveDns
            // 
            this.btnRemoveDns.Location = new System.Drawing.Point(274, 99);
            this.btnRemoveDns.Name = "btnRemoveDns";
            this.btnRemoveDns.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveDns.TabIndex = 7;
            this.btnRemoveDns.Text = "Remove";
            this.btnRemoveDns.UseVisualStyleBackColor = true;
            this.btnRemoveDns.Click += new System.EventHandler(this.btnRemoveDns_Click);
            // 
            // btnClearDns
            // 
            this.btnClearDns.Location = new System.Drawing.Point(274, 280);
            this.btnClearDns.Name = "btnClearDns";
            this.btnClearDns.Size = new System.Drawing.Size(75, 23);
            this.btnClearDns.TabIndex = 8;
            this.btnClearDns.Text = "Clear DNS";
            this.btnClearDns.UseVisualStyleBackColor = true;
            this.btnClearDns.Click += new System.EventHandler(this.btnClearDns_Click);
            // 
            // btnSetDns
            // 
            this.btnSetDns.Location = new System.Drawing.Point(28, 280);
            this.btnSetDns.Name = "btnSetDns";
            this.btnSetDns.Size = new System.Drawing.Size(75, 23);
            this.btnSetDns.TabIndex = 9;
            this.btnSetDns.Text = "Set DNS";
            this.btnSetDns.UseVisualStyleBackColor = true;
            this.btnSetDns.Click += new System.EventHandler(this.btnSetDns_Click);
            // 
            // listBoxDns
            // 
            this.listBoxDns.FormattingEnabled = true;
            this.listBoxDns.Location = new System.Drawing.Point(26, 70);
            this.listBoxDns.Name = "listBoxDns";
            this.listBoxDns.Size = new System.Drawing.Size(233, 108);
            this.listBoxDns.TabIndex = 10;
            this.listBoxDns.SelectedIndexChanged += new System.EventHandler(this.listBoxDns_SelectedIndexChanged);
            // 
            // ipAddressControl
            // 
            this.ipAddressControl.Location = new System.Drawing.Point(109, 13);
            this.ipAddressControl.Name = "ipAddressControl";
            this.ipAddressControl.Size = new System.Drawing.Size(150, 25);
            this.ipAddressControl.TabIndex = 4;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(274, 155);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAll.TabIndex = 11;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Prefered DNS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Alternate DNS:";
            // 
            // btnPresets
            // 
            this.btnPresets.Location = new System.Drawing.Point(184, 280);
            this.btnPresets.Name = "btnPresets";
            this.btnPresets.Size = new System.Drawing.Size(75, 23);
            this.btnPresets.TabIndex = 14;
            this.btnPresets.Text = "Presets...";
            this.btnPresets.UseVisualStyleBackColor = true;
            this.btnPresets.Click += new System.EventHandler(this.btnPresets_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 336);
            this.Controls.Add(this.btnPresets);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.listBoxDns);
            this.Controls.Add(this.btnSetDns);
            this.Controls.Add(this.btnClearDns);
            this.Controls.Add(this.btnRemoveDns);
            this.Controls.Add(this.btnEditDns);
            this.Controls.Add(this.btnAddDns);
            this.Controls.Add(this.ipAddressControl);
            this.Controls.Add(this.cmbAlternateDns);
            this.Controls.Add(this.cmbPreferredDns);
            this.Controls.Add(this.lblSavedDnsAddresses);
            this.Controls.Add(this.lblDnsAddress);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void listBoxDns_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        #endregion

        private System.Windows.Forms.Label lblDnsAddress;
        private System.Windows.Forms.Label lblSavedDnsAddresses;
        private System.Windows.Forms.ComboBox cmbPreferredDns;
        private System.Windows.Forms.ComboBox cmbAlternateDns;
        private IPAddressControl ipAddressControl;
        private System.Windows.Forms.Button btnAddDns;
        private System.Windows.Forms.Button btnEditDns;
        private System.Windows.Forms.Button btnRemoveDns;
        private System.Windows.Forms.Button btnClearDns;
        private System.Windows.Forms.Button btnSetDns;
        private System.Windows.Forms.ListBox listBoxDns;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPresets;
    }
}