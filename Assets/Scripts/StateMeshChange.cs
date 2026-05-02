using UnityEngine;
using Emberborn.Elements;
using System;
public class StateMeshChange : MonoBehaviour
{
    //Component of player Mesh
    private SkinnedMeshRenderer embyMesh;
    public ElementalStateManager stateManager;

    [Header("Textures for Emby state")]
    //Textures for each state 
    public Texture embyGreen;
    public Texture embyBlue;
    public Texture embyRed;

    private void Awake()
    {
        embyMesh = GetComponentInChildren<SkinnedMeshRenderer>();//gets Mesh component
        SetNormalState();
    }

    private void OnchangedState(ElementalTypes types)
    {

        MeshChange(types);
    }

    private void OnEnable()
    {
        ElementalStateManager.changedState += OnchangedState;

    }
    private void OnDisable()
    {
        ElementalStateManager.changedState -= OnchangedState;
    }


    public void MeshChange(ElementalTypes state)
    {
        switch (state)
        {
            case (ElementalTypes.Ice):
                SetIceState();
                break;
            case (ElementalTypes.Fire):
                SetFireState();
                break;
        }
    }
    private void SetNormalState()
    {
        embyMesh.material.SetTexture("_Albedo", embyGreen);
        Debug.Log("Normal state Mesh active");
    }
    public void SetIceState()
    {
        embyMesh.material.SetTexture("_Albedo", embyBlue);
        Debug.Log("Ice state Mesh active");
    }
    public void SetFireState()
    {
        embyMesh.material.SetTexture("_Albedo", embyRed);
        Debug.Log("Fire state Mesh active");
    }
}
