using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonController : MonoBehaviour
{

    [SerializeField] private ParticleSystem WaterSplasParticle;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private AudioSource splashAudioSource;
    [SerializeField] private AudioClip splashSound;
    [SerializeField] private Material goldMaterial;
    private float _slowDownTime = 10;
    private BallonType type = BallonType.NORMAL;
    public static int slowedDownTimeCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        splashAudioSource.clip = splashSound;
        if (Random.value < 0.3)
        {
            type = BallonType.SLOWDOWN;
            GetComponent<MeshRenderer>().material = goldMaterial;
            GetComponent<Light>().color = goldMaterial.color;
            GetComponent<Light>().intensity = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator slowDownTime()
    {
        slowedDownTimeCounter++;
        CountDown.refreshTimer();
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(_slowDownTime);
        if (!PauseMenu.isPaused && slowedDownTimeCounter == 1)
        {
            Time.timeScale = 1;
        }
        slowedDownTimeCounter--;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("SpawnArea"))
        {
            return;
        }
        
        // Play splash animation
        var isnta = Instantiate(WaterSplasParticle, transform.position, transform.rotation);
        if (type == BallonType.SLOWDOWN)
        {
            var rende = isnta.GetComponent<Renderer>();
            rende.material = goldMaterial;
        }
        
        // Play splash sound
        AudioSource.PlayClipAtPoint(splashSound, transform.position);

        if (collision.gameObject.name.Contains("Bullet"))
        {
            // Increase score
            scoreManager.increaseCurrentScore();

            if (type == BallonType.SLOWDOWN)
            {
                CoroutineManager.Instance.StartCoroutine(slowDownTime());
            }
        }

        // Destroy
        Destroy(gameObject);
        //Debug.Log(collision.gameObject.name);
    }
}

