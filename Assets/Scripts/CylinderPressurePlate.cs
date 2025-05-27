using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderPressurePlate : MonoBehaviour
{
    [SerializeField] private string requiredCylinderID = "Activator3";
    public bool isActivated = false;
    public DoorOpen door;

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated) return;

        var idComponent = other.GetComponent<CylinderIdentifier>();
        if (idComponent != null && idComponent.cylinderID == requiredCylinderID)
        {
            ActivatePlate();
        }
    }

    private void ActivatePlate()
    {
        //dodaj resetiranje - kada se objekt makne s pressure platea se on deaktivira
        isActivated = true;
        Debug.Log("Sphere Pressure Plate Activated!");

        // Optional: Visual or gameplay feedback
        GetComponent<Renderer>().material.color = Color.cyan;
        door.open();
    }
}
