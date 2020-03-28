using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch_Egg : MonoBehaviour
{
    [SerializeField] private GameObject Chick;
    internal float currentTime = 0f;
    internal float startingTime;
    void Start()
    {
        startingTime = Random.Range(2, 10);
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0)
        {
            Instantiate(Chick, gameObject.transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
