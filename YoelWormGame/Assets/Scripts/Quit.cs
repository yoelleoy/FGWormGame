using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    //Keeps object with this script between loading scenes
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    //Quit game and Quit application buttons
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (Input.GetKey(KeyCode.O))
        {
            Application.Quit();
        }
    }
}
