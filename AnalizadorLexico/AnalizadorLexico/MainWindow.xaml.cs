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
            Boolean prueba = true;
            for(int x = 0; x < largo; x++)
            {

            }
            while(prueba != false)
            {

            }
            if(prueba = true)
            {

            }
            else
            {

            }

            //caracter = cadena.Substring(2, 1);
            Listado.Items.Add(caracter);
            //FUNCION SUBSTRING EXTRAE CARACTER POR CARACTER DE UNA CADENA INDICANDO LA POSICION Y LA CANTIDAD DE LETRAS QUE EXTRAERÁ
            
            
            
        }
    }
}
