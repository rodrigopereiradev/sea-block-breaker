using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    GameSession session;
    [SerializeField] AudioClip loserSong;
    [SerializeField] AudioClip errorClip;

    AudioSource audioSource;
    Ball ball;

    private void Start() {
        session = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball> ();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        session.SubtractLife();
        if (session.GetLifes().Equals(0))
        {
            SceneManager.LoadScene("Game Over");
            audioSource.PlayOneShot(loserSong);

        }
        else {
            ball.LockBallToPaddle();
            ball.SetHasStarted(false);
            ball.LauchOnMouseClick();
        }
    }

    private void PlayLoserSong()
    {
        AudioSource.PlayClipAtPoint(loserSong, Camera.main.transform.position);
    }

    private void PlayErrorSong()
    {
        AudioSource.PlayClipAtPoint(errorClip, Camera.main.transform.position);
    }
}
