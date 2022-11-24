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
        int tableWidth = 73;
        public void ImprimeLinea()
        {
            Console.WriteLine(new string('-', tableWidth));
        }
        public void ImprimeFila(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = " ";
            foreach (string column in columns)
            {
                row += Centro(column, width) + " ";

            }
            Console.WriteLine(row);
        }


        public string Centro(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }

        }




        public String[] Menu()
        {
            String[] menu = { "                  Menu de Opciones: ",
                               "----------------------------------------------------------------------",
                               "",
                               "1 - Menú Cancion",
                               "2 - Menú Banda",
                               "3 - Menú Integrantes",
                               "4 - Menú Album",

                               "5 - Salir" };
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

                String nombre;
                do
                {
                    Console.WriteLine("Ingrese Nombre: ");
                    nombre = Console.ReadLine();


                } while (String.IsNullOrEmpty(nombre.Trim()));

                String duracionC;
                do
                {
                    Console.WriteLine("Ingrese Duracion: ");
                    duracionC = Console.ReadLine();

                } while (String.IsNullOrEmpty(duracionC.Trim()));
                int duracion = int.Parse(duracionC);

                String anioC;
                do 
                { 
                    Console.WriteLine("Ingrese Año: ");
                    anioC = Console.ReadLine();

                } while (String.IsNullOrEmpty(anioC.Trim()));
                int anio = int.Parse(anioC);

                String genero;
                do 
                {
                    Console.WriteLine("Ingrese Genero: ");
                   genero = Console.ReadLine();
                } while (String.IsNullOrEmpty(genero.Trim()));

                String id;
                do
                { 
                    Console.WriteLine("Ingrese ID Cantante: ");
                    id = Console.ReadLine();
                } while (String.IsNullOrEmpty(id.Trim()));
                int idCantante = int.Parse(id);

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

                String id;
                do
                { 
                    Console.WriteLine("Ingrese ID de la cancion: ");
                    id = Console.ReadLine();
                    if (String.IsNullOrEmpty(id.Trim()))
                    {
                        Console.WriteLine("desea salir? (y/n)");
                        if (Console.ReadLine() == "y")
                        {
                            id = "out";
                        }
                    }
                } while (String.IsNullOrEmpty(id.Trim()));

                //while (String.IsNullOrEmpty(id.Trim()));
                if (!(id == "out"))
                {
                    int idEliminar = int.Parse(id);
                    wService.BajaCancion(idEliminar);
                    Console.WriteLine("Borrado exitoso");
                    Console.ReadLine();
                }
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
                ImprimeLinea();
                ImprimeFila("ID-Cancion","Nombre","Duracion","Año","Genero","Cantante(ID)");
                Console.WriteLine(" ");
                VOCancion[] listVoc = wService.ListarCanciones(); 
                foreach (VOCancion vo in listVoc)
                {
                    String id = vo.Id.ToString();
                    String duracion = vo.Duracion.ToString();
                    String anio = vo.Anio.ToString();
                    String idc = vo.IdCantante.ToString();
                    ImprimeFila(id,vo.Nombre,duracion,anio,vo.GeneroMusical,idc);

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
                String nombre;
                do
                {
                    Console.WriteLine("Ingrese Nombre: ");
                    nombre = Console.ReadLine();
                }
                while (String.IsNullOrEmpty(nombre.Trim()));
                String genero;
                do
                {
                    Console.WriteLine("Ingrese Genero: ");
                    genero = Console.ReadLine();
                }while (String.IsNullOrEmpty(genero.Trim()));

                String anioCreacion;
                do
                {
                    Console.WriteLine("Ingrese Año Creacion: ");
                    anioCreacion = Console.ReadLine();
                } while (String.IsNullOrEmpty(anioCreacion.Trim()));
                int anioC = int.Parse(anioCreacion);

                Console.WriteLine("Ingrese Año Separacion: ");
                int anioS;
                String anioSeparacion = Console.ReadLine();
                if (String.IsNullOrEmpty(anioSeparacion))
                {
                    anioS = 0;
                }
                else
                anioS  = int.Parse(anioSeparacion);
                
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
                String eliminar;
                do
                {
                    Console.WriteLine("Ingrese ID de la banda: ");
                    eliminar = Console.ReadLine();
                } while (String.IsNullOrEmpty(eliminar.Trim()));
                int idEliminar = int.Parse(eliminar);

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
                ImprimeLinea();
                ImprimeFila("Nombre","Genero","Año-Creacion","Año-Separacion");
                Console.WriteLine(" ");
                VOBanda[] listvob = wService.ListarBandas();
                foreach (var vo in listvob)
                {
                    String anioC = vo.AnioCreacion.ToString();
                    String anioS = vo.AnioSeparacion.ToString();
                    ImprimeFila(vo.Nombre, vo.GeneroMusical,anioC,anioS);
                }
                Console.ReadLine();

            }
            catch (Exception e)
            {
                throw new ApplicationException("El dato ingresado no es correcto");
            }
        }

        public void AgregarIntegranteBanda()
        {
            Console.Clear();
            String integrante;
            do
            { 
                Console.WriteLine("Ingrese un ID de Integrante: ");
                integrante = Console.ReadLine();
            } while (String.IsNullOrEmpty(integrante.Trim()));
            int idIntegrante = int.Parse(integrante);

            String banda;
            do
            {
                Console.WriteLine("Ingrese un ID de Banda: ");
                banda = Console.ReadLine();
            } while (String.IsNullOrEmpty(banda.Trim()));
            int idBanda = int.Parse(banda);

            wService.AgregarIntegranteBanda(idIntegrante, idBanda);
            Console.WriteLine("Ingreso exitoso");
            Console.ReadLine();
        }


        public void QuitarIntegranteBanda()
        {
            Console.Clear();

            String integrante;
            do
            { 
                Console.WriteLine("Ingrese un ID de Integrante: ");
                integrante = Console.ReadLine();
            } while (String.IsNullOrEmpty(integrante.Trim()));
            int idIntegrante = int.Parse(integrante);

            String banda;
            do
            { 
                Console.WriteLine("Ingrese un ID de Banda: ");
                banda = Console.ReadLine();
            } while (String.IsNullOrEmpty(banda.Trim()));
            int idBanda = int.Parse(banda);

            wService.QuitarIntegranteBanda(idIntegrante, idBanda);
            Console.WriteLine("Borrado exitoso");
            Console.ReadLine();
        }

        public void InsertarIntegrante()
        {
            try
            {
                Console.Clear();

                String nombre;
                do
                {
                     Console.WriteLine("Ingrese Nombre: ");
                     nombre = Console.ReadLine();

                } while (String.IsNullOrEmpty(nombre.Trim()));

                String apellido;
                do
                {
                    Console.WriteLine("Ingrese Apellido: ");
                    apellido = Console.ReadLine();
                } while (String.IsNullOrEmpty(apellido.Trim()));

                String date;
                do 
                { 
                     Console.WriteLine("Ingrese Fecha Nacimiento: ");
                    date = Console.ReadLine();
                } while (String.IsNullOrEmpty(date.Trim()));
                DateTime fechaN = DateTime.Parse(date);

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

                String id;
                do
                { 
                    Console.WriteLine("Ingrese ID del Integrante: ");
                    id = Console.ReadLine();
                } while (String.IsNullOrEmpty(id.Trim()));
                int idEliminar = int.Parse(id);

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
                ImprimeLinea();
                ImprimeFila("Nombre","Apellido","Fecha Nacimiento");
                Console.WriteLine(" ");
                var listvoi = wService.ListarIntegrante();
                foreach (var vo in listvoi)
                {
                    String fecha = vo.FechaNacimiento.ToString();
                    ImprimeFila(vo.Nombre,vo.Apellido,fecha);

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
                String nombre;
                do 
                { 
                    Console.WriteLine("Ingrese Nombre: ");
                    nombre = Console.ReadLine();
                } while (String.IsNullOrEmpty(nombre.Trim()));


                String genero;
                do
                { 
                    Console.WriteLine("Ingrese Genero Musical: ");
                    genero = Console.ReadLine();
                } while (String.IsNullOrEmpty(genero.Trim()));

                String idb;
                do 
                { 
                    Console.WriteLine("Ingrese ID Banda: ");
                    idb = Console.ReadLine();
                } while (String.IsNullOrEmpty(idb.Trim()));
                int idBanda = int.Parse(idb);

                String anio;
                do
                {
                    Console.WriteLine("Ingrese Año Creacion: ");
                    anio = Console.ReadLine();
                } while (String.IsNullOrEmpty(anio.Trim()));
                int anioC = int.Parse(anio);
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
                String eliminar;
                do 
                { 
                    Console.WriteLine("Ingrese ID del Integrante: ");
                    eliminar = Console.ReadLine();
                } while (String.IsNullOrEmpty(eliminar.Trim()));
                int idEliminar = int.Parse(eliminar);
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
                ImprimeLinea();
                ImprimeFila("Nombre","Apellido","Banda(ID)","Año Creacion(ID)");
                Console.WriteLine(" ");
                var listvoa = wService.ListadoAlbum();
                foreach (var vo in listvoa)
                {
                    String idb = vo.IdBanda.ToString();
                    String anio = vo.AnioCreacion.ToString();
                    ImprimeFila(vo.Nombre,vo.GeneroMusical,idb,anio);
                }
                Console.ReadLine();

            }
            catch (Exception e)
            {
                throw new ApplicationException("El dato ingresado no es correcto");
            }
        }


        public void AgregarCancionAlbum()
        {
            Console.Clear();
            String idc;
            do
            { 
                Console.WriteLine("Ingrese un ID de Cancion: ");
                idc = Console.ReadLine();
            } while (String.IsNullOrEmpty(idc.Trim()));
            int idCancion = int.Parse(idc);

            String ida;
            do
            { 
                Console.WriteLine("Ingrese un ID de Album: ");
                ida = Console.ReadLine();
            } while (String.IsNullOrEmpty(ida.Trim()));
            int idAlbum = int.Parse(ida);
            wService.AgregarCancionAlbum(idCancion, idAlbum);
            Console.WriteLine("Ingreso exitoso");
            Console.ReadLine();
        }

        public void QuitarCancionAlbum()
        {
            Console.Clear();

            String idc;
            do
            { 
                Console.WriteLine("Ingrese un ID de Cancion: ");
                idc = Console.ReadLine();
            } while (String.IsNullOrEmpty(idc.Trim()));
            int idCancion = int.Parse(idc);

            String ida;
            do 
            { 
                Console.WriteLine("Ingrese un ID de Album: ");
                ida = Console.ReadLine();
            } while (String.IsNullOrEmpty(ida.Trim()));
            int idAlbum = int.Parse(ida);
            wService.QuitarCancionAlbum(idCancion, idAlbum);
            Console.WriteLine("Borrado exitoso");
            Console.ReadLine();
        }



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
                case 4:
                    AgregarIntegranteBanda();
                    break;
                case 5:
                    QuitarIntegranteBanda();
                    break;
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
                case 4:
                    AgregarCancionAlbum();
                    break;
                case 5:
                    QuitarCancionAlbum();
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
            }

        }
    }
}