using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text endText;
    public TMP_Text informationText;

    public GameObject panel;

    Color colorUnUse = new Color(59f / 255f, 59f / 255f, 59f / 255f, 1f);

    public int score;
    public Time time;

    public List<Button> buttonList;
    public List<TMP_Text> buttonsTextList;

    public float totalTime = 60f;
    private float currentTime; // Temps restant actuel

    public List<string> trollWords;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "60";
        scoreText.text = "0 Touch";

        ResetButton();
        ResetText();

        currentTime = totalTime;
        UpdateTimerText();

        panel.SetActive(true);
        endText.gameObject.SetActive(false);
        informationText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);

        // D�marre le timer en appelant la m�thode "Countdown" toutes les secondes
        InvokeRepeating("Countdown", 1f, 1f);

        ChooseRandomButton();
    }

    public void OnMouseDown()
    {
        if (gameObject.activeSelf)
        {
            Debug.Log("Objet cliqu� : " + gameObject.name + " est activ�.");
        }
        else
        {
            Debug.Log("Objet cliqu� : " + gameObject.name + " est d�sactiv�.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Countdown()
    {
        currentTime -= 1f; // D�cr�mente le temps restant

        if (currentTime <= 0f)
        {
            currentTime = 0f;

            ResetButton();
            ResetText();

            endText.text = score + " Touch";

            panel.SetActive(false);
            endText.gameObject.SetActive(true);
            informationText.gameObject.SetActive(true);

            scoreText.gameObject.SetActive(false);
            timerText.gameObject.SetActive(false);

            // Arr�te le timer lorsque le temps est �coul�
            CancelInvoke("Countdown");

            StartCoroutine(GameOverRoutine());
        }

        UpdateTimerText();
    }

    private IEnumerator GameOverRoutine()
    {
        yield return new WaitForSeconds(5f);

        // Charger la sc�ne du menu principal
        SceneManager.LoadScene("MainMenu");
    }

    private void UpdateTimerText()
    {
        // Affiche le temps restant dans le composant Text
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void ResetText()
    {
        foreach (TMP_Text text in buttonsTextList)
            text.text = "";
    }

    void ResetButton()
    {
        foreach (Button button in buttonList)
        {
            button.enabled = false;

            Image buttonImage = button.GetComponent<Image>();
            buttonImage.color = colorUnUse;
        }
    }

    public void OnClick()
    {
        ChangeScore();
        ChooseRandomButton();
    }

    void ChangeScore()
    {
        score++;
        scoreText.text = score + " Touch";
    }

    private bool IsColorLight(Color color)
    {
        // Calcul de la luminosit� de la couleur
        float brightness = (color.r * 0.299f + color.g * 0.587f + color.b * 0.114f);

        // V�rifie si la luminosit� est sup�rieure � la moiti�
        return brightness > 0.5f;
    }

    void ChooseRandomButton()
    {
        int index = (int)Random.Range(0, buttonList.Count);
        int indexWord = (int)Random.Range(0, trollWords.Count);

        int r = (int)Random.Range(0, 256);
        int g = (int)Random.Range(0, 256);
        int b = (int)Random.Range(0, 256);

        ResetButton();
        ResetText();

        buttonList[index].enabled = true;
        buttonsTextList[index].text = trollWords[indexWord];
        //Debug.Log($"Changing color to {buttonList[index].name} : Color({r},{g},{b},255)");
        Color newColor = new Color(r / 255f, g / 255f, b / 255f, 1f);

        Image buttonImage = buttonList[index].GetComponent<Image>();
        buttonImage.color = newColor;

        // V�rifie si la couleur est claire ou fonc�e
        bool isColorLight = IsColorLight(newColor);

        // D�finit la couleur du texte en cons�quence
        if (isColorLight)
        {
            buttonsTextList[index].color = Color.black;
        }
        else
        {
            buttonsTextList[index].color = Color.white;
        }
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
