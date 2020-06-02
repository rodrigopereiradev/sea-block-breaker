using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] int blockPoints = 10;

    GameSession status;

    // cached references
    Level level;

    // state variables
    [SerializeField] int timesHit; // TODO only serialized for debum purposes

    private void Start()
    {
        level = FindObjectOfType<Level>();
        status = FindObjectOfType<GameSession>();
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError("Block sprite is missing from array " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        PlayBlockImpact();
        Destroy(gameObject);
        TriggerSparklesVFX();
        status.addToScore(blockPoints);
        level.BlockDestroy();
    }

    private void PlayBlockImpact()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
