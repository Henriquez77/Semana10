using System;
using SEMANA10.DAO;
using SEMANA10.Models;
using System.Threading;
using System.Collections.Generic;

namespace SEMANA10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create database Almacen;
            //use Almacen;

            //create table Producto(
            //    Id int primary key identity,
            //    Nombre varchar(50),
            //    Descripcion varchar(255),
            //    Precio decimal(16, 2),
            //    Stock int
            //);
            //insert into Producto(Nombre, Descripcion, Precio, Stock)
            //values('Intel core i9-12900', 'Procesador', 600.00, 15);

            Producto producto = new Producto();
            CrudProductos crudProductos = new CrudProductos();
            do
            {
                int op = 0;

                do
                {
                    Console.Clear();
                    Console.WriteLine("\n     Menu\n");
                    Console.WriteLine("1- Insertar producto");
                    Console.WriteLine("2- Listar productos");
                    Console.WriteLine("3- Listar productos por ID");
                    Console.WriteLine("4- Actualizar producto");
                    Console.WriteLine("5- Eliminar producto");
                    Console.WriteLine("6- Salir\n");
                    Console.Write("Selecciona una opcion valida ");
                    op = int.Parse(Console.ReadLine());
                    if (!(op >= 1 && op <= 6))
                    {
                        Console.WriteLine("\nOpcion invalida, intentalo de nuevo!");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        break;
                    }
                } while (true);
                switch (op)
                {
                    case 1:
                        //Insert
                        Console.Write("Ingrese el nombre del producto: ");
                        producto.Nombre = Console.ReadLine();
                        Console.Write("Ingrese la descripcion del producto: ");
                        producto.Descripcion = Console.ReadLine();
                        Console.Write("Ingrese el precio del producto: ");
                        producto.Precio = decimal.Parse(Console.ReadLine());
                        Console.Write("Ingrese el stock del producto: ");
                        producto.Stock = int.Parse(Console.ReadLine());
                        if (crudProductos.Insert(producto) > 0)
                        {
                            Console.WriteLine("\nProducto almacenado correctamente!");
                        }
                        Console.Write("\nPresiona una tecla para regresar");
                        Console.ReadKey();
                        break;
                    case 2:
                        //Read
                        foreach (var read in crudProductos.SelectAll())
                        {
                            Console.WriteLine("\n---------------------------------------");
                            Console.WriteLine($"Registro #{read.Id}");
                            Console.WriteLine($"Id: {read.Id}");
                            Console.WriteLine($"Nombre: {read.Nombre}");
                            Console.WriteLine($"Descripcion: {read.Descripcion}");
                            Console.WriteLine($"Precio: ${read.Precio}");
                            Console.WriteLine($"Stock: {read.Stock}");
                            Console.WriteLine("---------------------------------------\n");
                        }
                        Console.Write("\nPresiona una tecla para regresar");
                        Console.ReadKey();
                        break;
                    case 3:
                        //SelectById
                        Console.Write("Ingresa el ID del producto que desea visualizar: ");
                        producto.Id = int.Parse(Console.ReadLine());
                        if (crudProductos.SelectById(producto) != null)
                        {
                            List<Producto> selectById = new List<Producto>();
                            selectById.Add(crudProductos.SelectById(producto));

                            foreach (var read in selectById)
                            {
                                Console.WriteLine("\n---------------------------------------");
                                Console.WriteLine($"Registro #{read.Id}");
                                Console.WriteLine($"Id: {read.Id}");
                                Console.WriteLine($"Nombre: {read.Nombre}");
                                Console.WriteLine($"Descripcion: {read.Descripcion}");
                                Console.WriteLine($"Precio: ${read.Precio}");
                                Console.WriteLine($"Stock: {read.Stock}");
                                Console.WriteLine("---------------------------------------\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Error, ID {producto.Id} no esta registrado");

                        }
                        Console.Write("\nPresiona una tecla para regresar");
                        Console.ReadKey();
                        break;
                    case 4:
                        //Update
                        Console.Write("Ingresa el ID del producto que desea actualizar: ");
                        producto.Id = int.Parse(Console.ReadLine());
                        if (crudProductos.SelectById(producto) != null)
                        {
                            Console.Write("Ingrese el nuevo nombre del producto: ");
                            producto.Nombre = Console.ReadLine();
                            Console.Write("Ingrese la nueva descripcion del producto: ");
                            producto.Descripcion = Console.ReadLine();
                            Console.Write("Ingrese el nuevo precio del producto: ");
                            producto.Precio = decimal.Parse(Console.ReadLine());
                            Console.Write("Ingrese el nuevo stock del producto: ");
                            producto.Stock = int.Parse(Console.ReadLine());
                            if (crudProductos.Update(producto) > 0)
                            {
                                Console.WriteLine("\nProducto actualizado correctamente!");
                            }

                        }
                        else
                        {
                            Console.WriteLine($"Error, ID {producto.Id} no esta registrado");

                        }
                        Console.Write("\nPresiona una tecla para regresar");
                        Console.ReadKey();
                        break;
                    case 5:
                        //Delete
                        Console.Write("Ingresa el ID del producto que desea eliminar: ");
                        producto.Id = int.Parse(Console.ReadLine());
                        if (crudProductos.SelectById(producto) != null)
                        {
                            if (crudProductos.Delete(producto) > 0)
                            {
                                Console.WriteLine("\nProducto eliminado correctamente!");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Error, ID {producto.Id} no esta registrado");

                        }
                        Console.Write("\nPresiona una tecla para regresar");
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.WriteLine("\nFinalizando ejecucion!");
                        break;
                    default:
                        Console.WriteLine("\nFinalizando ejecucion!");
                        break;
                }
                if ((op != 1 && op != 2 && op != 3 && op != 4) || op == 5) { break; }
            } while (true);
        }
    }
}
