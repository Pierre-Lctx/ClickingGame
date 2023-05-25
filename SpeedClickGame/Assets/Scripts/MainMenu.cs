using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public List<Button> buttonList;

    public GameObject PanelMainMenu;
    public GameObject PanelOption;

    public GameObject parametersObject;

    Parameters parameters;

    Color colorUnUse = new Color(62f / 255f, 62f / 255f, 62f / 255f, 1f);
    Color colorEasyDifficultyButton = new Color(0, 196f / 255f, 61f / 255f, 1f);
    Color colorNormalDifficultyButton = new Color(255 / 255f, 141f / 255f, 0f / 255f, 1f);
    Color colorHardDifficultyButton = new Color(240f / 255f, 0f / 255f, 0f / 255f, 1f);
    Color colorUse = new Color(91f / 255f, 91f / 255f, 91f / 255f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        parameters = parametersObject.GetComponent<Parameters>();

        PanelOption.SetActive(false);
        PanelMainMenu.SetActive(true);
    }

    void ResetButton()
    {
        foreach(Button button in buttonList)
        {
            Image buttonImage = button.GetComponent<Image>();
            buttonImage.color = colorUnUse;
            
            button.enabled = true;
        }
    }

    private Button FindButton(string name)
    {
        return GameObject.Find(name).GetComponent<Button>();
    }

    void ChangeColor()
    {
        //Changement des boutons de la durée de la partie
        if (parameters.GameTime == 30)
        {
            Image button1 = FindButton("Button30").GetComponent<Image>();
            button1.color = colorUse;

            FindButton("Button30").enabled = false;

            Image button2 = FindButton("Button60").GetComponent<Image>();
            button2.color = colorUnUse;

            FindButton("Button60").enabled = true;

            Image button3 = FindButton("Button90").GetComponent<Image>();
            button3.color = colorUnUse;

            FindButton("Button90").enabled = true;
        }
        else if (parameters.GameTime == 60)
        {
            Image button1 = FindButton("Button30").GetComponent<Image>();
            button1.color = colorUnUse;

            FindButton("Button30").enabled = true;

            Image button2 = FindButton("Button60").GetComponent<Image>();
            button2.color = colorUse;

            FindButton("Button60").enabled = false;

            Image button3 = FindButton("Button90").GetComponent<Image>();
            button3.color = colorUnUse;

            FindButton("Button90").enabled = true;
        }
        else if (parameters.GameTime == 90)
        {
            Image button1 = FindButton("Button30").GetComponent<Image>();
            button1.color = colorUnUse;

            FindButton("Button30").enabled = true;

            Image button2 = FindButton("Button60").GetComponent<Image>();
            button2.color = colorUnUse;

            FindButton("Button60").enabled = true;

            Image button3 = FindButton("Button90").GetComponent<Image>();
            button3.color = colorUse;

            FindButton("Button90").enabled = false;
        }

        //Changement des boutons de changement de taille
        if (parameters.ScalingChange)
        {
            Image button1 = FindButton("ButtonYes").GetComponent<Image>();
            button1.color = colorEasyDifficultyButton;

            FindButton("ButtonYes").enabled = false;

            Image button2 = FindButton("ButtonNO").GetComponent<Image>();
            button2.color = colorUnUse;

            FindButton("ButtonNO").enabled = true;
        }
        else
        {
            Image button1 = FindButton("ButtonYes").GetComponent<Image>();
            button1.color = colorUnUse;

            FindButton("ButtonYes").enabled = true;

            Image button2 = FindButton("ButtonNO").GetComponent<Image>();
            button2.color = colorHardDifficultyButton;

            FindButton("ButtonNO").enabled = false;
        }

        //Changement des boutons de la difficulté
        if (parameters.Difficulty == Difficulty.Easy)
        {
            Image button1 = FindButton("ButtonEasy").GetComponent<Image>();
            button1.color = colorEasyDifficultyButton;

            FindButton("ButtonEasy").enabled = false;

            Image button2 = FindButton("ButtonMedium").GetComponent<Image>();
            button2.color = colorUnUse;

            FindButton("ButtonMedium").enabled = true;

            Image button3 = FindButton("ButtonHard").GetComponent<Image>();
            button3.color = colorUnUse;

            FindButton("ButtonHard").enabled = true;
        }
        else if (parameters.Difficulty == Difficulty.Normal)
        {
            Image button1 = FindButton("ButtonEasy").GetComponent<Image>();
            button1.color = colorUnUse;

            FindButton("ButtonEasy").enabled = true;

            Image button2 = FindButton("ButtonMedium").GetComponent<Image>();
            button2.color = colorNormalDifficultyButton;

            FindButton("ButtonMedium").enabled = false;

            Image button3 = FindButton("ButtonHard").GetComponent<Image>();
            button3.color = colorUnUse;

            FindButton("ButtonHard").enabled = true;
        }
        else if (parameters.Difficulty == Difficulty.Hard)
        {
            Image button1 = FindButton("ButtonEasy").GetComponent<Image>();
            button1.color = colorUnUse;

            FindButton("ButtonEasy").enabled = true;

            Image button2 = FindButton("ButtonMedium").GetComponent<Image>();
            button2.color = colorUnUse;

            FindButton("ButtonMedium").enabled = true;

            Image button3 = FindButton("ButtonHard").GetComponent<Image>();
            button3.color = colorHardDifficultyButton;

            FindButton("ButtonHard").enabled = false;
        }
    }

    public void SelectButton(Button button)
    {
        if (button.name == "Button30")
        {
            parameters.GameTime = 30;
        }
        else if (button.name == "Button60")
        {
            parameters.GameTime = 60;
        }
        else if (button.name == "Button90")
        {
            parameters.GameTime = 90;
        }
        else if (button.name == "ButtonYes")
        {
            parameters.ScalingChange = true;
        }
        else if (button.name == "ButtonNO")
        {
            parameters.ScalingChange = false;
        }
        else if (button.name == "ButtonEasy")
        {
            parameters.Difficulty = Difficulty.Easy;
        }
        else if (button.name == "ButtonMedium")
        {
            parameters.Difficulty = Difficulty.Normal;
        }
        else if (button.name == "ButtonHard")
        {
            parameters.Difficulty = Difficulty.Hard;
        }

        ChangeColor();
    }

    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Option()
    {
        ResetButton();
        PanelOption.SetActive(true);
        PanelMainMenu.SetActive(false);

        ChangeColor();
    }

    public void Return()
    {
        PanelOption.SetActive(false);
        PanelMainMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
