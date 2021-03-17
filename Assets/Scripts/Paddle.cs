using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 0.05f;
    [SerializeField] float maxX = 14.0f;
    [SerializeField] Color[] colors;

    //state
    int index = 0;

    //Cached component references
    GameStatus gameStatus;
    Ball ball;

    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        GetPaddlePos();

        if (Input.GetKeyDown(KeyCode.Space) && colors != null)
        {
            ColorChange();
        }
    }

    /// <summary>
    /// Recupera la posizione del paddle in base a dove si trova il mouse.
    /// </summary>
    private void GetPaddlePos()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePos(), minX, maxX);
        transform.position = paddlePos;
    }

    /// <summary>
    /// Cambia il colore del paddle quando premo barra spaziatrice.
    /// </summary>
    private void ColorChange()
    {
        GetComponent<SpriteRenderer>().color = colors[index];

        if (Input.GetKeyDown(KeyCode.Space) && (index >= colors.Length - 1)) index = 0;
        else index++;
    }

    /// <summary>
    /// Calcola la posizione attuale del mouse sull'asse delle X in unità.
    /// </summary>
    /// <returns>Posizone del mouse sull'asse delle X.</returns>
    private float mousePos()
    {
        float aspectRatio = Screen.width / Screen.height;
        float cameraWidth = Camera.main.orthographicSize * 2 * aspectRatio;
        float mousePositionX = Input.mousePosition.x / Screen.width * cameraWidth;

        return mousePositionX;
    }
}
