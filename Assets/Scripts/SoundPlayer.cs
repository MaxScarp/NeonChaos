using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] AudioSource clip;

    /// <summary>
    /// Fa partire una traccia audio.
    /// </summary>
    public void PlayClip()
    {
        clip.Play();
    }
}
