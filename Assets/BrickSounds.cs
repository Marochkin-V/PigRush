using UnityEngine;

public class BrickSounds : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;

    [SerializeField] public AudioClip[] crash;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = GlobalValues.sfxVolume;
    }
}
