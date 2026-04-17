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
    public GameObject tutorial;
    public GameObject tutorialIce;
    public GameObject tutorialFire;

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

    public void OnCrystalCollected(ElementalTypes uh)
    {
        if (uh == ElementalTypes.Ice)
        {
            tutorial = tutorialIce;
        }
        else if (uh == ElementalTypes.Fire) 
        {
            tutorial = tutorialFire;
        }

        Tutorial(tutorial);
    }
    private void Tutorial(GameObject tutorial)
    {
        tutorial.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseTutorial(GameObject tutorial)
    {
        tutorial.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void OnEnable()
    {
        Portals.levelBeaten += OnLevelBeat;
        ElementalCrystal.collected += OnCrystalCollected;
    }

    public void OnDisable()
    {
        Portals.levelBeaten -= OnLevelBeat;
        ElementalCrystal.collected -= OnCrystalCollected;
    }
}
