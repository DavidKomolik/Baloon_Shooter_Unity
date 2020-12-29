using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonController : MonoBehaviour
{

    [SerializeField] ParticleSystem WaterSplasParticle;
    // Start is called before the first frame update
    void Start()
    {
        
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

            // Destroy itself
            Destroy(gameObject);
        }

        Debug.Log(collision.gameObject.name);
    }

}
