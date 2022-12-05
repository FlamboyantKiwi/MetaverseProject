using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody Player; //stores the player's rigidbody
    private Vector3 MovementDirection; //stores the Horizontal and Vertical inputs as a Vector3
    private Vector2 MouseDirection; //stores the Mouse X/Y inputs as a Vector2
    private float rotation; //used in the roataion of the camera/player
    private bool canJump = true; //controls whether or not the player can jump

    //SerializeFields allow me to easily tweak values, while keeping them private.
    [SerializeField] private float MovementSpeed; //number multiplied to player movement 
    [SerializeField] private float Sensitivity; //sensitivity of the player rotation
    [SerializeField] private float JumpForce; //number multiplied to jump force

    private void Start()
    {//sets Player's Rigidbody component at start.
        Player = this.GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { //gets input data every update.
        MovementDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        MouseDirection = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        rotation = Input.GetAxis("Horizontal");

        MovePlayer(); //calls private function MovePlayer()
    }

    //moves Player's Location//
    private void MovePlayer()
    {
        //Player Movement//     -   with horizontal/vertical inputs 
        Vector3 Movement = transform.TransformDirection(MovementDirection) * MovementSpeed;
        Player.velocity = new Vector3(Movement.x, Player.velocity.y, Movement.z);

        //Player Rotation//     -   with mouse movement 
        transform.Rotate(0f, rotation, 0f);
        rotation -= MouseDirection.y * Sensitivity;
        transform.Rotate(0f, MouseDirection.x * 2 * Sensitivity, 0f);

        //Player Jump//         -   with Spacebar
        if (Input.GetKeyDown(KeyCode.Space) && canJump) 
        {// If the space key is pressed and the Player is able to jump.
            //A force is applied uppwards (making them jump).
            Player.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    //Collision//
    //-   Allows the Player to jump if thy're touching another collider
    private void OnCollisionStay(Collision collider)
    {//if the player is colliding with something, they can jump.
        canJump = true;
    }
    private void OnCollisionExit(Collision collider)
    { //if the player isn't colliding with anything, they can't jump.
        canJump = false;
    }
}