using UnityEngine;

public class Trampoline : MonoBehaviour
{

    public float trampolineJumpForce;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "Player")
        {
            animator.SetTrigger("jumping");
            colisao.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, trampolineJumpForce), ForceMode2D.Impulse);
        }
  
    }

}
