using System;
using Unity.VisualScripting;
using UnityEngine;

public class ProgressiveScaler : MonoBehaviour
{
    #region Fields
    [SerializeField] private Vector3 min_scale;
    [SerializeField] private Vector3 max_scale;
    [SerializeField] private float scale_rate;

    [SerializeField] private Vector3 target_scale;
    //private Vector3 current_scale;
    //private Vector3 default_scale;
    #endregion

    #region Properties
    #endregion

    #region Methods
    private void Awake()
    {
        //default_scale = transform.localScale;
    }
    private void Start()
    {
        target_scale = transform.localScale;
    }
    void Update()
    {
        //current_scale = transform.localScale;
        Vector3 scale_to_set = new Vector3();

        //Debug.Log($"Beforebefore local = {transform.localScale}");
        //Debug.Log($"Beforebefore target = {target_scale}");

        
            for (int i = 0; i < 3; i++)
            {
                if (Math.Round(transform.localScale[i], 2) != Math.Round(target_scale[i], 2))
                {
                    //Debug.Log($"Before = {transform.localScale[i]}");

                    scale_to_set[i] = GetAmountToAdd(i);

                    //Debug.Log($"After = {transform.localScale[i]}");
                }
            }
            transform.localScale += scale_to_set;

    }

    /// <summary>
    /// Gets the amount to add to the Vector element
    /// </summary>
    /// <returns></returns>
    private float GetAmountToAdd(int index)
    {
        int sign = Math.Sign(target_scale[index] - transform.localScale[index]); //decides whether its a up-scale or down-scale
        Debug.Log($"sign = {sign}");

        float amount_to_add = (sign * scale_rate * Time.deltaTime);
        Debug.Log($"Amount to add = {amount_to_add}");

        switch (sign) //checks if its over OR under the target scale
        {
            case -1: //for down-scaling
                if ((amount_to_add + transform.localScale[index]) < target_scale[index])
                {
                    amount_to_add = (transform.localScale[index] - target_scale[index]);
                }
                break; 
            case 1: //for up-scaling
                if ((amount_to_add + transform.localScale[index]) > target_scale[index])
                {
                    amount_to_add = (target_scale[index] - transform.localScale[index]);
                }
                break;
            case 0:
                Debug.Log($"sign is 0 bruh");
                break;
            default:
                Debug.Log($"lmao");
                break;
        }

        return amount_to_add;
    }

    public void ChangeTargetScale(float scale)
    {
        Vector3 temp_scale = target_scale + new Vector3(scale, scale, scale);

        for (int i = 0; i < 3; i++)
        {
            if (temp_scale[i] < min_scale[i]) //checks if its under minimum scale
            {
                temp_scale[i] = min_scale[i];
            }
            else if (temp_scale[i] > max_scale[i]) //checks if its over max scale
            {
                temp_scale[i] = max_scale[i];
            }
        }

        target_scale = temp_scale;
    }
    #endregion

    #region Events
    #endregion
}

