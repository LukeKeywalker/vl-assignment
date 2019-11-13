using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float direction = 1;
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * 10 * direction, 0);
    }
}
