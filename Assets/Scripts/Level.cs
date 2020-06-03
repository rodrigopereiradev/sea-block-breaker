using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int breakbleBlocks; // Serialized for debugging purposes

    // cached reference
    SceneLoader sceneLoader;
    GameSession session;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        session = FindObjectOfType<GameSession>();
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
            session.AddLife();
            sceneLoader.LoadNextScene();
        }
    }

}
