using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    public void PickUp(){
        Debug.Log("Pick Up " + item.name);
        //Add in Inventory
        bool wasPickUp = Inventory.instance.AddItem(item);
        if(wasPickUp){
            Destroy(gameObject);
        }
    }
}
