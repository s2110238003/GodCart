using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.Diagnostics;


public class MovingCart : MonoBehaviour
{

    public Transform[] targets;  // destinations
    NavMeshAgent nav;
    int counter;  // current target i
    Vector3 currentPosition;  // current transform of target
    public float inRangeDistance;  // check in range not actual point
    int currenDest;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        counter = 0;
        currentPosition = targets[0].position;
        currenDest = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, currentPosition) < inRangeDistance)
        {
            counter++;  // get next i
            currenDest++;  // count destinations
            if (currenDest >= targets.Length*3+1)  // if three rounds passed
            {
                SceneManager.LoadScene("statsscreen");  // endscreen
            }

            if (counter >= targets.Length)  
            {
                counter = 0; // set to first index

            }
            currentPosition = targets[counter].position;  // set to first target
        }

        nav.SetDestination(currentPosition);  // follow current destination
        //UnityEngine.Debug.Log(currenDest);
    }
    

}
