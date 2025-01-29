using UnityEngine;
using UnityEngine.AI;

public class Rabbit : MonoBehaviour
{
    public float maxHealth = 50f;
    public float currentHealth;
    public float healthReductionRate = 0.5f;
    public float healthGainOnEatMin = 10f;
    public float healthGainOnEatMax = 20f;
    public float eatDistance = 1f;
    public float maxSightDistance = 15f;
    public float wanderRadius = 8f;
    public float wanderTimer = 5f;
    public float maxLifetimeMin = 45f;
    public float maxLifetimeMax = 75f;
    public float minSpeed = 2.5f; // Minimum speed of the rabbit
    public float maxSpeed = 4.5f; // Maximum speed of the rabbit

    private NavMeshAgent agent;
    private GameObject targetFood;
    private GameObject closestFox;
    private float timer;
    private float lifetimeTimer;
    private float maxLifetime;
    private float currentSpeed; // Current speed of the rabbit

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

        closestFox = FindClosestFox();

        // If a fox is too close, run away
        if (closestFox != null && Vector3.Distance(transform.position, closestFox.transform.position) < maxSightDistance)
        {
            RunAwayFromFox();
            timer = wanderTimer; // Reset wander timer
        }
        else
        {
            // No immediate danger, look for food or wander
            if (targetFood == null || !targetFood.activeInHierarchy)
            {
                targetFood = FindClosestFood();
            }

            if (targetFood != null)
            {
                agent.SetDestination(targetFood.transform.position);
                if (Vector3.Distance(transform.position, targetFood.transform.position) <= eatDistance)
                {
                    EatFood();
                }
                timer = wanderTimer;
            }
            else
            {
                Wander();
            }
        }
    }

    void ReduceHealth()
    {
        currentHealth -= healthReductionRate;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
    }

    void EatFood()
    {
        // Destroy the food
        Destroy(targetFood);
        targetFood = null;
        agent.ResetPath();

        // Gain health
        float healthGain = Random.Range(healthGainOnEatMin, healthGainOnEatMax);
        currentHealth += healthGain;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        lifetimeTimer = 0f; // Reset lifetime timer after eating (optional)
    }

    GameObject FindClosestFood()
    {
        GameObject[] foodObjects = GameObject.FindGameObjectsWithTag("Food");
        GameObject closestFood = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject food in foodObjects)
        {
            float distanceToFood = Vector3.Distance(transform.position, food.transform.position);
            if (distanceToFood < closestDistance)
            {
                if (HasPathTo(food))
                {
                    closestDistance = distanceToFood;
                    closestFood = food;
                }
            }
        }

        return closestFood;
    }

    GameObject FindClosestFox()
    {
        GameObject[] foxes = GameObject.FindGameObjectsWithTag("Fox");
        GameObject closestFox = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject fox in foxes)
        {
            float distanceToFox = Vector3.Distance(transform.position, fox.transform.position);
            if (distanceToFox < closestDistance)
            {
                closestDistance = distanceToFox;
                closestFox = fox;
            }
        }

        return closestFox;
    }

    void RunAwayFromFox()
    {
        if (closestFox != null)
        {
            // Set speed to max when running away
            agent.speed = maxSpeed;

            // Calculate the direction away from the fox
            Vector3 runDirection = transform.position - closestFox.transform.position;

            // Use NavMesh sampling to find a valid point in the run direction
            NavMeshHit hit;
            if (NavMesh.SamplePosition(transform.position + runDirection, out hit, maxSightDistance, NavMesh.AllAreas))
            {
                // Set the destination to the sampled point
                agent.SetDestination(hit.position);
            }
        }
        else
        {
            // Reset to normal speed if no fox is detected
            SetRandomSpeed();
        }
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

    bool HasPathTo(GameObject target)
    {
        NavMeshPath path = new NavMeshPath();
        if (agent.CalculatePath(target.transform.position, path))
        {
            return path.status == NavMeshPathStatus.PathComplete;
        }
        return false;
    }

    void SetRandomSpeed()
    {
        currentSpeed = Random.Range(minSpeed, maxSpeed);
        agent.speed = currentSpeed;
    }

// In your Rabbit script:

void Die()
{
    // Decrement the rabbit count in the GameManager
    if (LifeGameManager.Instance != null)
    {
        LifeGameManager.Instance.DecrementRabbitCount();
    }

    Destroy(gameObject);
}
}