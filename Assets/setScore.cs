using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class setScore: MonoBehaviour
{
    public GameObject Nombre;
    public GameObject Puntuacion;
    

    public void SetScore (string nombrejugador,string puntuacionjugador)
    {
        Nombre.GetComponent<Text>().text = nombrejugador;
        Puntuacion.GetComponent<Text>().text = puntuacionjugador;


    }
}
