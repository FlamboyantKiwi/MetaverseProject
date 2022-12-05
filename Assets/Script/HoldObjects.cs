using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldObjects : MonoBehaviour
{
    private Transform Player; //Stores the transform of this component
    private Interactable interact; 
    //holds the Interactable class of the object being held by the player

    [SerializeField] private float Distance; 
        //Player reach distance
    [SerializeField] private LayerMask layerMask; 
        //LayerMask in which to look for interactables
    [SerializeField] private Transform HoldPosition; 
        //Place in which to move interactable objects
    [SerializeField] private float ThrowForce; 
        //Force applied to thrown interactables

    private void Start()
    { //stores Player's Transform component at start.
        Player = this.GetComponentInChildren<Transform>();
    }
    void Update()
    { //Calls another function
        Inputs(Input.GetKeyDown(KeyCode.E), Input.GetKeyDown(KeyCode.Q));
    }   
    private void Inputs(bool Ekey, bool Qkey)
    {
        if (Ekey) //if E key is pressed
        { 
            if (interact == null)
            { //if player presses E while not holding anything,
                //try to grab object in front of them.
                Hold(); // calls Hold function (below)
            }
            else
            {  //if player presses E while holding an object, drop object.
                interact.Drop(); //calls interact's Drop() Function (from interactables Script)
                interact = null; //removes interactable gameObject from interact variable
            }
        }
        else if (Qkey && interact != null)
        { //if player presses Q while holding an object, throws object.
            //interact.GetComponent<Rigidbody>().AddForce(transform.forward * ThrowForce)
            interact.Throw(Player.forward + Player.up, ThrowForce); 
                //calls interact's Throw() Function (from interactables Script)
            interact = null; //removes interactable gameObject from interact variable
        }
    }
    private void Hold()
    { //finds interactable to hold and makes it be held by player.
        bool checkRaycast = Physics.Raycast(Player.position, Player.forward, 
            out RaycastHit raycasthit, Distance, layerMask);
        // sends out a raycast from player position, forwards to a pre-set distance
            // focussing only on a pre-set Layermask. This returns a RaycastHit
        if (checkRaycast)
        {//if the raycast found a gameobject fitting the requirements,
            // it calls Hold() from its Interactable component
            interact = raycasthit.transform.GetComponent<Interactable>();
            if (interact != null)
            {
                interact.Hold(HoldPosition);
            }
        }
    }
}
