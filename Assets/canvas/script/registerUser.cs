﻿using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class registerUser : MonoBehaviour{
    public object result;
    
    public void Start(string name,string mail,string password, Action<bool> result) {
        StartCoroutine(CreateUser( name, mail, password, (onSuccess) => {
            //Debug.Log(onSuccess); 
            result(onSuccess);
        }));
    }

    IEnumerator CreateUser(string name,string mail,string password, Action<bool> onSuccess) {

        WWWForm form = new WWWForm();
        form.AddField("name",name);
        form.AddField("email",mail);
        form.AddField("password",password);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost:4000/api/SaveUsers", form);
        yield return www.SendWebRequest();
        
        onSuccess(!(www.isNetworkError || www.isHttpError));
    }
}