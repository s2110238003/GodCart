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
    int currentRound;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        counter = 0;
        currentPosition = targets[0].position;
        currentRound = 0;
        UnityEngine.Debug.Log("Hello World");
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
        //Console.Log(currentRound);
    }

    /*

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            currentRound++;
            //Debug.Log(currentRound);
            if (currentRound >= 4)
            {
                // Collider hat Trigger "MyObjectTag" betreten
                // füge hier deinen Code ein, um auf die Kollision zu reagieren
                SceneManager.LoadScene("statsscreen");
            }
            
        }
    }

    */

}
