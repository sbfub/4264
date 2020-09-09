using UnityEngine;

public class Playerhealth : MonoBehaviour
{ 
void OnCollisionEnter(Collision other)
{
    if(other.gameObject.CompareTag("EnemyBullet"))
    {
        Debug.Log("shit"); 
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
}
