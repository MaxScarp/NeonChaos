using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 0.05f;
    [SerializeField] float maxX = 14.0f;

    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePos(), minX, maxX);
        transform.position = paddlePos;
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
