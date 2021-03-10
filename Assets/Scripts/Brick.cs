using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Color brickColor = GetComponent<SpriteRenderer>().color;
        Color ballColor = collision.collider.GetComponent<SpriteRenderer>().color;

        if ( gameObject.name == "Special Brick")
        {
            Destroy(gameObject);
        }
        else if( ballColor == brickColor)
        {
            Destroy(gameObject);
        }
    }
}
