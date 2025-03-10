using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;

public class FSM_WaypointPatrol : StateMachineBehaviour
{
    GameObject PatrolWayPoints, NPC_00;
    private RandomiseWaypoints randomiseWaypoints;
    [SerializeField] Transform WaypointTarget;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // debug statement 
        Debug.Log("Entering Patrol State");
        PatrolWayPoints = GameObject.Find("PatrolWaypoints");
        NPC_00 = GameObject.Find("NPC_00");
        randomiseWaypoints = PatrolWayPoints.GetComponent<RandomiseWaypoints>();
        WaypointTarget = randomiseWaypoints.waypoints[Random.Range(0, randomiseWaypoints.waypoints.Count)];
        NPC_00.GetComponent<NavMeshAgent>().SetDestination(WaypointTarget.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Debug log showing the current state
        Debug.Log("On State Update ~ Patrol State");

        // get parent object of the object containing the animator
        if (Vector3.Distance(NPC_00.transform.position, WaypointTarget.position) < 0.1f)
        {
            WaypointTarget = randomiseWaypoints.waypoints[Random.Range(0, randomiseWaypoints.waypoints.Count)];
            NPC_00.GetComponent<NavMeshAgent>().SetDestination(WaypointTarget.position);
        }
        
        //NPC_00.transform.position = Vector3.MoveTowards(animator.transform.position, WaypointTarget.position, GameManager.Instance.NPC_AI_01.Speed * Time.deltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // debug statement 
        Debug.Log("Exiting Patrol State");
    }

}
