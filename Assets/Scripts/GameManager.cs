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
    public GameObject endScreen;
    public TMP_Text highscoreText;
    public float gameStartTime;
    AudioSource endgameSound;
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

    }
    public void startGame()
    {
        startText.gameObject.SetActive(false);
        time.text = "30";
        gameStartTime = Time.time;
    }
    public void endGame()
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
    }
    public void addPoint()
    {
        points.text = (int.Parse(points.text) + 1).ToString();
    }
    public void changeTimer()
    {
        time.text = (int.Parse(time.text) - 1).ToString();
    }
    
}
