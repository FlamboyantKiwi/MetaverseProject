using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float TrampolineForce; 
    //allows changable force between different trampolines
    private Rigidbody rb; //temp stores rigidbody of object its collided with

    private void OnCollisionEnter(Collision collision)
    {
        rb = collision.gameObject.GetComponent<Rigidbody>(); 
        //gets rigidbody of object its collided with
        rb.AddForce(TrampolineForce * rb.mass * Vector3.up, ForceMode.Impulse);
        //adds instant upward force to rigidbody, making it 'bounce'/jump upwards
    }
}