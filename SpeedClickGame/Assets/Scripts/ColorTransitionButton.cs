using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;

public class ColorTransitionButton : MonoBehaviour, IPointerClickHandler
{
    public float transitionDuration = 1f;
    public Color startColor = Color.white;
    public Color targetColor = Color.red;

    public TMP_Text textComponent;
    private bool isTransitioning = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isTransitioning)
            StartCoroutine(TransitionColor());
    }

    private IEnumerator TransitionColor()
    {
        isTransitioning = true;

        float timeElapsed = 0f;
        Color currentColor = textComponent.color;

        while (timeElapsed < transitionDuration)
        {
            float normalizedTime = timeElapsed / transitionDuration;
            textComponent.color = Color.Lerp(currentColor, targetColor, normalizedTime);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Reverse transition
        timeElapsed = 0f;

        while (timeElapsed < transitionDuration)
        {
            float normalizedTime = timeElapsed / transitionDuration;
            textComponent.color = Color.Lerp(targetColor, startColor, normalizedTime);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        textComponent.color = startColor;
        isTransitioning = false;
    }
}
