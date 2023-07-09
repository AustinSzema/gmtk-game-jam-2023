using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VisualSoundOnClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private VisualSoundPresets _preset;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click");
        Events.SpawnSound.Invoke(_preset, eventData.position);
    }

}
