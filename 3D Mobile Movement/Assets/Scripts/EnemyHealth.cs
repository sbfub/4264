using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{  
    private int health = 1; 
    
    private void OnTriggerEnter3D(Collider collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); 

            health--;
            
            if (health <= 0)
            Destroy(gameObject); 
        }
    }
}