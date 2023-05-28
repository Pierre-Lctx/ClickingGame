using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestGradient : MonoBehaviour
{
    public TMP_Text textComponent;
    public Gradient gradient;
    public float duration = 1f;

    private bool isAnimating = false;

    private void Start()
    {
        if (textComponent == null)
            textComponent = GetComponent<TMP_Text>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isAnimating)
            StartCoroutine(AnimateGradient());
    }

    private System.Collections.IEnumerator AnimateGradient()
    {
        isAnimating = true;

        float timeElapsed = 0f;
        Color startColor = textComponent.color;
        Color endColor = gradient.Evaluate(1f);

        while (timeElapsed < duration)
        {
            float normalizedTime = timeElapsed / duration;
            textComponent.color = Color.Lerp(startColor, endColor, normalizedTime);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        textComponent.color = endColor;
        isAnimating = false;
    }
}
