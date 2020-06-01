using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        
    }
    public void SampleScene(){
        SceneManager.LoadScene("SampleScene");
        
    } public void VamosaLeer(){
        SceneManager.LoadScene("Vamos a leer");

    } public void PongamosAtencion(){

        SceneManager.LoadScene("Pongamos atencion");

    } public void Ranking(){

        SceneManager.LoadScene("Ranking");
    }
}
