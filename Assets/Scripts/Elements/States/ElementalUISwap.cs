using Emberborn.Elements;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ElementalAssetSwap : MonoBehaviour
{
    [SerializeField] private RawImage currentImage;
    public ElementalStateManager state;
    public Texture iceImage;
    public Texture fireImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void Update()
    {
        if (currentImage != null) {
            if (state.Current_state == null)
            {
                Debug.Log("No power up yet");
            }
            else if (state.Current_element == ElementalTypes.Ice)
            {
                Debug.Log("You are in ice mode");
                SwapAsset(iceImage);
            }
            else if (state.Current_element == ElementalTypes.Fire)
            {
                Debug.Log("You are in fire mode");
                SwapAsset(fireImage);
            }
        }
    }
    //swap the things
    public void SwapAsset(Texture textureSet) 
    {
        if(textureSet != null && currentImage != null)
        {
            currentImage.texture = textureSet;
        }
    }
}
