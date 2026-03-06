using System;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public EggController method;
    public Startbgm startbgm;
    public GameObject player;

    private void Awake()
    {
        gameObject.SetActive(true);
        player.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (method != null)
            {
                startbgm.PlayBGM();
                method.Hatch();
                player.SetActive(true);
                gameObject.SetActive(false);
                Debug.Log("space was pressed");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Game should be shut");
        }
    }
}