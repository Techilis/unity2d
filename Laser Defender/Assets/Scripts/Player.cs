using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.5f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Restricts movement to camera where (1,1) is top right of screen and (0,0) is btm left of screen
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Debug.Log(xMin + " : " + xMax);
    }

    private void Move()
    {

        // this is a float type
        // Time.deltaTime tells us how long each frame takes to execute
        // Example 10fps means 1 frame per 0.1s
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin+padding, xMax-padding);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin+padding, yMax-padding);
        Debug.Log(deltaX);
        transform.position = new Vector2(newXPos, newYPos);
    }
}
