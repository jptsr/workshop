using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
