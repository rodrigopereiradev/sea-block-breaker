using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratsSong : MonoBehaviour
{
   
    [SerializeField] AudioClip victorySong;

    // Start is called before the first frame update
    void Start()
    {
        PlayVictorySong();
    }

    private void PlayVictorySong()
    {
        AudioSource.PlayClipAtPoint(victorySong, Camera.main.transform.position);
    }
}
