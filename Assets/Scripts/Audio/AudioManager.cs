using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{

    #region OneShots
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


    #endregion

    #region MusicPlayback
    [SerializeField]
    private AudioSourceSettings _defaultMusicSourceSettings;

    private MusicSection _currentMusicSection = null;

    public void PlayMusic(MusicSection section)
    {
        AudioSource musicSource = FindMusicSource();

       _defaultMusicSourceSettings.SetSourceSettings(musicSource);

        section.PlaySection(musicSource);
        _currentMusicSection = section;

       StartCoroutine( PlayNextSectionDelayed(_currentMusicSection));

    }

    public void OverrideMusic(MusicSection section)
    {
        _currentMusicSection.OverrideSection(section);
       
    }




    private IEnumerator PlayNextSectionDelayed(MusicSection currentSection)
    {

        yield return new WaitForSecondsRealtime(currentSection._length);

        if (currentSection._overrideSection != null)
        {
            PlayMusic(currentSection._overrideSection);
            currentSection._overrideSection = null;
        }
        else
        {
            PlayMusic(currentSection._nextSection);
            currentSection._overrideSection = null;
        }

       
    }


    #endregion




    #region Initiation

    private List<AudioSource> _sources = new List<AudioSource>();

    [SerializeField] 
    private List<AudioSource> _musicSources = new List<AudioSource>();

    public void Awake( )
    {
        GameObject tempObject = new GameObject();
        for(int i = 0; i < 15; i++)
        {
            GameObject newAudioSource = Instantiate(tempObject, this.transform);

            _sources.Add(newAudioSource.AddComponent<AudioSource>());

          

        }

        for (int i = 0; i < 3; i++)
        {
            GameObject newAudioSource = Instantiate(tempObject, this.transform);

            _musicSources.Add(newAudioSource.AddComponent<AudioSource>());



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


    private AudioSource FindMusicSource()
    {
        bool foundSource = false;

        int index = 0;

        while (foundSource == false && index < _musicSources.Count)
        {
            if (_musicSources[index].isPlaying == false)
            {
                foundSource = true;
                return _musicSources[index];

            }
            else
            {
                index++;
            }

        }


        GameObject newAudioSource = new GameObject();



        var tempAudioSource = Instantiate(newAudioSource, this.transform);
        _musicSources.Add(tempAudioSource.AddComponent<AudioSource>());

        Destroy(newAudioSource);
        return _musicSources[_sources.Count - 1];
    }


    #endregion
}
