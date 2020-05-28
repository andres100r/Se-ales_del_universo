using System;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;


public class validarEmail : MonoBehaviour{
    public object result;

    public void Start(string email , Action<bool> result){
        
         StartCoroutine(validarEmailUser(email, (onSuccess) => {
            result(onSuccess);
        }));
    }

    IEnumerator validarEmailUser(string email , Action<bool> onSuccess){
        
        UnityWebRequest www = UnityWebRequest.Get("http://localhost:4000/api/validateEmail/"+email);
        yield return www.SendWebRequest();

       //parse json 
       JSONNode jsonData = JSON.Parse(System.Text.Encoding.UTF8.GetString(www.downloadHandler.data));
       //print(jsonData.Count);

        if(!(www.isNetworkError || www.isHttpError)){

            if (jsonData["data"][0]["idUsers"] == null){
              onSuccess(true); 
            }else{
            onSuccess(false);
            }
        }
        
    }
}
