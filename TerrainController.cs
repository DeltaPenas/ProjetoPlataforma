using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainController : MonoBehaviour
{
    private TilemapCollider2D terrenoCollider;


    private void OnCollisionStay2D(Collision2D colisao)
    {
        atravessar(colisao);

    }

    void Start()
    {
        terrenoCollider = GetComponent<TilemapCollider2D>();
    }


    void Update()
    {

    }

    public void atravessar(Collision2D colisao)
    {
        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && colisao.gameObject.CompareTag("Player"))
        {
            terrenoCollider.enabled = false;
            Invoke(nameof(ativar), 0.2f);


        }


    }
     public void ativar() {
            terrenoCollider.enabled = true;
            
        }
}
