using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;


public class Bullet : MonoBehaviour
{
    public float velocity;

    public GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);

        Destroy(gameObject, 5f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(particle, transform.position, transform.rotation);
            Destroy(gameObject);
            // Destroy(particle, 3);

        }

    }

}
