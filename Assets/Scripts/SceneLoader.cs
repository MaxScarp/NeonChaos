using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Chached references
    GameStatus gameStatus;

    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
    }

    /// <summary>
    /// Carica la scena di partenza del gioco.
    /// </summary>
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        gameStatus.ResetGame();
    }

    /// <summary>
    /// Carica la scena successiva a qualsiasi sia quella attuale.
    /// </summary>
    public void LoadNextScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 1);
    }

    /// <summary>
    /// Esce dal gioco.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
