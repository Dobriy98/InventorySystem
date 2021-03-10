using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int health = 10;
    public int damage = 1;

    public void TakeDamage(int damage){
        health -= damage;
        if(health <= 0){
            Destroy(gameObject);
        }
    }
}
