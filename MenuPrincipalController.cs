using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalController : MonoBehaviour
{
    public GameObject telaInicial;
    public GameObject telaDeSeleçãoDeFase;

    public string fase1;
    public string fase2;
    public string fase3;


    public void abrirTelaDeFases()
    {

        telaInicial.SetActive(false);
        telaDeSeleçãoDeFase.SetActive(true);

    }

    public void abrirTelaDeInicio()
    {
        telaDeSeleçãoDeFase.SetActive(false);
        telaInicial.SetActive(true);

    }

    public void iniciarfase1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(fase1);
    }
    public void iniciarfase2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(fase2);
    }
    public void iniciarfase3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(fase3);
    }

    public void fecharjogo()
    {
        Application.Quit();
        

    }

    


}
