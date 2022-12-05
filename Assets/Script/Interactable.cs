using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Rigidbody rb; //this gameObject's RigidBody
    private Transform holdPosition; 
        //Position the interactable is moved to when held

    private void Start()
    { //stores gameObject's Rigidbody component at start.
        rb = this.GetComponent<Rigidbody>(); 
    }
    private void Update()
    { //every update, moves gameobject to holdposition
        if (holdPosition != null)
        {
            rb.MovePosition(holdPosition.position);
        }
    }
    public void Hold(Transform holdPosition)
    { //Sets holdposition and prevents the Object from being affected by gravity
        this.holdPosition = holdPosition;
        rb.useGravity = false;
    }
    public void Drop()
    { // clear holdposition and enables gravity again - makes object fall
        this.holdPosition = null;
        rb.useGravity = true;
    }
    public void Throw(Vector3 direction, float force)
    { //drops and adds force to object - makng it be thrown
        Drop();
        rb.AddForce(direction * force);
    }
}
