using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSong : MonoBehaviour
{

    [SerializeField] AudioClip loserSong;

    // Start is called before the first frame update
    void Start()
    {
        PlayLoserSong();
    }

    private void PlayLoserSong()
    {
        AudioSource.PlayClipAtPoint(loserSong, Camera.main.transform.position);
    }
}
