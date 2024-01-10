using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Atributes
    public float enemyLife = 100f;
    public float enemyMaxLife = 100f;
    public float enemyDamage = 10;

    //components
    [SerializeField] Animator anim;

    //AI Navigation
    public NavMeshAgent agent;
    public Transform[] targets;
    public int currentTarget = 0;
    public float pursuitRadius;
    private Transform playerReference;
    
    //Attack
    private BoxCollider hitBox;
    private bool canAtk;
    public float debuff;

    private void Awake()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        hitBox = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if(enemyLife > 0)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerReference.position);

            if (distanceToPlayer <= agent.stoppingDistance)
            {
                StartCoroutine(Attack());
            }
            else if (distanceToPlayer <= pursuitRadius)
            {
                Pursuit(playerReference);
            }
            else
            {
                Patrol();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Patrol()
    {
        Debug.Log("Patrulhando");
        agent.isStopped = false;
        if (!agent.pathPending && agent.remainingDistance < 1.5f)
            GotoNextPoint();
    }

    void Pursuit(Transform newTarget)
    {
        Debug.Log("Perseguindo");
        hitBox.enabled = false;
        anim.SetBool("walking", true);
        agent.SetDestination(newTarget.position);
    }

    IEnumerator Attack()
    {
        Debug.Log("Atacando");
        transform.LookAt(playerReference.position);
        hitBox.enabled = true;
        anim.SetBool("walking", false);
        anim.SetTrigger("attaking");
        hitBox.enabled = false;
        yield return new WaitForSeconds(5f);
        
    }

    public void GotoNextPoint()
    {
        anim.SetBool("walking", true);
        
        if (targets.Length <= 0)
            return;
        
        currentTarget += 1;

        if (currentTarget >= targets.Length)
            currentTarget = 0;
        
        agent.SetDestination(targets[currentTarget].position);
    }

    public void GetHit(float damage)
    {
        enemyLife -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag("Player"))
        {
            Player.instance.TakeDamage(enemyLife -debuff);
            Debug.Log(other.gameObject.name);
        }
    }
}