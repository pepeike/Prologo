using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{

    private void Start() {
        StartCoroutine(WaitForEnd());
    }

    IEnumerator WaitForEnd() {
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene("MainMenu");
    }

}
