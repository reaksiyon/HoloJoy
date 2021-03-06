using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform target;

    public LayerMask Ground, Player;

    public Animator anim;

    private Enemy enemy;

    public float MinInaccuracyTolerance, MaxInaccuracyTolerance;

    public new Rigidbody rigidbody;

    //Patroling
    public Vector3 walkPoint;

    bool walkPointSet;

    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;

    bool alreadyAttacked;

    public GameObject projectile;

    //States
    public float sightRange, attackRange;

    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        EnemyList.Add(this);

        enemy = GetComponent<Enemy>();

        SetRetarget();

        agent = GetComponent<NavMeshAgent>();
    }

    private void OnDestroy()
    {
        EnemyList.Remove(this);
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);

        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);


        if (!playerInSightRange && !playerInAttackRange) Patroling();

        if (playerInSightRange && !playerInAttackRange) ChasePlayer();

        if (playerInAttackRange && playerInSightRange) AttackPlayer();

    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);

            anim.SetBool("move", true);
        }
        
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;

            anim.SetBool("move", false);
        }
            
    }
    private void SearchWalkPointWhenAttacking()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        float randomX = Random.Range(-walkPointRange, walkPointRange);


        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, Ground))
        {
            walkPointSet = true;
        }

        Patroling();
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        float randomX = Random.Range(-walkPointRange, walkPointRange);


        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, Ground))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        anim.SetBool("move", true);

        if(target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    private void AttackPlayer()
    {
 
        if (!alreadyAttacked)
        {
            // Enemy Stop & Attack
            anim.SetBool("move", false);

            agent.SetDestination(transform.position);

            transform.LookAt(target);
            // Attack code
            anim.SetTrigger("attack");

            StartCoroutine(WaitAndDo(0.6f, CreateProjectile));
            // End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

            StartCoroutine(WaitAndDo(2, SearchWalkPointWhenAttacking));
        }

        
    }

    public void CreateProjectile()
    {
        var _projectile = Instantiate(projectile, transform.position + (Vector3.up * 2) + transform.forward, transform.rotation).GetComponent<IProjectile>();

        _projectile.CreateProjectile(enemy, transform.forward + (Vector3.right * Random.Range(MinInaccuracyTolerance, MaxInaccuracyTolerance)));
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void SetRetarget()
    {
        StartCoroutine(Retarget());
    }

    IEnumerator Retarget()
    {
        yield return new WaitForSeconds(1);
        target = GameObject.Find("Player(Clone)").transform;
    }

    IEnumerator WaitAndDo(float second, UnityAction action)
    {
        yield return new WaitForSeconds(second);

        action();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    public static List<EnemyAI> EnemyList = new List<EnemyAI>();
}
