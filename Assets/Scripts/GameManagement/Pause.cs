using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    private InputSystem_Actions ourInputActions;//makes an object of our input action asset (named "InputSystem_Actions"), so that we can access OUR actions

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        pauseMenu.SetActive(false);
        ourInputActions = new InputSystem_Actions();
        Debug.Log(ourInputActions.Player.enabled + "player");
        ourInputActions.Player.Enable();
        Debug.Log(ourInputActions.Player.enabled + "player");
    }

    private void OnEnable()
    {
        ourInputActions.Player.Pause.performed += PauseMenu;
    }

    private void OnDisable()
    {
        ourInputActions.Player.Pause.performed -= PauseMenu;
    }

    public void PauseMenu(InputAction.CallbackContext ctx)
    {
        Debug.Log("escape pressed");

        if (pauseMenu.activeSelf == false)
        {
            ourInputActions.Player.Disable();//disabling player controls
            ourInputActions.UI.Enable(); //enabling UI controls

            Debug.Log("Game should pause");
            pauseMenu.SetActive(true);
        }
    }

    public void Unpause() 
    {
        if (pauseMenu.activeSelf == true)
        {
            ourInputActions.Player.Enable(); //disabling UI controls
            ourInputActions.UI.Disable(); //enabling player controls

            pauseMenu.SetActive(false);
        }
    }
}
