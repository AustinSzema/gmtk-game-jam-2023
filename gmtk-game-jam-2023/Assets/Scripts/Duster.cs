using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class Duster : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private Transform feetPosition;
    [SerializeField] private GameObject dustPrefab;
    //[SerializeField] private ParticleSystem dust;
    [SerializeField] private float dustFrequency = 0.5f;

    public IEnumerator StartDuster()
    {
        while (true)
        {
            if (!GameController.editing)
            {
                RaycastHit2D hit = Physics2D.Raycast(feetPosition.position, -transform.up, 1f, mask);
                if (hit.collider != null)
                {
                    SpriteRenderer spriteRenderer = hit.collider.GetComponent<SpriteRenderer>();
                    if (spriteRenderer != null)
                    {
                        Debug.Log("test");
                        Sprite sprite = spriteRenderer.sprite;
                        Texture2D texture = sprite.texture;

                        Vector2 localPoint = hit.transform.InverseTransformPoint(hit.point);
                        Vector2 pixelUV = new Vector2(
                            (localPoint.x - sprite.bounds.min.x) / sprite.bounds.size.x,
                            (localPoint.y - sprite.bounds.min.y) / sprite.bounds.size.y
                        );

                        Color color = texture.GetPixelBilinear(pixelUV.x, pixelUV.y);
                        color.a = 1;
                        ParticleSystem dust = GameObject.Instantiate(dustPrefab, feetPosition.position, dustPrefab.transform.rotation).GetComponent<ParticleSystem>();
                        dust.startColor = color;
                        dust.Play();
                        Events.SpawnWorldSpaceSound.Invoke(VisualSoundPresets.Squeak, feetPosition.position + new Vector3(0f, 0.5f), 0.5f);

                    }
                }
            }
            
            yield return new WaitForSeconds(dustFrequency);
        }

    }

    public void Dust()
    {
        StartCoroutine(StartDuster());
    }

    /*private void Start()
    {
        Dust();
    }*/
}
