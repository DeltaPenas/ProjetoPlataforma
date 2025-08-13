using UnityEngine;

public class saw : MonoBehaviour
{

    public float velocidade;
    public float tempoDeMovimento;

    private bool dirBaixo = true;
    private float timer;

    public Vector2 direcaoum = Vector2.up;
    public Vector2 direcaodois = Vector2.down;




    void Start()
    {
        
    }


    void Update()
    {
        if (dirBaixo)
        {
            transform.Translate(direcaoum.normalized * velocidade * Time.deltaTime);
        }
        else
        {
            transform.Translate(direcaodois.normalized * velocidade * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if (timer >= tempoDeMovimento)
        {
            dirBaixo = !dirBaixo;
            timer = 0f;
        }
        
    }
}
