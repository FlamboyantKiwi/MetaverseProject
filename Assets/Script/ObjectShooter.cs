using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectShooter : MonoBehaviour
{ // Can be added to Player Character, or gameobjects.
    [SerializeField] private GameObject[] objects;
    // Stores an array of gameobjects for the shooter to call upon and create.
    private int objectNo; // Temp holds Object ID that will be Instantiated
    [Space] // Gives a space in Unity Component layout - making it easier to understand.
    [SerializeField] private string buttonName;
    // allows 'Fire' Button to be easily changed during testing, while keeping variable private
        // Must be a valid button name, recognised by unity
    [SerializeField] private float force; 
    // Stores force at which new object is instantiated forwards with.
    [SerializeField] private Transform parent;
    // Stores Parent assigned to new object
        // so all objects are stored in the same parent
    private void Update()
    { 
        if (Input.GetButtonDown(buttonName))
        { // If buttonName is pressed, calls FireObject()
            FireObject();
        }
    }
    private void FireObject()
    {//create a object and 'fires it' the direction Script-Owner is facing.
        objectNo = Random.Range(0, objects.Length); 
        //makes a random number so random object is fired
        GameObject ball = Instantiate(objects[objectNo], transform.position + Vector3.forward, 
            this.transform.rotation, parent) as GameObject;
        //creates a new GameObject, slightly infront of the Script-Owner's transform, with the same rotation
            //these gameobjects are all placed as children to the same pre-determined parent.
        ball.GetComponent<Rigidbody>().AddForce(transform.forward * force); 
        //adds additional force to the object so it 'shoots', instead of just dropping to the floor
    }
}