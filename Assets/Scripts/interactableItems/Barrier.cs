using UnityEngine;

public class Barrier : MonoBehaviour
{
    GameObject barrier;

    [SerializeField] GameObject alter1;
    [SerializeField] GameObject alter2;
    [SerializeField] GameObject alter3;

    private ActiveCheck checkAlt1;
    private ActiveCheck checkAlt2;
    private ActiveCheck checkAlt3;

    void Start()
    {
        barrier = gameObject;
        barrier.SetActive(true);

        checkAlt1 = alter1.GetComponent<ActiveCheck>();
        checkAlt2 = alter2.GetComponent<ActiveCheck>();
        checkAlt3 = alter3.GetComponent<ActiveCheck>();
    }

    private void Update()
    {
        CheckBarrierDeActivation();
    }

    private void CheckBarrierDeActivation()
    {
        if(checkAlt1.ObjectState == true && checkAlt2.ObjectState == true && checkAlt3.ObjectState == true)
        {
            Debug.Log("Barrier deactivated");
            barrier.SetActive(false);
        }
    }
}
