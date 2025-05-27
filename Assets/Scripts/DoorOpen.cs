using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public CubePressurePlate pressurePlateCube;
    public SpherePressurePlate pressurePlateSphere;
    public CylinderPressurePlate pressurePlateCylinder;

    private bool doorOpened = false;

    public void open()
    {
        if (!doorOpened && pressurePlateCube.isActivated && pressurePlateSphere.isActivated && pressurePlateCylinder.isActivated)
        {
            doorOpened = true;
            Debug.Log("All plates activated - opening door!");

            Vector3 currentRotation = transform.eulerAngles;
            transform.eulerAngles = new Vector3(currentRotation.x, 165.36f, currentRotation.z);
        }
    }
    
}
