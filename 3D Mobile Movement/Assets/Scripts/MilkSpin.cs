using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkSpin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(transform.up * 40 * Time.deltaTime);
    }
}
