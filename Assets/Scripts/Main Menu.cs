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
public class Portals : MonoBehaviour
{
    // levels 
    Scene level1;
    Scene level2;
    Scene level3;

    public GameObject portal1;
    public GameObject portal2;
    public GameObject portal3;
    public GameObject currentportal;
    public bool level1beat = false;
    public bool level2beat = false;

   

    private void Awake()
    {
        portal2.SetActive(false);
        portal3.SetActive(false);
    }

    private void Update()
    {
        if(level1beat == true)
        {
            portal2.SetActive(true);
            
        }

        if (level2beat == true) 
        {
            portal3.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (currentportal == portal1)
        {
            //move to level 1
        }
        else if (currentportal == portal2)
        {
            
        }
        else if(currentportal == portal3)
        {

        }
    }
}