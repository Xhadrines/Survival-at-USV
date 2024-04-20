using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;

    private Vector2 input;

    private Animator animator;

    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;

    private void Awake() 
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // Debug.Log("This is input.x: " + input.x);
            // Debug.Log("This is input.y: " + input.y);

            if (input.x != 0)
                input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPosition = transform.position;

                targetPosition.x += input.x;
                targetPosition.y += input.y;

                if (IsWalkable(targetPosition))
                    StartCoroutine(Move(targetPosition));
            }
        }
        animator.SetBool("isMoving", isMoving);

        if (Input.GetKeyDown(KeyCode.Space))
            Interact();
    }

    void Interact()
    {
        var facingDirection = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPosition = transform.position + facingDirection;

        Debug.DrawLine(transform.position, interactPosition, Color.red, 1f);

        var collider = Physics2D.OverlapCircle(interactPosition, 0.2f, interactableLayer);

        if (collider != null)
            Debug.Log("This is an NPC!");
    }

    IEnumerator Move(Vector3 targetPosition)
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            yield return null;
        }

        transform.position = targetPosition;
        
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPosition)
    {
        if (Physics2D.OverlapCircle(targetPosition, 0.2f, solidObjectsLayer | interactableLayer) != null)
            return false;
            
        return true;
    }
}
