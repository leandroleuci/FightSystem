using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PruebaPuntaje
{
    public partial class Form1 : Form
    {
        private int[] votoJ1;
        private int[] votoJ2;



        public Form1()
        {
            InitializeComponent();
        }

        private void btnRojo_A_Click(object sender, EventArgs e)
        {

        }


        public void AgregarVoto(string juez, string voto)
        {

            int valorVoto = 0;

            switch (juez)
            {
                case "J1":
                    //votoJ1[votoJ1. + 1] += valorVoto;
                    break;
                case "2":
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }
    }
}
