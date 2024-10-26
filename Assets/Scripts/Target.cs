using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Target : MonoBehaviour
{
    public GameManager game;
    float timeLoad;
    AudioSource pointSound;

    // Start is called before the first frame update
    void Start()
    {
        pointSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (game.GameGoing & transform.localScale.x < 2)
        {
            transform.localScale = Vector3.one * 0.33f * (Time.time - timeLoad + 0.5f);
        }
    }
    private void OnMouseDown()
    {
        if (!game.GameGoing && transform.position.Equals(new Vector3(0,0,-0.1f)))
        {
            game.startGame();
            changePos();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (game.GameGoing)
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
