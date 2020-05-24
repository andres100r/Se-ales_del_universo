using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class login : MonoBehaviour {
    [SerializeField] private GameObject m_menuUI = null;
    [SerializeField] private GameObject m_loginUI = null;

    public Text user;
    public Text password;
    public Text message;

    private apiLogin apiLogin = null;

    private void Awake () {
        apiLogin = GameObject.FindObjectOfType<apiLogin> ();
    }

    public void userLogin () {

        if (user.text == "" || password.text == "") {
            message.text = "Todos los campos son obligatorios";
        } else {
            apiLogin.Start (user.text, password.text, (result) => {
                if (result == false) {
                    message.text = "Usuario o Contraseña incorrectos";
                    StartCoroutine (deleteMensage ());
                } else {
                    m_loginUI.SetActive (false);
                    m_menuUI.SetActive (true);
                }
            });
        }
    }

    IEnumerator deleteMensage () {
        yield return new WaitForSeconds (2);
        message.text = "";
    }
    
}