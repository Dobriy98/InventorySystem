using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform transformParent;
    public GameObject inventoryUI;
    private InventorySlot[] slots;
    Inventory inventory;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = transformParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    private void UpdateUI(){
        Debug.Log("Updating UI");
        for(int i = 0; i < slots.Length; i++){
            if(i < inventory.items.Count){
                slots[i].AddItem(inventory.items[i]);
            } else {
                slots[i].ClearSlot();
            }
        }
    }
}
