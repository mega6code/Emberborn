using UnityEngine;

public struct InteractData
{
    public GameObject sender;

    public InteractData(GameObject sender)
    {
        this.sender = sender;
    }
}