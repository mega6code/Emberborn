using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.InputSystem;

public class MenuOptions : MonoBehaviour
{
    public Pause pausePanel;
    private void Awake()
    {
        AudioListener.volume = 1;
    }

    public void Unpause()
    {
        pausePanel.Unpause();
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
        Debug.Log("Game should close");
        Application.Quit();
    }

    public void MuteOrUnmute()
    {
        // Toggle the master volume
        AudioListener.volume = 1 - AudioListener.volume; 
    }
}
