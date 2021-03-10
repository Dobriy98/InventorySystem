using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("Set in Inspector")]
    public float health = 5;
    public float speed = 0.5f;
    private float angle = 0;
    private float radius = 1f;
    public Vector3 center = new Vector3(4,0,4);
    public Vector3 pos{
        get{
            return(this.transform.position);
        }
        set{
            this.transform.position = value;
        }
    }

    private void Update() {
        Move();    
    }

    public virtual void Move(){
        angle += speed * Time.deltaTime;
        
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        pos = new Vector3(x, pos.y, y) + center;
    }

    public virtual void TakeDamage(int damage){
        health -= damage;
        Debug.Log(this.health);
        if(health <= 0){
            Destroy(this.gameObject);
        }
    }
}
