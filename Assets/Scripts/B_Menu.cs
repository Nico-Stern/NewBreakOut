using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B_Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Babacar");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
