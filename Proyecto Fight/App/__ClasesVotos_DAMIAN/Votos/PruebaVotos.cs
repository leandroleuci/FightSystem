using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Votos
{
    public partial class PruebaVotos : Form
    {

        private bool Habil_J1_Azul_PA = true;
        private bool Habil_J1_Azul_PB = true;
        private bool Habil_J1_Azul_PC = true;

        private bool Habil_J1_Rojo_PA = true;
        private bool Habil_J1_Rojo_PB = true;
        private bool Habil_J1_Rojo_PC = true;

        private bool Habil_J2_Azul_PA = true;
        private bool Habil_J2_Azul_PB = true;
        private bool Habil_J2_Azul_PC = true;

        private bool Habil_J2_Rojo_PA = true;
        private bool Habil_J2_Rojo_PB = true;
        private bool Habil_J2_Rojo_PC = true;

        private bool Habil_J3_Azul_PA = true;
        private bool Habil_J3_Azul_PB = true;
        private bool Habil_J3_Azul_PC = true;

        private bool Habil_J3_Rojo_PA = true;
        private bool Habil_J3_Rojo_PB = true;
        private bool Habil_J3_Rojo_PC = true;

        private bool Habil_J4_Azul_PA = true;
        private bool Habil_J4_Azul_PB = true;
        private bool Habil_J4_Azul_PC = true;

        private bool Habil_J4_Rojo_PA = true;
        private bool Habil_J4_Rojo_PB = true;
        private bool Habil_J4_Rojo_PC = true;



        Ataque objAtaque = null;
        Punto objPunto = null;

        public PruebaVotos()
        {
            InitializeComponent();

            objAtaque = new Ataque(1, 2, 3, 4, 3);

        }

        #region ' Juez1

        private void btnRojo_A_Click(object sender, EventArgs e)
        {
            objPunto = new Punto(Ataque.nroJuez.J1, Ataque.tipoPunto.A, Ataque.Peleador.Rojo);

            objAtaque.Add(objPunto);

        }

        private void btnJuez1_Rojo_B_Click(object sender, EventArgs e)
        {
            objPunto = new Punto(Ataque.nroJuez.J1, Ataque.tipoPunto.B, Ataque.Peleador.Rojo);

            objAtaque.Add(objPunto);
        }

        private void btnJuez1_Rojo_C_Click(object sender, EventArgs e)
        {
            objPunto = new Punto(Ataque.nroJuez.J1, Ataque.tipoPunto.C, Ataque.Peleador.Rojo);

            objAtaque.Add(objPunto);
        }

        private void btnJuez1_Azul_A_Click(object sender, EventArgs e)
        {
            objPunto = new Punto(Ataque.nroJuez.J1, Ataque.tipoPunto.A, Ataque.Peleador.Azul);

            objAtaque.Add(objPunto);
        }

        private void btnJuez1_Azul_B_Click(object sender, EventArgs e)
        {
            objPunto = new Punto(Ataque.nroJuez.J1, Ataque.tipoPunto.B, Ataque.Peleador.Azul);

            objAtaque.Add(objPunto);
        }

        private void btnJuez1_Azul_C_Click(object sender, EventArgs e)
        {
            objPunto = new Punto(Ataque.nroJuez.J1, Ataque.tipoPunto.C, Ataque.Peleador.Azul);

            objAtaque.Add(objPunto);
        }


        #endregion
    
        #region ' Juez2


        private void btnJuez2_Rojo_A_Click(object sender, EventArgs e)
        {
            objPunto = new Punto(Ataque.nroJuez.J2, Ataque.tipoPunto.A, Ataque.Peleador.Rojo);

            objAtaque.Add(objPunto);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            objPunto = new Punto(Ataque.nroJuez.J2, Ataque.tipoPunto.B, Ataque.Peleador.Rojo);

            objAtaque.Add(objPunto);
        }

      private void button5_Click(object sender, EventArgs e)
        {
            objPunto = new Punto(Ataque.nroJuez.J2, Ataque.tipoPunto.C, Ataque.Peleador.Rojo);

            objAtaque.Add(objPunto);
        }

      private void button4_Click(object sender, EventArgs e)
        {
            objPunto = new Punto(Ataque.nroJuez.J2, Ataque.tipoPunto.A, Ataque.Peleador.Azul);

            objAtaque.Add(objPunto);
        }

         private void button3_Click(object sender, EventArgs e)
        {
            objPunto = new Punto(Ataque.nroJuez.J2, Ataque.tipoPunto.B, Ataque.Peleador.Azul);

            objAtaque.Add(objPunto);
        }

         private void button2_Click(object sender, EventArgs e)
        {
            objPunto = new Punto(Ataque.nroJuez.J2, Ataque.tipoPunto.C, Ataque.Peleador.Azul);

            objAtaque.Add(objPunto);
        }


        #endregion

        #region ' Juez3

        private void btnJuez3_Rojo_A_Click(object sender, EventArgs e)
         {
             objPunto = new Punto(Ataque.nroJuez.J3, Ataque.tipoPunto.A, Ataque.Peleador.Rojo);

             objAtaque.Add(objPunto);

         }

        private void button12_Click(object sender, EventArgs e)
         {
             objPunto = new Punto(Ataque.nroJuez.J3, Ataque.tipoPunto.B, Ataque.Peleador.Rojo);

             objAtaque.Add(objPunto);
         }

        private void button11_Click(object sender, EventArgs e)
         {
             objPunto = new Punto(Ataque.nroJuez.J3, Ataque.tipoPunto.C, Ataque.Peleador.Rojo);

             objAtaque.Add(objPunto);
         }

        private void button10_Click(object sender, EventArgs e)
         {
             objPunto = new Punto(Ataque.nroJuez.J3, Ataque.tipoPunto.A, Ataque.Peleador.Azul);

             objAtaque.Add(objPunto);
         }

        private void button9_Click(object sender, EventArgs e)
         {
             objPunto = new Punto(Ataque.nroJuez.J3, Ataque.tipoPunto.B, Ataque.Peleador.Azul);

             objAtaque.Add(objPunto);
         }

        private void button8_Click(object sender, EventArgs e)
         {
             objPunto = new Punto(Ataque.nroJuez.J3, Ataque.tipoPunto.C, Ataque.Peleador.Azul);

             objAtaque.Add(objPunto);
         }


         #endregion

        #region ' Juez4

          private void button19_Click(object sender, EventArgs e)
        {
            objPunto = new Punto(Ataque.nroJuez.J4, Ataque.tipoPunto.A, Ataque.Peleador.Rojo);

            objAtaque.Add(objPunto);

        }

        private void button18_Click(object sender, EventArgs e)
        {
            objPunto = new Punto(Ataque.nroJuez.J4, Ataque.tipoPunto.B, Ataque.Peleador.Rojo);

            objAtaque.Add(objPunto);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            objPunto = new Punto(Ataque.nroJuez.J4, Ataque.tipoPunto.C, Ataque.Peleador.Rojo);

            objAtaque.Add(objPunto);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            objPunto = new Punto(Ataque.nroJuez.J4, Ataque.tipoPunto.A, Ataque.Peleador.Azul);

            objAtaque.Add(objPunto);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            objPunto = new Punto(Ataque.nroJuez.J4, Ataque.tipoPunto.B, Ataque.Peleador.Azul);

            objAtaque.Add(objPunto);
        }

       private void button14_Click(object sender, EventArgs e)
        {
            objPunto = new Punto(Ataque.nroJuez.J4, Ataque.tipoPunto.C, Ataque.Peleador.Azul);

            objAtaque.Add(objPunto);
        }


        #endregion


        private void button1_Click(object sender, EventArgs e)
        {
            CalcularPuntosAtaque();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.txtTotalPuntajeAzul.Text = "0";
            this.txtTotalPuntajeRojo.Text = "0";
        }


        private void CalcularPuntosAtaque()
        {
            int puntosAzul = 0, puntosRojo = 0;
            objAtaque.CalcularPuntaje(ref puntosAzul, ref puntosRojo);

            this.txtTotalPuntajeAzul.Text = puntosAzul.ToString();
            this.txtTotalPuntajeRojo.Text = puntosRojo.ToString();
        }


          



    }
}
