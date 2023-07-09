using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class VisualSoundSystem : MonoBehaviour
{
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private GameObject canvas;

    private void OnEnable()
    {
        Events.SpawnSound.AddListener(SpawnVisualSound);
    }

    private void OnDisable()
    {
        Events.SpawnSound.RemoveListener(SpawnVisualSound);
    }

    private void SpawnVisualSound(VisualSoundPresets preset, Vector2 position)
    {
        Debug.Log("spawning visual sound");
        string text;
        switch (preset)
        {
            case VisualSoundPresets.Bang:
                text = "<BANG>";
                break;
            case VisualSoundPresets.Pow:
                text = "<POW>";
                break;
            case VisualSoundPresets.Squeak:
                text = "<squeak>";
                break;
            case VisualSoundPresets.Kaboom:
                text = "<KABOOM>";
                break;
            case VisualSoundPresets.Click:
                text = "<click>";
                break;
            default:
                text = "<fart>";
                break;
        }

        GameObject visualSound = Instantiate(textPrefab, position, transform.rotation);
        visualSound.GetComponent<TextMeshProUGUI>().text = text;
        visualSound.transform.SetParent(canvas.transform, true);
        
        //visualSound.GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
    }
}
