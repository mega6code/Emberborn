using UnityEngine;

public class AlterPortal : MonoBehaviour
{

    [SerializeField] GameObject alter1;
    [SerializeField] GameObject alter2;
    [SerializeField] GameObject alter3;

    private bool activation1;
    private bool activation2;
    private bool activation3;

    private void Awake()
    {
        activation1 = alter1.GetComponent<PuzzleAlter>().alterActivated;
        activation2 = alter2.GetComponent<PuzzleAlter>().alterActivated;
        activation3 = alter3.GetComponent<PuzzleAlter>().alterActivated;   
    }
    private void OnTriggerEnter(Collider other)
    {
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
        Debug.Log("Player has been transported to second area.");
    }
    private void CheckActivation()
    {
        activation1 = alter1.GetComponent<PuzzleAlter>().alterActivated;
        activation2 = alter2.GetComponent<PuzzleAlter>().alterActivated;
        activation3 = alter3.GetComponent<PuzzleAlter>().alterActivated;
    }
}
