using UnityEngine;

public class ScaleTransition : MonoBehaviour
{
    public float minScale = 0.05f;
    public float maxScale = 0.13f;
    public float transitionDuration = 2f;
    private bool scalingUp = true;
    private float timer = 0f;

    void Update()
    {
        float scale = Mathf.Lerp(minScale, maxScale, timer / transitionDuration);

        transform.localScale = new Vector3(scale, scale, scale);

        if (scalingUp)
        {
            timer += Time.deltaTime;
            if (timer > transitionDuration)
            {
                scalingUp = false;
                timer = transitionDuration; 
            }
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                scalingUp = true;
                timer = 0;
            }
        }
    }
}
