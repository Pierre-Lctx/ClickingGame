using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Difficulty
{
    Easy,
    Normal,
    Hard,
    Custom
}

public enum GameType
{
    Decrement,
    Life
}

public class Parameters : MonoBehaviour
{
    public static Parameters instance;

    public Difficulty Difficulty = Difficulty.Easy;
    public bool ScalingChange = false;
    public float GameTime = 60;

    public float CoolDownScalingChange = .75f;
    public float MinimumSizeScalingChange = .25f;

    public GameType GameType = GameType.Decrement;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
