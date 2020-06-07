using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    GameSession session;

    [SerializeField] AudioClip errorClip;

    Ball ball;

    private void Start() {
        session = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball> ();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        session.SubtractLife();
        if (session.GetLifes().Equals(0))
        {
            SceneManager.LoadScene("Game Over");

        }
        else {
            ball.RestartBallOnError();
            PlayErrorSong();
        }
    }

    private void PlayErrorSong()
    {
        AudioSource.PlayClipAtPoint(errorClip, Camera.main.transform.position);
    }


}
