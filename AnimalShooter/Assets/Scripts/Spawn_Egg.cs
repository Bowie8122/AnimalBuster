using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Egg : MonoBehaviour
{
    [SerializeField] private GameObject Egg;
    internal float currentTime = 0f;
    internal float startingTime;
    void Start()
    {
        startingTime = Random.Range(5, 60);
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0)
        {
            Instantiate(Egg, gameObject.transform.position + new Vector3(0, .5f, 0), Quaternion.identity);
            startingTime = Random.Range(5, 60);
            currentTime = startingTime;
        }
    }
}
