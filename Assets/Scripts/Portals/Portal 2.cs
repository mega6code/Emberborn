using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : Portals
{
    public GameObject player;
    private GameObject portalVFX;

    private void Awake()
    {
        //getting the VFX for portal from the child - Sam
        Transform child = transform.GetChild(0);
        portalVFX = child.gameObject;

        portalVFX.SetActive(false);

        if (GameManager.Instance.Levelclears[0] == true)
        {
            portalVFX.SetActive(true);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            BeatLevel(1);
            SceneManager.LoadScene("Final Level");
            Debug.Log("Portal 2");
        }
    }
}
