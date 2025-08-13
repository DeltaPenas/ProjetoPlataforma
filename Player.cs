using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public float dubleJumpForce; // Achei o segundo pulo mt fraco
    public bool isJumping;
    public bool dubleJump;
    private Rigidbody2D rig;
    private Animator animations;

    private BoxCollider2D colliderplayer;


    void Start()
    {
        colliderplayer = GetComponent<BoxCollider2D>();
        rig = GetComponent<Rigidbody2D>();
        animations = GetComponent<Animator>();
    }

    void Update()
    {
        move();
        Jump();
        
        

    }

    private void OnCollisionStay2D(Collision2D colisao)
    {
        
    }

    void move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
        if (Input.GetAxis("Horizontal") > 0f)
        {
            animations.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0f)
        {
            animations.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            animations.SetBool("walk", false);
        }



    }


    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                animations.SetBool("jump", true);
                dubleJump = true;
            }
            else
            {
                if (dubleJump)
                {
                    rig.linearVelocity = new Vector2(rig.linearVelocity.x, 0f);
                    rig.AddForce(new Vector2(0f, dubleJumpForce), ForceMode2D.Impulse);
                    animations.SetBool("dublejumping", true);
                    dubleJump = false;

                }

            }



        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.layer == 6)
        {
            isJumping = false;
            animations.SetBool("jump", false);
            animations.SetBool("dublejumping", false);


        }
        if (colisao.gameObject.tag == "spike")
        {
            GameController.instance.Showgameover();
            Destroy(gameObject);
            
        }
    }

    void OnCollisionExit2D(Collision2D colisao)
    {
        if (colisao.gameObject.layer == 6)
        {
            isJumping = true;
        }
    }



}
