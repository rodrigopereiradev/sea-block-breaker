using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameSession : MonoBehaviour
{
    // configuration parames
    [Range(0.1f, 10f)] [SerializeField] private float gameSpeed = 1f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled = false;

    // state variables
    [SerializeField] int currentScore = 0;

    private void Awake() // method used to not reset score when the level change. Singleton Pattern.
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject );
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;  
    }

    public void addToScore(int blockPoints)
    {
        currentScore = currentScore + blockPoints;
        scoreText.text = currentScore.ToString();
    }

    public void RestartScore()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
