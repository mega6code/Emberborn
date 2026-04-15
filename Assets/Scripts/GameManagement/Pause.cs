using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;

    //eventssss!!!!!!!!!
    public static event Action gamePaused;
    public static event Action gameUnPaused;

    private void Awake()
    {
        pauseMenu.SetActive(false);

    }

    private void OnEnable()
    {
        //attaching the PauseMenu function to the'performed' event of the 'Pause' Action
        InputSystem.actions.FindAction("Player/Pause").performed += PauseMenu;
    }

    private void OnDisable()
    {
        //de-attaching the PauseMenu function from the 'performed' event of the 'Pause' Action
        InputSystem.actions.FindAction("Player/Pause").performed -= PauseMenu;
    }

    public void PauseMenu(InputAction.CallbackContext ctx)
    {
        Debug.Log("escape pressed");

        //Changing the visibility of the cursor and unlocking its position to the screen
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (pauseMenu.activeSelf == false)
        {
            Debug.Log("Game should pause");
            pauseMenu.SetActive(true);
            gamePaused?.Invoke();
            Time.timeScale = 0f;
        }
    }

    public void Unpause() 
    {
        if (pauseMenu.activeSelf == true)
        {
            //Changing the visibility of the cursor and locking its position to the screen
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            Debug.Log("Game should unpause");
            pauseMenu.SetActive(false);
            gameUnPaused?.Invoke();
            Time.timeScale = 1.0f;
        }
    }



}
