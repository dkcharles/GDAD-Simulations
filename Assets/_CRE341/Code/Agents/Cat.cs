using UnityEngine;
using System.Collections.Generic;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{

    float catMaxSight;
    float catMaxAngle; // degrees
    float catMaxChaseTime; 

    float mouseDistance = Mathf.Infinity;
    float mouseAngle = Mathf.Infinity;
    float mouseChaseTime = 0;

    public float fuzzyDistance = 1;
    public float fuzzyAngle = 0;
    public float fuzzyChaseContinuity = 0;

    [SerializeField] GameObject mostDesireableMouse = null;
    private NavMeshAgent navMeshAgent; // Add NavMeshAgent

    void Start()
    {
        // get chase parameters from CatMiceGameManager.Instance
        catMaxSight = CatMiceGameManager.Instance.catMaxSight;
        catMaxAngle = CatMiceGameManager.Instance.catMaxAngle;
        catMaxChaseTime = CatMiceGameManager.Instance.catMaxChaseTime;

        // Get the NavMeshAgent component
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Check if NavMeshAgent exists
        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent not found on this GameObject");
        }
    }

    // Update is called once per frame
    void Update()
    {
        var miceList = CatMiceGameManager.Instance.miceList;
        foreach (GameObject mouse in miceList)
        {
            mouseDistance = Vector3.Distance(transform.position, mouse.transform.position);
            Vector3 targetDir = mouse.transform.position - transform.position;
            mouseAngle = Vector3.Angle(targetDir, transform.forward);
            Mouse mouseComponent = mouse.GetComponent<Mouse>();
            mouseChaseTime = mouseComponent.chaseTime;

            // calculate fuzzy values
            fuzzyDistance = CatMiceGameManager.Instance.distanceCurve.Evaluate(mouseDistance / catMaxSight);
            fuzzyAngle = CatMiceGameManager.Instance.angleCurve.Evaluate(mouseAngle / catMaxAngle);
            fuzzyChaseContinuity = CatMiceGameManager.Instance.chaseContinuityCurve.Evaluate(mouseChaseTime / catMaxChaseTime);

            // calculate desireability
            float desireability = fuzzyDistance * fuzzyAngle * fuzzyChaseContinuity;

            if (mostDesireableMouse == null)
            {
                mostDesireableMouse = mouse;
            }
            // if desireability is greater than the current most desireable mouse, set most desireable mouse to this mouse
            else if (desireability > mostDesireableMouse.GetComponent<Mouse>().desireability)
            {
                mostDesireableMouse.GetComponent<Mouse>().desireability = 0; 
                mostDesireableMouse = mouse;
                mostDesireableMouse.GetComponent<Mouse>().desireability = desireability;
            } 
        }

        // chase the most desireable mouse
        if (mostDesireableMouse != null && navMeshAgent != null)
        {
            navMeshAgent.destination = mostDesireableMouse.transform.position;
        }

        // increment chase time
        mouseChaseTime += Time.deltaTime;

        // if chase time is greater than max chase time, reset most desireable mouse
        if (mouseChaseTime > catMaxChaseTime)
        {
            mostDesireableMouse = null;
            mouseChaseTime = 0;
        }
    }
}
