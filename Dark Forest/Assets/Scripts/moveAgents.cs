using UnityEngine;
using UnityEngine.AI;

public class moveAgents : MonoBehaviour
{
    public Transform[] positions;
    private NavMeshAgent agent;
    private Transform nowPlace;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNewPath();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Dots"))
        {
            SetNewPath();
        }
    }

    public void SetNewPath()
    {
        Transform moveTo = positions[Random.Range(0, positions.Length)];
        if(nowPlace != null && nowPlace.position == moveTo.position)
        {
            SetNewPath();
            return;
        }

        nowPlace = moveTo;
        if(agent.enabled)
        agent.SetDestination(moveTo.position);
    }
}
