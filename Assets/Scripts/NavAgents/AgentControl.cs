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
                NavAgents[i].SetDestination(new Vector3(Random.Range(-7, 7), 0, Random.Range(-7, 7)));
            }

            yield return new WaitForSeconds(Random.Range(PathTimer, PathTimer+.2f));

        }

        StartCoroutine(MoveAgents());

    }


    // Update is called once per frame
    void Update () {
		
	}
}
