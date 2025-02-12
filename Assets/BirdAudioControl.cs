using UnityEngine;

public class BirdAudioControl : MonoBehaviour
{

    [SerializeField] public AudioSource audioSource;

    [SerializeField] public AudioClip launch;
    [SerializeField] public AudioClip voice;

    [SerializeField] public AudioClip[] crash;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = GlobalValues.sfxVolume;
    }

}
