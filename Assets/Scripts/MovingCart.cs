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

    // Death Counter
    int sheepCounter;
    int peopleCounter;

    // Stop Seconds
    public float sheepStopSeconds;
    public float peopleStopSeconds;

    // Audio
    public AudioClip sheepSound;
    public AudioClip peopleSound;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        counter = 0;
        currentPosition = targets[0].position;
        currenDest = 0;
        sheepCounter = 0;
        peopleCounter = 0;
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!nav.isStopped)
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
        }
        //UnityEngine.Debug.Log(currenDest);
    }

    // Collision with Sheep or People
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the one we're interested in
        if (other.gameObject.tag == "Sheep")
        {
            audioSource.clip = sheepSound;
            audioSource.Play();
            sheepCounter++;  // death counter
            other.gameObject.SetActive(false);  // disable sheep
            // Stop the NavMeshAgent for 3 seconds
            StartCoroutine(StopForSeconds(sheepStopSeconds));
        } 
        else if (other.gameObject.tag == "People")
        {
            audioSource.clip = peopleSound;
            audioSource.Play();
            peopleCounter++;  // death counter
            other.gameObject.SetActive(false);  // disable human

            if (peopleCounter >= 3)
            {
                SceneManager.LoadScene("creditscreen"); // game over
            }

            // Stop the NavMeshAgent for 3 seconds
            StartCoroutine(StopForSeconds(peopleStopSeconds));
        }
    }

    IEnumerator StopForSeconds(float seconds)
    {
        // Get the current velocity of the NavMeshAgent
        Vector3 currentVelocity = nav.velocity;

        // Stop the NavMeshAgent
        nav.isStopped = true;

        // Set the velocity of the NavMeshAgent to zero
        nav.velocity = Vector3.zero;

        // Wait for the specified number of seconds
        yield return new WaitForSeconds(seconds);

        // Resume movement
        nav.isStopped = false;

        // Restore the previous velocity of the NavMeshAgent
        nav.velocity = currentVelocity;
    }


}
