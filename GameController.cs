using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    public int playerScore;
    public static GameController instance;
    public TextMeshProUGUI scoreText;
    public GameObject gameOver;

    public GameObject telaProximaFase;

    public GameObject telaDePausa;

    public string stringlvlName;

    public string nextlvlname;

    public int playerSconeFinal;
    public string telaMenu = "Menu";

    private bool faseConcluida = false;

    void Start()
    {
        instance = this; // da à variável estática o caminho de outros scripts pra cá
        Time.timeScale = 1f;
        faseConcluida = false; // reseta o controle

    }

    void Update()
    {
        if (!faseConcluida)
        {
            colectall();
        }
        pausar();

    }

    public void updateScoreText()
    {
        scoreText.text = playerScore.ToString();
    }

    public void Showgameover()
    {
        gameOver.SetActive(true);
    }

    public void restartGame()
    {
        Time.timeScale = 1f; //volta o tempo ao normal antes de reiniciar
        SceneManager.LoadScene(stringlvlName);
    }

    public void colectall()
    {
        if (!faseConcluida && playerSconeFinal == playerScore)
        {
            faseConcluida = true;
            Time.timeScale = 0f;
            telaProximaFase.SetActive(true);
        }
    }

    public void trocarfase()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextlvlname);
    }

    public void pausar()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            telaDePausa.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void despausar()
    {

        telaDePausa.SetActive(false);
        Time.timeScale = 1f;



    }

    public void voltarMenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(telaMenu);

        
    }

    


}
