using System;
using System.Collections.Generic;
using System.Text;

namespace FlotaMariaPerezGoti
{
    // Representa una jugada: donde disparaste y que paso
    public class Jugada
    {
        public int Numero { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public string Resultado { get; set; }

        public Jugada(int numero, int posX, int posY, string resultado)
        {
            Numero = numero;
            PosX = posX;
            PosY = posY;
            Resultado = resultado;
        }
    }
}