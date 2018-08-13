using Ejercicio_1EntityFramework.Data;
using System;

namespace Ejercicio_1EntityFramework
{
    class Program
    {
        static readonly MockPersona Personarepository = new MockPersona();
        static readonly MockMascota Mascotarepository = new MockMascota();
        static void Main(string[] args)
        {
            int selecion = 0;
            do
            {
                Console.WriteLine(" 1) Menu Personas \n 2)Menu Mascota \n 3) Menu Intermedio\n 4)salir");
                if (int.TryParse(Console.ReadLine(), out selecion))
                {
                    switch (selecion)
                    {
                        case 1:
                            MenuPersona();
                            break;
                        case 2:
                            MenuMascota();
                            break;
                        case 3:
                            break;
                        case 4:
                        default:
                            Console.WriteLine("debe ser un numero del menu");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("debe ser un numero");
                }
            } while (selecion != 4);

        }

        static void MenuPersona()
        {
            int selecion = 0;
            do
            {
                Console.WriteLine(" 1) Agregar Personas \n 2)Eliminar Personas \n 3)Editar persona \n 4)Mostrar Todas las Personas\n 5)volver al menu principal");
                if (int.TryParse(Console.ReadLine(), out selecion))
                {
                    switch (selecion)
                    {
                        case 1:
                            CrearPersona();
                            break;
                        case 2:
                            EliminarPersona();
                            break;
                        case 3:
                            EditarPersona();
                            break;
                        case 4:
                            foreach (var item in Personarepository.GetAll())
                            {
                                Console.WriteLine("Cedula: " + item.Cedula + " Nombre: " + item.Nombre);
                            }
                            break;
                        case 5:
                        default:
                            Console.WriteLine("debe ser un numero del menu");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("debe ser un numero");
                }
            } while (selecion != 4);
        }

        static void MenuMascota()
        {
            int selecion = 0;
            do
            {
                Console.WriteLine(" 1) Agregar Mascota \n 2)Eliminar Mascota \n 3)Editar Mascota \n 4)Mostrar Todas las mascotas\n 5)volver al menu principal");
                if (int.TryParse(Console.ReadLine(), out selecion))
                {
                    switch (selecion)
                    {
                        case 1:
                            CrearMascota();
                            break;
                        case 2:
                            EliminarMascota();
                            break;
                        case 3:
                            EditarMascota();
                            break;
                        case 4:
                            foreach (var item in Mascotarepository.GetAll())
                            {
                                Console.WriteLine("Id: " + item.Id + " Nombre: " + item.Nombre);
                            }
                            break;
                        case 5:
                        default:
                            Console.WriteLine("debe ser un numero del menu");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("debe ser un numero");
                }
            } while (selecion != 4);
        }

        static void CrearPersona()
        {
            Persona persona = new Persona();
            Console.WriteLine("ingrese la cedula");
            if (int.TryParse(Console.ReadLine(), out int cedula))
            {
                persona.Cedula = cedula;
                Console.WriteLine("ingrese El nombre");
                persona.Nombre = Console.ReadLine();
                Console.WriteLine("ingrese la Fecha de nacimiento en formato dd/mm/aaaa");
                string fecha = Console.ReadLine();
                if (DateTime.TryParse(fecha, out DateTime fechaNacimieno))
                {
                    persona.FechaNacimiento = fechaNacimieno;
                    if (!Personarepository.Add(persona))
                    {
                        Console.WriteLine("ya existe una persona con este nombre");
                    }

                }
                else
                {
                    Console.WriteLine("la fecha no esta en un correcto formato");
                }
            }
            else
            {
                Console.WriteLine("la cedula debe ser numerica");
            }

        }
        static void EditarPersona()
        {
            foreach (var _persona in Personarepository.GetAll())
            {
                Console.WriteLine("Cedula: " + _persona.Cedula + " Nombre: " + _persona.Nombre);
            }

            Persona persona = new Persona();
            Console.WriteLine("Ingrese cedula a editar");
            if (int.TryParse(Console.ReadLine(), out int cedula))
            {
                persona.Cedula = cedula;
                Console.WriteLine("Ingrese nuevo nombre");
                persona.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese nueva fecha de nacimiento");
                Console.WriteLine("ingrese la Fecha de nacimiento en formato dd/mm/aaaa");
                string fecha = Console.ReadLine();
                if (DateTime.TryParse(fecha, out DateTime fechaNacimieno))
                {
                    persona.FechaNacimiento = fechaNacimieno;
                    if (!Personarepository.Edit(persona))
                    {
                        Console.WriteLine("El id no existe");
                    }

                }
                else
                {
                    Console.WriteLine("la fecha no esta en un correcto formato");
                }
            }
            else
            {
                Console.WriteLine("la cedula debe ser numerica");
            }

        }
        static void EliminarPersona()
        {
            foreach (var item in Personarepository.GetAll())
            {
                Console.WriteLine("Cedula: " + item.Cedula + " Nombre: " + item.Nombre);
            }
            Console.WriteLine("Ingrese cedula a eliminar");
            if (int.TryParse(Console.ReadLine(), out int cedula))
            {
                Personarepository.Delete(cedula);
            }
        }

        static void CrearMascota()
        {
            Mascota mascota = new Mascota();
            Console.WriteLine("ingrese El nombre");
            mascota.Nombre = Console.ReadLine();
            Console.WriteLine("ingrese la raza");
            mascota.Nombre = Console.ReadLine();
            mascota.EstadoAdopcion = false;
            Mascotarepository.Add(mascota);
        }

        static void EliminarMascota()
        {
            foreach (var item in Mascotarepository.GetAll())
            {
                Console.WriteLine("Id: " + item.Id + " Nombre: " + item.Nombre);
            }
            Console.WriteLine("Ingrese Id a eliminar");
            if (int.TryParse(Console.ReadLine(), out int Id))
            {
                Mascotarepository.Delete(Id);
            }
        }

        static void EditarMascota()
        {

        }
    }
}
