using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class UIInitializer : MonoBehaviour
{
    public GameObject menuOptions;
    public VideoPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(hideOptions());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator hideOptions()
    {
        menuOptions.SetActive(false);
        yield return new WaitUntil(() => player.time > 3.3f);
        menuOptions.SetActive(true);
    }
}
