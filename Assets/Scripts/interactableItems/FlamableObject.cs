using Emberborn.Elements;
using Emberborn.Interfaces;
using UnityEngine;

public class FlamableObject : MonoBehaviour , IFreezable, IFlammable
{
    GameObject FireVisuals;
    void Start()
    {
        //automatically turns off the Fire Child GameObject
        FireVisuals = transform.GetChild(0).gameObject;
        FireVisuals.SetActive(false);
    }


    public void OnFreeze(PureElementMessageObjects message_objects)//fire extinguisher
    {
        FireVisuals.SetActive(false);
        changeActiveState(false);
    }

    public void OnFire(PureElementMessageObjects message_objects)//lights the torch
    {
        FireVisuals.SetActive(true); 
        changeActiveState(true);
    }
    private void changeActiveState(bool ActiveState)//if gameobject has an activation script, change the state(bool) activation
    {
        if (gameObject.GetComponent<ActiveCheck>())
        {
            ActiveCheck activationObject = GetComponent<ActiveCheck>();
            activationObject.ChangeState(ActiveState);
        }
    }
}
