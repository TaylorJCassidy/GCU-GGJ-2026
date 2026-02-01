using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController current;
    public GameObject menuCanvas;

    bool open;

    void Start() {
        current = this;
    }

    public void StartGame() {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void ExitGame() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void ToggleMenu() {
        if (open) {
            CameraController.current.cameraLocked = false;
            Cursor.lockState = CursorLockMode.Locked;
            menuCanvas.SetActive(false);
        }
        else {
            CameraController.current.cameraLocked = true;
            Cursor.lockState = CursorLockMode.None;
            menuCanvas.SetActive(true);
        }
        open = !open;
    }
}
