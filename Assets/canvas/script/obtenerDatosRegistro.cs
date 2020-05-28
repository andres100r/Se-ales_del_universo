using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class obtenerDatosRegistro : MonoBehaviour {
    public Text name;
    public Text mail;
    public Text password;
    public Text repitPassword;
    public Text message;
    public Text successmessage;

    private registerUser api = null;
    private validarEmail validarEmail = null;

    private void Awake () {
        api = GameObject.FindObjectOfType<registerUser> ();
        validarEmail = GameObject.FindObjectOfType<validarEmail> ();
    }

    public void resgistrarUsuario () {

        if (name.text == "" || mail.text == "" || password.text == "" || repitPassword.text == "") {
            message.text = "Todos los campos son obligtorios";
        } else if (password.text != repitPassword.text) {
            message.text = "Las contraseñas no coinciden ";
        } else {
            validarEmail.Start (mail.text, (onSuccess) => {
                if (onSuccess) {
                    api.Start (name.text, mail.text, password.text, (result) => {
                        if (result) {
                            message.text = "";
                            successmessage.text = "Usuario Creado Correctamente";
                            StartCoroutine (deleteMensage ());
                        } else {
                            message.text = "Hubo un error intentando registrar el usuario";
                        }
                    });
                } else {
                    message.text = "Ya existe un usuario con el mismo correo";
                }
            });

        }
    }

    IEnumerator deleteMensage () {
        yield return new WaitForSeconds (2);
        successmessage.text = "";
    }
}