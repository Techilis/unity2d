using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config Params
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] AudioClip breakSound;
    [SerializeField] Sprite[] hitSprite;

    // Cached Component Reference
    Level level;
    GameStatus gameStatus;

    // State Variables
    [SerializeField] int timesHit = 0; //TODO only serialized for debugging


    private void Start()
    {
        CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }



    // Script here is to destroy object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprite.Length + 1;
            if (timesHit >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }
    private void ShowNextHitSprite()
    {
        if (hitSprite[timesHit-1] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprite[timesHit - 1];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array - "+ gameObject.name);
        }
    }
    private void DestroyBlock()
    {
        // This function creates an audio source but automatically disposes of it once the clip has finished playing
        // Input parameters are AudioClip and Vector3 position which is source of audio
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        gameStatus.AddToScore();
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
