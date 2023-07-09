using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    [SerializeField] private ParticleSystem winParticles;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

            StartCoroutine(loadNextScene());
        }
    }

    IEnumerator loadNextScene()
    {

        if (!winParticles.isPlaying)
        {
            winParticles.Play();

        }

        yield return new WaitForSeconds(winParticles.duration);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }



}
