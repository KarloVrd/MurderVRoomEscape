using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ButtonWrong : MonoBehaviour
{
    public GameObject objectToChange;

    private Renderer objectRenderer;
    private Color originalColor;

    private void OnEnable()
    {
        GetComponent<XRBaseInteractable>().selectEntered.AddListener(OnButtonPressed);
    }

    private void OnDisable()
    {
        GetComponent<XRBaseInteractable>().selectEntered.RemoveListener(OnButtonPressed);
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        if (objectToChange == null) return;

        objectRenderer = objectToChange.GetComponent<Renderer>();
        if (objectRenderer == null) return;

        // Save the original color
        originalColor = objectRenderer.material.color;

        // Set to red with 40% transparency
        Color redTransparent = new Color(1f, 0f, 0f, 0.4f);
        objectRenderer.material.color = redTransparent;

        // Start coroutine to restore color
        StartCoroutine(RestoreOriginalColor());
    }

    private IEnumerator RestoreOriginalColor()
    {
        OnDisable();
        yield return new WaitForSeconds(2f);

        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor;
            OnEnable();
        }
    }
}
