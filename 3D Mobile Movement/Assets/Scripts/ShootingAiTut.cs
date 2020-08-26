﻿
using UnityEngine;
using UnityEngine.AI;
public class ShootingAiTut : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    

    //Stats
    public int health;

    //Check for Ground/Obstacles
    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //Attack Player
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public bool isDead;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Special
   
    public GameObject projectile;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (!isDead)
        {
            //Check if Player in sightrange
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

            //Check if Player in attackrange
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!playerInSightRange && !playerInAttackRange) Patroling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInAttackRange && playerInSightRange) AttackPlayer();
        }
    }

    private void Patroling()
    {
        if (isDead) return;

        if (!walkPointSet) SearchWalkPoint();

        //Calculate direction and walk to Point
        if (walkPointSet){
            agent.SetDestination(walkPoint);

            //Vector3 direction = walkPoint - transform.position;
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.15f);
        }

        //Calculates DistanceToWalkPoint
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

        
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint,-transform.up, 2,whatIsGround))
        walkPointSet = true;
    }
    private void ChasePlayer()
    {
        if (isDead) return;

        agent.SetDestination(player.position);

        
    }
    
    public Transform attackPosition;

    private void AttackPlayer()
    {
        if (isDead) return;

        //Make sure enemy doesn't move
        agent.SetDestination(attackPosition.position);

        attackPosition.LookAt(player);

        if (!alreadyAttacked){

            //Attack
            Rigidbody rb = Instantiate(projectile, attackPosition.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(attackPosition.forward * 32f, ForceMode.Impulse);
            rb.AddForce(attackPosition.up * 8, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke("ResetAttack", timeBetweenAttacks);
        }

       
    }
    private void ResetAttack()
    {
        if (isDead) return;

        alreadyAttacked = false;
    }
 

   
}
