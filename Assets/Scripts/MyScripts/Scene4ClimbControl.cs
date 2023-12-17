using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4ClimbControl : MonoBehaviour
{
    public GameObject tree;
    public GameObject character; 
    public Vector3 climbIncrement = new Vector3(0, .5f, 0); 
    public int climbCount = 0;
    public int maxClimbCount = 12;

    public Transform treeTransform;
    private Animator characterAnimator;
    private bool isFirstClimb;

    private Vector3 targetPosition; 
    public float climbSpeed = 1f;

    public GameObject Image;
    public GameObject Btn;

    private void Start()
    {
        characterAnimator = character.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject == tree)
                {
                    if(!isFirstClimb)
                    {
                        character.transform.position = treeTransform.position;
                        character.transform.rotation = treeTransform.rotation;
                        characterAnimator.SetBool("Climb", true);
                        character.GetComponent<ChaController>().enabled = false;
                        character.GetComponent<CharacterController>().enabled = false;
                        character.GetComponent<Rigidbody>().isKinematic = true;
                        isFirstClimb = true;
                    }
                    StartCoroutine(ClimbTree());
                }
            }
        }

        if (character.transform.position != targetPosition)
        {
            character.transform.position = Vector3.MoveTowards(character.transform.position, targetPosition, climbSpeed * Time.deltaTime);
        }
    }

    IEnumerator ClimbTree()
    {
        if (climbCount < maxClimbCount)
        { 
            characterAnimator.speed = 1; 

            targetPosition = character.transform.position + climbIncrement;

            climbCount++;

            yield return new WaitForSeconds(1f); 

            characterAnimator.speed = 0; 

            if (climbCount == maxClimbCount)
            {
                yield return new WaitForSeconds(2f);
                Image.SetActive(true);
                Btn.SetActive(true);
            }
        }
    }
}
