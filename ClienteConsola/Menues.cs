using Logica.Negocio;
using Logica.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClienteConsola
{
    public class Menues
    {

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
                VOCancion voc = new VOCancion();
                Console.WriteLine("Ingrese Nombre: ");
                voc.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese Duracion: ");
                voc.Duracion = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese Año: ");
                voc.Anio = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese Genero: ");
                voc.GeneroMusical = Console.ReadLine();
               Console.WriteLine("Ingrese ID Cantante: ");
               voc.IdCantante = int.Parse(Console.ReadLine());
                Fachada.Instancia.AltaCancion(voc);
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
                Fachada.Instancia.BajaCancion(idEliminar);
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
                List<VOCancion> listvoc = Fachada.Instancia.ListarCanciones();
                foreach (var vo in listvoc)
                {
                    Console.WriteLine(vo.Nombre+ "\t " + vo.Duracion+ "\t\t " + vo.Anio+ "\t " + vo.GeneroMusical+ "\t " + vo.IdCantante);
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
                VOBanda vob = new VOBanda();
                Console.WriteLine("Ingrese Nombre: ");
                vob.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese Genero: ");
                vob.GeneroMusical = Console.ReadLine();
                Console.WriteLine("Ingrese Año Creacion: ");
                vob.AnioCreacion = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese Año Separacion: ");
                vob.AnioSeparacion = int.Parse(Console.ReadLine());   
                Fachada.Instancia.AltaBanda(vob);
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
                Fachada.Instancia.BajaBanda(idEliminar);
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
                List<VOBanda> listvob = Fachada.Instancia.ListarBandas();
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














                //private static void ShowError(TipoError error)
                //{
                //    Console.WriteLine();
                //    Console.WriteLine("Ha ocurrido el siguiente error al procesar el requerimiento : {0}", error.ToString());
                //}
                #endregion
            }

        internal void ExecuteOption(int optionSelected)
        {
            //String actionText;
            //int action;
            switch (optionSelected)
            {
                case 1:
                    ShowMenu(MenuCancion());
                    ActionCancion(OptionSelected());
                    break;

                case 2:
                    ShowMenu(MenuBanda());
                    break;

                case 3:
                    ShowMenu(MenuIntegrante());
                    break;
                case 4:
                    ShowMenu(MenuAlbum());
                    break;
                case 5:
                    ShowMenu(MenuUsuario());
                    break;
            }

        }
    }
}
