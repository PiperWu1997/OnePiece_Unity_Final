using UnityEngine;

public class FloatingUI : MonoBehaviour
{
    public float floatStrength = 10f;
    public float floatSpeed = 5f;

    private Transform rectTransform;
    private Vector3 originalPosition;

    void Start()
    {
        rectTransform = GetComponent<Transform>();
        originalPosition = transform.position;
    }

    void Update()
    {
        float newY = originalPosition.y + (Mathf.Sin(Time.time * floatSpeed) * floatStrength);
        Vector3 newPosition = new Vector3(originalPosition.x, newY,originalPosition.z);

        transform.position = newPosition;
    }
}
