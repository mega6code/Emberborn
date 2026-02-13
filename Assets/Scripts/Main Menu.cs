using System;
using Unity.VectorGraphics;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

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