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

    // Death Counters are static, so all chariots can access them
    public int sheepCounter;
    public int peopleCounter;

    // Stop Seconds
    public float sheepStopSeconds;
    public float peopleStopSeconds;

    // Audio
    public AudioClip sheepSound;
    public AudioClip peopleSound;
    AudioSource audioSource;

    // Graves for Humans
    public GameObject Grave1;
    public GameObject Grave2;
    public GameObject Grave3;


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
        PlayerPrefs.SetInt("SheepDeaths", 0);
        PlayerPrefs.SetInt("PeopleDeaths", 0);

        Grave1 = GameObject.Find("blade_gravestone");
        Grave2 = GameObject.Find("cross_gravestone");
        Grave3 = GameObject.Find("standard_gravestone");
        Grave1.GetComponent<Renderer>().enabled = false;
        Grave2.GetComponent<Renderer>().enabled = false;
        Grave3.GetComponent<Renderer>().enabled = false;
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

                if (currenDest >= targets.Length*3+1 && tag == "RedChariot")  // if red one did three rounds 
                {
                    //PlayerPrefs.SetInt("SheepDeaths", sheepCounter);
                    //PlayerPrefs.SetInt("PeopleDeaths", peopleCounter);
                    SceneManager.LoadScene("endVR");  // endscreen
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
            sheepCounter = PlayerPrefs.GetInt("SheepDeaths");
            sheepCounter++;
            PlayerPrefs.SetInt("SheepDeaths", sheepCounter);
            UnityEngine.Debug.Log(sheepCounter);
            other.gameObject.SetActive(false);  // disable sheep
            // Stop the NavMeshAgent for 3 seconds
            UnityEngine.Debug.Log("Sheeps: " + sheepCounter);
            StartCoroutine(StopForSeconds(sheepStopSeconds));
        }
        else if (other.gameObject.tag == "People")
        {
            audioSource.clip = peopleSound;
            audioSource.Play();
            peopleCounter = PlayerPrefs.GetInt("PeopleDeaths");
            peopleCounter++;
            PlayerPrefs.SetInt("PeopleDeaths", peopleCounter);
            other.gameObject.SetActive(false);  // disable human

            if (peopleCounter == 1 && Grave1 != null)
            {
                Grave1.GetComponent<Renderer>().enabled = true;
            }
            else if (peopleCounter == 2 && Grave2 != null)
            {
                Grave2.GetComponent<Renderer>().enabled = true;
            }
            else if (peopleCounter == 3 && Grave3 != null)
            {
                Grave3.GetComponent<Renderer>().enabled = true;
            }

            if (peopleCounter >= 3)
            {
                //PlayerPrefs.SetInt("SheepDeaths", sheepCounter);
                //PlayerPrefs.SetInt("PeopleDeaths", peopleCounter);
                SceneManager.LoadScene("gameOverVR");  // game over
            }


            // Stop the NavMeshAgent for 3 seconds
            StartCoroutine(StopForSeconds(peopleStopSeconds));
        }
        else if (other.gameObject.tag == "EndSphere")
        {
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
