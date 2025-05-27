using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderPressurePlate : MonoBehaviour
{
    public AudioSource impactSound;
    private bool hasPlayed = false; // To prevent multiple plays

    [SerializeField] private string requiredCylinderID = "Activator3";
    public bool isActivated = false;
    public DoorOpen door;
    [SerializeField] private GameObject bucket;
    [SerializeField] private GameObject showerCap;
    private Vector3 originalBucketPosition;
    private Quaternion originalBucketRotation;

    private void Start()
    {
        if (bucket != null)
        {
            originalBucketPosition = bucket.transform.position;
            originalBucketRotation = bucket.transform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated) return;

        var idComponent = other.GetComponent<CylinderIdentifier>();
        if (idComponent != null && idComponent.cylinderID == requiredCylinderID)
        {
            ActivatePlate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var idComponent = other.GetComponent<CylinderIdentifier>();
        if (idComponent != null && idComponent.cylinderID == requiredCylinderID)
        {
            DeactivatePlate();
        }
    }

    private void ActivatePlate()
    {
        isActivated = true;
        Debug.Log("Sphere Pressure Plate Activated!");

        if (hasPlayed == false)
        {
            PlayImpactSound();
        }
        
        if (showerCap != null)
        {
            showerCap.SetActive(true);
        }
        

        if (bucket != null)
        {
            Vector3 currentRotation = bucket.transform.eulerAngles;
            bucket.transform.eulerAngles = new Vector3(-39.73f, -23f, -74.43f);

            // end position = (-9.87, 0.135, 3.16)
            bucket.transform.position = originalBucketPosition + (new Vector3(0.56f, -0.9f, 0f));

        }


        // Optional: Visual or gameplay feedback
        GetComponent<Renderer>().material.color = Color.green;
        door.open();
    }

    public void DeactivatePlate()
    {
        isActivated = false;
        Debug.Log("Pressure Plate Deactivated!");
        
        /*
        if (showerCap != null)
        {
            showerCap.SetActive(false);
        }
        

        if (bucket != null)
        {
            bucket.transform.position = originalBucketPosition;
            bucket.transform.rotation = originalBucketRotation;

        }
        */

        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = Color.gray;
        }
        if (door.doorOpened)
        {
            door.close();
        }
    }
    //plays the sound of the bucket falling
    void PlayImpactSound()
    {
        if (impactSound != null)
        {
            impactSound.Play();
            hasPlayed = true;
        }
    }

}
