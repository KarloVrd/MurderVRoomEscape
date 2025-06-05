using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class SceneFeedbackManager : MonoBehaviour
{
    public static SceneFeedbackManager Instance;

    public GameObject canvas;
    public TextMeshProUGUI feedbackText;
    public GameObject blackoutSphere; // nova referenca na crnu sferu

    public float displayTime = 3f;
    public float restartDelay = 2f;

    private void Awake()
    {
        Instance = this;
        canvas.SetActive(false);

        if (blackoutSphere != null)
        {
            blackoutSphere.SetActive(false); // ugasi sferu na startu
        }
    }

    public void ShowFeedback(string message)
    {
        StartCoroutine(ShowFeedbackRoutine(message));
    }

    private IEnumerator ShowFeedbackRoutine(string message)
    {
        // Prikaži tekst
        canvas.SetActive(true);
        feedbackText.text = message;

        // Pričekaj neko vrijeme
        yield return new WaitForSeconds(displayTime);

        // Aktiviraj blackout sferu
        if (blackoutSphere != null)
        {
            blackoutSphere.SetActive(true);
        }

        // Pričekaj prije restarta
        yield return new WaitForSeconds(restartDelay);

        // Reset scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
