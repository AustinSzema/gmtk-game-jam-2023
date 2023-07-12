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
            VisualSoundPresets choice;
            int randomChoice = Random.Range(0, 2);
            if (randomChoice == 0)
            {
                choice = VisualSoundPresets.Kaboom;
            }
            else if (randomChoice == 1)
            {
                choice = VisualSoundPresets.Bang;
            }
            else
            {
                choice = VisualSoundPresets.Pow;
            }
            Events.SpawnWorldSpaceSound.Invoke(choice, transform.position + new Vector3(0, 30), 1f);
            StartCoroutine(reloadScene());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DamagePlayer"))
        {
            VisualSoundPresets choice;
            int randomChoice = Random.Range(0, 2);
            if (randomChoice == 0)
            {
                choice = VisualSoundPresets.Kaboom;
            }
            else if (randomChoice == 1)
            {
                choice = VisualSoundPresets.Bang;
            }
            else
            {
                choice = VisualSoundPresets.Pow;
            }
            //Events.SpawnWorldSpaceSound.Invoke(choice, rb.transform.position, 1f);
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
