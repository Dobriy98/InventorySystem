using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public delegate void OnItemChanged();
    public static Inventory instance;

    private void Awake() {
        if(instance != null){
            Debug.LogWarning("More than one instance of Inventory!");
            return;
        }
        instance = this;
    }
    #endregion
    public OnItemChanged onItemChangedCallBack;
    public int space = 5;
    public List<Item> items = new List<Item>();

    public bool AddItem(Item item){

        if(items.Count >= space){

            Debug.Log("Not more space");
            return false;

        }

        items.Add(item);
        if(onItemChangedCallBack != null){
            onItemChangedCallBack.Invoke();
        }
        return true;
    }

    public void RemoveItem(Item item){
        
        items.Remove(item);

        if(onItemChangedCallBack != null){
            onItemChangedCallBack.Invoke();
        }
    }
}
