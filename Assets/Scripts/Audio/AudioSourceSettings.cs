using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;


[CreateAssetMenu(menuName = "Audio/AudioSettings")]
public class AudioSourceSettings : ScriptableObject
{

    [SerializeField]
    private float _maxDistance = 10.0f;
    [SerializeField]
    private float _minDistance = 0.1f;
    [SerializeField]
    [Range(-1f, 1f)]
    private float _pitch = 0.0f;

    [SerializeField]
    [Range(-1f, 1f)]
    private float _stereoPan = 0.0f;

    [SerializeField]
    [Range(0f, 1.1f)]
    private float _spatialBlend = 1.0f;

    [SerializeField]
    private bool _loop = false;

    [SerializeField]
    
    private AnimationCurve _spatializedCurve;

   


    public void SetSourceSettings( AudioSource source )
    {
      

        source.maxDistance  = _maxDistance;
        source.minDistance = _minDistance;
        source.pitch = _pitch;
        source.panStereo = _stereoPan;
        source.spatialBlend = _spatialBlend;
        source.loop = _loop;

        source.SetCustomCurve(AudioSourceCurveType.CustomRolloff, _spatializedCurve);


    }



}
