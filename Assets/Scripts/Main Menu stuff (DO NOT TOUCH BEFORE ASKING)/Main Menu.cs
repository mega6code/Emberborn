using System;
using Unity.VectorGraphics;
using UnityEditor;
using UnityEditor.Rendering;
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
    }
}