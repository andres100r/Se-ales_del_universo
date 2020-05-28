using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

public class apiLogin : MonoBehaviour {
    public object result;

    public void Start (string user, string password, Action<bool> result) {
        StartCoroutine (validarLogin (user, password, (onSuccess) => {
            result (onSuccess);
        }));
    }

    IEnumerator validarLogin (string user, string password, Action<bool> onSuccess) {

        WWWForm form = new WWWForm ();
        form.AddField ("user", user);
        form.AddField ("password", password);

        UnityWebRequest www = UnityWebRequest.Post ("http://localhost:4000/api/login", form);
        yield return www.SendWebRequest ();

        JSONNode jsonData = JSON.Parse (System.Text.Encoding.UTF8.GetString (www.downloadHandler.data));

        if (!(www.isNetworkError || www.isHttpError)) {
            onSuccess (true);
        }else {
            onSuccess (false);
        }
    }
}