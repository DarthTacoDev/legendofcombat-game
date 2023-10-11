using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Town");
        //make a start area (town)?
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
