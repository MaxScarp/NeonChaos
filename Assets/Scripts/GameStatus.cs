using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10.0f)] [SerializeField] float gameSpeed = 1.0f;
    [SerializeField] int pointPerBrickDestroyed = 21;
    [SerializeField] int pointPerSpecialBrickDestroyed = 9;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool autoplay = false;

    int score = 0;

    void Awake()
    {
        int countGameStatus = FindObjectsOfType<GameStatus>().Length;
        if(countGameStatus > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = score.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        score += pointPerBrickDestroyed;
        scoreText.text = score.ToString();
    }
    public void AddToScoreSpecial()
    {
        score += pointPerSpecialBrickDestroyed;
        scoreText.text = score.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
        score = 0;
    }

    public bool GetAutoplay() => autoplay;
}
