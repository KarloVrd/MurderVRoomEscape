using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ButtonWrong : MonoBehaviour
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
        Debug.Log("Netočan odgovor!");

        if (objectToChange != null)
        {
            Renderer rend = objectToChange.GetComponent<Renderer>();
            if (rend != null)
            {
                Color redTransparent = new Color(1f, 0f, 0f, 0.4f);
                rend.material.color = redTransparent;
            }
        }

        SceneFeedbackManager.Instance.ShowFeedback(
    "Netočan odgovor!\nPustili ste ubojicu na slobodu!\nKrenite ispočetka!");

    }
}
