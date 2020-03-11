using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
    Rigidbody2D ballBody;
    [SerializeField] float speed = 10f;
    Vector2 originalPos;
    int player1score = 0;
    int player2score = 0;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        launch();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void launch()
    {
        gameObject.transform.position = originalPos;
        ballBody = gameObject.GetComponent<Rigidbody2D>();
        ballBody.velocity = new Vector2(speed, -speed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Player1win")
        {
            launch();
            player1score++;
            Debug.Log(player1score);
        }
        else
        {
            launch();
            player2score++;
            Debug.Log(player2score);
        }
    }

    public string GetScore1()
    {
        return player1score.ToString();
    }

    public string GetScore2()
    {
        return player2score.ToString();
    }
}
