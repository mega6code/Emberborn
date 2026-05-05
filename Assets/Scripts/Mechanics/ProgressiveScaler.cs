using System;
using Unity.VisualScripting;
using UnityEngine;

public class ProgressiveScaler : MonoBehaviour
{
    #region Fields
    [Header("Scale Limits")]
    [SerializeField] private Vector3 minScale;
    [SerializeField] private bool useStartScaleForMin = false;
    [SerializeField] private Vector3 maxScale;
    [SerializeField] private bool useStartScaleForMax = false;

    [Header("Scale Rate")]
    [Tooltip("Rate = amount of units it will scale per every 1 second")]
    [SerializeField] private float upscale_rate = 1;
    [Tooltip("Rate = amount of units it will scale per every 1 second")]
    [SerializeField] private float downscale_rate = 1;

    [Header("Other Cool Stuff")]
    [Tooltip("Reset the overall physics for the object each time the scale changes (if its floating and stuff)")]
    [SerializeField] private bool resetGravityEachScale = false;

    [Space]
    [Header("| DEBUGGING ONLY |")]
    [SerializeField] private Vector3 target_scale;

    private bool check_size_limits = false;
    #endregion

    #region Properties
    #endregion

    #region Events
    public event Action minimumScaleReached;
    public event Action maximumScaleReached;
    #endregion

    #region Methods
    private void Start()
    {
        target_scale = transform.localScale;

        if (useStartScaleForMin)
        {
            minScale = transform.localScale;
        }

        if (useStartScaleForMax)
        {
            maxScale = transform.localScale;
        }
    }
    void Update()
    {
        Vector3 scale_to_set = new Vector3();
        int min_check = 0;
        int max_check = 0;

        for (int i = 0; i < 3; i++)
        {
            if (IsFloatsInRange(transform.localScale[i], target_scale[i])) //is the size at target size yet?
            {
                //if yes, time to check if we need to check

                if (check_size_limits)
                {
                    //if yes, time to check!!!!!! (the min/max limits)

                    if (IsFloatsInRange(transform.localScale[i], minScale[i])) //is the size at minimum size yet?
                    {
                        min_check++;
                    }
                    if (IsFloatsInRange(transform.localScale[i], maxScale[i])) //is the size at maximum size yet?
                    {
                        max_check++;
                    } 
                }
                continue;
            }
            else
            {
                scale_to_set[i] = GetAmountToAdd(i); //if no, keep doing what u doing
            }
        }

        transform.localScale += scale_to_set;

        //if (adjustYPositioning)
        //{
        //    transform.localPosition -= new Vector3(0, (scale_to_set.y/2), 0);
        //}

        if (resetGravityEachScale)
        {
            if(TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.useGravity = !(rigidbody.useGravity);
                rigidbody.useGravity = !(rigidbody.useGravity);
            }

        }

        if (min_check == 3)
        {
            minimumScaleReached?.Invoke();
        }

        if (max_check == 3)
        {
            maximumScaleReached?.Invoke();
        }
    }

    private bool IsFloatsInRange(float f1, float f2, float range = 0.1f, int rounding = 3)
    {
        double result = Math.Round(f1, rounding) - Math.Round(f2, rounding);

        if (Math.Abs(result) > range)
        {
            return false;
        }
        return true;
    }
    /// <summary>
    /// Gets the amount to add to the Vector element
    /// </summary>
    /// <returns></returns>
    private float GetAmountToAdd(int index)
    {
        int sign = Math.Sign(target_scale[index] - transform.localScale[index]); //decides whether its a up-scale or down-scale
        Debug.Log($"sign = {sign}");

        float amount_to_add = (sign * Time.deltaTime);
        Debug.Log($"Amount to add = {amount_to_add}");

        switch (sign) //checks if its over OR under the target scale
        {
            case -1: //for down-scaling

                amount_to_add = amount_to_add * downscale_rate;

                if ((amount_to_add + transform.localScale[index]) < target_scale[index])
                {
                    amount_to_add = (transform.localScale[index] - target_scale[index]);
                }
                break; 
            case 1: //for up-scaling

                amount_to_add = amount_to_add * upscale_rate;

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
        int min_check = 0;
        int max_check = 0;

        for (int i = 0; i < 3; i++)
        {
            if (temp_scale[i] < minScale[i]) //checks if its under minimum scale
            {
                temp_scale[i] = minScale[i];
                min_check++;
            }
            else if (temp_scale[i] > maxScale[i]) //checks if its over max scale
            {
                temp_scale[i] = maxScale[i];
                max_check++;
            }
        }

        target_scale = temp_scale;

        if (min_check == 3 || max_check == 3)
        {
            check_size_limits = true;
        }
        else 
        {
            check_size_limits = false;
        }

    }
    #endregion
}

