using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Interactable
{

    private Transform playerTransform = null;
    public float speed = 2;
    private bool moveTo = false;

    public override void Interact()
    {
        base.Interact();
        SetPlayerTransform(player);
    }

    private void LateUpdate() {
        if(playerTransform != null){
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            if(distance <= radius){
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, step);
            }
        }
    }

    public void SetPlayerTransform(Transform player){
        playerTransform = player;
    }

}
