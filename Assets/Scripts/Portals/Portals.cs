using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portals : MonoBehaviour
{
    public static event Action<int> levelBeaten;

    public void BeatLevel(int i)
    {
        levelBeaten.Invoke(i);
    }
    
}
