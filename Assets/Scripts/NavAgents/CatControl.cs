using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatControl : MonoBehaviour {

    Animator anim;
    NavMeshAgent agent;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

        anim.SetFloat("Speed", agent.velocity.magnitude/agent.speed);

	}
}
