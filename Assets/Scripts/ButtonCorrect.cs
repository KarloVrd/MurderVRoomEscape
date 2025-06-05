using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ButtonCorrect : MonoBehaviour
{
    public GameObject objectToChange;
    public SceneFeedbackManager feedbackManager;

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
        Debug.Log("Točan odgovor!");

        if (objectToChange != null)
        {
            Renderer rend = objectToChange.GetComponent<Renderer>();
            if (rend != null)
            {
                Color newColor = new Color(0f, 1f, 0f, 0.4f); // zeleno
                rend.material.color = newColor;
            }
        }

        SceneFeedbackManager.Instance.ShowFeedback(
    "Točno!\nUspješno ste pronašli ubojicu!\nMožete ponovno pokušati biti detektiv!");

    }

}
