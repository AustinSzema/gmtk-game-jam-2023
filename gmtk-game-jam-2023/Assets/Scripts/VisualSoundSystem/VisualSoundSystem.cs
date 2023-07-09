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
        Events.SpawnWorldSpaceSound.AddListener(SpawnVisualSoundWorldSpace);
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
        Events.SpawnWorldSpaceSound.RemoveListener(SpawnVisualSoundWorldSpace);
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


        int offset = Random.Range(-3, 3);
        GameObject visualSound = Instantiate(textPrefab, position, transform.rotation * new Quaternion(0, 0, 1, offset));
        visualSound.GetComponent<TextMeshProUGUI>().text = text;
        visualSound.transform.SetParent(canvas.transform, true);
        visualSound.transform.localScale = new Vector2(scale, scale);
        
        //visualSound.GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
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


        int offset = Random.Range(-3, 3);
        GameObject visualSound = Instantiate(textPrefab, position, transform.rotation * new Quaternion(0, 0, 1, offset));
        visualSound.GetComponent<TextMeshProUGUI>().text = text;
        visualSound.transform.SetParent(canvas.transform, true);
        visualSound.transform.localScale = new Vector2(scale, scale);

        //this is your object that you want to have the UI element hovering over
        GameObject WorldObject;

        //this is the ui element
        RectTransform UI_Element;

        //first you need the RectTransform component of your canvas
        RectTransform CanvasRect = canvas.GetComponent<RectTransform>();

        //then you calculate the position of the UI element
        //0,0 for the canvas is at the center of the screen, whereas WorldToViewPortPoint treats the lower left corner as 0,0. Because of this, you need to subtract the height / width of the canvas * 0.5 to get the correct position.

        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));

        //now you can set the position of the ui element
        visualSound.transform.position = WorldObject_ScreenPosition + new Vector2(CanvasRect.position.x, CanvasRect.position.y);

        //visualSound.GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
    }


}
