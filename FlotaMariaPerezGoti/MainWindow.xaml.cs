using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FlotaMariaPerezGoti
{
    public partial class MainWindow : Window
    {
        private LogicaNegocio logica;

        public MainWindow()
        {
            InitializeComponent();

            // Creamos la logica de negocio
            logica = new LogicaNegocio();

            // Le decimos a la tabla que use la lista de jugadas
            tablaJugadas.ItemsSource = logica.Jugadas;
        }

        // Se ejecuta cuando se pulsa cualquier boton del tablero
        private void Boton_Click(object sender, RoutedEventArgs e)
        {
            // Cogemos el boton que se pulso
            Button boton = (Button)sender;

            // Leemos las coordenadas del Tag ("0,1" -> fila=0, col=1)
            string[] coords = boton.Tag.ToString().Split(',');
            int fila = int.Parse(coords[0]);
            int col = int.Parse(coords[1]);

            // Le decimos a la logica que procese el disparo
            string resultado = logica.RegistrarDisparo(fila, col);

            // Cambiamos la imagen segun el resultado
            Image img = (Image)boton.Content;

            if (resultado == "Barco hundido")
            {
                img.Source = new BitmapImage(new Uri("Imagenes/barco.png", UriKind.Relative));
            }
            else
            {
                img.Source = new BitmapImage(new Uri("Imagenes/agua_vacio.png", UriKind.Relative));
            }

            // Deshabilitamos el boton para no poder volver a pulsar
            boton.IsEnabled = false;

            // Comprobamos si hemos ganado
            if (logica.JuegoTerminado())
            {
                foreach (UIElement elemento in gridTablero.Children)
                {
                    if (elemento is Button b)
                    {
                        b.IsEnabled = false;
                    }
                }

                MessageBox.Show("Has hundido todos los barcos. Has ganado!");
            }
        }

        // Se ejecuta cuando se pulsa Reiniciar
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            // Reiniciamos la logica
            logica.Reiniciar();

            // Restauramos todos los botones del tablero
            foreach (UIElement elemento in gridTablero.Children)
            {
                if (elemento is Button boton)
                {
                    Image img = (Image)boton.Content;
                    img.Source = new BitmapImage(new Uri("Imagenes/agua.png", UriKind.Relative));
                    boton.IsEnabled = true;
                }
            }
        }
    }
}