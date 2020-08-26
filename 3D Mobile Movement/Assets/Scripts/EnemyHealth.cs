using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{  
    [SerializeField]
    public float lives = 1f;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            lives--;
        }
               
        if (lives == 0) 
        {
            Destroy(other.gameObject); 
        }

    }
}
