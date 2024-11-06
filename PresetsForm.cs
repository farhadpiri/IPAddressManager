using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace IPAddressManager
{
    public partial class PresetsForm : Form
    {
        private List<DNSEntry> dnsPresets = new List<DNSEntry>();
        private readonly string presetsFilePath = "dnsPresets.txt"; // File to store DNS presets

        public PresetsForm()
        {
            InitializeComponent();
            LoadPresets();
        }

        private void LoadPresets()
        {
            if (File.Exists(presetsFilePath))
            {
                var lines = File.ReadAllLines(presetsFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length == 3)
                    {
                        var preset = new DNSEntry(parts[0], parts[1], parts[2]);
                        dnsPresets.Add(preset);
                        listBoxPresets.Items.Add(preset.Name);
                    }
                }
            }
        }

        private void btnAddPreset_Click(object sender, EventArgs e)
        {
            var presetName = txtPresetName.Text;
            var preferredDns = cmbPresetPreferredDns.SelectedItem?.ToString();
            var alternateDns = cmbPresetAlternateDns.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(presetName) || preferredDns == "None")
            {
                MessageBox.Show("Please enter a valid preset name and select a preferred DNS.");
                return;
            }

            var newPreset = new DNSEntry(presetName, preferredDns, alternateDns);
            dnsPresets.Add(newPreset);
            listBoxPresets.Items.Add(newPreset.Name);
            SavePresets();
            ClearInputs();
        }

        private void btnRemovePreset_Click(object sender, EventArgs e)
        {
            if (listBoxPresets.SelectedItem != null)
            {
                var selectedPreset = listBoxPresets.SelectedItem.ToString();
                dnsPresets.RemoveAll(p => p.Name == selectedPreset);
                listBoxPresets.Items.Remove(selectedPreset);
                SavePresets();
            }
        }

        private void btnUpdatePreset_Click(object sender, EventArgs e)
        {
            if (listBoxPresets.SelectedItem != null)
            {
                var selectedPreset = listBoxPresets.SelectedItem.ToString();
                var presetToUpdate = dnsPresets.Find(p => p.Name == selectedPreset);

                presetToUpdate.PreferredDns = cmbPresetPreferredDns.SelectedItem?.ToString();
                presetToUpdate.AlternateDns = cmbPresetAlternateDns.SelectedItem?.ToString();
                SavePresets();
                ClearInputs();
            }
        }

        private void ClearInputs()
        {
            txtPresetName.Clear();
            cmbPresetPreferredDns.SelectedIndex = -1;
            cmbPresetAlternateDns.SelectedIndex = -1;
        }

        private void SavePresets()
        {
            var lines = new List<string>();
            foreach (var preset in dnsPresets)
            {
                lines.Add($"{preset.Name};{preset.PreferredDns};{preset.AlternateDns}");
            }
            File.WriteAllLines(presetsFilePath, lines);
        }

        private void listBoxPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPresets.SelectedItem != null)
            {
                var selectedPreset = dnsPresets.Find(p => p.Name == listBoxPresets.SelectedItem.ToString());
                txtPresetName.Text = selectedPreset.Name;
                cmbPresetPreferredDns.SelectedItem = selectedPreset.PreferredDns;
                cmbPresetAlternateDns.SelectedItem = selectedPreset.AlternateDns;
            }
        }
    }

    public class DNSEntry
    {
        public string Name { get; set; }
        public string PreferredDns { get; set; }
        public string AlternateDns { get; set; }

        public DNSEntry(string name, string preferredDns, string alternateDns)
        {
            Name = name;
            PreferredDns = preferredDns;
            AlternateDns = alternateDns;
        }
    }
}
