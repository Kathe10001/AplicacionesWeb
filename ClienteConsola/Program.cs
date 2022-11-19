using Logica.Negocio;
using Logica.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteConsola
{
    class Program
    {
        
            #region Main Method

            static void Main(string[] args)
            {
            //Fachada f = new Fachada();
                Menues m = new Menues();
                bool mustExit = false;
                int exitOption = 6;
                do
                {
                    m.ShowMenu(m.Menu());
                    int? optionSelected = m.OptionSelected();

                    Console.Clear();

                    if (!optionSelected.HasValue)
                        Console.WriteLine("Ha seleccionado una opción incorrecta");
                    else
                    {
                        if (optionSelected.Value != exitOption)
                            // ExecuteOption(f, optionSelected.Value);
                            m.ExecuteOption(optionSelected.Value);
                        else
                            mustExit = true;
                    }

                } while (!mustExit);
            }


            #endregion
        }
}

