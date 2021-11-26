using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] createdObjects;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(createdObjects[Random.Range(0, createdObjects.Length)], transform.position, Quaternion.identity);
        StartCoroutine(createObject());
    }

    IEnumerator createObject()
    {
        yield return new WaitForSeconds(2);
        Instantiate(createdObjects[Random.Range(0, createdObjects.Length)], transform.position, Quaternion.identity);
        StartCoroutine(createObject());
    }
}
