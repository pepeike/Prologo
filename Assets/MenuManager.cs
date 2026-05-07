using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{

    public GameObject pauseObj;

    public void CallPause(InputAction.CallbackContext context) {
        if (context.started) {
            pauseObj.SetActive(true);
            pauseObj.GetComponentInChildren<PauseMenu>().TogglePause(context);
        }
    }

}
