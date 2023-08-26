
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiTest : MonoBehaviour
{
    public Transform[] points;
    public int target;
    public float speed;

    private AiAgent agent;

    private void Start()
    {
        agent = GetComponent<AiAgent>();
        target = 0;
        
    }

    private void Update()
    {
        if ( target < points.Length ) 
        {
            Return();
        }      
        agent.navMeshAgent.SetDestination(points[target].position);
    }

    private void Return()
    {
        target++;
        if (target >= points.Length)
        {
            target = 0;
        }
    }

}
