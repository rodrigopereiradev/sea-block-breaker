using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int breakbleBlocks; // Serialized for debugging purposes

    // cached reference
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breakbleBlocks++;
    }

    public void BlockDestroy()
    {
        breakbleBlocks--;
        if (breakbleBlocks <= 0) 
        {
            sceneLoader.LoadNextScene();
        }
    }

}
