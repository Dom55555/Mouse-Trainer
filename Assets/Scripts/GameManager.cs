using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    public TMP_Text startText;
    public TMP_Text points;
    public TMP_Text time;
    public TMP_Text highscoreText;
    public GameObject endScreen;
    public GameObject crosshair;
    AudioSource endgameSound;
    public bool GameGoing;
    float gameStartTime;
    float lastSec;
    int HighScore;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        endgameSound = GetComponent<AudioSource>();
        HighScore = PlayerPrefs.GetInt("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameGoing)
        {
            if (Time.time - gameStartTime > 30 && GameGoing)
            {
                GameGoing = false;
                endGame();
            }
            if (Time.time - lastSec >= 1 && GameGoing)
            {
                lastSec = Time.time;
                changeTimer();
            }
        }
    }
    public void startGame()
    {
        GameGoing = true;
        startText.gameObject.SetActive(false);
        time.text = "30";
        lastSec = Time.time;
        gameStartTime = Time.time;
        crosshair.SetActive(true);
        Cursor.visible = false;
    }
    private void endGame()
    {
        time.text = "0";
        endgameSound.Play();
        endScreen.SetActive(true);
        if (int.Parse(points.text) > HighScore)
        {
            HighScore = int.Parse(points.text);
            PlayerPrefs.SetInt("highscore", HighScore);
        }
        highscoreText.text = HighScore.ToString();
        crosshair.SetActive(false);
        Cursor.visible = true;
    }
    public void addPoint()
    {
        points.text = (int.Parse(points.text) + 1).ToString();
    }
    private void changeTimer()
    {
        time.text = (int.Parse(time.text) - 1).ToString();
    }
    
}
