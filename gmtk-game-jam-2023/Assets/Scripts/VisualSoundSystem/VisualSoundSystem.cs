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
            case VisualSoundPresets.Boing:
                text = "<BOING>";
                break;
            default:
                text = "<fart>";
                break;
        }


        int offset = Random.Range(-10, 10);
        GameObject visualSound = Instantiate(textPrefab, position, transform.rotation * new Quaternion(0, 0, 1, offset));
        visualSound.GetComponent<TextMeshProUGUI>().text = text;
        visualSound.transform.SetParent(canvas.transform, true);
        
        //visualSound.GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
    }
}
