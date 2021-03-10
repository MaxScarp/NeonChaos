using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFade : MonoBehaviour
{
    [SerializeField] float duration = 1f;
    [SerializeField] float speed = 2f;

    Color startColor;
    Color endColor = new Color(0.25f, 0.25f, 0.25f);
    Color lerpedColor;

    float t = 0f;
    bool flag = false;

    GameObject brick;

    private void Start()
    {
        brick = gameObject;
        startColor = brick.GetComponent<SpriteRenderer>().color;
    }

    private void Update()
    {
        if(brick) //Controllo che il mattoncino esista altrimenti può provocare errori quando loo distruggo con la palla.
        {
            FadeInOut();
        }
    }

    /// <summary>
    /// Fa lampeggiare il mattoncino.
    /// </summary>
    private void FadeInOut()
    {
        lerpedColor = Color.Lerp(startColor, endColor, t);

        if (flag)
        {
            t -= (Time.deltaTime / duration) * speed;
            brick.GetComponent<SpriteRenderer>().color = lerpedColor;
            if (t < 0.01f) flag = false;
        }
        else
        {
            t += (Time.deltaTime / duration) * speed;
            brick.GetComponent<SpriteRenderer>().color = lerpedColor;
            if (t > 0.99f) flag = true;
        }
    }
}
