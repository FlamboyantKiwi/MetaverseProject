using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goal: MonoBehaviour
{ //Used in Prefabs: Ring and Target
    private AudioSource goalAudio; //stores sound to be played
    private void Start()
    {
        goalAudio = this.GetComponent<AudioSource>(); //gets audiosource
    }
    private void Collision(Collision collision)
    { //if the 
        if (collision.transform.GetComponent<Interactable>())
        {
            goalAudio.Play(); //plays the audio
            //Debug.Log("Woo!"); testing code - Ensured gameobject was detected
            Destroy(collision.gameObject); 
            //destroys the object that collided with the trigger collider.
        }
    }
    //Used all 3 types of onCollisions as the collision is sometimes not detected.
        //forgot how to fix this and ran out of time to fix it properly
        //this makes it less likely to happen (along with a larger collision area)
    private void OnCollisionEnter(Collision collision) => Collision(collision);
    private void OnCollisionExit(Collision collision) => Collision(collision);
    private void OnCollisionStay(Collision collision) => Collision(collision);
}
