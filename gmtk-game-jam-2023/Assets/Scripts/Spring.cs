using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private float springPower = 10f;
    [SerializeField] private AudioClip springSfx;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, springPower);
            Events.SpawnWorldSpaceSound.Invoke(VisualSoundPresets.Boing, transform.position, 1.5f);
            AudioSource.PlayClipAtPoint(springSfx, Camera.main.transform.position, .5f);
        }
    }
}
