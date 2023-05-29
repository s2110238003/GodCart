using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class lightingBoltEnd : MonoBehaviour
{

    // Death Counters are static, so all chariots can access them
    public int sheepCounter;
    public int peopleCounter;

    // Stop Seconds
    public float sheepStopSeconds;
    public float peopleStopSeconds;

    // Audio
    public AudioClip sheepSound;
    public AudioClip peopleSound;
    public AudioClip chariotSound;
    AudioSource audioSource;

    // Graves for Humans
    public GameObject Grave1;
    public GameObject Grave2;
    public GameObject Grave3;

    int counter;  // current target i
    Vector3 currentPosition;  // current transform of target
    public float inRangeDistance;  // check in range not actual point

    public NavMeshAgent nav1;
    public NavMeshAgent nav2;
    public NavMeshAgent nav3;
    public NavMeshAgent nav4;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

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
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the one we're interested in
        if (other.gameObject.tag == "Sheep")
        {
            audioSource.clip = sheepSound;
            audioSource.Play();
            sheepCounter = PlayerPrefs.GetInt("SheepDeaths");
            PlayerPrefs.SetInt("SheepDeaths", sheepCounter++);
            UnityEngine.Debug.Log(sheepCounter);
            other.gameObject.SetActive(false);  // disable sheep
        }
        else if (other.gameObject.tag == "People")
        {
            audioSource.clip = peopleSound;
            audioSource.Play();
            peopleCounter = PlayerPrefs.GetInt("PeopleDeaths");
            PlayerPrefs.SetInt("PeopleDeaths", peopleCounter++);
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
                SceneManager.LoadScene("gameOverVR");  // game over
            }


        }
        else if (other.gameObject.tag == "RedChariot" || other.gameObject.tag == "BlueChariot" || other.gameObject.tag == "YellowChariot" || other.gameObject.tag == "PurpleChariot")
        {
            audioSource.clip = chariotSound;
            audioSource.Play();
        } 
    }

}
