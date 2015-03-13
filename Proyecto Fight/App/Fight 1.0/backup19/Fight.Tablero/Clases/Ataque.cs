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
        bool puntuacionPerfecta = false;

        int sumaPuntajeAzul = 0;
        int sumaPuntajeRojo = 0;

        double NumCorreccion = 0;

        #region CalculoPuntajeJuezAcumulado
        int[] azul = new int[4];
        int[] rojo = new int[4];
        int tempValPunto = 0;

        foreach (var item in Puntos)
        {
            switch (item.punto)
            {
                case tipoPunto.A:
                    tempValPunto = pA;
                    break;
                case tipoPunto.B:
                    tempValPunto = pB;
                    break;
                case tipoPunto.C:
                    tempValPunto = pC;
                    break;
                default:
                    //dostuff;
                    break;
            }

            if (item.peleador == Peleador.Azul)
            {
                switch (item.juez)
                {
                    case nroJuez.J1:
                        azul[0] += tempValPunto; //acuJ1_azul
                        break;
                    case nroJuez.J2:
                        azul[1] += tempValPunto; //acuJ2_azul 
                        break;
                    case nroJuez.J3:
                        azul[2] += tempValPunto; //acuJ3_azul 
                        break;
                    case nroJuez.J4:
                        azul[3] += tempValPunto; //acuJ4_azul 
                        break;
                    default:
                        //dostuff;
                        break;
                }
            }

            if (item.peleador == Peleador.Rojo)
            {
                switch (item.juez)
                {
                    case nroJuez.J1:
                        rojo[0] += tempValPunto; //acuJ1_Rojo
                        break;
                    case nroJuez.J2:
                        rojo[1] += tempValPunto; //acuJ2_Rojo 
                        break;
                    case nroJuez.J3:
                        rojo[2] += tempValPunto; //acuJ3_Rojo 
                        break;
                    case nroJuez.J4:
                        rojo[3] += tempValPunto; //acuJ4_Rojo 
                        break;
                    default:
                        //dostuff;
                        break;
                }
            }
            tempValPunto = 0;
        }

        #endregion

        #region CalculoPuntajeLuchadorAcumulado
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

        #endregion

        #region VerificacionDePuntuacionPerfecta
        int cantRepite = 0;
        foreach (int acuJuez1 in azul)
        {
            if (!puntuacionPerfecta)
            {
                foreach (int acuJuez2 in azul)
                    if (acuJuez1 == acuJuez2)
                        cantRepite += 1;

                if (cantRepite == cantVotosParaAprobar)
                    puntuacionPerfecta = true;
                else
                    cantRepite = 0;
            }
        }
        #endregion

        if (!puntuacionPerfecta)
            NumCorreccion = (double)cantVotosParaAprobar / cantJueces;
        else
            NumCorreccion = 1;


        puntosAzul = Convert.ToInt16(Math.Round((sumaPuntajeAzul * NumCorreccion) / cantJueces));
        puntosRojo = Convert.ToInt16(Math.Round((sumaPuntajeRojo * NumCorreccion) / cantJueces));

        ReiniciarPuntaje();

    }

    public void ReiniciarPuntaje()
    {
        Puntos.Clear();
    }

}

