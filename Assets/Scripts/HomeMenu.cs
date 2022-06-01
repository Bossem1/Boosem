using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    public void PlayableDemo()
    {
        SceneManager.LoadScene("Playable Demo");
    }

    public void LoadHomeMenu()
    {
        SceneManager.LoadScene("Home Menu");
    }
}
