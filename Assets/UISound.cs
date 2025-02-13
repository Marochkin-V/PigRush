using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip click;
    [SerializeField] AudioClip hover;
    [SerializeField] AudioClip pigsWin;
    [SerializeField] AudioClip birdsWin;
    [SerializeField] AudioClip levelStart;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickFX()
    {
        audioSource.PlayOneShot(click);
    }

    public void HoverFX()
    {
        audioSource.PlayOneShot(hover);
    }

    public void LevelFailedFX()
    {
        audioSource.PlayOneShot(pigsWin);
    }

    public void LevelClearedFX()
    {
        audioSource.PlayOneShot(birdsWin);
    }

    public void PlayMMM()
    {
        audioSource.Play();
    }

    public void StopMMM()
    {
        audioSource.Stop();
    }
}
