using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float launchX = 1.0f;
    [SerializeField] float launchY = 15.0f;

    Vector2 paddleToBallVector;
    bool hasStarted = false; //Segnala quando la palla è stata lanciata

    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    void Update()
    {
        if(!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == paddle.name)
        GetComponent<SpriteRenderer>().color = paddle.GetComponent<SpriteRenderer>().color;
        Debug.Log(collision.name);
    }

    /// <summary>
    /// Lancia la palla quando viene premuto il tasto sinistro del mouse.
    /// </summary>
    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(launchX, launchY);
            hasStarted = true;
        }
    }

    /// <summary>
    /// Tiene agganciata la palla sopra al centro del paddle.
    /// </summary>
    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
}
