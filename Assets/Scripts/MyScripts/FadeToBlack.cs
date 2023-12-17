using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeToBlack : MonoBehaviour
{
    private Image fadePanel; // UI Panel Image used for fading
    public float fadeDuration = 2f; // Duration of the fade-out effect
    public float imageDisplayDuration = 3f; // Duration to display each image

    void Start()
    {
        fadePanel = GetComponent<Image>();
        // Display three images before starting the fade-out
        StartCoroutine(DisplayImages());
    }

    IEnumerator DisplayImages()
    {
        yield return new WaitForSeconds(imageDisplayDuration);
        // Display Image 1 (you can replace this with your own logic)

        yield return new WaitForSeconds(imageDisplayDuration);
        // Display Image 2

        yield return new WaitForSeconds(imageDisplayDuration);
        // Display Image 3

        // Start the fade-out process after displaying three images
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;

        // Initialize color
        Color color = fadePanel.color;
        color.a = 0f;
        fadePanel.color = color;

        // Fade-out process
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadePanel.color = color;
            yield return null;
        }

        // Load the next scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
