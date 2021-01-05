using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonController : MonoBehaviour
{

    [SerializeField] private ParticleSystem WaterSplasParticle;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private AudioSource splashAudioSource;
    [SerializeField] private AudioClip splashSound;
    // Start is called before the first frame update
    void Start()
    {
        splashAudioSource.clip = splashSound;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("SpawnArea"))
        {
            return;
        }

        // Play splash animation
        Instantiate(WaterSplasParticle, transform.position, transform.rotation);

        // Play splash sound
        AudioSource.PlayClipAtPoint(splashSound, transform.position);

        if (collision.gameObject.name.Contains("Bullet"))
        {
            // Increase score
            scoreManager.increaseCurrentScore();
        }

        // Destroy
        Destroy(gameObject);
        //Debug.Log(collision.gameObject.name);
    }
}

