using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource: MonoBehaviour
{
    protected int resValue;
    public string nameValue;
    public int maxValue = 5;
    public int minValue = 0;
    public int defValue;

    public void ShowValue(Text text){
        text.text = resValue.ToString();
    }

    public void PlusValue(int plus){
        if(resValue < maxValue){
            resValue += plus;
        }
    }

    public void MinusValue(int minus){
        if(resValue > minValue){
            resValue -= minus;
        }
    }

    protected void SaveValue(){
        PlayerPrefs.SetInt(this.nameValue,this.resValue);
    }

    protected void TakeValue(){
        if(PlayerPrefs.HasKey(this.nameValue)){
            this.resValue = PlayerPrefs.GetInt(this.nameValue);
        } else {
            this.resValue = PlayerPrefs.GetInt(this.nameValue,this.defValue);
        }
    }
}
