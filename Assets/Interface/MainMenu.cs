using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Tooltip("Nome da cena do jogo para carregar ao clicar em Play")]
    public string gameSceneName = "GameScene";

    [Tooltip("AudioSource para a m�sica de fundo do menu")]
    public AudioSource backgroundMusic;  // Refer�ncia ao AudioSource do menu

    void Start()
    {
        // Verifica se o AudioSource foi atribu�do e come�a a m�sica em loop
        if (backgroundMusic != null)
        {
            backgroundMusic.loop = true;  // Configura para tocar em loop
            backgroundMusic.Play();       // Inicia a m�sica
        }
        else
        {
            Debug.LogWarning("AudioSource n�o atribu�do para a m�sica de fundo!");
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
            Debug.LogWarning("O nome da cena do jogo n�o foi definido!");
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