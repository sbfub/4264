using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunPickUp : MonoBehaviour
{
    public joybutton2 joyButton;
    public float cooldownTime = 0.2f;

    public ProjectileGunTutorial gunScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;
    public bool cooldown;

    private void Start()
    {
        rb.isKinematic = false;

        //Setup
        if (!equipped)
        {
            gunScript.enabled = false;
            rb.useGravity = true;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            gunScript.enabled = true;
            rb.isKinematic = true;
            rb.useGravity = false;
            slotFull = true;
        }
    }

    private void Update()
    {
        //Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && joyButton.Pressed && !slotFull && !cooldown)
        {
            PickUp();
            cooldown = true;
            Invoke("ResetCooldown", cooldownTime);
        }

        //Drop if equipped and "Q" is pressed
        if (equipped && joyButton.Pressed && !cooldown)
        {
            Drop();
            cooldown = true;
            Invoke("ResetCooldown", cooldownTime);
        }
    }
    private void ResetCooldown()
    {
        cooldown = false;
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //Make weapon a child of the camera and move it to default position
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.useGravity = false;
        coll.isTrigger = true;

        //Enable script
        gunScript.enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        //Set parent to null
        transform.SetParent(null);

        //Make Rigidbody not kinematic and BoxCollider normal
        rb.useGravity = true;
        coll.isTrigger = false;

        //Gun carries momentum of player
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //AddForce
        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);
        //Add random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);

        //Disable script
        gunScript.enabled = false;
    }
}
