using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is to constantly update ball position w.r.t paddle before launching the ball
public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float launchVelocityX = 2f;
    [SerializeField] float launchVelocityY = 15f;
    [SerializeField] AudioClip[] ballSounds;

    // State
    Vector2 paddleToBallVector;
    bool hasStarted;

    // Cached component reference
    AudioSource myAudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        hasStarted = false;
        myAudioSource = GetComponent<AudioSource>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random .Range(0,ballSounds.Length)];
            // PlayOneShot to play it without being interrupted
            myAudioSource.PlayOneShot(clip);
        }
        
    }
}
