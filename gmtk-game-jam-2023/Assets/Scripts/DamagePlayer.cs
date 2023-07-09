using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class DamagePlayer : MonoBehaviour
{

    [SerializeField] private ParticleSystem deathParticles;

    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DamagePlayer"))
        {
            StartCoroutine(reloadScene());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DamagePlayer"))
        {
            Events.SpawnScaledSound.Invoke(VisualSoundPresets.Bang, transform.position, 2);
            StartCoroutine(reloadScene());
        }
    }

    IEnumerator reloadScene()
    {

        Debug.Log("Collison");

        rb.Sleep();

        if (!deathParticles.isPlaying)
        {
            deathParticles.Play();

        }

        yield return new WaitForSeconds(deathParticles.duration);
        GameObject.FindGameObjectWithTag("SoftResetButton").GetComponent<MoveToStart>().MoveToStartingPos();
    }



}
