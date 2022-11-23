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

                // String.IsNullOrEmpty(anioCreacion.Trim())
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
                } while (String.IsNullOrEmpty(id.Trim()));
                int idEliminar = int.Parse(id);
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