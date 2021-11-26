using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeActivator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "cube" || other.gameObject.tag == "sphere")
        {
            //gameObject.GetComponent<BoxCollider>().enabled = false;
            //StartCoroutine(colliderActivator());
            other.gameObject.GetComponent<Swipe>().canSwipe = true;
        }
    }

    IEnumerator colliderActivator()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
