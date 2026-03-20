using Emberborn.Interfaces;
using UnityEngine;

public class Torch : MonoBehaviour , IFreezable, IFlammable
{
    GameObject torchFire;
    void Start()
    {
        //automatically turns off the Fire Child GameObject
        torchFire = transform.GetChild(0).gameObject;
        torchFire.SetActive(false);
    }


    public void OnFreeze(object o)//fire extinguisher
    {
        Debug.Log("Torch frozen!");
        torchFire.SetActive(false);
    }

    public void OnFire(object o)//lights the torch
    {
        Debug.Log("Torch is lit!");
        torchFire.SetActive(true);  
    }
}
