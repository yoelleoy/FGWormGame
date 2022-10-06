using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    //Unlocks cursor in menu
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    //On button press loads game scene
    public void LoadGame()
    {
        SceneManager.LoadScene("GameLevel");
    } 
}
