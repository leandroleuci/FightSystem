using System;
using System.Collections.Generic;
using System.Text;

namespace Fight.Tablero.Clases
{
    public class Fight
    {

        public event EventHandler DiferenciaPuntos;
        public event EventHandler MaximaFaltas;
        public event EventHandler PuntuacionMaxima;


        Clases.Parametrizacion objParametrizacion = null;

        struct combatiente
        {
            public int puntaje;
            public int faltas;

            public string nombre;
            public int edad;
            public int peso;
            public char sexo;
            public char nacionalidad;

            public bool rojo;
        };

        struct juez
        {
            public string nombre;

            public bool voto;

            public bool PuntoA;
            public bool PuntoB;
            public bool PuntoC;

            public int[] Votos;
        };

        struct arbitroCentral
        {
            public string nombre;
        };

        struct coach
        {
            public string nombre;
            public bool rojo;
        };

        private combatiente combatienteAzul;
        private combatiente combatienteRojo;

        private juez juez1;
        private juez juez2;
        private juez juez3;
        private juez juez4;

        //Valores Iniciales

        public int estadoPelea { get; set; }
        public int roundActual { get; set; }

        public Fight()
        {

            objParametrizacion = new Clases.Parametrizacion();

            estadoPelea = enumEstado.Inicio.GetHashCode();
            roundActual = enumEstado.Round1.GetHashCode();

        }

        #region Puntos
        public int PuntoCombatienteAzul(int Valor, bool suma)
        {
            if (suma)
                combatienteAzul.puntaje = combatienteAzul.puntaje + Valor;
            else
            {
                combatienteAzul.puntaje = combatienteAzul.puntaje - Valor;

                if (combatienteAzul.puntaje < 0)
                    combatienteAzul.puntaje = 0;
            }

            if (combatienteAzul.puntaje >= objParametrizacion.puntuacionMaxima)
                PuntuacionMaxima.Invoke(null, null);

            if ((combatienteAzul.puntaje - combatienteRojo.puntaje) >= objParametrizacion.diferenciaPuntos)
                DiferenciaPuntos.Invoke(null, null);


            return combatienteAzul.puntaje;
        }

        public int PuntoCombatienteRojo(int Valor, bool suma)
        {
            if (suma)
                combatienteRojo.puntaje = combatienteRojo.puntaje + Valor;
            else
            {
                combatienteRojo.puntaje = combatienteRojo.puntaje - Valor;

                if (combatienteRojo.puntaje < 0)
                    combatienteRojo.puntaje = 0;
            }

            if (combatienteRojo.puntaje >= objParametrizacion.puntuacionMaxima)
                PuntuacionMaxima.Invoke(null, null);

            if ((combatienteRojo.puntaje - combatienteAzul.puntaje) >= objParametrizacion.diferenciaPuntos)
                DiferenciaPuntos.Invoke(null, null);

            return combatienteRojo.puntaje;
        }

        #endregion

        #region Faltas

        public int FaltaCombatienteAzul()
        {
            combatienteAzul.faltas = combatienteAzul.faltas + objParametrizacion.valorFalta;

            if ((combatienteAzul.faltas - combatienteRojo.faltas) >= objParametrizacion.faltasMaximas)
            {
                MaximaFaltas.Invoke(null, null);
            }

            return combatienteAzul.faltas;
        }

        public int ObtenerFaltasCombatienteAzul()
        {
            return combatienteAzul.faltas;
        }

        public int FaltaCombatienteRojo()
        {
            combatienteRojo.faltas = combatienteRojo.faltas + objParametrizacion.valorFalta;

            if ((combatienteRojo.faltas - combatienteAzul.faltas) >= objParametrizacion.faltasMaximas)
            {
                MaximaFaltas.Invoke(null, null);
            }

            return combatienteRojo.faltas;
        }

        public int ObtenerFaltasCombatienteRojo()
        {
            return combatienteRojo.faltas;
        }

        #endregion

        public void ResultadoFinal(ref bool rojo, ref bool azul, ref bool empate)
        {
            rojo = false;
            azul = false;
            empate = false;

            if ((combatienteAzul.puntaje - combatienteAzul.faltas) > (combatienteRojo.puntaje - combatienteRojo.faltas))
                azul = true;

            if ((combatienteAzul.puntaje - combatienteAzul.faltas) == (combatienteRojo.puntaje - combatienteRojo.faltas))
                empate = true;

            if ((combatienteAzul.puntaje - combatienteAzul.faltas) < (combatienteRojo.puntaje - combatienteRojo.faltas))
                rojo = true;
        }

        public void ReiniciarPuntuaciones()
        {
            this.combatienteAzul.faltas = 0;
            this.combatienteAzul.puntaje = 0;

            this.combatienteRojo.faltas = 0;
            this.combatienteRojo.puntaje = 0;
        }

    }


}
