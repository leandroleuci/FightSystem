using System;
using System.Collections.Generic;
using System.Text;

namespace Pelea
{
    public class Punto
    {
        public Ataque.nroJuez juez;
        public Ataque.tipoPunto punto;
        public Ataque.Peleador peleador;

        public Punto(Ataque.nroJuez Juez, Ataque.tipoPunto Punto, Ataque.Peleador Peleador)
        {
            Juez = juez;
            Punto = punto;
            Peleador = peleador;
        }

    }
}
