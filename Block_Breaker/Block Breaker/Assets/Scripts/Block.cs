using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Script here is to destroy object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
