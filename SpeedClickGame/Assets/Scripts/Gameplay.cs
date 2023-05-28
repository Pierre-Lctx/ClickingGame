using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    [Header("Paramètres V1"), Space]
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text endText;
    public TMP_Text informationText;

    public GameObject panel;

    Color colorUnUse = new Color(59f / 255f, 59f / 255f, 59f / 255f, 132 / 255);


    public int score;
    public Time time;

    public List<Button> buttonList;
    public List<TMP_Text> buttonsTextList;

    public float totalTime;
    private float currentTime; // Temps restant actuel

    public List<string> trollWords;

    //Code ajouté de la V2

    [Space, Header("Paramètres V2"), Space]
    public float shrinkDuration;
    public const float originalScale = 1f;
    public float shrinkScale;

    public bool isClick = false;
    public bool canClick = true;

    public Button targetButton;

    public float transitionDuration = 1f;
    public Color startColor = Color.white;
    public Color targetColor = Color.red;

    public List<Image> hearts;
    public int lifeRemaning = 3;

    public GameObject panelLife;

    private bool isTransitioning = false;

    private Coroutine shrinkCoroutine;
    public Parameters parameters;

    //Fin de code ajouté de la V2

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0 Touch";

        //Code ajouté de la V2

        parameters = FindAnyObjectByType<Parameters>();
        totalTime = parameters.GameTime;
        shrinkDuration = parameters.CoolDownScalingChange;
        shrinkScale = parameters.MinimumSizeScalingChange;

        if (parameters.GameType == GameType.Decrement)
        {
            panelLife.SetActive(false);
        }
        else
        {
            panelLife.SetActive(true);
        }

        //Fin code ajouté de la V2

        ResetButton();
        ResetText();

        currentTime = totalTime;
        UpdateTimerText();

        panel.SetActive(true);
        endText.gameObject.SetActive(false);
        informationText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);


        // Démarre le timer en appelant la méthode "Countdown" toutes les secondes
        InvokeRepeating("Countdown", 1f, 1f);

        ChooseRandomButton();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Countdown()
    {
        currentTime -= 1f; // Décrémente le temps restant

        if (currentTime <= 0f)
        {
            StopScreen();
        }

        UpdateTimerText();
    }

    private IEnumerator GameOverRoutine()
    {
        yield return new WaitForSeconds(5f);

        // Charger la scène du menu principal
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

    public void OnClick(Button button)
    {
        //Code ajouté à la V2
        
        isClick = true;

        //Debug.Log("Clicked");
        
        if (parameters.ScalingChange)
        {
            if (shrinkCoroutine != null)
            {
                // Rétablir la taille d'origine du bouton
                button.transform.localScale = Vector3.one * originalScale;
                StopCoroutine(shrinkCoroutine);
            }
        }

        //Fin de code ajouté à la V2

        ChangeScore(button.gameObject);
        ChooseRandomButton();
    }

    //Code de la V2

    void StopScreen()
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

        GameData data = new GameData();
        if (parameters.Difficulty == Difficulty.Easy)
        {
            data.gameMode = "Easy";
        }
        else if (parameters.Difficulty == Difficulty.Normal)
        {
            data.gameMode = "Normal";
        }
        else if (parameters.Difficulty == Difficulty.Hard)
        {
            data.gameMode = "Hard";
        }
        else
        {
            data.gameMode = "Custom";
        }
        data.score = score;

        // Arrête le timer lorsque le temps est écoulé
        CancelInvoke("Countdown");

        StartCoroutine(GameOverRoutine());
    }

    public void OnPanelClick(GameObject panel)
    {
        //Code ajouté à la V2

        isClick = true;

        //Debug.Log("Clicked");

        if (parameters.ScalingChange)
        {
            if (shrinkCoroutine != null)
            {
                // Rétablir la taille d'origine du bouton
                targetButton.transform.localScale = Vector3.one * originalScale;
                StopCoroutine(shrinkCoroutine);
            }
        }

        if (parameters.GameType == GameType.Life)
        {
            if (lifeRemaning > 1)
            {
                Color color = new Color(0, 0, 0, 1);

                hearts[lifeRemaning - 1].color = color;
                lifeRemaning--;
            }
            else
            {
                Color color = new Color(0, 0, 0, 1);

                hearts[0].color = color;
                lifeRemaning--;

                StopScreen();
            }
        }

        //Fin de code ajouté à la V2

        ChangeScore(panel);
        ChooseRandomButton();
    }

    private IEnumerator TransitionColor()
    {
        isTransitioning = true;

        float timeElapsed = 0f;
        Color currentTimerColor = timerText.color;
        Color currentScoreColor = scoreText.color;

        while (timeElapsed < transitionDuration)
        {
            float normalizedTime = timeElapsed / transitionDuration;
            timerText.color = Color.Lerp(currentTimerColor, targetColor, normalizedTime);
            scoreText.color = Color.Lerp(currentScoreColor, targetColor, normalizedTime);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Reverse transition
        timeElapsed = 0f;

        while (timeElapsed < transitionDuration)
        {
            float normalizedTime = timeElapsed / transitionDuration;
            timerText.color = Color.Lerp(targetColor, startColor, normalizedTime);
            scoreText.color = Color.Lerp(targetColor, startColor, normalizedTime);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        timerText.color = startColor;
        scoreText.color = startColor;
        isTransitioning = false;
    }

    //Fin ajout de code de la V2

    void ChangeScore(GameObject button)
    {
        if (button == targetButton.gameObject)
        {
            score++;
        }
        else
        {
            if (parameters.GameType == GameType.Decrement)
            {
                score--;

                if (!isTransitioning)
                    StartCoroutine(TransitionColor());
            }
        }
        
        scoreText.text = score + " Touch";
    }

    private bool IsColorLight(Color color)
    {
        // Calcul de la luminosité de la couleur
        float brightness = (color.r * 0.299f + color.g * 0.587f + color.b * 0.114f);

        // Vérifie si la luminosité est supérieure à la moitié
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

        targetButton = buttonList[index];

        buttonList[index].enabled = true;
        buttonsTextList[index].text = trollWords[indexWord];
        //Debug.Log($"Changing color to {buttonList[index].name} : Color({r},{g},{b},255)");
        Color newColor = new Color(r / 255f, g / 255f, b / 255f, 1f);

        Image buttonImage = buttonList[index].GetComponent<Image>();
        buttonImage.color = newColor;

        // Vérifie si la couleur est claire ou foncée
        bool isColorLight = IsColorLight(newColor);

        // Définit la couleur du texte en conséquence
        if (isColorLight)
        {
            buttonsTextList[index].color = Color.black;
        }
        else
        {
            buttonsTextList[index].color = Color.white;
        }

        //Code ajouté à la V2

        if (parameters.ScalingChange)
        {
            isClick = false; // Réinitialiser isClick à false
            shrinkCoroutine = StartCoroutine(ShrinkButton(buttonList[index]));
        }
            
        //Fin de code ajouté à la V2
    }

    //Code ajouté à la V2

    private IEnumerator ShrinkButton(Button button)
    {
        canClick = false;

        // Diminuer la taille du bouton pendant la durée spécifiée
        float timeElapsed = 0f;
        while (timeElapsed < shrinkDuration)
        {
            if (isClick)
            {
                // Rétablir la taille d'origine du bouton
                button.transform.localScale = Vector3.one * originalScale;

                isClick = false;
                break;
            }
            float t = timeElapsed / shrinkDuration;
            button.transform.localScale = Vector3.Lerp(Vector3.one * originalScale, Vector3.one * shrinkScale, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        canClick = true;
    }

    //Fin code ajouté à la V2
}
