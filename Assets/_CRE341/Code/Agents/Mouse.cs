using Unity.Mathematics;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public float maxSpeed;
    public float maxSight;

    public float wanderSpeed;
    public float wanderTime;
    private float timeToChangeDirection = 0;
    private Vector3 randomDirection;
    private Transform closestCatPosition = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // iterate through all cats in CatMiceGameManager.Instance.catList
        // find the closest cat and move directly away from it 

        foreach (GameObject cat in CatMiceGameManager.Instance.catList)
        {
            // debug/log 
            // Debug.Log(cat.transform.position);
            
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

            // Debug.Log("cat at this distance " + distance.magnitude);

            if (distance.magnitude < maxSight)
            {
                Debug.Log("cat within sight");
                // normalise distance over maxSight
                float distScaled = distance.magnitude/maxSight; 
                // get flee distance value from CatMiceGameManager.Instance.fleeDistanceCurve
                float fleeDistance = CatMiceGameManager.Instance.fleeDistanceCurve.Evaluate(distScaled);

                                transform.position += direction.normalized * fleeDistance * maxSpeed * Time.deltaTime;
                            }
                            else
                            {
                                // move randomly
                                // move randomly
                                if (timeToChangeDirection <= 0)
                                {
                                    float x = UnityEngine.Random.Range(-1.0f, 1.0f);
                                    float z = UnityEngine.Random.Range(-1.0f, 1.0f);
                                    randomDirection = new Vector3(x, 0, z);
                                    timeToChangeDirection = wanderTime;
                                }
                                transform.position += randomDirection.normalized * wanderSpeed * Time.deltaTime;
                                timeToChangeDirection -= Time.deltaTime;
                            }
                            
                        }
                    }

                }
