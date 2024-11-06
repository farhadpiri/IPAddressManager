namespace IPAddressManager
{
    partial class PresetsForm
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
            this.listBoxPresets = new System.Windows.Forms.ListBox();
            this.btnAddPreset = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cmbPresetPreferredDns = new System.Windows.Forms.ComboBox();
            this.cmbPresetAlternateDns = new System.Windows.Forms.ComboBox();
            this.txtPresetName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxPresets
            // 
            this.listBoxPresets.FormattingEnabled = true;
            this.listBoxPresets.Location = new System.Drawing.Point(126, 72);
            this.listBoxPresets.Name = "listBoxPresets";
            this.listBoxPresets.Size = new System.Drawing.Size(205, 95);
            this.listBoxPresets.TabIndex = 0;
            this.listBoxPresets.SelectedIndexChanged += new System.EventHandler(this.listBoxPresets_SelectedIndexChanged);
            // 
            // btnAddPreset
            // 
            this.btnAddPreset.Location = new System.Drawing.Point(337, 73);
            this.btnAddPreset.Name = "btnAddPreset";
            this.btnAddPreset.Size = new System.Drawing.Size(75, 23);
            this.btnAddPreset.TabIndex = 1;
            this.btnAddPreset.Text = "Add";
            this.btnAddPreset.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(337, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(337, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // cmbPresetPreferredDns
            // 
            this.cmbPresetPreferredDns.FormattingEnabled = true;
            this.cmbPresetPreferredDns.Location = new System.Drawing.Point(125, 180);
            this.cmbPresetPreferredDns.Name = "cmbPresetPreferredDns";
            this.cmbPresetPreferredDns.Size = new System.Drawing.Size(121, 21);
            this.cmbPresetPreferredDns.TabIndex = 4;
            // 
            // cmbPresetAlternateDns
            // 
            this.cmbPresetAlternateDns.FormattingEnabled = true;
            this.cmbPresetAlternateDns.Location = new System.Drawing.Point(126, 207);
            this.cmbPresetAlternateDns.Name = "cmbPresetAlternateDns";
            this.cmbPresetAlternateDns.Size = new System.Drawing.Size(121, 21);
            this.cmbPresetAlternateDns.TabIndex = 5;
            // 
            // txtPresetName
            // 
            this.txtPresetName.Location = new System.Drawing.Point(126, 29);
            this.txtPresetName.Name = "txtPresetName";
            this.txtPresetName.Size = new System.Drawing.Size(205, 20);
            this.txtPresetName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Preset Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Presets:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Prefered DNS:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Altered DNS:";
            // 
            // PresetsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 261);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPresetName);
            this.Controls.Add(this.cmbPresetAlternateDns);
            this.Controls.Add(this.cmbPresetPreferredDns);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAddPreset);
            this.Controls.Add(this.listBoxPresets);
            this.Name = "PresetsForm";
            this.Text = "PresetsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPresets;
        private System.Windows.Forms.Button btnAddPreset;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cmbPresetPreferredDns;
        private System.Windows.Forms.ComboBox cmbPresetAlternateDns;
        private System.Windows.Forms.TextBox txtPresetName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}