using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using static Unity.VisualScripting.Member;

[CreateAssetMenu(menuName = "Audio/MusicSection")]
public class MusicSection : ScriptableObject
{
    [SerializeField] private AudioMixerGroup _group;
   
    [SerializeField] private AudioClip _clip;

    public MusicSection _nextSection;

   

   

     public MusicSection _overrideSection = null;

    
    public float _length = 0f;

  

   

    
   


    public void PlaySection(AudioSource audioSource)
    {
        audioSource.clip = _clip;
        audioSource.outputAudioMixerGroup = _group;
        
        audioSource.Play();

        
        


    }


    public void OverrideSection(MusicSection overrideSection)
    {
        _overrideSection = overrideSection;
    }
    
    
    
    
    public event EventHandler<ClipLengthChangedArgs> ClipLengthChanged;


    public class ClipLengthChangedArgs : EventArgs
    {
       public float _length;

        public ClipLengthChangedArgs(float length)
        {
           _length= length;
        }
    }

    protected virtual void OnClipLengthChanged(ClipLengthChangedArgs eventargs)
    {
        var handler = ClipLengthChanged;
        handler?.Invoke(this, eventargs);
    }


}
