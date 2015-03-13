using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestJoystick
{
    public partial class Form1 : Form
    {

        private int trackValue   = 0;
        
        public Form1()
        {
            InitializeComponent();

            this.timer.Interval = 3000;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad1)
                this.panel1.BackColor = Color.Yellow;


            if (e.KeyCode == Keys.NumPad2)
                this.panel2.BackColor = Color.Yellow;


            if (e.KeyCode == Keys.NumPad3)
                this.panel3.BackColor = Color.Yellow;


            if (e.KeyCode == Keys.NumPad4)
                this.panel4.BackColor = Color.Yellow;
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad1)
                this.panel1.BackColor = Color.DarkGray;


            if (e.KeyCode == Keys.NumPad2)
                this.panel2.BackColor = Color.DarkGray;


            if (e.KeyCode == Keys.NumPad3)
                this.panel3.BackColor = Color.DarkGray;


            if (e.KeyCode == Keys.NumPad4)
                this.panel4.BackColor = Color.DarkGray;

            if (this.timer.Enabled)
                lblPuntaje.Text = Convert.ToString(Convert.ToInt16(lblPuntaje.Text) + 1);
            else
                AbrirVentana();
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            if (trackValue > 0)
            {
                trackValue -= 1;
                this.trackBar1.Value = trackValue;
            }
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            if (trackValue < 10)
            {
                trackValue += 1;
                this.trackBar1.Value = trackValue;
            }
        }

        //private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    this.timer.Enabled = true();
        //    this.timer.Start();
        //}

        //private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    this.Enabled=fal
        //}

        private void AbrirVentana()
        {
            this.lblPuntaje.Text = "0";

            this.timer.Enabled = true;
            this.timer.Start();
            this.panelWindow.BackColor = Color.Yellow;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.timer.Enabled = false;
            this.timer.Stop();
            this.panelWindow.BackColor = Color.Red;
        }



     
    }
}
