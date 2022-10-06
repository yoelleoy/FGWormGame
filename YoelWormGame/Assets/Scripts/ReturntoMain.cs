using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturntoMain : MonoBehaviour
{   //Unlocks cursos in win menu
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    //On button press retuns to manin menu
    public void LoadGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
