using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBricks; //Serialized for debug purpose

    SceneLoader sceneLoader;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBricks()
    {
        breakableBricks++;
    }

    public void BrickDestroyed()
    {
        breakableBricks--;
        if(breakableBricks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
