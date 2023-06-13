using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    Animator anim;
    public int HP;
    CapsuleCollider coll;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);

        if (HP == 0) 
        {
            anim.SetTrigger("die");
            agent.speed = 0;
            coll.enabled = false;
            Destroy(gameObject, 5);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP--;
        }


    }
}
