using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "path")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "arch")
        {
            Destroy(other.gameObject);
        }
    }
}
