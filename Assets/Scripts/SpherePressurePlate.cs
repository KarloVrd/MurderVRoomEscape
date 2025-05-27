using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePressurePlate : MonoBehaviour
{
    public AudioSource impactSound;
    private bool hasPlayed = false; // To prevent multiple plays

    [SerializeField] private string requiredSphereID = "Activator2";
    public bool isActivated = false;
    public DoorOpen door;
    [SerializeField] private GameObject moustache;
    [SerializeField] private GameObject picture;
    private Vector3 originalPicturePosition;
    private Quaternion originalPictureRotation;

    private void Start()
    {
        if (picture != null)
        {
            originalPicturePosition = picture.transform.position;
            originalPictureRotation = picture.transform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated) return;

        var idComponent = other.GetComponent<SphereIdentifier>();
        if (idComponent != null && idComponent.sphereID == requiredSphereID)
        {
            ActivatePlate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var idComponent = other.GetComponent<SphereIdentifier>();
        if (idComponent != null && idComponent.sphereID == requiredSphereID)
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

        if (moustache != null)
        {
            moustache.SetActive(true);
        }

        if (picture != null)
        {
            Vector3 currentRotation = picture.transform.eulerAngles;
            picture.transform.eulerAngles = new Vector3(currentRotation.x, 90f, currentRotation.z);

            picture.transform.position = originalPicturePosition - (new Vector3(0f,0f,0.59f));

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
        if (moustache != null)
        {
            moustache.SetActive(false);
        }

        if (picture != null)
        {
            picture.transform.position = originalPicturePosition;
            picture.transform.rotation = originalPictureRotation;

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
