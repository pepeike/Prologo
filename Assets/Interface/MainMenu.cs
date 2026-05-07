using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Tooltip("Nome da cena do jogo para carregar ao clicar em Play")]
    public string gameSceneName = "GameScene";

    [Tooltip("AudioSource para a música de fundo do menu")]
    public AudioSource backgroundMusic;  // Referência ao AudioSource do menu

    void Start()
    {
        // Verifica se o AudioSource foi atribuído e começa a música em loop
        if (backgroundMusic != null)
        {
            backgroundMusic.loop = true;  // Configura para tocar em loop
            backgroundMusic.Play();       // Inicia a música
        }
        else
        {
            Debug.LogWarning("AudioSource não atribuído para a música de fundo!");
        }
    }

    public void PlayGame()
    {
        if (!string.IsNullOrEmpty(gameSceneName))
        {
            SceneManager.LoadScene(gameSceneName);
        }
        else
        {
            Debug.LogWarning("O nome da cena do jogo não foi definido!");
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}