using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AnimationEvent : UnityEvent<string>

{

}
public class WeaponAnimationEvent : MonoBehaviour
{
   public AnimationEvent WeaponAnimEvent = new AnimationEvent();

    public void OnAimationEvent(string eventName)
    {
        WeaponAnimEvent.Invoke(eventName);
    }
    public void AudioOnShootRilfe()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_RILFE);
        }
    }

    public void AudioOnShootPistol()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_PISTOL);
        }
    }

    public void AudioReloadRilfe()
    {
        if (AudioManager.HasInstance) 
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_RILFE_RELOAD);
        }
    }

    public void AudioReloadPistol()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_PISTOL_RELOAD);
        }
    }

}
