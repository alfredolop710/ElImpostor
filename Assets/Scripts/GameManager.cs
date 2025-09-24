using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalJugadores = 3;
    public int totalImpostores = 1;
    public string tema = "";
    public string palabra = "";

    public List<string> nombres = new List<string>();
    public List<Jugador> jugadores = new List<Jugador>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GenerarJugadores()
    {
        jugadores.Clear();

        foreach (var nombre in nombres)
        {
            jugadores.Add(new Jugador { nombre = nombre, esImpostor = false });
        }

        List<int> indices = new List<int>();
        for (int i = 0; i < jugadores.Count; i++) indices.Add(i);
        indices.Shuffle();

        for (int i = 0; i < totalImpostores; i++)
        {
            jugadores[indices[i]].esImpostor = true;
        }
        jugadores.Shuffle();
    }
}
