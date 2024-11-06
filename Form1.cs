using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using static IPAddressManager.PresetsForm;

namespace IPAddressManager
{
    public partial class Form1 : Form
    {
        private List<string> dnsAddresses = new List<string>();
        private readonly string dnsFilePath = "dnsAddresses.txt"; // File to store DNS addresses
        private NotifyIcon notifyIcon;
        private static Form1 instance; // Static variable to hold the single instance

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;

            notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application, // Set your icon here
                Visible = false, // Initially hidden
                ContextMenuStrip = contextMenuStrip1 // Assign the ContextMenuStrip
            };

            notifyIcon.MouseClick += NotifyIcon_MouseClick; // Handle regular click

            contextMenuStrip1.Opening += contextMenuStrip1_Opening; // This assumes you named your ContextMenuStrip "contextMenuStrip1"
                                                                    // Check if an instance already exists
            if (instance != null)
            {
                instance.BringToFront(); // Bring the existing instance to the front
                this.Close(); // Close the new instance
                return;
            }
            instance = this; // Set the current instance
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Load presets every time the context menu opens
            ShowPresets();
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Regular click to show the form
            {

               
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.BringToFront();
                
                
                

               
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(endApp) return;
            e.Cancel = true; // Prevent form from closing
            this.Hide(); // Hide the form instead
            notifyIcon.Visible = true; // Show the icon in the tray
        }
        bool endApp = false;
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false; // Hide the icon before closing
            endApp = true;
            Application.Exit(); // Close the application
        }


        private void ShowPresets()
        {
            // Clear existing items in the submenu
            applyPresetToolStripMenuItem.DropDownItems.Clear();

            // Load presets from a file or however you maintain them
            if (File.Exists("dnsPresets.txt"))
            {
                var lines = File.ReadAllLines("dnsPresets.txt");
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length == 3)
                    {
                        var preset = new DNSEntry(parts[0], parts[1], parts[2]);
                        ToolStripMenuItem item = new ToolStripMenuItem(preset.Name);
                        item.Click += (s, e) => ApplyPreset(preset); // Use lambda to call ApplyPreset method
                        applyPresetToolStripMenuItem.DropDownItems.Add(item);
                    }
                }
            }
        }


        private void ApplyPreset(DNSEntry preset)
        {
            if (preset != null)
            {
                ApplyDnsSettings(preset.PreferredDns, preset.AlternateDns);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCurrentDnsSettings(); // Load current DNS settings from Windows
            LoadDnsAddresses(); // Load saved DNS addresses

        }


        private void LoadCurrentDnsSettings()
        {
            // Clear previous items in the combo boxes and add "None"
            cmbPreferredDns.Items.Clear();
            cmbAlternateDns.Items.Clear();
            cmbPreferredDns.Items.Add("None");
            cmbAlternateDns.Items.Add("None");

            // Clear the list box
            listBoxDns.Items.Clear();

            // Variables to store DNS addresses
            string preferredDns = "None";
            string alternateDns = "None";

            // Retrieve DNS settings from Windows
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if ((ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet || ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                    && ni.OperationalStatus == OperationalStatus.Up)
                {
                    IPInterfaceProperties ipProperties = ni.GetIPProperties();


                    var dnsList = ipProperties.DnsAddresses.Select(dns => dns.ToString()).ToList();

                    if (dnsList.Count > 0)
                    {
                        // If only one DNS is set, it becomes the Preferred DNS
                        preferredDns = dnsList[0];

                        // If a second DNS exists, it becomes the Alternate DNS
                        if (dnsList.Count > 1)
                        {
                            alternateDns = dnsList[1];
                        }

                        // Add the DNS addresses to the list and combo boxes
                        foreach (var dns in dnsList)
                        {
                            if (!dnsAddresses.Contains(dns))
                            {
                                dnsAddresses.Add(dns);
                                listBoxDns.Items.Add(dns);
                                cmbPreferredDns.Items.Add(dns);
                                cmbAlternateDns.Items.Add(dns);
                            }
                        }
                        break; // We only need the DNS settings from one active adapter
                    }
                }
            }

            // Set the combo boxes to the current DNS settings
            cmbPreferredDns.SelectedItem = cmbPreferredDns.Items.Contains(preferredDns) ? preferredDns : "None";
            cmbAlternateDns.SelectedItem = cmbAlternateDns.Items.Contains(alternateDns) ? alternateDns : "None";
        }




        // Event: Apply the DNS addresses
        private void btnSetDns_Click(object sender, EventArgs e)
        {
            string preferredDns = cmbPreferredDns.SelectedItem?.ToString();
            string alternateDns = cmbAlternateDns.SelectedItem?.ToString();

            // Handle "None" selection by reverting to DHCP
            if ((preferredDns == "None" || string.IsNullOrEmpty(preferredDns)) &&
                (alternateDns == "None" || string.IsNullOrEmpty(alternateDns)))
            {
                ClearDnsSettings();

                return;
            }

            List<string> dnsToSet = new List<string>();

            if (!string.IsNullOrEmpty(preferredDns) && preferredDns != "None")
            {
                dnsToSet.Add(preferredDns);
            }

            if (!string.IsNullOrEmpty(alternateDns) && alternateDns != "None")
            {
                dnsToSet.Add(alternateDns);
            }

            if (dnsToSet.Count > 0)
            {
                SetDnsSettings(dnsToSet);
                MessageBox.Show("DNS settings applied successfully.");
            }
        }

        // Helper: Set DNS settings for all network adapters
        private void SetDnsSettings(List<string> dnsServers)
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if ((ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet || ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                    && ni.OperationalStatus == OperationalStatus.Up)
                {
                    if (dnsServers.Count > 0)
                    {
                        // Set the "Preferred" DNS server
                        string command = $"netsh interface ip set dns name=\"{ni.Name}\" static {dnsServers[0]}";
                        ExecuteCommand(command);

                        // Set the "Alternate" DNS server, if available
                        if (dnsServers.Count > 1)
                        {
                            command = $"netsh interface ip add dns name=\"{ni.Name}\" {dnsServers[1]} index=2";
                            ExecuteCommand(command);
                        }
                    }
                }
            }
        }

        // Event: Add a DNS address
        private void btnAddDns_Click(object sender, EventArgs e)
        {
            string dns = ipAddressControl.GetIPAddress();
            if (IsValidIPAddress(dns))
            {
                // Check if the IP address already exists in the list
                if (dnsAddresses.Contains(dns))
                {
                    MessageBox.Show("This IP address already exists in the list.");
                }
                else
                {
                    // Add the new DNS address if it doesn't exist
                    dnsAddresses.Add(dns);
                    listBoxDns.Items.Add(dns);
                    cmbPreferredDns.Items.Add(dns);
                    cmbAlternateDns.Items.Add(dns);
                    SaveDnsAddresses(); // Save DNS addresses to file
                }
                ipAddressControl.SetIPAddress(""); // Clear the control
            }
            else
            {
                MessageBox.Show("Invalid IP address format. Please enter a valid IP address.");
                ipAddressControl.SetIPAddress(""); // Clear the control
            }
        }


        // Event: Edit the selected DNS address
        private void btnEditDns_Click(object sender, EventArgs e)
        {
            if (listBoxDns.SelectedItem != null)
            {
                string selectedDns = listBoxDns.SelectedItem.ToString();
                ipAddressControl.SetIPAddress(selectedDns);
                dnsAddresses.Remove(selectedDns);
                listBoxDns.Items.Remove(selectedDns);
                cmbPreferredDns.Items.Remove(selectedDns);
                cmbAlternateDns.Items.Remove(selectedDns);
                SaveDnsAddresses(); // Save updated DNS addresses to file
            }
        }

        // Event: Remove the selected DNS address
        private void btnRemoveDns_Click(object sender, EventArgs e)
        {
            if (listBoxDns.SelectedItem != null)
            {
                string selectedDns = listBoxDns.SelectedItem.ToString();
                dnsAddresses.Remove(selectedDns);
                listBoxDns.Items.Remove(selectedDns);
                cmbPreferredDns.Items.Remove(selectedDns);
                cmbAlternateDns.Items.Remove(selectedDns);
                SaveDnsAddresses(); // Save updated DNS addresses to file
            }
        }

        // Event: Clear the DNS settings
        private void btnClearDns_Click(object sender, EventArgs e)
        {
            ClearDnsSettings();
            MessageBox.Show("DNS settings cleared.");
        }


        // Helper: Clear DNS settings for all network adapters and revert to DHCP
        private void ClearDnsSettings()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType != NetworkInterfaceType.Loopback && ni.OperationalStatus == OperationalStatus.Up)
                {
                    string command = $"netsh interface ip set dns name=\"{ni.Name}\" dhcp";
                    ExecuteCommand(command);
                }
            }
            cmbPreferredDns.SelectedItem = "None";
            cmbAlternateDns.SelectedItem = "None";
            this.Close();
        }
        // Event: Load event for ipAddressControl (if necessary)
        private void ipAddressControl_Load(object sender, EventArgs e)
        {
            // This method can be left empty unless specific actions are needed when the control loads
        }

        // Helper: Execute a command with elevated permissions
        private void ExecuteCommand(string command)
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
            {
                Arguments = "/C " + command,
                Verb = "runas", // Run as administrator
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process process = Process.Start(psi);
            process.WaitForExit();
        }

        // Helper: Validate IP address format
        private bool IsValidIPAddress(string ipAddress)
        {
            return IPAddress.TryParse(ipAddress, out _);
        }

        // Method: Save DNS addresses to a file
        private void SaveDnsAddresses()
        {
            File.WriteAllLines(dnsFilePath, dnsAddresses);
        }

        // Method: Load DNS addresses from a file
        private void LoadDnsAddresses()
        {
            if (File.Exists(dnsFilePath))
            {
                dnsAddresses = new List<string>(File.ReadAllLines(dnsFilePath));
                foreach (string dns in dnsAddresses)
                {
                    listBoxDns.Items.Add(dns);
                    cmbPreferredDns.Items.Add(dns);
                    cmbAlternateDns.Items.Add(dns);
                }
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            // Clear all DNS addresses from the list
            dnsAddresses.Clear();

            // Clear all items from the list box and combo boxes
            listBoxDns.Items.Clear();
            cmbPreferredDns.Items.Clear();
            cmbAlternateDns.Items.Clear();

            // Add "None" back to the combo boxes and select it as the default option
            cmbPreferredDns.Items.Add("None");
            cmbAlternateDns.Items.Add("None");
            cmbPreferredDns.SelectedItem = "None";
            cmbAlternateDns.SelectedItem = "None";

            // Save the updated (empty) DNS addresses list to the file
            SaveDnsAddresses();

            MessageBox.Show("All DNS addresses have been removed.");
        }

        private void btnPresets_Click(object sender, EventArgs e)
        {
            using (var presetsForm = new PresetsForm(dnsAddresses, this)) // Pass the existing DNS addresses
            {
                presetsForm.ShowDialog();
            }
        }

        public void ApplyDnsSettings(string preferredDns, string alternateDns)
        {
            // Update the combo boxes with the preset DNS addresses
            cmbPreferredDns.SelectedItem = preferredDns;
            cmbAlternateDns.SelectedItem = alternateDns;

            // Instead of performing a click, call the logic directly
            SetDnsSettings(new List<string> { preferredDns, alternateDns });

         
            // Close the Presets form
            this.Close();
        }


        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Code to show the main form
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void clearDNSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Code to clear DNS settings
            ClearDnsSettings();
            MessageBox.Show("DNS settings cleared and reverted to DHCP.");
        }

        private void applyPresetToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            // Clear existing items in the submenu
            applyPresetToolStripMenuItem.DropDownItems.Clear();

            // Load presets from a file
            if (File.Exists("dnsPresets.txt"))
            {
                var lines = File.ReadAllLines("dnsPresets.txt");
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length == 3)
                    {
                        var preset = new DNSEntry(parts[0], parts[1], parts[2]);
                        ToolStripMenuItem item = new ToolStripMenuItem(preset.Name);
                        item.Click += (s, ee) => ApplyPreset(preset); // Use lambda to call ApplyPreset method
                        applyPresetToolStripMenuItem.DropDownItems.Add(item);
                    }
                }
            }
        }
        private void applyPresetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Maximize the main form
            this.WindowState = FormWindowState.Maximized;

            // Show the PresetsForm
            using (var presetsForm = new PresetsForm(dnsAddresses, this)) // Pass the existing DNS addresses
            {
                presetsForm.ShowDialog();
            }
        }



    }
}