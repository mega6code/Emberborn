using UnityEngine;

public class AlterPortal : Portals
{

    [SerializeField] GameObject alter1;
    [SerializeField] GameObject alter2;
    [SerializeField] GameObject alter3;

    private bool activation1;
    private bool activation2;
    private bool activation3;

    public GameObject portal;

    private void Awake()
    {
        activation1 = alter1.GetComponent<PuzzleAlter>().alterActivated;
        activation2 = alter2.GetComponent<PuzzleAlter>().alterActivated;
        activation3 = alter3.GetComponent<PuzzleAlter>().alterActivated;   
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger portal please");
        CheckActivation();

        if (other.CompareTag("Animal"))
        {
            if (activation1 == true && activation2 == true && activation3 == true)
            {
                ActivatePortal();
            }
        }
    }
    private void ActivatePortal()
    {
        portal.SetActive(true);
        Debug.Log("Portal activate.");
    }
    private void CheckActivation()
    {
        activation1 = alter1.GetComponent<PuzzleAlter>().alterActivated;
        activation2 = alter2.GetComponent<PuzzleAlter>().alterActivated;
        activation3 = alter3.GetComponent<PuzzleAlter>().alterActivated;
    }
}
