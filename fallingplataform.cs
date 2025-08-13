using UnityEngine;

public class fallingplataform : MonoBehaviour
{
    public float tempo;

    private TargetJoint2D target2d;
    private SpriteRenderer spriteRender;
    private BoxCollider2D boxcollider;

    public float velocidade;
    public float distanciaMovimento; 
    private Vector3 posicaoInicial;

    public bool issomexe = false;

    void Start()
    {
        target2d = GetComponent<TargetJoint2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        boxcollider = GetComponent<BoxCollider2D>();

        posicaoInicial = transform.position; 
    }

    void Update()
    {
        if (issomexe)
        {
            
            float deslocamento = Mathf.PingPong(Time.time * velocidade, distanciaMovimento) - (distanciaMovimento / 2f);
            transform.position = posicaoInicial + Vector3.up * deslocamento;
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Player"))
        {
            Invoke("caindoooooooooo", tempo);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }

    void caindoooooooooo()
    {
        target2d.enabled = false;
        boxcollider.isTrigger = true;
    }
}