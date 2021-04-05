using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer music;

    public static AudioSource themeMusic;
    // Use this for initialization

    void Start()
    {
        if (music == null)
        {
            DontDestroyOnLoad(this);
            music = this;
        }
        else if (music != this)
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(this);
        //themeMusic = GetComponent<AudioSource>();
    }

    void OnLevelWasLoaded()
    {
        if (Application.loadedLevel != 0)
        {
            //StartCoroutine(FadeOut(themeMusic, 3)); // Lovely tutorial code courtesy of: https://forum.unity3d.com/threads/fade-out-audio-source.335031/
        }
    }

    // Update is called once per frame
    public IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }
        themeMusic.Stop();
        themeMusic.volume = startVolume;
    }
}
