using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Option()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
