using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class VisualSoundSystem : MonoBehaviour
{
    [SerializeField] private GameObject worldSpaceTextPrefab;
    [SerializeField] private GameObject UITextPrefab;
    [SerializeField] private GameObject canvas;

    private void OnEnable()
    {
        //Events.SpawnSound.AddListener(SpawnVisualSound);
        Events.SpawnUIVisualSound.AddListener(SpawnVisualSoundUI);
        Events.SpawnWorldSpaceSound.AddListener(SpawnVisualSoundWorldSpace);
    }

    /*private void SpawnVisualSound(VisualSoundPresets arg1, Vector2 arg2)
    {
        SpawnVisualSoundUI(arg1, arg2);
    }

    private void SpawnScaledVisualSound(VisualSoundPresets arg1, Vector2 arg2, float arg3)
    {
        SpawnVisualSoundUI(arg1, arg2, arg3);
    }*/

    private void OnDisable()
    {
        //Events.SpawnSound.RemoveListener(SpawnVisualSound);
        Events.SpawnUIVisualSound.RemoveListener(SpawnVisualSoundUI);
        Events.SpawnWorldSpaceSound.RemoveListener(SpawnVisualSoundWorldSpace);
    }

    private void SpawnVisualSoundUI(VisualSoundPresets preset, Vector2 position, float scale = 1)
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


        float offset = Random.Range(-1f, 1f);
        GameObject visualSound = Instantiate(UITextPrefab, position, transform.rotation);
        visualSound.GetComponent<TextMeshProUGUI>().text = text;
        visualSound.transform.SetParent(canvas.transform, true);
        visualSound.transform.localScale = new Vector2(scale, scale);
        visualSound.transform.Rotate(0, 0, offset);
        
    }

    private void SpawnVisualSoundWorldSpace(VisualSoundPresets preset, Vector2 position, float scale = 1)
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

        float offset = Random.Range(-1f, 1f);
        GameObject visualSound = Instantiate(worldSpaceTextPrefab, position, transform.rotation * new Quaternion(0, 0, offset, 1));
        visualSound.GetComponent<TextMeshPro>().text = text;
        visualSound.transform.SetParent(canvas.transform, true);
        visualSound.transform.localScale = new Vector2(scale, scale);
        visualSound.transform.Rotate(0, 0, offset);

    }


}
