using UnityEngine;
using UnityEngine.AI;

public class Fox : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float healthReductionRate = 1f;
    public float healthGainOnEatMin = 15f;
    public float healthGainOnEatMax = 25f;
    public float eatDistance = 1.5f;
    public float maxSightDistance = 20f;
    public float wanderRadius = 10f;
    public float wanderTimer = 5f;
    public float maxLifetimeMin = 90f;
    public float maxLifetimeMax = 150f;
    public float minSpeed = 3.5f; // Minimum speed of the fox
    public float maxSpeed = 5.5f; // Maximum speed of the fox

    private NavMeshAgent agent;
    private GameObject targetRabbit;
    private float timer;
    private float lifetimeTimer;
    private float maxLifetime;
    private float currentSpeed;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        timer = wanderTimer;
        lifetimeTimer = 0f;
        maxLifetime = Random.Range(maxLifetimeMin, maxLifetimeMax);

        // Set initial random speed
        SetRandomSpeed();

        // Start reducing health over time
        InvokeRepeating("ReduceHealth", 1f, 1f);
    }

    void Update()
    {
        lifetimeTimer += Time.deltaTime;

        if (currentHealth <= 0 || lifetimeTimer >= maxLifetime)
        {
            Die();
            return;
        }

        if (targetRabbit == null || !targetRabbit.activeInHierarchy)
        {
            targetRabbit = FindClosestRabbit();
        }

        if (targetRabbit != null)
        {
            // Set speed to max when chasing
            agent.speed = maxSpeed;

            agent.SetDestination(targetRabbit.transform.position);

            if (Vector3.Distance(transform.position, targetRabbit.transform.position) <= eatDistance)
            {
                EatRabbit();
            }
            timer = wanderTimer;
        }
        else
        {
            Wander();
        }
    }

    void ReduceHealth()
    {
        currentHealth -= healthReductionRate;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
    }

    void EatRabbit()
    {
        Destroy(targetRabbit);
        LifeGameManager.Instance.DecrementRabbitCount();
        targetRabbit = null;
        agent.ResetPath();

        float healthGain = Random.Range(healthGainOnEatMin, healthGainOnEatMax);
        currentHealth += healthGain;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        lifetimeTimer = 0f;
    }

    GameObject FindClosestRabbit()
    {
        GameObject[] rabbits = GameObject.FindGameObjectsWithTag("Rabbit");
        GameObject closestRabbit = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject rabbit in rabbits)
        {
            float distanceToRabbit = Vector3.Distance(transform.position, rabbit.transform.position);

            if (distanceToRabbit < closestDistance && distanceToRabbit <= maxSightDistance)
            {
                if (HasPathTo(rabbit))
                {
                    closestDistance = distanceToRabbit;
                    closestRabbit = rabbit;
                }
            }
        }

        return closestRabbit;
    }

    bool HasPathTo(GameObject target)
    {
        NavMeshPath path = new NavMeshPath();
        if (agent.CalculatePath(target.transform.position, path))
        {
            return path.status == NavMeshPathStatus.PathComplete;
        }
        return false;
    }

    void Wander()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            // Reset to normal speed when wandering
            SetRandomSpeed();

            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }

    void SetRandomSpeed()
    {
        currentSpeed = Random.Range(minSpeed, maxSpeed);
        agent.speed = currentSpeed;
    }

// In your Fox script:

void Die()
{
    // Decrement the fox count in the GameManager
    if (LifeGameManager.Instance != null)
    {
        LifeGameManager.Instance.DecrementFoxCount();
    }

    Destroy(gameObject);
}
}