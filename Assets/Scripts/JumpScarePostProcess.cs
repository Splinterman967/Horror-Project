using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class JumpScarePostProcess : MonoBehaviour
{
    private PostProcessVolume postProcessVolume;
    void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        EventManager.Instance.OnFirstJumpScare += JumpScareEffects;
    }

   private void JumpScareEffects()
    {
        postProcessVolume.profile.TryGetSettings(out Vignette vignette);
        vignette.intensity.value = 0.55f;
    }
}
