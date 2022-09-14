using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01Encap
{
    public class Negocio
    {
        private PuestoAtencion caja;
        private Queue<Cliente> clientes;
        private string nombre;

        private Negocio()
        {
            clientes = new Queue<Cliente>();
            caja = new PuestoAtencion(PuestoAtencion.Puesto.Caja1);
        }

        public Negocio(string nombre):this()
        {
            this.nombre = nombre;
        }

        public Cliente Clientes
        {
            get
            {
                return this.clientes.Dequeue();
            }
            set
            {
                _ = this + value;
            }
        }
        public int ClientesPendientes
        {
            get
            {
                return this.clientes.Count;
            }
        }
        public static bool operator +(Negocio n , Cliente c)
        {
            bool todoOk = false;

            if(n != c)
            {
                n.clientes.Enqueue(c);
                todoOk = true;
            }
            return todoOk;
        }

        public static bool operator ==(Negocio n, Cliente c)
        {
            bool todoOk = false;

            foreach (Cliente item in n.clientes)
            {
                if (item == c)
                {
                    todoOk = true;
                }
            }
            return todoOk;
        }
        public static bool operator !=(Negocio n, Cliente c)
        {
            return !(n == c);
        }
        public static bool operator ~(Negocio n)
        {
            bool todoOk = false;
            if(n.clientes.Count > 0)
            {
                todoOk = n.caja.Atender(n.Clientes);
            }
            return todoOk;
        }


    }
}
