using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    //Cached reference
    Level level;

    void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBricks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Color brickColor = GetComponent<SpriteRenderer>().color;
        Color ballColor = collision.collider.GetComponent<SpriteRenderer>().color;

        if ( gameObject.name == "Special Brick")
        {
            DestroyBrick();
        }
        else if( ballColor == brickColor)
        {
            DestroyBrick();
        }
    }

    private void DestroyBrick()
    {
        PlaySound();
        Destroy(gameObject);
        level.BrickDestroyed();
    }

    private void PlaySound()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }
}
