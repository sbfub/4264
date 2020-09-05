using UnityEngine;

public class Playerhealth : MonoBehaviour
{
   public GameObject player;
   public GameObject panel;
   private int health = 1; 

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.SetActive(false);
            panel.SetActive (true);
            Destroy(other.gameObject);
        }
        
    }
}