using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coat : Resource
{
    public static Coat instance = null;
    private Text resText;

    private void Awake() {
        resText = GetComponent<Text>();
        if(instance == null){
            instance = this;
        } else if(instance == this){
            Destroy(gameObject);
        }
        TakeValue();
    }

    private void Update() {
        ShowValue(resText);
    }

    private void OnApplicationQuit() {
        Debug.Log("Save " + this.nameValue + " value = " + this.resValue);
        SaveValue();
    }
}
