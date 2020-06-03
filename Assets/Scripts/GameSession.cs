using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class GameSession : MonoBehaviour
{
    // configuration parames
    [Range(0.1f, 10f)] [SerializeField] private float gameSpeed = 1f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI lifesText;
    [SerializeField] bool isAutoPlayEnabled = false;
    [SerializeField] int lifes = 3;

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
        lifesText.text = lifes.ToString();
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

    public void SubtractLife() 
    {
        lifes--;
        lifesText.text = lifes.ToString();
    }

    public void AddLife() 
    {
        lifes++;
        lifesText.text = lifes.ToString();
    }

    public int GetLifes() 
    {
        return lifes;
    }
}
