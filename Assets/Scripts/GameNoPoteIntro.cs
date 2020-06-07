using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNoPoteIntro : MonoBehaviour
{

    SceneLoader sceneLoader;

    [SerializeField] AudioClip introClip;
    [SerializeField] float sceneDelay = 4;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(introClip, Camera.main.transform.position);
        sceneLoader = FindObjectOfType<SceneLoader>();
        Invoke("LoadNextLevelAfterDelay", sceneDelay);
    }

    private void LoadNextLevelAfterDelay()
    {
        sceneLoader.LoadNextScene();
    }
}
