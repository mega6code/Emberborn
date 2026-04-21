using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Emberborn.Elements;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private List<bool> levelclears;

    public static GameManager Instance { get => instance; }
    public List<bool> Levelclears { get => levelclears; }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        levelclears = new List<bool>() {false, false, false, false, false};
    }
    private void Update()
    {
        Debug.Log($"Level 1 is {levelclears[0]}");
    }
    public void OnLevelBeat(int level) 
    {
        Debug.Log($"level is {level}");
        levelclears[level - 1] = true;
    }
    public void OnEnable()
    {
        Portals.levelBeaten += OnLevelBeat;
    }

    public void OnDisable()
    {
        Portals.levelBeaten -= OnLevelBeat;
    }
}
