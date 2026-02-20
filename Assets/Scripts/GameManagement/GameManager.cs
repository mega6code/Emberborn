using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public bool isLevel1Beat = false;
    public bool isLevel2Beat = false;

    public GameObject pauseMenu;//Always make sure to place the inactive panel in Level UI here

    public static GameManager Instance { get => instance; }

    public void OnAwake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        pauseMenu.SetActive(false);
    }
}
