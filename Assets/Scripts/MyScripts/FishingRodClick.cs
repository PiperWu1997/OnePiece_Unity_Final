using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FishingRodClick : MonoBehaviour
{
    public Transform characterTransform;
    public string animationTriggerName;
    public GameObject yugan;
    public AudioClip clickSound;
    public AudioClip fishSound;
    public AudioClip shoeSound; // New field for the shoe sound effect

    public GameObject fish1;
    public GameObject fish2;
    public GameObject shoe;
    public GameObject recordPicture;
    public GameObject continueBtn;
    public GameObject blackImg;

    public Transform fishPosition;

    private Animator characterAnimator;
    private bool isFishing;
    private int fishCount;

    private AudioSource audioSource;

    public GameObject cameraObj;
    public Transform cameraTarget;
    public float moveDuration = 2f;
    public float smoothTime = 0.3F;

    private void Start()
    {
        characterAnimator = characterTransform.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isFishing)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    isFishing = true;

                    if (audioSource != null && clickSound != null)
                    {
                        audioSource.PlayOneShot(clickSound);
                    }

                    yugan.SetActive(true);
                    characterTransform.position = fishPosition.position;
                    characterTransform.rotation = Quaternion.Euler(0f, 120f, 0f);
                    characterTransform.GetComponent<ChaController>().enabled = false;

                    characterAnimator.SetTrigger(animationTriggerName);
                    fishCount += 1;
                    StartCoroutine(WaitAndExecute());
                }
            }
        }

        if (blackImg.GetComponent<Image>().color.a >= 0.99)
            SceneManager.LoadScene("Scene2");
    }

    IEnumerator WaitAndExecute()
    {
        yield return new WaitForSeconds(6);

        if (isFishing)
        {
            isFishing = false;
            yugan.SetActive(false);
            characterTransform.GetComponent<ChaController>().enabled = true;
            StartCoroutine(MoveCameraToTarget());
            if (fishCount == 1)
            {
                fish1.SetActive(true);

                if (audioSource != null && fishSound != null)
                {
                    audioSource.PlayOneShot(fishSound);
                }
            }
            else if (fishCount == 2)
            {
                fish2.SetActive(true);

                if (audioSource != null && fishSound != null)
                {
                    audioSource.PlayOneShot(fishSound);
                }
            }
            else if (fishCount == 3)
            {
                shoe.SetActive(true);

                // Play the shoe sound
                if (audioSource != null && shoeSound != null)
                {
                    audioSource.PlayOneShot(shoeSound);
                }

                yield return new WaitForSeconds(2.6f);
                recordPicture.SetActive(true);
                continueBtn.SetActive(true);
            }
            else
            {
                // Handle other cases
            }
        }
    }

    IEnumerator MoveCameraToTarget()
    {
        cameraObj.GetComponent<CameraFollow>().enabled = false;
        float elapsedTime = 0f;
        Vector3 originalPosition = transform.position;

        Quaternion originalRotation = cameraObj.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(70f, originalRotation.eulerAngles.y, originalRotation.eulerAngles.z);

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;

            cameraObj.transform.position = Vector3.Lerp(originalPosition, cameraTarget.position, elapsedTime / moveDuration);
            cameraObj.transform.rotation = Quaternion.Slerp(originalRotation, targetRotation, elapsedTime / moveDuration);

            yield return null;
        }

        cameraObj.transform.position = cameraTarget.position;
        cameraObj.transform.rotation = targetRotation;

        yield return new WaitForSeconds(2);

        elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;

            cameraObj.transform.rotation = Quaternion.Slerp(targetRotation, originalRotation, elapsedTime / moveDuration);

            yield return null;
        }

        cameraObj.transform.rotation = originalRotation;
        cameraObj.GetComponent<CameraFollow>().enabled = true;
    }

    public void SetBlackImg()
    {
        blackImg.SetActive(true);
    }
}
