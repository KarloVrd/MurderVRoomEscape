using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePressurePlate : MonoBehaviour
{
    [SerializeField] private string requiredCubeID = "Activator";
    public bool isActivated = false;
    public DoorOpen door;

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated) return;

        var idComponent = other.GetComponent<CubeIdentifier>();
        if (idComponent != null && idComponent.cubeID == requiredCubeID)
        {
            ActivatePlate();
        }
    }

    private void ActivatePlate()
    {
        //dodaj resetiranje - kada se objekt makne s pressure platea se on deaktivira
        isActivated = true;
        Debug.Log("Cube Pressure Plate Activated!");

        // Optional: Visual or gameplay feedback
        GetComponent<Renderer>().material.color = Color.green;
        door.open();
    }
}

