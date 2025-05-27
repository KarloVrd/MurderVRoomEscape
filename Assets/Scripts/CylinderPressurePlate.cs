using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderPressurePlate : MonoBehaviour
{
    [SerializeField] private string requiredCylinderID = "Activator3";
    public bool isActivated = false;
    public DoorOpen door;
    [SerializeField] private GameObject minerHat;

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
        //dodaj resetiranje - kada se objekt makne s pressure platea se on deaktivira
        isActivated = true;
        Debug.Log("Sphere Pressure Plate Activated!");

        
        if (minerHat != null)
        {
            minerHat.SetActive(true);
        }
        

        // Optional: Visual or gameplay feedback
        GetComponent<Renderer>().material.color = Color.cyan;
        door.open();
    }

    public void DeactivatePlate()
    {
        isActivated = false;
        Debug.Log("Pressure Plate Deactivated!");

        if (minerHat != null)
        {
            minerHat.SetActive(false);
        }

        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = Color.gray;
        }
        door.close();
    }
}
