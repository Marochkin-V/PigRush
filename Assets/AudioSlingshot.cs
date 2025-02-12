using Unity.VisualScripting;
using UnityEngine;

public class AudioSlingshot : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;

    [SerializeField] public AudioClip stretch;
    [SerializeField] public AudioClip fire;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = GlobalValues.sfxVolume;
    }
}
