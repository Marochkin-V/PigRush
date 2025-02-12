using UnityEngine;

public class UIAudioManager : MonoBehaviour
{
    public static UIAudioManager instance;
    public AudioSource audioSource;

    public AudioClip click;
    public AudioClip select;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayOneShot(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void Click()
    {
        PlayOneShot(click);
    }

    public void Hover()
    {
        PlayOneShot(select);
    }
}