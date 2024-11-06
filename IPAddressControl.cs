using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;



    namespace IPAddressManager
    {
        public partial class IPAddressControl : UserControl
        {
            private TextBox[] octetTextBoxes = new TextBox[4];

            public IPAddressControl()
            {
                InitializeComponent();

                // Initialize and add TextBoxes
                for (int i = 0; i < 4; i++)
                {
                    octetTextBoxes[i] = new TextBox
                    {
                        MaxLength = 3,
                        Width = 30,
                        Location = new Point(i * 35, 0), // Adjust spacing as needed
                        BackColor = SystemColors.Window,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    octetTextBoxes[i].TextChanged += OctetTextBox_TextChanged;
                    octetTextBoxes[i].KeyDown += OctetTextBox_KeyDown;
                    octetTextBoxes[i].ContextMenuStrip = new ContextMenuStrip(); // Prevent default paste context menu
                    octetTextBoxes[i].ContextMenuStrip.Opening += HandleContextMenuPaste;
                    Controls.Add(octetTextBoxes[i]);
                }
            }

            // Handle paste operation when right-click menu is opened
            private void HandleContextMenuPaste(object sender, System.ComponentModel.CancelEventArgs e)
            {
                if (Clipboard.ContainsText())
                {
                    string clipboardText = Clipboard.GetText();
                    if (IsValidIPAddress(clipboardText))
                    {
                        SetIPAddress(clipboardText);
                    }
                }
                e.Cancel = true; // Cancel the default context menu
            }

            private void OctetTextBox_TextChanged(object sender, EventArgs e)
            {
                TextBox textBox = sender as TextBox;
                if (int.TryParse(textBox.Text, out int value) && (value < 0 || value > 255))
                {
                    MessageBox.Show("Each octet must be a number between 0 and 255.");
                    textBox.Clear();
                }
            }

            private void OctetTextBox_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Control && e.KeyCode == Keys.V)
                {
                    string clipboardText = Clipboard.GetText();
                    if (IsValidIPAddress(clipboardText))
                    {
                        SetIPAddress(clipboardText);
                    }
                    e.Handled = true;
                }
                else
                {
                    TextBox textBox = sender as TextBox;
                    if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Right)
                    {
                        MoveToNextOctet(textBox);
                    }
                    else if (e.KeyCode == Keys.Left)
                    {
                        MoveToPreviousOctet(textBox);
                    }
                }
            }

            private void MoveToNextOctet(TextBox textBox)
            {
                int index = Array.IndexOf(octetTextBoxes, textBox);
                if (index < 3)
                {
                    octetTextBoxes[index + 1].Focus();
                }
            }

            private void MoveToPreviousOctet(TextBox textBox)
            {
                int index = Array.IndexOf(octetTextBoxes, textBox);
                if (index > 0)
                {
                    octetTextBoxes[index - 1].Focus();
                }
            }

            public string GetIPAddress()
            {
                return string.Join(".", octetTextBoxes.Select(tb => tb.Text));
            }

            public void SetIPAddress(string ipAddress)
            {
                string[] octets = ipAddress.Split('.');
                for (int i = 0; i < octetTextBoxes.Length; i++)
                {
                    if (i < octets.Length)
                    {
                        octetTextBoxes[i].Text = octets[i];
                    }
                    else
                    {
                        octetTextBoxes[i].Text = ""; // Clear remaining text boxes
                    }
                }
            }


        private bool IsValidIPAddress(string ipAddress)
            {
                return IPAddress.TryParse(ipAddress, out _);
            }

            private void InitializeComponent()
            {
                this.SuspendLayout();
                this.Name = "IPAddressControl";
                this.Size = new System.Drawing.Size(150, 25); // Adjust size as needed
                this.ResumeLayout(false);
            }
        }
    }

