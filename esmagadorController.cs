
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class esmagadorController : MonoBehaviour
{
    private Animator animations;
    private Rigidbody2D rig;
    public float tempo;
    public float vel;
    private bool voltando;
    public Vector3 posiçãoInicial;

    public float força = 0f;

    public float velocidadeRetorno = 2f;


    void Start()

    {
        posiçãoInicial = transform.position;
        rig = GetComponent<Rigidbody2D>();
        animations = GetComponent<Animator>();

    }


    void Update()
    {
        if (voltando)
        {
            Vector2 novaPosicao = Vector2.MoveTowards(
                rig.position,
                posiçãoInicial,
                velocidadeRetorno * Time.deltaTime
            );

            rig.MovePosition(novaPosicao);
            if (Vector2.Distance(rig.position, posiçãoInicial) < 0.01f)
            {
                rig.MovePosition(posiçãoInicial);
                voltando = false;
                animations.SetBool("subindo", false);
                animations.SetBool("idle", true);
            }
        }
    }

    public void cair()
    {
        if (!voltando)
        {
            Invoke("ativarRig", tempo);
        }
        

    }

    public void ativarRig()
    {
        rig.gravityScale = força;
        animations.SetBool("caindo", false);
        animations.SetBool("caindo", true);

    }
    
    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Chão"))
        {
            rig.linearVelocity = Vector2.zero;
            rig.gravityScale = 0;
            animations.SetBool("idle", false);
            animations.SetBool("caindo", false);
            animations.SetBool("subindo", true);
            voltando = true;
        }
    }
    
}
