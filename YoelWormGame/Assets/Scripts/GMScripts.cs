using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GMScripts : MonoBehaviour
{
    public int currentPlayer = 0;
    public int selectedCharacter = 0;
    public GameObject[] P;
    public GameObject[] C;
    public GameObject[] G;
    public GameObject[] T;
    public GameObject floatingCam;
    public static bool changePlayer = false;
    public float Timer = 15f;
    public float grace = 5f;

    //Locks cursor during game and gets all player componets in an array
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        P[selectedCharacter].GetComponent<Movement>().enabled = true;
        C[selectedCharacter].SetActive(true);
        G[selectedCharacter].GetComponent<VerticalAim>().enabled = true;
    }

    void Update()
    {   //Winning team checks
        if ((GameObject.FindGameObjectsWithTag("Red").Length == 0) && (GameObject.FindGameObjectsWithTag("Blue").Length == 0) && (GameObject.FindGameObjectsWithTag("Green").Length == 0))
        {
            SceneManager.LoadScene("YellowWin");
        }

        if ((GameObject.FindGameObjectsWithTag("Red").Length == 0) && (GameObject.FindGameObjectsWithTag("Blue").Length == 0) && (GameObject.FindGameObjectsWithTag("Yellow").Length == 0))
        {
            SceneManager.LoadScene("GreenWin");
        }

        if ((GameObject.FindGameObjectsWithTag("Red").Length == 0) && (GameObject.FindGameObjectsWithTag("Yellow").Length == 0) && (GameObject.FindGameObjectsWithTag("Green").Length == 0))
        {
            SceneManager.LoadScene("BlueWin");
        }

        if ((GameObject.FindGameObjectsWithTag("Yellow").Length == 0) && (GameObject.FindGameObjectsWithTag("Blue").Length == 0) && (GameObject.FindGameObjectsWithTag("Green").Length == 0))
        {
            SceneManager.LoadScene("RedWin");
        }

        //Changes current player, first sets all players to false and then resets their variables to default. Then moves along the array to the next player and enables it
        if ((Movement.changePlayer==true)||((Input.GetKeyDown(KeyCode.E))))
        {
            foreach (GameObject player in P)
            {
                player.GetComponent<Movement>().enabled = false;
                player.GetComponent<Movement>().hasShot = false;
                player.GetComponent<Movement>().canMove = true;
                player.GetComponent<Movement>().currentTime = Timer;
                player.GetComponent<Movement>().gracePeriod = grace;
            }
            foreach (GameObject camera in C)
            {
                camera.SetActive(false);
            }

            foreach (GameObject Text in T)
            {
                Text.SetActive(false);
            }

            foreach (GameObject gun in G)
            {
                gun.GetComponent<VerticalAim>().enabled = false;
            }

            if (selectedCharacter < 7)
            { selectedCharacter++; }

            else
            { selectedCharacter = 0; }

            floatingCam.SetActive(false);
            Movement.reset = false;      
            P[selectedCharacter].GetComponent<Movement>().enabled = true;
            C[selectedCharacter].SetActive(true);
            T[selectedCharacter].SetActive(true);
            G[selectedCharacter].GetComponent<VerticalAim>().enabled = true;
            Movement.changePlayer = false;
        }
    }
}
