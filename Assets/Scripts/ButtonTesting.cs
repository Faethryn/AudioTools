using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTesting : MonoBehaviour
{
    private AudioManager _audioManager;

    [SerializeField]
    private Patch _patch;

    [SerializeField]
    private AudioSourceSettings _3DaudioSourceSettings;

    [SerializeField]
    private AudioSourceSettings _2DaudioSourceSettings;

    public void Play3D()
    {
        if(_audioManager  == null)
        {
            _audioManager =  FindObjectOfType<AudioManager>();
        }
       

        _audioManager.PlayAudio(_audioManager.transform.position, _patch, _3DaudioSourceSettings);


    }

    public void Play2D()
    {
        if (_audioManager == null)
        {
            _audioManager = FindObjectOfType<AudioManager>();
        }


        _audioManager.PlayAudio(_audioManager.transform.position, _patch, _2DaudioSourceSettings);
    }

    public void PlayDefault()
    {
        if (_audioManager == null)
        {
            _audioManager = FindObjectOfType<AudioManager>();
        }


        _audioManager.PlayAudio(_audioManager.transform.position, _patch);
    }

}
