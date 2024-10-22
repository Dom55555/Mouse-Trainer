using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Target : MonoBehaviour
{
    public GameManager game;
    float lastSec = 1;
    AudioSource pointSound;
    bool started = false;
    public float timeLoad;

    // Start is called before the first frame update
    void Start()
    {
        pointSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if(transform.localScale.x < 2)
            {
                transform.localScale = Vector3.one * 0.33f * (Time.time - timeLoad + 0.5f);
            }
            if (Time.time - game.gameStartTime > 30)
            {
                game.endGame();
                started = false;
            }
        }
        if (Time.time - lastSec >= 1 && started)
        {
            lastSec = Time.time;
            game.changeTimer();
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)&& !started && transform.position.x == 0 && transform.position.y == 0)
        {
            started = true;
            game.startGame();
            changePos();
        }    
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (started)
        {
            changePos();
            game.addPoint();
        }
    }
    void changePos()
    {
        pointSound.Play();
        transform.localScale = Vector3.one * 0.33f;
        transform.position = new Vector2(Random.Range(-7.0f, 7.0f), Random.Range(-4.0f, 2.5f));
        timeLoad = Time.time;
    }
}
