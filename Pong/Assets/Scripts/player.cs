using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Vector2 originalPos;
    float moveSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    public void resetPos()
    {
        gameObject.transform.position = originalPos;
    }

    public void movePlayer()
    {
        float vertical;
        if (gameObject.tag == "Player1win")
        {

            vertical = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        }
        else
        {
            vertical = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        }
        var newPosY = Mathf.Clamp(transform.position.y+vertical, -3, 3);
        transform.position = new Vector2(transform.position.x, newPosY);
    }
}
