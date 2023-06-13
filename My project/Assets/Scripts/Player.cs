using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public int HpPlayer;
    public GameObject keyAdvertention;
    public GameObject area;
    bool withKey;
    public GameObject door;
    public GameObject key;
    public GameObject text;
    public GameObject g1;
    public GameObject g2;
    public GameObject g3;

    public GameObject g4;

    public GameObject g5;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        /*
        float MovementHorizontal = Input.GetAxis("Horizontal");
        float MovementVertical = Input.GetAxis("Vertical");
        Vector3 VectorMovement = new Vector3(MovementHorizontal, 0.0f, MovementVertical);
        rb.AddForce(VectorMovement * speed);
        */

        if (HpPlayer == 0)
        {
            SceneManager.LoadScene(3);
        }    
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("Door") && withKey == true)
        {
            door.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("area"))      
        {
            keyAdvertention.SetActive(true);
        }

        if (other.gameObject.CompareTag("firs"))
        {
            text.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("area"))
        {
            keyAdvertention.SetActive(false);
        }

        if (other.gameObject.CompareTag("firs"))
        {
            text.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("key"))
        {
            withKey = true;
            key.SetActive(false);
           area.SetActive(false);
        }

        if (other.gameObject.CompareTag("win"))
        {
            SceneManager.LoadScene(2);
        }

        if (other.gameObject.CompareTag("Grupo1"))
        {
            g1.SetActive(true);
        }

        if (other.gameObject.CompareTag("grupo2"))
        {
            g2.SetActive(true);
        }
        if(other.gameObject.CompareTag("g3"))
        {
            g3.SetActive(true);
        }
        if(other.gameObject.CompareTag("g4"))
        {
            g4.SetActive(true);
        }
        if(other.gameObject.CompareTag("g5"))
        {
            g5.SetActive(true);
        }


    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HpPlayer--;
        }
    }
}
