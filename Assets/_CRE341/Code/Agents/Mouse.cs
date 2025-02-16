using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class Mouse : MonoBehaviour
{
    public float maxSpeed;
    public float maxSight;

    public float wanderSpeed;
    public float wanderTime;
    private float timeToChangeDirection = 0;
    private Vector3 randomDirection;
    private Transform closestCatPosition = null;

    public float desireability = 0;
    public float chaseTime = 0;
    private Rigidbody rb;
    private NavMeshAgent agent;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();

        // Ensure the NavMeshAgent is not null
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent not found on this GameObject.  Please add one.");
            enabled = false; // Disable this script to prevent further errors
            return;
        }

        agent.speed = wanderSpeed; // Set initial speed
    }

    void Update()
    {
        // Find the closest cat and move away from it using NavMeshAgent

        // Reset closestCatPosition at the beginning of each update
        closestCatPosition = null;

        foreach (GameObject cat in CatMiceGameManager.Instance.catList)
        {
            if (closestCatPosition == null)
            {
                closestCatPosition = cat.transform;
            }
            else
            {
                if (Vector3.Distance(transform.position, cat.transform.position) < Vector3.Distance(transform.position, closestCatPosition.position))
                {
                    closestCatPosition = cat.transform;
                }
            }
        }

        if (closestCatPosition != null)
        {
            Vector3 direction = transform.position - closestCatPosition.position;
            Vector3 distance = transform.position - closestCatPosition.position;

            if (distance.magnitude < maxSight)
            {
                // Calculate flee position
                Vector3 fleePosition = transform.position + direction.normalized * maxSight * 2; // Flee further than sight range

                // Move to flee position using NavMeshAgent
                agent.speed = maxSpeed;
                agent.SetDestination(fleePosition);
            }
            else if (timeToChangeDirection <= 0)
            {
                // Wander using NavMeshAgent
                Wander();
            }

            timeToChangeDirection -= Time.deltaTime;
        }
        else if (timeToChangeDirection <= 0)
        {
            // If no cat is in sight, wander
            Wander();
        }
        timeToChangeDirection -= Time.deltaTime;
    }

    void Wander()
    {
        // Generate a random point within a sphere and set it as the destination
        Vector3 randomPoint = UnityEngine.Random.insideUnitSphere * wanderTime;
        randomPoint += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, wanderTime, 1))
        {
            agent.speed = wanderSpeed;
            agent.SetDestination(hit.position);
            timeToChangeDirection = wanderTime;
        }
    }
}
