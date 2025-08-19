
using Unity.VisualScripting;
using UnityEngine;


public class esmagadorArea : MonoBehaviour
{
    public esmagadorController esmagadorC;
    void Start()
    {

    }

    void Update()
    {

    }

   
    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.CompareTag("Player"))
        {
            Debug.Log("Player entrou na area");
            esmagadorC.cair();
        }
    }

}
