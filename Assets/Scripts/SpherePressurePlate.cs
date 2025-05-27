using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePressurePlate : MonoBehaviour
{
    [SerializeField] private string requiredSphereID = "Activator2";
    public bool isActivated = false;
    public DoorOpen door;
    [SerializeField] private GameObject magicHat;

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated) return;

        var idComponent = other.GetComponent<SphereIdentifier>();
        if (idComponent != null && idComponent.sphereID == requiredSphereID)
        {
            ActivatePlate();
        }
    }

    private void ActivatePlate()
    {
        //dodaj resetiranje - kada se objekt makne s pressure platea se on deaktivira
        isActivated = true;
        Debug.Log("Sphere Pressure Plate Activated!");

        if (magicHat != null)
        {
            magicHat.SetActive(true);
        }

        // Optional: Visual or gameplay feedback
        GetComponent<Renderer>().material.color = Color.cyan;
        door.open();
    }
}
