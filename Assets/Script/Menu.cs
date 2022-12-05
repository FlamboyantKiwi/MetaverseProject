using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] public GameObject menu; //menu gameObject
    [SerializeField] public GameObject player; //player Character gameObject
    [SerializeField] public GameObject cineCamera; //cinemachine's camera gameObject
    private void Start()
    { //Activates menu & prevents player movement, till menu is minimised.
        Button(true);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        { //if ESC is pressed during gameplay, menu is activated 
            Button(true);
        }
    }
    public void Button(bool active)
    { //when menu is activated, player and camera movement is deactivated (& vice versa) 
        //called by the menu's RESUME button.
        menu.SetActive(active); 
        player.SetActive(!active);
        cineCamera.SetActive(!active);
    }
    public void ExitButton()
    { //exits the game - called by the menu's EXIT button
        Application.Quit();
    }
}
