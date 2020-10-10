using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private static float inBetweenPause= 2;
    public float TimeRemaining = inBetweenPause;
    public GameObject baloon;
    private bool thrown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        if (TimeRemaining > 0)
        {
            TimeRemaining -= Time.deltaTime;
        }
        else
        {
            // Spawn new object
            Tuple<bool, GameObject> objectSpawn = spawnNewGameObject();
            if (!objectSpawn.Item1)
            {
                Debug.LogError("Failed to spawn object");
                return;
            }
            // Throw it
            GetComponent<ParabolaController>().FollowParabola();
            thrown = true;
            TimeRemaining = inBetweenPause;
        }

        if (thrown)
        {
            GetComponent<ParabolaController>().FollowParabola();
        }
    }

    private  Tuple<bool, GameObject> spawnNewGameObject()
    {
        Vector3 spawnPosition = new Vector3(0.7f, 5f, -48f);
        Quaternion rotation = new Quaternion();
        GameObject newBaloon = Instantiate(baloon, spawnPosition, rotation);
        Debug.Log("Spawned baloon");
        return new Tuple<bool, GameObject>(true, newBaloon);
    }
}
