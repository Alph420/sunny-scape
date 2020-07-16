using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class DeathZone : MonoBehaviour
{
    private Animator fadeSystem;
    private Transform playerSpawn;
    public SpriteRenderer sprite;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("Respawn").transform;
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayerInScene(collision));
        }
    }
    //Coroutine for the transition
    public IEnumerator ReplacePlayerInScene(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position = playerSpawn.position;
        if(sprite.flipX) sprite.flipX = false;
        yield return new WaitForSeconds(2f);


    }
}


