using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Reflection;

namespace USBDriveSerialNumber {
    public partial class Form1 : Form {
        
        WindowsMessageFilter myFilter = new WindowsMessageFilter();

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            myFilter.setTextBox(ref textBox2);
            Application.AddMessageFilter(myFilter);

        }

        private void button2_Click(object sender, EventArgs e) {
            USBSerialNumber usb = new USBSerialNumber();
            string serial = usb.getSerialNumberFromDriveLetter(textBox1.Text);
            MessageBox.Show(serial);
        }
    }
}