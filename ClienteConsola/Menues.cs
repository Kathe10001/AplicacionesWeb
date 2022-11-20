using ClienteConsola.localhost;
using Logica.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClienteConsola
{
    public class Menues
    {
        localhost.WebService1 wService = new localhost.WebService1();

        #region Menu Display

        public String[] Menu()
        {
            String[] menu = { "                  Menu de Opciones: ",
                               "----------------------------------------------------------------------",
                               "",
                               "1 - Menú Cancion",
                               "2 - Menú Banda",
                               "3 - Menú Integrantes",
                               "4 - Menú Album",
                               "5 - Menú Usuario",

                               "6 - Salir" };
            return menu;
        }

        public String[] MenuCancion()
        {
            String[] menu = { "                  Menu de Opciones: ",
                               "----------------------------------------------------------------------",
                               "",
                               "1 - Alta Cancion",
                               "2 - Baja Cancion",
                               "3 - Listado Canciones",

                               "4 - Salir" };
            return menu;
        }

        public String[] MenuBanda()
        {
            String[] menu = { "                  Menu de Opciones: ",
                               "----------------------------------------------------------------------",
                               "",
                               "1 - Alta Banda",
                               "2 - Baja Banda",
                               "3 - Listado Bandas",
                               "4 - Añadir Integrante",
                               "5 - Quitar Integrante",

                               "6 - Salir" };
            return menu;
        }

        public String[] MenuIntegrante()
        {
            String[] menu = { "                  Menu de Opciones: ",
                               "----------------------------------------------------------------------",
                               "",
                               "1 - Alta Integrante",
                               "2 - Baja Integrante",
                               "3 - Listado Integrantes",

                               "4 - Salir" };
            return menu;
        }

        public String[] MenuAlbum()
        {
            String[] menu = { "                  Menu de Opciones: ",
                               "----------------------------------------------------------------------",
                               "",
                               "1 - Alta Album",
                               "2 - Baja Album",
                               "3 - Listado Albumes",
                               "4 - Añadir Cancion-Album",
                               "5 - Quitar Cancion-Album",

                               "6 - Salir" };
            return menu;
        }

        public String[] MenuUsuario()
        {
            String[] menu = { "                  Menu de Opciones: ",
                               "----------------------------------------------------------------------",
                               "",
                               "1 - Alta Usuario",
                               "2 - Baja Usuario",
                               "3 - Listado Usuarios",

                               "4 - Salir" };
            return menu;
        }

        public void ShowMenu(String[] menu)
        {
            Console.Clear();
            foreach (String line in menu)
                Console.WriteLine(line);
        }

        #endregion

        #region Option Selection Parsing

        public int? OptionSelected()
        {
            String lineRead = Console.ReadLine();
            int optionSelected;

            if (Int32.TryParse(lineRead, out optionSelected))
            {
                if (optionSelected >= 1 && optionSelected <= 6)
                    return optionSelected;
                else
                    return new int?();
            }
            else
                return new int?();
        }

        #endregion

        #region Execute Requeriments
        public void InsertarCancion()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese Nombre: ");
                String nombre = Console.ReadLine();
                Console.WriteLine("Ingrese Duracion: ");
                int duracion = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese Año: ");
                int anio = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese Genero: ");
                String genero = Console.ReadLine();
                Console.WriteLine("Ingrese ID Cantante: ");
                int idCantante = int.Parse(Console.ReadLine());
                wService.AltaCancion(nombre, duracion, genero, idCantante, anio);
                Console.WriteLine("Ingreso exitoso");
                Console.ReadLine();

            }
            catch (Exception e)
            {
                throw new ApplicationException("El dato ingresado no es correcto");
            }
        }
        public void BorrarCancion()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese ID de la cancion: ");
                int idEliminar = int.Parse(Console.ReadLine());
                wService.BajaCancion(idEliminar);
                Console.WriteLine("Borrado exitoso");
                Console.ReadLine();

            }
            catch (Exception e)
            {
                throw new ApplicationException("El dato ingresado no es correcto");
            }
        }
        public void ListarCancion()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Nombre\t Duracion\t Año\t Genero\t Cantante(ID)\t");
                VOCancion[] listVoc = wService.ListarCanciones(); //ya intenté de todo
                foreach (VOCancion vo in listVoc)
                {
                    Console.WriteLine(vo.Nombre + "\t " + vo.Duracion + "\t\t " + vo.Anio + "\t " + vo.GeneroMusical + "\t " + vo.IdCantante);
                }
                Console.ReadLine();

            }
            catch (Exception e)
            {
                throw new ApplicationException("El dato ingresado no es correcto");
            }
        }


        public void InsertarBanda()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese Nombre: ");
                String nombre = Console.ReadLine();
                Console.WriteLine("Ingrese Genero: ");
                String genero = Console.ReadLine();
                Console.WriteLine("Ingrese Año Creacion: ");
                int anioC = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese Año Separacion: ");
                int anioS = int.Parse(Console.ReadLine());
                wService.AltaBanda(nombre, genero, anioC, anioS);
                Console.WriteLine("Ingreso exitoso");
                Console.ReadLine();


            }
            catch (Exception e)
            {
                throw new ApplicationException("El dato ingresado no es correcto");
            }
        }
        public void BorrarBanda()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese ID de la banda: ");
                int idEliminar = int.Parse(Console.ReadLine());
                wService.BajaBanda(idEliminar);
                Console.WriteLine("Borrado exitoso");
                Console.ReadLine();

            }
            catch (Exception e)
            {
                throw new ApplicationException("El dato ingresado no es correcto");
            }
        }
        public void ListarBanda()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Nombre\t Genero\t Año-Creacion\t Año-Separacion\t");
                VOBanda[] listvob = wService.ListarBandas();
                foreach (var vo in listvob)
                {
                    Console.WriteLine(vo.Nombre + "\t " + vo.GeneroMusical + "\t " + vo.AnioCreacion + "\t " + vo.AnioSeparacion);
                }
                Console.ReadLine();

            }
            catch (Exception e)
            {
                throw new ApplicationException("El dato ingresado no es correcto");
            }
        }


        public void InsertarIntegrante()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese Nombre: ");
                String nombre = Console.ReadLine();
                Console.WriteLine("Ingrese Apellido: ");
                String apellido = Console.ReadLine();
                Console.WriteLine("Ingrese Fecha Nacimiento: ");
                DateTime fechaN = DateTime.Parse(Console.ReadLine());
                wService.AltaIntegrante(nombre, apellido, fechaN);
                Console.WriteLine("Ingreso exitoso");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                throw new ApplicationException("El dato ingresado no es correcto");
            }
        }
        public void BorrarIntegrante()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese ID del Integrante: ");
                int idEliminar = int.Parse(Console.ReadLine());
                wService.BajaIntegrante(idEliminar);
                Console.WriteLine("Borrado exitoso");
                Console.ReadLine();

            }
            catch (Exception e)
            {
                throw new ApplicationException("El dato ingresado no es correcto");
            }
        }
        public void ListarIntegrante()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Nombre\t Apellido\t Fecha Nacimiento\t ");
                var listvoi = wService.ListarIntegrante();
                foreach (var vo in listvoi)
                {
                    Console.WriteLine(vo.Nombre + "\t " + vo.Apellido + "\t " + vo.FechaNacimiento);
                }
                Console.ReadLine();

            }
            catch (Exception e)
            {
                throw new ApplicationException("El dato ingresado no es correcto");
            }
        }

        public void InsertarAlbum()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese Nombre: ");
                String nombre = Console.ReadLine();
                Console.WriteLine("Ingrese Genero Musical: ");
                String genero = Console.ReadLine();
                Console.WriteLine("Ingrese ID Banda: ");
                int idBanda = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese Año Creacion: ");
                int anioC = int.Parse(Console.ReadLine());
                wService.AltaAlbum(nombre, anioC, genero, idBanda);
                Console.WriteLine("Ingreso exitoso");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                throw new ApplicationException("El dato ingresado no es correcto");
            }
        }
        public void BorrarAlbum()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese ID del Integrante: ");
                int idEliminar = int.Parse(Console.ReadLine());
                wService.BajaAlbum(idEliminar);
                Console.WriteLine("Borrado exitoso");
                Console.ReadLine();

            }
            catch (Exception e)
            {
                throw new ApplicationException("El dato ingresado no es correcto");
            }
        }
        public void ListarAlbum()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Nombre\t Apellido\t Banda(ID)\t Año Creacion(ID)\t");
                var listvoa = wService.ListadoAlbum();
                foreach (var vo in listvoa)
                {
                    Console.WriteLine(vo.Nombre + "\t " + vo.GeneroMusical + "\t " + vo.IdBanda + "\t " + vo.AnioCreacion);
                }
                Console.ReadLine();

            }
            catch (Exception e)
            {
                throw new ApplicationException("El dato ingresado no es correcto");
            }
        }

        /*    ///  NO HAY METODOS DE USUARIO ///
         *      
                public void InsertarUsuario()
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese Nombre: ");
                        String nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese Apellido: ");
                        String apellido = Console.ReadLine();
                        Console.WriteLine("Ingrese Email: ");
                        int email = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese Contraseña: ");
                        int pass = int.Parse(Console.ReadLine());
                        wService.Alta(nombre, anioC, genero, idBanda);
                        Console.WriteLine("Ingreso exitoso");
                        Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        throw new ApplicationException("El dato ingresado no es correcto");
                    }
                }
                public void BorrarUsuario()
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese ID del Integrante: ");
                        int idEliminar = int.Parse(Console.ReadLine());
                        wService.BajaAlbum(idEliminar);
                        Console.WriteLine("Borrado exitoso");
                        Console.ReadLine();

                    }
                    catch (Exception e)
                    {
                        throw new ApplicationException("El dato ingresado no es correcto");
                    }
                }
                public void ListarUsuario()
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Nombre\t Apellido\t Banda(ID)\t Año Creacion(ID)\t");
                        var listvoa = wService.ListadoAlbum();
                        foreach (var vo in listvoa)
                        {
                            Console.WriteLine(vo.Nombre + "\t " + vo.GeneroMusical + "\t " + vo.IdBanda + "\t " + vo.AnioCreacion);
                        }
                        Console.ReadLine();

                    }
                    catch (Exception e)
                    {
                        throw new ApplicationException("El dato ingresado no es correcto");
                    }
                }
        */
        public void ActionCancion(int? action)
        {
            switch (action)
            {
                case 1:
                    InsertarCancion();
                    break;

                case 2:
                    BorrarCancion();
                    break;

                case 3:
                    ListarCancion();
                    break;
            }
        }

        public void ActionBanda(int? action)
        {
            switch (action)
            {
                case 1:
                    InsertarBanda();
                    break;

                case 2:
                    BorrarBanda();
                    break;

                case 3:
                    ListarBanda();
                    break;
                    //case 4:
                    //    AgregarIntegrante();
                    //    break;
                    //case 5:
                    //    QuitarIntegrante();
                    //    break;
            }

        }

        public void ActionIntegrante(int? action)
        {
            switch (action)
            {
                case 1:
                    InsertarIntegrante();
                    break;

                case 2:
                    BorrarIntegrante();
                    break;

                case 3:
                    ListarIntegrante();
                    break;
            }
        }

        public void ActionAlbum(int? action)
        {
            switch (action)
            {
                case 1:
                    InsertarAlbum();
                    break;

                case 2:
                    BorrarAlbum();
                    break;

                case 3:
                    ListarAlbum();
                    break;
                    //case 4:
                    //    AgregarCancionAlbum();
                    //    break;
                    //case 5:
                    //    QuitarCancionAlbum();
                    //    break;
            }
        }

        public void ActionUsuario(int? action)
        {
            switch (action)
            {
                case 1:
                    //    InsertarUsuario();
                    break;

                case 2:
                    //    BorrarUsuario();
                    break;

                case 3:
                    //   ListarUsuario();
                    break;
            }
        }
        #endregion

        internal void ExecuteOption(int optionSelected)
        {
            switch (optionSelected)
            {
                case 1:
                    ShowMenu(MenuCancion());
                    ActionCancion(OptionSelected());
                    break;

                case 2:
                    ShowMenu(MenuBanda());
                    ActionBanda(OptionSelected());
                    break;

                case 3:
                    ShowMenu(MenuIntegrante());
                    ActionIntegrante(OptionSelected());
                    break;
                case 4:
                    ShowMenu(MenuAlbum());
                    ActionAlbum(OptionSelected());
                    break;
                case 5:
                    ShowMenu(MenuUsuario());
                    ActionUsuario(OptionSelected());
                    break;
            }

        }
    }
}