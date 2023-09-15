using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] 
    private AudioSourceSettings _defaultAudioSourceSettings;

    public void PlayAudio(Vector3 sourcePosition, Patch patchToPlay)
    {
        AudioSource chosenSource = FindAudioSource();
        chosenSource.gameObject.transform.position = sourcePosition;
        Patch patch = patchToPlay;
        _defaultAudioSourceSettings.SetSourceSettings(chosenSource);
        patch.Play(chosenSource);
    }

    public void PlayAudio(Transform sourcePosition, Patch patchToPlay)
    {
        AudioSource chosenSource = FindAudioSource();
        chosenSource.gameObject.transform.position = sourcePosition.position;
        Patch patch = patchToPlay;

        _defaultAudioSourceSettings.SetSourceSettings(chosenSource);

        patch.Play(chosenSource);
    }

    public void PlayAudio(Vector3 sourcePosition, Patch patchToPlay, AudioSourceSettings settings)
    {
        AudioSource chosenSource = FindAudioSource();
        chosenSource.gameObject.transform.position = sourcePosition;
        Patch patch = patchToPlay;
        settings.SetSourceSettings(chosenSource);
        patch.Play(chosenSource);
    }

    public void PlayAudio(Transform sourcePosition, Patch patchToPlay, AudioSourceSettings settings)
    {
        AudioSource chosenSource = FindAudioSource();
        chosenSource.gameObject.transform.position = sourcePosition.position;
        Patch patch = patchToPlay;
        settings.SetSourceSettings(chosenSource);

        patch.Play(chosenSource);
    }


    private List<AudioSource> _sources = new List<AudioSource>();

   

    public void Awake( )
    {
        GameObject tempObject = new GameObject();
        for(int i = 0; i < 15; i++)
        {
            GameObject newAudioSource = Instantiate(tempObject, this.transform);

            _sources.Add(newAudioSource.AddComponent<AudioSource>());      
            
        }

        Destroy( tempObject );
       
    }

   private AudioSource FindAudioSource()
    {
        bool foundSource = false;

        int index = 0;

        while(foundSource == false && index < _sources.Count)
        {
            if (_sources[index].isPlaying == false)
            {
                foundSource = true;
                return _sources[index];

            }
            else
            {
                index++;
            }
            
        }
       

        GameObject newAudioSource = new GameObject();
       


      var tempAudioSource =  Instantiate(newAudioSource, this.transform);
        _sources.Add(tempAudioSource.AddComponent<AudioSource>());

        Destroy( newAudioSource );
        return _sources[_sources.Count - 1];
    }
}