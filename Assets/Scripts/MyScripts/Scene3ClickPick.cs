using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3ClickPick : MonoBehaviour
{
    public GameObject character;
    public int PickCount = 0;
    public int maxPickCount = 5;

    public float maxPickDistance = 1f; // Maximum distance for the pick action

    private Animator characterAnimator;
    private GameObject pickGameObject;

    public GameObject Image;
    public GameObject Btn;

    private void Start()
    {
        characterAnimator = character.GetComponent<Animator>();

        if (characterAnimator == null)
        {
            Debug.LogError("Character Animator not found. Make sure 'character' is properly assigned.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "yezi" && IsPlayerCloseEnough(hit.collider.gameObject.transform.position))
                {
                    StartCoroutine(PickUp(hit.collider.gameObject));
                }
            }
        }
    }

    bool IsPlayerCloseEnough(Vector3 targetPosition)
    {
        if (character != null)
        {
            float distance = Vector3.Distance(character.transform.position, targetPosition);
            return distance <= maxPickDistance;
        }
        else
        {
            Debug.LogError("Character GameObject is not assigned. Assign 'character' in the Inspector.");
            return false;
        }
    }

    IEnumerator PickUp(GameObject pickedObject)
    {
        if (PickCount < maxPickCount)
        {
            PickCount++;
            characterAnimator.SetTrigger("Pick");
            character.GetComponent<ChaController>().enabled = false;
            yield return new WaitForSeconds(4.5f);

            if (pickedObject != null)
            {
                pickedObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Trying to deactivate a null object. Make sure 'pickedObject' is not null.");
            }

            if (character != null)
            {
                character.GetComponent<ChaController>().enabled = true;
            }
            else
            {
                Debug.LogError("Character GameObject is not assigned. Assign 'character' in the Inspector.");
            }

            if (PickCount == maxPickCount)
            {
                if (Image != null)
                {
                    Image.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("Image GameObject is not assigned. Assign 'Image' in the Inspector.");
                }

                if (Btn != null)
                {
                    Btn.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("Btn GameObject is not assigned. Assign 'Btn' in the Inspector.");
                }
            }
        }
    }
}
