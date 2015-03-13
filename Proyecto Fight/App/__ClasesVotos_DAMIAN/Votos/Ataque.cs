using System;
using System.Collections.Generic;
using System.Text;


public class Ataque
{
    private int pA, pB, pC;
    private int cantJueces, cantVotosParaAprobar;

    public List<Punto> Puntos = new List<Punto>();

    public Ataque()
    { }

    public enum nroJuez
    {
        J1, J2, J3, J4
    }

    public enum tipoPunto
    {
        A, B, C
    }

    public enum Peleador
    {
        Azul, Rojo
    }

    public Ataque(int PA, int PB, int PC, int CantJueces, int CantVotosParaAprobar)
    {
        pA = PA;
        pB = PB;
        pC = PC;

        cantVotosParaAprobar = CantVotosParaAprobar;
        cantJueces = CantJueces;
    }

    public void Add(Punto p)
    {
        Puntos.Add(p);
    }

    public void CalcularPuntaje(ref int puntosAzul, ref int puntosRojo)
        {
            int sumaPuntajeAzul = 0;
            int sumaPuntajeRojo = 0;

            double NumCorreccion = 0;

            foreach (var item in Puntos)
            {
                if (item.peleador == Peleador.Azul)
                {
                    switch (item.punto)
                    {
                        case tipoPunto.A:
                            sumaPuntajeAzul += pA;
                            break;
                        case tipoPunto.B:
                            sumaPuntajeAzul += pB;
                            break;
                        case tipoPunto.C:
                            sumaPuntajeAzul += pC;
                            break;
                        default:
                            //dostuff;
                            break;
                    }
                }

                if (item.peleador == Peleador.Rojo)
                {
                    switch (item.punto)
                    {
                        case tipoPunto.A:
                            sumaPuntajeRojo += pA;
                            break;
                        case tipoPunto.B:
                            sumaPuntajeRojo += pB;
                            break;
                        case tipoPunto.C:
                            sumaPuntajeRojo += pC;
                            break;
                        default:
                            //dostuff;
                            break;
                    }
                }
            }

            NumCorreccion = (double)cantVotosParaAprobar / cantJueces;

            puntosAzul = Convert.ToInt16(Math.Round((sumaPuntajeAzul * NumCorreccion) / cantJueces));
            puntosRojo = Convert.ToInt16(Math.Round((sumaPuntajeRojo * NumCorreccion)/ cantJueces));

            Puntos.Clear();

        }

}

