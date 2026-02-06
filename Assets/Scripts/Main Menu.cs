using UnityEditor.Rendering;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public EggController method;

    private void Awake()
    {
        gameObject.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (method != null)
            {
                method.Hatch();
                gameObject.SetActive(false);
                Debug.Log("space was pressed");
            }
        }
    }
}
public class Portals : MonoBehaviour
{
    public GameObject portal2;
    public GameObject portal3;

    private void Awake()
    {
        portal2.SetActive(false);
        portal3.SetActive(false);
    }

    private void Update()
    {
        if ()
    }
}