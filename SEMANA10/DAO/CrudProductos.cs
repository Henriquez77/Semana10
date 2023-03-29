using System;
using System.Collections.Generic;
using System.Text;
using SEMANA10.Models;
using System.Linq;

namespace SEMANA10.DAO
{
     public class CrudProductos
    {
        public int Insert(Producto producto)
        {
            //Insert
            using (AlmacenContext context = new AlmacenContext())
            {
                context.Add(producto);
                return context.SaveChanges();
            }
        }
        public Producto SelectById(Producto producto)
        {
            //SelectById
            using (AlmacenContext context = new AlmacenContext())
            {
                return context.Productos.FirstOrDefault(x => x.Id == producto.Id);
            }
        }
        public int Update(Producto producto)
        {
            using (AlmacenContext context = new AlmacenContext())
            {
                context.Update(producto);
                return context.SaveChanges();
            }
        }
        public List<Producto> SelectAll()
        {
            using (AlmacenContext context = new AlmacenContext())
            {
                return context.Productos.ToList();
            }
        }
        public int Delete(Producto producto)
        {
            using (AlmacenContext context = new AlmacenContext())
            {
                context.Productos.Remove(producto);
                return context.SaveChanges();
            }
        }
    }

}
