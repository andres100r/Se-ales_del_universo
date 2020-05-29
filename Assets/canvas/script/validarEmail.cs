using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

public class validarEmail : MonoBehaviour {
    public object result;

    public void Start (string email, Action<bool> result) {

        StartCoroutine (validarEmailUser (email, (onSuccess) => {
            result (onSuccess);
        }));
    }

    IEnumerator validarEmailUser (string email, Action<bool> onSuccess) {

        UnityWebRequest www = UnityWebRequest.Get ("https://senales-universo-bakend.herokuapp.com/api/validateEmail/" + email);
        yield return www.SendWebRequest ();

        //parse json 
        JSONNode jsonData = JSON.Parse (System.Text.Encoding.UTF8.GetString (www.downloadHandler.data));
        //print(jsonData);

        if (!(www.isNetworkError || www.isHttpError)) {

            if (jsonData["data"][0]["idUsers"] == null) {
                onSuccess (true);
            } else {
                onSuccess (false);
            }
        }

    }
}