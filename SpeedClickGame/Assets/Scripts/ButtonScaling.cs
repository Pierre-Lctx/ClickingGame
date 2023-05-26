using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScaling : MonoBehaviour
{
    public float shrinkDuration = 1.25f;
    public const float originalScale = 1f;
    public float shrinkScale = 0.1f;

    public bool isClick = false;
    public bool canClick = true;
    public List<Button> buttons;
    public int score = 0;

    private Coroutine shrinkCoroutine;

    private void Start()
    {
        SelectButton();
    }

    void SelectButton()
    {
        // Désactiver tous les boutons sauf un bouton aléatoire
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }

        Button randomButton = GetRandomButton();
        if (randomButton != null)
        {
            randomButton.gameObject.SetActive(true);

            isClick = false; // Réinitialiser isClick à false
            shrinkCoroutine = StartCoroutine(ShrinkButton(randomButton));
        }
    }

    public void OnButtonClick()
    {
        score++;
        isClick = true;

        if (shrinkCoroutine != null)
        {
            StopCoroutine(shrinkCoroutine);
        }

        SelectButton();
    }

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

    private Button GetRandomButton()
    {
        return buttons[(int)Random.Range(0, buttons.Count)];
    }
}
