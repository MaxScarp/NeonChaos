using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject brickSparklesVFX;

    //Cached reference
    Level level;
    GameStatus gameStatus;

    void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();

        level.CountBreakableBricks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Color brickColor = GetComponent<SpriteRenderer>().color;
        Color ballColor = collision.collider.GetComponent<SpriteRenderer>().color;

        if ( gameObject.name == "Special Brick")
        {
            gameStatus.AddToScoreSpecial();
            DestroyBrick();
        }
        else if( ballColor == brickColor)
        {
            gameStatus.AddToScore();
            DestroyBrick();
        }
    }

    private void DestroyBrick()
    {
        PlaySound();
        TriggerSparklesVFX();
        Destroy(gameObject);
        level.BrickDestroyed();
    }

    private void PlaySound()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(brickSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
