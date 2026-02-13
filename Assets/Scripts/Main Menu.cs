using System;
using Unity.VectorGraphics;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public EggController method;
    public GameObject dragon;

    private void Awake()
    {
        gameObject.SetActive(true);
        dragon.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (method != null)
            {
                method.Hatch();
                dragon.SetActive(true);
                gameObject.SetActive(false);
                Debug.Log("space was pressed");
            }
        }
    }
}