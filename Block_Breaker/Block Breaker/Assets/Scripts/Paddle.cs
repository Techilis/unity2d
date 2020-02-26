using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paddle : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] Ball ball1;
    bool toggleCheat = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get ratio of x position in screen
        // size 6 means 12 in height, 4:3 means 16 in width
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        // Vector2 to store 2D (x and y)
        Vector2 paddlePos = new Vector2(mousePosInUnits, transform.position.y);
        // To prevent paddle from going overscreen
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        // To ask paddle to go to that position
        transform.position = paddlePos;

        ToggleCheatOnClick();
        if (toggleCheat)
        {
            LockPaddleToBall();
        }
    }

    private void ToggleCheatOnClick()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (toggleCheat == false)
            {
                toggleCheat = true;
            }
            else
            {
                toggleCheat = false;
            }
        }
    }

    private void LockPaddleToBall()
    {
        Vector2 ballPos = new Vector2(ball1.transform.position.x, transform.position.y);
        transform.position = ballPos;
    }
}
