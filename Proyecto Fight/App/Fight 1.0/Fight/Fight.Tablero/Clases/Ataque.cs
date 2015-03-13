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

    public void CalcularPuntaje(ref int puntosRojo, ref int puntosAzul, ref int[] _azul, ref int[] _rojo)
    {
        int puntuacionPerfectaRojo = 0;
        int puntuacionPerfectaAzul = 0;

        int sumaPuntajeAzul = 0;
        int sumaPuntajeRojo = 0;

        double NumCorreccionRojo = 0;
        double NumCorreccionAzul = 0;

        #region CalculoPuntajeJuezAcumulado
        int[] azul = new int[cantJueces];
        int[] rojo = new int[cantJueces];
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

        #region Sumatorias de votos de jueces para Auditoria
        int numeroJuez = 0;
        foreach (int sumaVotos in azul)
        {
            _azul[numeroJuez] = sumaVotos;
            numeroJuez++;
        }
        numeroJuez = 0;

        foreach (int sumaVotos in rojo)
        {
            _rojo[numeroJuez] = sumaVotos;
            numeroJuez++;
        }
        #endregion
        
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

        #region Verificacion de Minima cantidad de votaciones para calcular puntaje

        int cantDePuntuacionesNulas = cantJueces - cantVotosParaAprobar;
        bool VotacionValidaRojo = true, VotacionValidaAzul = true;
        int cantCerosRojo = 0;
        int cantCerosAzul = 0;

        foreach (int acuJuez1 in rojo)
        {
            if (acuJuez1 == 0)
                cantCerosRojo += 1;
        }

        if (cantCerosRojo > cantDePuntuacionesNulas)
            VotacionValidaRojo = false;

        foreach (int acuJuez1 in azul)
        {
            if (acuJuez1 == 0)
                cantCerosAzul += 1;
        }


        if (cantCerosAzul > cantDePuntuacionesNulas)
            VotacionValidaAzul = false;

        #endregion


        #region VerificacionDePuntuacionPerfecta
        //comprobacion si una puntuacion de un juez se repite la cantidad de veces minima de votacion para no ajustar el valor

        int cantRepite = 0;
        if (sumaPuntajeRojo != 0)
        {
            foreach (int acuJuez1 in rojo)
            {
                //if (!puntuacionPerfectaRojo)
                //{


                foreach (int acuJuez2 in rojo)
                    if (acuJuez1 == acuJuez2 && acuJuez2 != 0)
                        cantRepite += 1;

                if (cantRepite >= cantVotosParaAprobar) // || cantRepite == cantJueces)
                    puntuacionPerfectaRojo = cantRepite;
                //else
                //    if (cantRepite == cantJueces)
                //        puntuacionPerfectaRojo = cantJueces;

                cantRepite = 0;
                //}
            }
        }

        cantRepite = 0;

        if (sumaPuntajeAzul != 0)
        {
            foreach (int acuJuez1 in azul)
            {
                //if (!puntuacionPerfectaAzul)
                //{


                foreach (int acuJuez2 in azul)
                    if (acuJuez1 == acuJuez2 && acuJuez2 != 0)
                        cantRepite += 1;

                if (cantRepite >= cantVotosParaAprobar) // || cantRepite == cantJueces)
                    puntuacionPerfectaAzul = cantRepite;
                //else if (cantRepite == cantJueces)
                //    puntuacionPerfectaAzul = cantJueces;

                cantRepite = 0;
                //}
            }
        }
        #endregion

        if (VotacionValidaRojo)
            if (puntuacionPerfectaRojo == 0)
            {
                NumCorreccionRojo = (double)cantVotosParaAprobar / cantJueces;
                puntosRojo = Convert.ToInt16(Math.Round((sumaPuntajeRojo * NumCorreccionRojo) / cantJueces));
            }
            else
                puntosRojo = Convert.ToInt16(Math.Round((sumaPuntajeRojo * 1.0) / puntuacionPerfectaRojo));

        if (VotacionValidaAzul)
            if (puntuacionPerfectaAzul == 0)
            {
                NumCorreccionAzul = (double)cantVotosParaAprobar / cantJueces;
                puntosAzul = Convert.ToInt16(Math.Round((sumaPuntajeAzul * NumCorreccionAzul) / cantJueces));
            }
            else
                puntosAzul = Convert.ToInt16(Math.Round((sumaPuntajeAzul * 1.0) / puntuacionPerfectaAzul));

        ReiniciarPuntaje();

    }

    public void ReiniciarPuntaje()
    {
        Puntos.Clear();
    }

}

