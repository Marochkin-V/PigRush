using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip click;
    [SerializeField] AudioClip hover;

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

}
