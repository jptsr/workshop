using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    private float _passingTime = 0f;
    private float _limit1 = 10f;
    private float _limit2 = 20f;

    // Update is called once per frame
    void Update()
    {
        _passingTime += Time.deltaTime;

        if (_passingTime >= 0f && _passingTime <= _limit1)
        {
            transform.position += new Vector3(0, 0.2f * Time.deltaTime, 0);
        } 
        else if (_passingTime > _limit1 && _passingTime <= _limit2)
        {
            transform.position -= new Vector3(0, 0.2f * Time.deltaTime, 0);
        }
        else if (_passingTime > 20f)
        {
            _passingTime = 0f;
        }
    }
}
