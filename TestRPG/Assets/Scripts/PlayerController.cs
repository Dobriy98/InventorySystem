using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Interactable focus;
    private Rigidbody rb;
    private Transform target;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }

        float step = 5 * Time.deltaTime;
        if(Input.GetMouseButton(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit)){
                transform.position = Vector3.MoveTowards(transform.position, hit.point,step);
                RemoveFocus();
            }
        }
        if(Input.GetMouseButton(1)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit)){
                if(hit.collider.GetComponent<Interactable>()){
                    Interactable inter = hit.collider.GetComponent<Interactable>();
                    SetFocus(inter);
                }
            }
        }
        if(target != null && !focus.hasInteract){
            transform.position = Vector3.MoveTowards(transform.position,target.position,step);
        }
        // if(Input.GetKeyDown(KeyCode.Space)){
        //     Coat.instance.MinusValue(1);
        //     Gold.instance.MinusValue(2);
        // }
    }

    private void SetFocus(Interactable newFocus){
        if(newFocus != focus){
            if(focus != null){
                focus.OnDefocused();
            }
            focus = newFocus;
            MoveTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }

    private void RemoveFocus(){
        if(focus != null){
            focus.OnDefocused();
        }
        focus = null;
        StopFollow();
    }

    private void MoveTarget(Interactable focus){
        target = focus.transform;
    }
    private void StopFollow(){
        target = null;
    }
    // private void OnCollisionEnter(Collision other) {
    //     if(other.gameObject.tag == "Enemy"){
    //         other.gameObject.GetComponent<Enemy>().TakeDamage(1);
    //         Coat.instance.PlusValue(1);
    //         Gold.instance.PlusValue(2);
    //     }
    // }
}
