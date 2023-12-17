using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public Button startButton; // Reference to the start button
    public string nextSceneName;

    private int index;

    void Start()
    {
        textComponent.text = string.Empty;

        // Disable the start button initially
        startButton.gameObject.SetActive(false);

        StartCoroutine(ShowStartButtonDelayed());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        // Enable the start button when the dialogue is complete
        startButton.gameObject.SetActive(true);
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            // Do nothing here; wait for the start button click
        }
    }

    IEnumerator ShowStartButtonDelayed()
    {
        // Wait for a brief moment before showing the start button
        yield return new WaitForSeconds(1f);

        // Start the dialogue after the delay
        StartDialogue();
    }

    public void LoadNextScene()
    {
        // Check if the next scene name is not empty before trying to load
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            UnityEngine.Debug.LogError("Next scene name is not set!");
        }
    }
}
