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

    Color colorUnUse = new Color(59f / 255f, 59f / 255f, 59f / 255f, 1f);


    public int score;
    public Time time;

    public List<Button> buttonList;
    public List<TMP_Text> buttonsTextList;

    public float totalTime;
    private float currentTime; // Temps restant actuel

    public List<string> trollWords;

    //Code ajouté de la V2
    [Space,Header("Paramètres V2"), Space]
    public GameObject parametersObject;

    Parameters parameters;

    public float targetScale = 0.25f;
    public float scalingDuration = 0.75f;
    public float resetDuration = 0.5f;
    public float initialDelay = 0.25f;

    public bool isScaling = false;

    public List<Vector3> originScales;

    private Coroutine coroutine = null;

    //Fin de code ajouté de la V2

    // Start is called before the first frame update
    void Start()
    {
        parameters = parametersObject.GetComponent<Parameters>();

        totalTime = parameters.GameTime;

        scoreText.text = "0 Touch";

        //Code ajouté de la V2

        foreach(Button button in buttonList)
        {
            originScales.Add(button.transform.localScale);
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

    public void OnMouseDown()
    {
        if (gameObject.activeSelf)
        {
            Debug.Log("Objet cliqué : " + gameObject.name + " est activé.");
        }
        else
        {
            Debug.Log("Objet cliqué : " + gameObject.name + " est désactivé.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (parameters.ScalingChange)
        {
            //La taille des boutons doit changer

        }
    }

    private void Countdown()
    {
        currentTime -= 1f; // Décrémente le temps restant

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

            // Arrête le timer lorsque le temps est écoulé
            CancelInvoke("Countdown");

            StartCoroutine(GameOverRoutine());
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
        //Code ajouté de la V2

        if (!isScaling && parameters.ScalingChange)
        {
            coroutine = StartCoroutine(ScaleButton(buttonList.IndexOf(button)));
        }
        else if (isScaling && parameters.ScalingChange)
        {
            StopCoroutine(coroutine);
            StartCoroutine(ResetButton(buttonList.IndexOf(button)));
        }

        //Fin du code ajouté de la V2

        ChangeScore();
        ChooseRandomButton();

        //Code ajouté de la V2



        //Fin du code ajouté de la V2
    }

    void ChangeScore()
    {
        score++;
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

        if (!isScaling && parameters.ScalingChange && coroutine == null)
        {
            coroutine = StartCoroutine(ScaleButton(index));
        }

        ResetButton();
        ResetText();

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
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //Code ajouté de la V2

    private IEnumerator ScaleButton(int buttonIndex)
    {
        isScaling = true;
        float timer = 0f;
        Button button = buttonList[buttonIndex];

        while (timer < scalingDuration)
        {
            timer += Time.deltaTime;
            float scaleRatio = Mathf.Lerp(1f, targetScale, timer / scalingDuration);
            button.transform.localScale = originScales[buttonIndex] * scaleRatio;
            yield return null;
        }

        button.transform.localScale = originScales[buttonIndex] * targetScale;
        isScaling = false;
    }

    private IEnumerator ResetButton(int buttonIndex)
    {
        isScaling = true;
        float timer = 0f;
        Button button = buttonList[buttonIndex];

        while (timer < resetDuration)
        {
            timer += Time.deltaTime;
            float scaleRatio = Mathf.Lerp(targetScale, 1f, timer / resetDuration);
            button.transform.localScale = originScales[buttonIndex] * scaleRatio;
            yield return null;
        }

        button.transform.localScale = originScales[buttonIndex];
        isScaling = false;
    }

    //Fin de code ajouté de la V2
}
