using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is to constantly update ball position w.r.t paddle before launching the ball
public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float launchVelocityX = 2f;
    [SerializeField] float launchVelocityY = 15f;

    // State
    Vector2 paddleToBallVector;
    bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        LaunchBallOnMouseClick();
        if (!hasStarted)
        {
            LockBallToPaddle();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(launchVelocityX, launchVelocityY);
            hasStarted = true;
        }
    }
}
