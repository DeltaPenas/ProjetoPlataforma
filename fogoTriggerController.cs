using UnityEngine;

public class fogoTriggerController : MonoBehaviour
{

    public GameObject fogoativo;
    public float tempo;
    public float tempodesligar = 3;

    public bool detecção = true;

    void Start()
    {

    }

    void Update()
    {
        ativarciclo();

    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Player") && detecção == true)
        {
            Invoke("ativarfogo", tempo);

            

        }
    }

    public void ativarciclo()
    {
        if (detecção == false && fogoativo.activeSelf == false)
        {
            Invoke("ativarfogo", 2f);
            
            
        }
        
    }
    


    public void ativarfogo()
    {
        fogoativo.SetActive(true);
        if (fogoativo.activeSelf == true)
        {
            Invoke("desativar", tempodesligar);

        }
    }
    public void desativar()
    {
        fogoativo.SetActive(false);
    }

   
}
