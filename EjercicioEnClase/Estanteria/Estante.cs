using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estanteria
{
    public class Estante
    {
        private Producto[] producto;
        private int ubicacionEstante;

        private Estante(int capacidad)
        {
            producto = new Producto[capacidad];
        }

        public Estante(int capacidad, int ubicacion) : this(capacidad)
        {
            this.ubicacionEstante = ubicacion;
        }

        public Producto[] GetPRoductos()
        {
            return this.producto;
        }

        public static string MostrarEstante(Estante e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Producto x in e.producto)
            {
                sb.AppendLine($"{Producto.MostrarProducto(x)} \n");
            }

            return sb.ToString();
        }

        public static bool operator ==(Estante e, Producto p)
        {
            bool ok = false;
            foreach (Producto n in e.producto)
            {
                if (n is not null)
                {
                    if (n == p)
                    {
                        ok = true;
                        break;
                    }
                }

            }
            return ok;
        }

        public static bool operator !=(Estante e, Producto p)
        {
            return !(e == p);
        }

        public static bool operator +(Estante e, Producto p)
        {
            bool ok = false;
            if (e != p)
            {
                for (int i = 0; i < e.producto.Length; i++)
                {
                    if (e.producto[i] is null)
                    {
                        e.producto[i] = p;
                        ok = true;
                        break;
                    }
                }
            }
            return ok;
        }

        public static Estante operator -(Estante e, Producto p)
        {
            if (e != p)
            {
                for (int i = 0; i < e.producto.Length; i++)
                {
                    if (e.producto[i] is null)
                    {
                        e.producto[i] = null;
                        break;
                    }
                }
            }
            return e;
        }
    }
}
