using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class PostProcessControls : MonoBehaviour
{
     [SerializeField] public Volume postProcessingVolume;
     [Header("Post Processing profiles")]
     private Vignette vignette_val;
     private ChromaticAberration CA_val;
     [SerializeField] private VolumeProfile postProfileMain;
     [SerializeField] private VolumeProfile postProfileEther;
     private void Start()
     {
          postProcessingVolume.profile.TryGet(out vignette_val);
          postProcessingVolume.profile.TryGet(out CA_val);
     }
     public void MainPostProcess()
     {
          postProcessingVolume.profile = postProfileMain;
     }

     public void EtherPostProcess()
     {
          postProcessingVolume.profile = postProfileEther;
     }

     public void AdjustVignette(float newVignette)
     {
          if (newVignette > 1f)
          {
               vignette_val.intensity.value = 1f;
          }
          if (newVignette < 0f)
          {
               vignette_val.intensity.value = 0f;
          }
          vignette_val.intensity.value = newVignette;
     }

     public void AdjustCA(float newCA)
     {
          if (newCA > 1f)
          {
               CA_val.intensity.value = 1f;
          }
          if (newCA > 0f)
          {
               CA_val.intensity.value = 0f;
          }
          CA_val.intensity.value = newCA;
     }
}
