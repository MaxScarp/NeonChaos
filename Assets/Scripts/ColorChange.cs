using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField] Color startingColor;
    [SerializeField] Color endingColor;
    [SerializeField] float duration;
    [SerializeField] SpriteRenderer brick;

    Color lerpedColor = Color.white;
    bool flag = false;
    float t = 0f;

    void Update()
    {
        lerpedColor = Color.Lerp(startingColor, endingColor, t);
        
        if(flag == true)
        {
            t -= Time.deltaTime / duration;
            brick.color = lerpedColor;
            if (t <= 0.01f) flag = false;
        }
        else
        {
            t += Time.deltaTime / duration;
            brick.color = lerpedColor;
            if (t > 0.99f) flag = true;
        }
    }
}
