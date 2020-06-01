using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class VerJugadores : MonoBehaviour
{
    private string URLVerPuntuacion = "david19_prueba//Ranking//Verpuntuacion.php";
    private List<Jugador> rankingJugadores = new List<Jugador>();
    private string[] CurrentArray = null;
    public Transform tfPanelCargarDatos;
    public Text txtCargando;
    public GameObject Panelpre;

    void Start()
    {
        StartCoroutine(ObtenerJugadores());
    }

    IEnumerator ObtenerJugadores()
    {
        txtCargando.text = "Cargando...";
        WWW Dataserver = new WWW ("http://" + URLVerPuntuacion);
        yield return Dataserver;

        if(Dataserver.error !=null)
        {
            Debug.Log("Problema al intentar obtener los jugadores de la base de datos: " + Dataserver.error);
            txtCargando.text = Dataserver.error;
        }
        else
        {
            txtCargando.text = "";
            ObtenerRegistros(Dataserver);
            VerRegistros();
        }
    }

    void ObtenerRegistros(WWW Dataserver)
    {
        CurrentArray = System.Text.Encoding.UTF8.GetString(Dataserver.bytes).Split(";"[0]);

        for(int i=0; i<= CurrentArray.Length -3; i=i+2)
        {
            rankingJugadores.Add(new Jugador(CurrentArray[i], CurrentArray[i + 1]));
        }
    }

    void VerRegistros()
    {
        for (int i = 0; i < rankingJugadores.Count; i++)
        {
            GameObject obj = Instantiate(Panelpre);
            Jugador jg = rankingJugadores[i];
            obj.GetComponent<setScore>().SetScore(jg.nombre, jg.puntuacion);
            obj.transform.SetParent(tfPanelCargarDatos);
            obj.GetComponent<RectTransform>().localScale = new UnityEngine.Vector3(1, 1, 1);
        }
    }
}

public class Jugador
{
    public string puntuacion;
    public string nombre;

    public Jugador(string nombreJugador, string puntuacionJugador)
    {
        puntuacion = puntuacionJugador;
        nombre = nombreJugador;
    }
}
