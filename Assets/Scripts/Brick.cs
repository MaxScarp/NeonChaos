using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject brickSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    //Cached reference
    Level level;
    GameStatus gameStatus;

    [SerializeField] int timesHit;

    void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();

        if(tag == "Breakable")
        {
            level.CountBricks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Color brickColor = GetComponent<SpriteRenderer>().color;
        Color ballColor = collision.collider.GetComponent<SpriteRenderer>().color;

        if ( gameObject.name == "Special Brick")
        {
            if (tag == "Breakable")
            {
                HandleHit();
            }
        }
        else if( ballColor == brickColor)
        {
            if (tag == "Breakable")
            {
                HandleHit();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        int SpriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[SpriteIndex];
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            gameStatus.AddToScoreSpecial();
            DestroyBrick();
        }
        else
        {
            ShowNextHitSprite();
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
