using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_ReturnMain : MonoBehaviour
{
    // Start is called before the first frame update
    internal float currentTime = 0f;
    internal float startingTime = 10f;
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}