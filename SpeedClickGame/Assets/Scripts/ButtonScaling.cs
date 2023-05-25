using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScaling : MonoBehaviour
{
    public float targetScale = 0.25f;
    public float scalingDuration = 0.75f;
    public float resetDuration = 0.5f;
    public float initialDelay = 0.25f;

    private bool isFirstButtonClick = true;
    public bool isScaling = false;
    private Vector3[] originalScales;
    public Button[] buttons;

    private void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        originalScales = new Vector3[buttons.Length];

        for (int i = 0; i < buttons.Length; i++)
        {
            originalScales[i] = buttons[i].transform.localScale;
        }
    }

    private void Update()
    {
        if (isFirstButtonClick)
        {
            StartCoroutine(WaitForFirstButtonClick());
            isFirstButtonClick = false;
        }
    }

    private IEnumerator WaitForFirstButtonClick()
    {
        float timer = 0f;

        while (timer < initialDelay)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].onClick.AddListener(() => OnButtonClick(i));
        }
    }

    public void OnButtonClick(int buttonIndex)
    {
        if (!isScaling)
        {
            StartCoroutine(ScaleButton(buttonIndex));
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(ResetButton(buttonIndex));
        }
    }

    private IEnumerator ScaleButton(int buttonIndex)
    {
        isScaling = true;
        float timer = 0f;
        Button button = buttons[buttonIndex];
        Vector3 startScale = button.transform.localScale;

        while (timer < scalingDuration)
        {
            timer += Time.deltaTime;
            float scaleRatio = Mathf.Lerp(1f, targetScale, timer / scalingDuration);
            button.transform.localScale = originalScales[buttonIndex] * scaleRatio;
            yield return null;
        }

        button.transform.localScale = originalScales[buttonIndex] * targetScale;
        isScaling = false;
    }

    private IEnumerator ResetButton(int buttonIndex)
    {
        isScaling = true;
        float timer = 0f;
        Button button = buttons[buttonIndex];
        Vector3 startScale = button.transform.localScale;

        while (timer < resetDuration)
        {
            timer += Time.deltaTime;
            float scaleRatio = Mathf.Lerp(targetScale, 1f, timer / resetDuration);
            button.transform.localScale = originalScales[buttonIndex] * scaleRatio;
            yield return null;
        }

        button.transform.localScale = originalScales[buttonIndex];
        isScaling = false;
    }
}
