using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonController : MonoBehaviour
{

    [SerializeField] ParticleSystem WaterSplasParticle;
    [SerializeField] private ScoreManager scoreManager;
    public AudioSource splashAudioSource;
    [SerializeField] public AudioClip splashSound;
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
        if (collision.gameObject.name.Contains("Bullet"))
        {
            // play splash animation
            Instantiate(WaterSplasParticle, transform.position, transform.rotation);

            // Play splash sound
            splashAudioSource.Play();

            // Increase score
            scoreManager.increaseCurrentScore();

            // Destroy
            Destroy(gameObject);
            //Debug.Log(collision.gameObject.name);
        }

        //Debug.Log(collision.gameObject.name);
    }

}
