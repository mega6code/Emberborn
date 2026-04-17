using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : Portals
{
    public GameObject player;
    public GameObject portalVFX;
    public LoadingScreen loadingScreen;


    private void Awake()
    {
        if (portalVFX == null)
        {
            //getting the VFX for portal from the child - Sam
            Transform child = transform.GetChild(0);
            portalVFX = child.gameObject;
        }

        portalVFX.SetActive(true);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            BeatLevel(1);
            loadingScreen.LoadScene(3);//loads to the caves
            Debug.Log("Portal 2");
        }
    }
}
