using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePressurePlate : MonoBehaviour
{
    public AudioSource impactSound;
    private bool hasPlayed = false; // To prevent multiple plays

    [SerializeField] private string requiredCubeID = "Activator";
    public bool isActivated = false;
    public DoorOpen door;
    [SerializeField] private GameObject vikingHat;
    [SerializeField] private GameObject book;

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated) return;

        var idComponent = other.GetComponent<CubeIdentifier>();
        if (idComponent != null && idComponent.cubeID == requiredCubeID)
        {
            ActivatePlate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var idComponent = other.GetComponent<CubeIdentifier>();
        if (idComponent != null && idComponent.cubeID == requiredCubeID)
        {
            DeactivatePlate();
        }
    }

    private void ActivatePlate()
    {
        //dodaj resetiranje - kada se objekt makne s pressure platea se on deaktivira
        isActivated = true;
        Debug.Log("Cube Pressure Plate Activated!");

        if (hasPlayed == false)
        {
            PlayImpactSound();
        }

        /*
        if (vikingHat != null)
        {
            vikingHat.SetActive(true);
        }
        */

        if (book != null)
        {
            Animator anim = book.GetComponent<Animator>();
            anim.SetTrigger("PlaySlide");
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
        if (vikingHat != null)
        {
            vikingHat.SetActive(false);
        }
        
        if (book != null)
        {
            Vector3 newPos = book.transform.position;
            newPos.x = -4.4923f;
            book.transform.position = newPos;
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

