﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text scoreText,levelText, levelScoreText;

    public int score, levelScore, totalLevelScore;

    public bool isLevelFinish;

    public GameObject gameoverScreen, gameStartScreen, gameNextLevelScreen;

    public PlayerController playerController;

    public LevelController levelController;

    public GameObject player;

    private void Awake()
    {
        instance = this;
        StopGame();
        gameoverScreen.SetActive(false);
        gameNextLevelScreen.SetActive(false);
    }

    void Start()
    {
        SaveGameGet();
    }

    // Update is called once per frame
    void Update()
    {
        SaveGameSet();
        levelScoreText.text = totalLevelScore.ToString();
        //scoreText.text = score.ToString();

        //Debug.Log(playerController.boats.Count);
        //if (playerController.boats.Count == 0 && isLevelFinish==false)
        //{

        //    LoseGame();
        //}

    }

    public void AddPoint(int point)
    {
        score += point;
        levelScore += point;
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        gameStartScreen.SetActive(false);
    }

    public void LoseGame()
    {
        
        
            
            gameoverScreen.SetActive(true);
            StopGame();
      
              

    }

    public void StopGame()
    {
        Time.timeScale = 0.0f;
    }

    public void RestartGame()
    {

        gameoverScreen.SetActive(false);
        levelController.isCreated = false;
        levelController.RestartGame();
        playerController.PlayerStartPosition();
        StopGame();
        gameStartScreen.SetActive(true);


    }

    public void NextLevel() //GameNextLevel'deki nextLevel butonu bu methodu çalıştırır.
    {

        StartCoroutine(NextLevelMethod());

    }

    IEnumerator NextLevelMethod()
    {
        //gameNextLevelButton.interactable = false;
        score = score + totalLevelScore;
        yield return new WaitForSecondsRealtime(2);
        levelController.levelCount++;
        gameNextLevelScreen.SetActive(false);
        levelController.isCreated = false;
        playerController.PlayerStartPosition();
        gameStartScreen.SetActive(true);
        StopGame();
        RandomLevel();
        //gameNextLevelButton.interactable = true;
        levelScore = 0;
    }

    public void FinishLevel() // FinisLevel bu methodu çağırır.
    {
        if (isLevelFinish)
        {
          
            gameNextLevelScreen.SetActive(true);
            StopGame();
        }

            

    }

    private void SaveGameGet()
    {
        PlayerPrefs.DeleteAll();

        score = PlayerPrefs.GetInt("score");
        levelController.levelCount = PlayerPrefs.GetInt("level");
        levelController.randomLevel = PlayerPrefs.GetInt("randomlevel");
    }

    private void SaveGameSet()
    {
        PlayerPrefs.SetInt("randomlevel", levelController.randomLevel);

        PlayerPrefs.SetInt("level", levelController.levelCount);
        levelText.text = "Level " + (levelController.levelCount + 1).ToString(); //Level yazısı

        PlayerPrefs.SetInt("score", score);
        scoreText.text = "$ " + score.ToString();
    }

    private void RandomLevel()
    {
        levelController.randomLevel = UnityEngine.Random.Range(0, levelController.prefabLevels.Count);
    }

    public void LevelTotalPoint(int xpoint)
    {

        totalLevelScore = levelScore * xpoint;
    }
}
