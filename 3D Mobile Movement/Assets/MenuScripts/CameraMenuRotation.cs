using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenuRotation : MonoBehaviour
{
    private Transform cameraTransform; 
    private Transform cameraDesiredLookAt;
    
    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }
    
    private void Update()
    {
        if(cameraDesiredLookAt != null)
        {
            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, cameraDesiredLookAt.rotation, 2 * Time.deltaTime);
        }
    } 


    public void LookAtMenu(Transform menuTransform)
    {
        cameraDesiredLookAt = menuTransform; 
    }       
}    
