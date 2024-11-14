using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class UIAudio : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string clickAudioName;
    public string hoverEnterAudioName;
    public string hoverExitAudioName;
    public AudioMixerGroup mixerGroup;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(clickAudioName != "")
        {
            AudioManager.instance.Play(clickAudioName, mixerGroup);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverEnterAudioName != "")
        {
            AudioManager.instance.Play(hoverEnterAudioName, mixerGroup);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoverExitAudioName != "")
        {
            AudioManager.instance.Play(hoverExitAudioName, mixerGroup);
        }
    }
}
