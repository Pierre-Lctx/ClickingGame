using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeScript : MonoBehaviour
{
    public List<Image> hearts;
    public int lifeRemaning = 3;
    
    public void DecrementLife()
    {
        if (lifeRemaning > 0)
        {
            Color color = new Color(0, 0, 0, 1);

            hearts[lifeRemaning - 1].color = color;
            lifeRemaning--;
        }
        else
        {
            Debug.Log("Loose");
        }
    }
}
