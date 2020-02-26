using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    // Cached Component Reference
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    // Script here is to destroy object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestoryBlock();
    }

    private void DestoryBlock()
    {
        // This function creates an audio source but automatically disposes of it once the clip has finished playing
        // Input parameters are AudioClip and Vector3 position which is source of audio
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
    }
}
