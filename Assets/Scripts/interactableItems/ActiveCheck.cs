using UnityEngine;

public class ActiveCheck : MonoBehaviour
{
    //objects activation state
    private bool objectState;

    public bool ObjectState { get => objectState; }

    private void Awake()
    {
        objectState = false;
    }
    public void ChangeState(bool boolean)
    {
        objectState = boolean;
        Debug.Log("Object activated!");
    }
}
