using Emberborn.Elements;
using UnityEngine;

public class DragonBreathVFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem iceBreath;
    [SerializeField] private ParticleSystem fireBreath;

    private ParticleSystem currentBreath;
    private ElementalTypes elemental_type;

    private void SwitchParticles()
    {
        switch (elemental_type)
        {
            case ElementalTypes.Ice:
                currentBreath = iceBreath;
                break;
            case ElementalTypes.Fire:
                currentBreath = fireBreath;
                break;
            default:
                break;
        }
    }

    public void ActivateBreath(ElementalTypes elementalType)
    {
        if (currentBreath == null)
        {
            elemental_type = elementalType;
            SwitchParticles();
        }
        else if(elemental_type != elementalType) //Emby changed element state
        {
            DeActivateBreath(); //turn dat shit off
            elemental_type = elementalType; //the new element Emby changed to
            SwitchParticles(); //switch to that dragon breath particle system
        }

        if (!currentBreath.isEmitting) //if dat shit is off
        {
            Debug.Log($"{this.name}:{elemental_type} time to turn on again");
            currentBreath.Play(); //play
        }
    }

    public void DeActivateBreath()
    {
        if (currentBreath != null)
        {
            currentBreath.Stop();
        }
    }
}