using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MovingSheep : MonoBehaviour
{

    public Transform[] targets;  // destinations
    NavMeshAgent nav;
    int counter;  // current target i
    Vector3 currentPosition;  // current transform of target
    public float inRangeDistance;  // check in range not actual point

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        counter = 0;
        currentPosition = targets[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, currentPosition) < inRangeDistance)
        {
            counter++;
            if (counter >= targets.Length)
            {
                counter = 0;
            }
            currentPosition = targets[counter].position;
        }
        nav.SetDestination(currentPosition);
    }
}
