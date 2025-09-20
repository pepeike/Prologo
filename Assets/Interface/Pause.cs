using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Arraste aqui o painel do menu de pause no Inspector
    private bool isPaused = false;

    void Start()
    {
        // Garantir que o menu esteja invisível no início
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Detecta o pressionar da tecla ESC para pausar/despausar
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // volta o tempo normal
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // pausa o tempo
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // despausa antes de carregar a cena
        SceneManager.LoadScene("MainMenu"); // substitua pelo nome correto da sua cena
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}