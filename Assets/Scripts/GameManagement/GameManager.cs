using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public bool isLevel1Beat = false;
    public bool isLevel2Beat = false;

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
    }
}
