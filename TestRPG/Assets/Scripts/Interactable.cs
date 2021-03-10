using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3;
    private bool isFocus = false;
    public bool hasInteract = false;
    protected Transform player;

    public virtual void Interact(){
        Debug.Log("Interacting with " + transform.name);
    }

    private void Update() {
        if(isFocus && !hasInteract){
            float distance = Vector3.Distance(player.position, transform.position);
            if(distance <= radius){
                Interact();
                hasInteract = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform){
        isFocus = true;
        player = playerTransform;
        hasInteract = false;
    }

    public void OnDefocused(){
        isFocus = false;
        player = null;
        hasInteract = false;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,radius);
    }
}
