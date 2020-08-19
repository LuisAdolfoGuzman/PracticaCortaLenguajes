using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnalizadorLexico
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String cadena;
            cadena = Cadena.Text;
            String caracter = "";
            int largo = cadena.Length;
            String nuevaCadena = "";
            String cadenaEntero = "";
            String cadenaDecimal = "";
            String PosiblePunto = "";
            
            for (int x = 0; x < largo; x++)
            {
                caracter = cadena.Substring(x, 1);
                //EXTRAE UN CARACTER SEGUIDO DEL QUE ESTAMOS EVALUANDO EL CUAL SERVIRA PARA VERIFICAR SI HAY UN PUNTO ANTES DEL FINAL DE LA CADENA
                if (x != largo -1)
                {
                    PosiblePunto = cadena.Substring(x + 1, 1);
                }
                else
                {
                    PosiblePunto = "";
                }

                //VERIFICA SI TENEMOS UN NUMERO MANEJANDOSE DE TIPO TEXTO
                if (caracter == "1" || caracter == "2" || caracter == "3" || caracter == "4" || caracter == "5" || caracter == "6" || caracter == "7" || caracter == "8" || caracter == "9" || caracter == "0" || caracter == "." )
                {
                    cadenaEntero = cadenaEntero+ caracter;
                }
                else
                {
                    //AL NO CUMPLIRSE BUSCA ALGUN TIPO DE CARACTER DEFINIDO Y DE LOS MMAS COMUNES 
                    if (caracter == "!" || caracter == "¡" || caracter == "?" || caracter == "¿" || caracter == "+" || caracter == "-" || caracter == "/" || caracter == "*" || caracter == "*" || caracter == "=")
                    {
                        Listado.Items.Add("Signo: " + caracter);
                    }
                    else
                    {

                        //SI NO ENCUENTRA NUMERO NI CARACTER VERIFICA SI EXISTE UN ESPACIO VACIO LO QUE INIDICA CUALQUIER OTRO CARACTER DIFERENTE DEL ESPACIO
                        if (caracter != " ")
                        {
                            //EVALUA SI NUESTRO CARACTER EVALUADO Y EL QUE SIGUE FORMAN "Q." PARA HACER EL TIPO MONEDA Y SEPARARLO DE NUESTRA CADENA
                            //SALTANDOSE UNO ESPACIO EN X PARA EVITAR ERRORES CON LOS NUMEROS DECIMALES
                            if (caracter == "Q" & PosiblePunto == ".")
                            {
                                Listado.Items.Add("Moneda: " + caracter+PosiblePunto);
                                x = x + 1;
                            }
                            else
                            {
                                nuevaCadena = nuevaCadena + caracter;
                            }
                            //EN ESTE PUNTO QUIERE DECIR QUE LLEGAMOS AL FINAL DE NUESTRA CADENA POR LO QUE TAMBIEN AL FINAL DE NUESTRA SUB CADENA, ENTONCES LA AGREGA AL LISTADO
                            if (x == largo - 1)
                            {
                                
                                if (nuevaCadena != "")
                                {
                                    mostrarResultados(nuevaCadena, cadenaDecimal, cadenaEntero);
                                    nuevaCadena = "";
                                    cadenaDecimal = "";
                                    cadenaEntero = "";
                                }
                            }


                        }
                        else
                        {
                            //INIDICA QUE ENCONTRO UN ESPACIO POR LO QUE NUESTRA SUB CADENA HA TERMINADO Y PROCEDEMOS A MOSTRAR SI EXISTE ALGO EN SU INTERIOR
                            if (nuevaCadena != "")
                            {
                                mostrarResultados(nuevaCadena, cadenaDecimal, cadenaEntero);
                                nuevaCadena = "";
                                cadenaDecimal = "";
                                cadenaEntero = "";
                            }
                            

                        }


                    }


                }

                

          
                


                

                
            }
        }
        public void mostrarResultados(String cadenaTexto, String cadenaDecimal, String cadenaEntero)
        {
            if (cadenaTexto != "")
            {
                Listado.Items.Add("Palabra: "+cadenaTexto);
            }
            if (cadenaEntero != "")
            {
                for (int x = 0; x < cadenaEntero.Length; x++)
                {
                    if (cadenaEntero.Substring(x,1) == ".")
                    {
                        cadenaDecimal = cadenaEntero;
                        cadenaEntero = "";
                        Listado.Items.Add("Decimal: " + cadenaDecimal);
                        x = cadenaEntero.Length - 1;
                    }
                    else
                    {
                        if (x == cadenaEntero.Length - 1)
                        {
                            Listado.Items.Add("Entero: "+cadenaEntero);
                        }
                    }
                }
                
            }
            
        }
    }
}
