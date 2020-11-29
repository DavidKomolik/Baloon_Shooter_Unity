using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject baloon;
    [SerializeField] GameObject player;
    [SerializeField] GameObject spawnArea;
    [SerializeField] float throwForce = 60;
    public float throwYConstant = -0.1f;
    [SerializeField] float inBetweenPause = 2;
    private Difficulty difficulty = Difficulty.EASY;
    private float zSpawnOffset = 2;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            difficulty = (Difficulty)PlayerPrefs.GetInt("Difficulty");
            if (difficulty == Difficulty.HARD)
            {
                setHardDifficulty();
            } else
            {
                setEasyDifficulty();
            }
            
            Debug.Log("Difficulty set to : " + difficulty);
        }
        else
        {
            setEasyDifficulty();
        }
        StartCoroutine(spawnNewBalloon());
        spawnArea.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame

    void Update()
    {
       
    }

    IEnumerator spawnNewBalloon()
    {
        yield return new WaitForSeconds(inBetweenPause);
        while(true)
        {
            Debug.Log("Spawned baloon");
            // Spawn new object
            Tuple<bool, GameObject> objectSpawn = spawnNewGameObject();
            if (!objectSpawn.Item1)
            {
                Debug.LogError("Failed to spawn object");
            }

            // Throw it
            throwObject(objectSpawn.Item2);

            yield return new WaitForSeconds(inBetweenPause);
        }

    }

    private Tuple<bool, GameObject> spawnNewGameObject()
    {
        Vector3 sp = spawnArea.GetComponent<Collider>().bounds.extents;
        float randXLocation = (float)getRandomNumber(spawnArea.transform.position.x - sp.x, spawnArea.transform.position.x + sp.x);
        float randYLocation = (float)getRandomNumber(spawnArea.transform.position.y - sp.y, spawnArea.transform.position.y + sp.y);
        Vector3 spawnPosition = new Vector3(randXLocation, randYLocation, spawnArea.transform.position.z + zSpawnOffset);
        Quaternion rotation = new Quaternion();
        GameObject newBaloon = Instantiate(baloon, spawnPosition, Quaternion.identity);
        newBaloon.GetComponent<MeshRenderer>().material.SetColor("_Color", UnityEngine.Random.ColorHSV(0, 1, 0.7f, 1));
        return new Tuple<bool, GameObject>(true, newBaloon);
    }

    private void throwObject(GameObject balloon)
    {
        Debug.Log("Thrown baloon");
        float posXDiff = player.transform.position.x - balloon.transform.position.x;
        float posYDiff = throwYConstant*(balloon.transform.position.y - player.transform.position.y);
        Vector3 throwDirection = new Vector3(posXDiff, posYDiff, throwForce);
        balloon.GetComponent<Rigidbody>().AddForce(throwDirection, ForceMode.Impulse);
    }

    public double getRandomNumber(double minimum, double maximum)
    {
        System.Random random = new System.Random();
        return random.NextDouble() * (maximum - minimum) + minimum;
    }

    public void setEasyDifficulty()
    {
        throwForce = 60;
        inBetweenPause = 2;
        throwYConstant = -0.1f;
        Vector3 scale = new Vector3(2,2,2);
        baloon.transform.localScale = scale;
    }

    public void setHardDifficulty()
    {
        throwForce = 100;
        inBetweenPause = 1.3f;
        throwYConstant = -0.1f;
        Vector3 scale = new Vector3(0.7f, 0.7f, 0.7f);
        baloon.transform.localScale = scale;
    }
}
