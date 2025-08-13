using System;
using UnityEngine;
using UnityEngine.Rendering;

public class aplecoletavel : MonoBehaviour
{


    private SpriteRenderer spritemaça;
    private CircleCollider2D colissionmaça;
    public GameObject coletado;

    public float duraçaoAnimação;
    public int score;


    void Start()
    {
        spritemaça = GetComponent<SpriteRenderer>();
        colissionmaça = GetComponent<CircleCollider2D>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spritemaça.enabled = false;
            colissionmaça.enabled = false;
            coletado.SetActive(true);

            GameController.instance.playerScore += score;
            GameController.instance.updateScoreText();

            Destroy(gameObject, duraçaoAnimação);
            
        }
    }
}
