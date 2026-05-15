using System.Collections.ObjectModel;

namespace FlotaMariaPerezGoti;

public class LogicaNegocio
{
    // Lista de jugadas (la tabla la lee de aqui automaticamente)
    public ObservableCollection<Jugada> Jugadas { get; set; }

    // Donde estan los barcos: 1 = barco, 0 = agua
    public int[,] MatrizBarcos { get; set; }

    // Cuantos barcos hemos hundido ya
    public int BarcosHundidos { get; set; }

    // Cuantos barcos hay en total
    public int TotalBarcos { get; set; }

    // Para numerar las jugadas
    private int contadorJugadas;

    public LogicaNegocio()
    {
        Jugadas = new ObservableCollection<Jugada>();
        BarcosHundidos = 0;
        TotalBarcos = 4;
        contadorJugadas = 0;

        // Los 4 barcos estan en estas posiciones (fijos)
        MatrizBarcos = new int[4, 4]
        {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
        };
    }

    // Recibe donde disparo el jugador y devuelve lo que paso
    public string RegistrarDisparo(int fila, int col)
    {
        string resultado;

        if (MatrizBarcos[fila, col] == 1)
        {
            BarcosHundidos++;
            resultado = "Barco hundido";
        }
        else
        {
            resultado = "Agua";
        }

        // Guardamos la jugada en la lista
        contadorJugadas++;
        Jugadas.Add(new Jugada(contadorJugadas, fila, col, resultado));

        return resultado;
    }

    // Devuelve true si ya hundimos todos los barcos
    public bool JuegoTerminado()
    {
        return BarcosHundidos == TotalBarcos;
    }

    // Reinicia todo para jugar de nuevo
    public void Reiniciar()
    {
        Jugadas.Clear();
        BarcosHundidos = 0;
        contadorJugadas = 0;
    }
}
