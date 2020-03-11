using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class score1 : MonoBehaviour
{
    Text scoreText;
    ball ballSession;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        ballSession = FindObjectOfType<ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Player1win")
        {
            scoreText.text = ballSession.GetScore1();
        }
        else
        {
            scoreText.text = ballSession.GetScore2();
        }
    }
}
