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
        Events.SpawnScaledSound.AddListener(SpawnScaledVisualSound);
    }

    private void SpawnVisualSound(VisualSoundPresets arg1, Vector2 arg2)
    {
        SpawnVisualSoundWithScale(arg1, arg2);
    }

    private void SpawnScaledVisualSound(VisualSoundPresets arg1, Vector2 arg2, float arg3)
    {
        SpawnVisualSoundWithScale(arg1, arg2, arg3);
    }

    private void OnDisable()
    {
        Events.SpawnSound.RemoveListener(SpawnVisualSound);
        Events.SpawnScaledSound.RemoveListener(SpawnScaledVisualSound);
    }

    private void SpawnVisualSoundWithScale(VisualSoundPresets preset, Vector2 position, float scale = 1)
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
            case VisualSoundPresets.Knock:
                text = "<KNOCK>";
                break;
            default:
                text = "<fart>";
                break;
        }


        int offset = Random.Range(-6, 6);
        GameObject visualSound = Instantiate(textPrefab, position, transform.rotation * new Quaternion(0, 0, 1, offset));
        visualSound.GetComponent<TextMeshProUGUI>().text = text;
        visualSound.transform.SetParent(canvas.transform, true);
        visualSound.transform.localScale = new Vector2(scale, scale);
        
        //visualSound.GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
    }


}
