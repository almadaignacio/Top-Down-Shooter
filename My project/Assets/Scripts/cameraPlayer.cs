using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;

    private Transform characterTransform;
    private Camera mainCamera;
    private Rigidbody rb;

    Animator anim;
    private Vector3 movement;

    private Vector3 Movement
    {
        get { return movement; }
    }

    private void Awake()
    {
        characterTransform = GetComponent<Transform>();
        mainCamera = Camera.main;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        // Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, 0f, vertical)* moveSpeed * Time.deltaTime;
        characterTransform.Translate(movement, Space.World);

        rb.AddForce(movement *Time.deltaTime);

        /*
        if(movement.x > 0 && movement.y > 0)
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }
        */
        
        anim.SetFloat("movX",movement.x);
        anim.SetFloat("movY", movement.z);
        movement.Normalize();
        
        
        // Rotation
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = new Vector3(hit.point.x, characterTransform.position.y, hit.point.z);
            Vector3 direction = targetPosition - characterTransform.position;

            if (direction != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(direction);
                characterTransform.rotation = Quaternion.RotateTowards(characterTransform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + moveSpeed * Time.deltaTime * movement);

    }
}
