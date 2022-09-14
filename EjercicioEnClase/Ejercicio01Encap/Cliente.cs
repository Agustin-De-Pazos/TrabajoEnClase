using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01Encap
{
    public class Cliente
    {
        private string nombre;
        private int numero;

        public Cliente(int numero)
        {
            this.Numero = numero;
        }
        public Cliente(int numero, string nombre):this(numero)
        {
            this.Nombre = nombre;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Numero { get => numero; set => numero = value; }

        public static bool operator ==(Cliente c1, Cliente c2)
        {
            return c1.Numero == c2.Numero;
        }

        public static bool operator !=(Cliente c1, Cliente c2)
        {
            return c1.Numero == c2.Numero;
        }
    }
}
