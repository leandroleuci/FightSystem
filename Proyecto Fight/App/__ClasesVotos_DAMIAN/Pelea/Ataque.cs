using System;
using System.Collections.Generic;
using System.Text;

namespace Pelea
{
    public class Ataque
    {
        private int pA, pB, pC;
        public List<Punto> Puntos = new List<Punto>();

        public enum nroJuez
        {
            J1,J2,J3,J4
        }

        public enum tipoPunto
        {
            A,B,C
        }

        public enum Peleador
        { 
            Azul, Rojo
        }

        public Ataque(int PA, int PB, int PC)
        {
            pA = PA;
            pB = PB;
            pC = PC;
        }

        public void Add(Punto p)
        {
            Puntos.Add(p);
        }

        public int Puntaje()
        {
            int puntaje = 0;

            return puntaje;
        }

    }
}
