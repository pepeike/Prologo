using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public GameObject pauseMenuUI; // Arraste aqui o painel do menu de pause no Inspector
    private bool isPaused = false;
    InputAction inputAction;

    

    void Start() {
        // Garantir que o menu esteja invisível no início
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void TogglePause(InputAction.CallbackContext context) {
        if (context.started) {
            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    void Update() {
        // Detecta o pressionar da tecla ESC para pausar/despausar

        

    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // volta o tempo normal
        isPaused = false;
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // pausa o tempo
        isPaused = true;
    }

    public void LoadMainMenu() {
        Time.timeScale = 1f; // despausa antes de carregar a cena
        SceneManager.LoadScene("MainMenu"); // substitua pelo nome correto da sua cena
    }

    public void QuitGame() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}