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

    Parameters parameters;

    Color colorUnUse = new Color(62f / 255f, 62f / 255f, 62f / 255f, 1f);
    Color colorEasyDifficultyButton = new Color(0, 196f / 255f, 61f / 255f, 1f);
    Color colorNormalDifficultyButton = new Color(255 / 255f, 141f / 255f, 0f / 255f, 1f);
    Color colorHardDifficultyButton = new Color(240f / 255f, 0f / 255f, 0f / 255f, 1f);
    Color colorUse = new Color(91f / 255f, 91f / 255f, 91f / 255f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        parameters = Parameters.instance;

        PanelOption.SetActive(false);
        PanelMainMenu.SetActive(true);
    }

    void ResetButton()
    {
        foreach(Button button in buttonList)
        {
            Image buttonImage = button.GetComponent<Image>();
            buttonImage.color = colorUnUse;
        }
    }

    public void SelectButton(Button button)
    {
        if (button.name.Contains("30") || button.name.Contains("60") || button.name.Contains("90"))
        {
            if (button.name == "Button30")
            {
                Image buttonImage = button.GetComponent<Image>();
                buttonImage.color = colorUse;

                parameters.GameTime = 30;

                foreach (Button buttonF in buttonList)
                {
                    if (buttonF.name == "Button60" || buttonF.name == "Button90")
                    {
                        Image buttonImageOther = buttonF.GetComponent<Image>();
                        buttonImage.color = colorUnUse;
                    }
                }
            }
            if (button.name == "Button60")
            {
                Image buttonImage = button.GetComponent<Image>();
                buttonImage.color = colorUse;

                parameters.GameTime = 60;

                foreach(Button buttonF in buttonList)
                {
                    if (buttonF.name == "Button30" || buttonF.name == "Button90")
                    {
                        Image buttonImageOther = buttonF.GetComponent<Image>();
                        buttonImage.color = colorUnUse;
                    }
                }
            }
            if (button.name == "Button90")
            {
                Image buttonImage = button.GetComponent<Image>();
                buttonImage.color = colorUse;

                parameters.GameTime = 90;

                foreach (Button buttonF in buttonList)
                {
                    if (buttonF.name == "Button30" || buttonF.name == "Button60")
                    {
                        Image buttonImageOther = buttonF.GetComponent<Image>();
                        buttonImage.color = colorUnUse;
                    }
                }
            }
        }
        else if (button.name.Contains("Yes"))
        {
            Image buttonImage = button.GetComponent<Image>();
            buttonImage.color = colorEasyDifficultyButton;

            parameters.ScalingChange = true;

            foreach (Button buttonF in buttonList)
            {
                if (buttonF.name == "ButtonNO")
                {
                    Image buttonImageOther = buttonF.GetComponent<Image>();
                    buttonImage.color = colorUnUse;
                }
            }
        }
        else if (button.name.Contains("NO"))
        {
            Image buttonImage = button.GetComponent<Image>();
            buttonImage.color = colorHardDifficultyButton;

            parameters.ScalingChange = false;

            foreach (Button buttonF in buttonList)
            {
                if (buttonF.name == "ButtonYes")
                {
                    Image buttonImageOther = buttonF.GetComponent<Image>();
                    buttonImage.color = colorUnUse;
                }
            }
        }
        else if (button.name.Contains("Easy"))
        {
            Image buttonImage = button.GetComponent<Image>();
            buttonImage.color = colorEasyDifficultyButton;

            parameters.Difficulty = Difficulty.Easy;

            foreach (Button buttonF in buttonList)
            {
                if (buttonF.name == "ButtonMedium" || buttonF.name == "ButtonHard")
                {
                    Image buttonImageOther = buttonF.GetComponent<Image>();
                    buttonImage.color = colorUnUse;
                }
            }
        }
        else if (button.name.Contains("Medium"))
        {
            Image buttonImage = button.GetComponent<Image>();
            buttonImage.color = colorNormalDifficultyButton;

            parameters.Difficulty = Difficulty.Normal;

            foreach (Button buttonF in buttonList)
            {
                if (buttonF.name == "ButtonEasy" || buttonF.name == "ButtonHard")
                {
                    Image buttonImageOther = buttonF.GetComponent<Image>();
                    buttonImage.color = colorUnUse;
                }
            }
        }
        else if (button.name.Contains("Hard"))
        {
            Image buttonImage = button.GetComponent<Image>();
            buttonImage.color = colorHardDifficultyButton;

            parameters.Difficulty = Difficulty.Hard;

            foreach (Button buttonF in buttonList)
            {
                if (buttonF.name == "ButtonMedium" || buttonF.name == "ButtonEasy")
                {
                    Image buttonImageOther = buttonF.GetComponent<Image>();
                    buttonImage.color = colorUnUse;
                }
            }
        }
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
