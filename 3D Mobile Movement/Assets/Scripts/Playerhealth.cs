using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhealth : MonoBehaviour
{  
    private int health = 1; 
    
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject); 

            health--;
            
            if (health <= 0)
            Destroy(gameObject); 
        }
    }
}