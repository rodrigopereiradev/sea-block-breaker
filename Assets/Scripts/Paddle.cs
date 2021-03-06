﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    // Configuration Parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f; 
    [SerializeField] float maxX = 15f;

    // Cached References
    GameSession session;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        session = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x =  Mathf.Clamp(GetXPosition(), minX, maxX);
        transform.position = paddlePosition;
    }

    private float GetXPosition()
    {
        if (session.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            var mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
            return mousePositionInUnits;
        }
    }
}
