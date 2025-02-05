using Unity.Mathematics;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public float maxSpeed = 1.0f;
    public float maxSight = 5.0f;
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

                transform.position += direction.normalized * fleeDistance * Time.deltaTime;
            }
            
        }
    }
}
