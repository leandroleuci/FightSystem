using System;
using System.Collections.Generic;
using System.Text;

        /// <summary>
        /// Estados de la pelea.
        /// </summary>
        public enum enumEstado
        {
            Inicio = 0,
            Round1 = 1,
            Round2 = 2,
            Round3 = 3,
            EnCurso   = 4,
            FinRound = 5,
            Descaso = 6,
            FinDescanso = 7,
            GoldenPoint = 99,
            Fin = 9,
            TiempoMedico = 10,
            Pause = 12

        }


        public class excepciones
        {
            public const string CopiaIlegal = "La copia del producto no es original. Consulte al distribuidor del producto.";
            public const string LecturaKeyBat = "No se pudo leer la llave del producto. Verifique el la llave exista o que la copia del producto sea original.";
            public const string EncriptadoNumeroSerie = "Ocurrió un error al intentar validar la copia del producto. Informe al distribuidor del producto.";

        }
