using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(-250f * Time.deltaTime, 0, 0));
    }
}
