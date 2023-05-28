using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        //Changement couleur bouton taille minimum changement de taille
        if (parameters.MinimumSizeScalingChange == 0.1f)
        {
            Image button1 = FindButton("ButtonDizieme").GetComponent<Image>();
            button1.color = colorUse;

            FindButton("ButtonDizieme").enabled = false;

            Image button2 = FindButton("ButtonQuart").GetComponent<Image>();
            button2.color = colorUnUse;

            FindButton("ButtonQuart").enabled = true;
        }
        else if (parameters.MinimumSizeScalingChange == 0.25f)
        {
            Image button1 = FindButton("ButtonDizieme").GetComponent<Image>();
            button1.color = colorUnUse;

            FindButton("ButtonDizieme").enabled = true;

            Image button2 = FindButton("ButtonQuart").GetComponent<Image>();
            button2.color = colorUse;

            FindButton("ButtonQuart").enabled = false;
        }

        //Changement couleur boutons timer changement de taille
        if (parameters.CoolDownScalingChange == 0.5f)
        {
            Image button1 = FindButton("Button05").GetComponent<Image>();
            button1.color = colorUse;

            FindButton("Button05").enabled = false;

            Image button2 = FindButton("Button075").GetComponent<Image>();
            button2.color = colorUnUse;

            FindButton("Button075").enabled = true;

            Image button3 = FindButton("Button1").GetComponent<Image>();
            button3.color = colorUnUse;

            FindButton("Button1").enabled = true;

            Image button4 = FindButton("Button125").GetComponent<Image>();
            button4.color = colorUnUse;

            FindButton("Button125").enabled = true;
        }
        else if (parameters.CoolDownScalingChange == 0.75f)
        {
            Image button1 = FindButton("Button05").GetComponent<Image>();
            button1.color = colorUnUse;

            FindButton("Button05").enabled = true;

            Image button2 = FindButton("Button075").GetComponent<Image>();
            button2.color = colorUse;

            FindButton("Button075").enabled = false;

            Image button3 = FindButton("Button1").GetComponent<Image>();
            button3.color = colorUnUse;

            FindButton("Button1").enabled = true;

            Image button4 = FindButton("Button125").GetComponent<Image>();
            button4.color = colorUnUse;

            FindButton("Button125").enabled = true;
        }
        else if (parameters.CoolDownScalingChange == 1f)
        {
            Image button1 = FindButton("Button05").GetComponent<Image>();
            button1.color = colorUnUse;

            FindButton("Button05").enabled = true;

            Image button2 = FindButton("Button075").GetComponent<Image>();
            button2.color = colorUnUse;

            FindButton("Button075").enabled = true;

            Image button3 = FindButton("Button1").GetComponent<Image>();
            button3.color = colorUse;

            FindButton("Button1").enabled = false;

            Image button4 = FindButton("Button125").GetComponent<Image>();
            button4.color = colorUnUse;

            FindButton("Button125").enabled = true;
        }
        else if (parameters.CoolDownScalingChange == 1.25f)
        {
            Image button1 = FindButton("Button05").GetComponent<Image>();
            button1.color = colorUnUse;

            FindButton("Button05").enabled = true;

            Image button2 = FindButton("Button075").GetComponent<Image>();
            button2.color = colorUnUse;

            FindButton("Button075").enabled = true;

            Image button3 = FindButton("Button1").GetComponent<Image>();
            button3.color = colorUnUse;

            FindButton("Button1").enabled = true;

            Image button4 = FindButton("Button125").GetComponent<Image>();
            button4.color = colorUse;

            FindButton("Button125").enabled = false;
        }

        //Changement des boutons du type de jeu
        if (parameters.GameType == GameType.Decrement)
        {
            Image button1 = FindButton("ButtonDecrementiel").GetComponent<Image>();
            button1.color = colorUse;

            FindButton("ButtonDecrementiel").enabled = false;

            Image button2 = FindButton("ButtonLife").GetComponent<Image>();
            button2.color = colorUnUse;

            FindButton("ButtonLife").enabled = true;
        }
        else if (parameters.GameType == GameType.Life)
        {
            Image button1 = FindButton("ButtonDecrementiel").GetComponent<Image>();
            button1.color = colorUnUse;

            FindButton("ButtonDecrementiel").enabled = true;

            Image button2 = FindButton("ButtonLife").GetComponent<Image>();
            button2.color = colorUse;

            FindButton("ButtonLife").enabled = false;
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

            Image button4 = FindButton("ButtonCustom").GetComponent<Image>();
            button4.color = colorUnUse;

            FindButton("ButtonCustom").enabled = true;
            FindButton("ButtonDizieme").enabled = false;
            FindButton("ButtonQuart").enabled = false;
            FindButton("Button05").enabled = false;
            FindButton("Button075").enabled = false;
            FindButton("Button1").enabled = false;
            FindButton("Button125").enabled = false;
            FindButton("Button30").enabled = false;
            FindButton("Button60").enabled = false;
            FindButton("Button90").enabled = false;
            FindButton("ButtonYes").enabled = false;
            FindButton("ButtonNO").enabled = false;
            FindButton("ButtonDecrementiel").enabled = false;
            FindButton("ButtonLife").enabled = false;
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

            Image button4 = FindButton("ButtonCustom").GetComponent<Image>();
            button4.color = colorUnUse;

            FindButton("ButtonCustom").enabled = true;

            FindButton("ButtonCustom").enabled = true;
            FindButton("ButtonDizieme").enabled = false;
            FindButton("ButtonQuart").enabled = false;
            FindButton("Button05").enabled = false;
            FindButton("Button075").enabled = false;
            FindButton("Button1").enabled = false;
            FindButton("Button125").enabled = false;
            FindButton("Button30").enabled = false;
            FindButton("Button60").enabled = false;
            FindButton("Button90").enabled = false;
            FindButton("ButtonYes").enabled = false;
            FindButton("ButtonNO").enabled = false;
            FindButton("ButtonDecrementiel").enabled = false;
            FindButton("ButtonLife").enabled = false;
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

            Image button4 = FindButton("ButtonCustom").GetComponent<Image>();
            button4.color = colorUnUse;

            FindButton("ButtonCustom").enabled = true;

            FindButton("ButtonCustom").enabled = true;
            FindButton("ButtonDizieme").enabled = false;
            FindButton("ButtonQuart").enabled = false;
            FindButton("Button05").enabled = false;
            FindButton("Button075").enabled = false;
            FindButton("Button1").enabled = false;
            FindButton("Button125").enabled = false;
            FindButton("Button30").enabled = false;
            FindButton("Button60").enabled = false;
            FindButton("Button90").enabled = false;
            FindButton("ButtonYes").enabled = false;
            FindButton("ButtonNO").enabled = false;
            FindButton("ButtonDecrementiel").enabled = false;
            FindButton("ButtonLife").enabled = false;
        }
        else if (parameters.Difficulty == Difficulty.Custom)
        {
            Image button1 = FindButton("ButtonEasy").GetComponent<Image>();
            button1.color = colorUnUse;

            FindButton("ButtonEasy").enabled = true;

            Image button2 = FindButton("ButtonMedium").GetComponent<Image>();
            button2.color = colorUnUse;

            FindButton("ButtonMedium").enabled = true;

            Image button3 = FindButton("ButtonHard").GetComponent<Image>();
            button3.color = colorUnUse;

            FindButton("ButtonHard").enabled = true;

            Image button4 = FindButton("ButtonCustom").GetComponent<Image>();
            button4.color = colorUse;

            FindButton("ButtonCustom").enabled = false;
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
            parameters.ScalingChange = false;
            parameters.GameTime = 60;
            parameters.GameType = GameType.Decrement;
        }
        else if (button.name == "ButtonMedium")
        {
            parameters.Difficulty = Difficulty.Normal;
            parameters.ScalingChange = true;
            parameters.GameTime = 30;
            parameters.MinimumSizeScalingChange = 0.25f;
            parameters.CoolDownScalingChange = 1f;
            parameters.GameType = GameType.Decrement;
        }
        else if (button.name == "ButtonHard")
        {
            parameters.Difficulty = Difficulty.Hard;
            parameters.ScalingChange = true;
            parameters.GameTime = 60;
            parameters.MinimumSizeScalingChange = 0.1f;
            parameters.CoolDownScalingChange = 0.75f;
            parameters.GameType = GameType.Life;
        }
        else if (button.name == "ButtonCustom")
        {
            parameters.Difficulty = Difficulty.Custom;
            parameters.ScalingChange = false;
            parameters.GameTime = 60;
            parameters.MinimumSizeScalingChange = 0.25f;
            parameters.CoolDownScalingChange = 1.25f;
            parameters.GameType = GameType.Decrement;
        }
        else if (button.name == "ButtonQuart")
        {
            parameters.MinimumSizeScalingChange = 0.25f;
        }
        else if (button.name == "ButtonDizieme")
        {
            parameters.MinimumSizeScalingChange = 0.1f;
        }
        else if (button.name == "Button05")
        {
            parameters.CoolDownScalingChange = 0.5f;
        }
        else if (button.name == "Button075")
        {
            parameters.CoolDownScalingChange = 0.75f;
        }
        else if (button.name == "Button1")
        {
            parameters.CoolDownScalingChange = 1f;
        }
        else if (button.name == "Button125")
        {
            parameters.CoolDownScalingChange = 1.25f;
        }
        else if (button.name == "ButtonDecrementiel")
        {
            parameters.GameType = GameType.Decrement;
        }
        else if (button.name == "ButtonLife")
        {
            parameters.GameType = GameType.Life;
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
