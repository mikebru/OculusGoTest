using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentControl : MonoBehaviour {

    public NavMeshAgent[] NavAgents;

    [Range(.1f, 20)]
    public float PathTimer;

	// Use this for initialization
	void Start () {

        NavAgents = FindObjectsOfType<NavMeshAgent>();

        StartCoroutine(MoveAgents());
	}

    IEnumerator MoveAgents()
    {

        for (int i = 0; i < NavAgents.Length; i++)
        {

            if (NavAgents[i].enabled == true)
            {

                float range = 20.0f;
                Vector3 point;
                if(RandomPoint(NavAgents[i].transform.position, range, out point))
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                    NavAgents[i].SetDestination(point);
                }


                
            }

            yield return new WaitForSeconds(Random.Range(PathTimer, PathTimer+.2f));

        }

        StartCoroutine(MoveAgents());

    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }


    // Update is called once per frame
    void Update () {
		
	}
}
