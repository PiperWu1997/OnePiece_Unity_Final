using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public GameObject milkBottle; // Milk bottle GameObject
    public GameObject milk;       // Milk GameObject
    public GameObject milk2;      // Another state of milk
    public GameObject cat;        // Cat GameObject

    public GameObject blackImg;   // Black image GameObject
    public GameObject Btn;        // Button GameObject

    public Animator characterAnimator; // Reference to the character's Animator component

    private bool isClickMilk;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for mouse click
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject == milkBottle)
                {
                    // Trigger the "Pick" animation
                    characterAnimator.SetTrigger("Pick");

                    // Start the coroutine for further actions after a delay
                    StartCoroutine(DelayedAction());
                }
                else if (hit.collider.gameObject == milk && isClickMilk)
                {
                    // Rotate the cat and show another state of milk
                    cat.transform.Rotate(new Vector3(0, 1, 0), 90f);
                    milk2.SetActive(true);

                    // Start the coroutine for further actions
                    StartCoroutine(WaitCat());
                }
            }
        }
    }

    IEnumerator DelayedAction()
    {
        // Wait for the "Pick" animation to finish
        yield return new WaitForSeconds(4.5f);

        // Hide the milk bottle and show another state of milk
        milkBottle.SetActive(false);
        milk2.SetActive(true);

        isClickMilk = true;
    }

    IEnumerator WaitCat()
    {
        yield return new WaitForSeconds(2f);

        // Activate the specified UI elements
        blackImg.SetActive(true);
        Btn.SetActive(true);
    }
}
