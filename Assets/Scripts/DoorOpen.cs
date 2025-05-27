using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public AudioSource impactSound;
    public AudioSource closeSound;
    private bool hasPlayed = false; // To prevent multiple plays

    public CubePressurePlate pressurePlateCube;
    public SpherePressurePlate pressurePlateSphere;
    public CylinderPressurePlate pressurePlateCylinder;

    public bool doorOpened = false;

    public void open()
    {
        if (!doorOpened && pressurePlateCube.isActivated && pressurePlateSphere.isActivated && pressurePlateCylinder.isActivated)
        {
            doorOpened = true;
            Debug.Log("All plates activated - opening door!");

            if (hasPlayed == false)
            {
                PlayImpactSound();
            }

            Vector3 currentRotation = transform.eulerAngles;
            transform.eulerAngles = new Vector3(currentRotation.x, 165.36f, currentRotation.z);
        }
    }

    public void close()
    {
        PlayCloseSound();
        doorOpened = false;
        Debug.Log("All plates activated - opening door!");

        Vector3 currentRotation = transform.eulerAngles;
        transform.eulerAngles = new Vector3(currentRotation.x, 90f, currentRotation.z);
    }

    void PlayImpactSound()
    {
        if (impactSound != null)
        {
            impactSound.Play();
            hasPlayed = true;
        }
    }
    void PlayCloseSound()
    {
        if (closeSound != null)
        {
            closeSound.Play();
            hasPlayed = false;
        }
    }

}
