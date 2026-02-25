using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    private InputAction pause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        pauseMenu.SetActive(false);
        pause = InputSystem.actions.FindAction("Pause");
    }

    public void PauseMenu()
    {
        //opening and closing the pause menu
        if (pause.IsPressed())
        {
            Debug.Log("escape pressed");

            if (pauseMenu.activeSelf == false)
            {
                Debug.Log("Game should pause");
                pauseMenu.SetActive(true);
            }
        }
    }

    public void Unpause() 
    {
        if (pauseMenu.activeSelf == true)
        {
            pauseMenu.SetActive(false);
        }
    }
}
