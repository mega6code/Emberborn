using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.InputSystem;

public class MenuOptions : MonoBehaviour
{
    public GameObject pauseMenu;

    private void Awake()
    {
        pauseMenu.SetActive(false);
        AudioListener.volume = 1;
    }
    public void PauseMenu()
    {
        //opening and closing the pause menu
        if (pauseMenu.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.SetActive(true);
            }
        }
        else if (pauseMenu.activeSelf == true)
        {
            pauseMenu.SetActive(false);
        }
    }

    public void ReturnToMain()
    {
        //Return to main menu
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Returning to Main menu");
    }

    public void QuitGame()
    {
        //Close game
        Application.Quit();
    }

    public void MuteOrUnmute()
    {
        // Toggle the master volume
        AudioListener.volume = 1 - AudioListener.volume; 
    }
}
