using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Text

public class GameController : MonoBehaviour {

    public static GameController _instance;
    private int orbsCollected;
    private int orbsTotal;

    public Text scoreText;

    /*
    [Header("Object References")]
    public Transform wall;
    public Transform player;
    public Transform orb;
    public Transform goal;
    */

    private ParticleSystem goalPS;

    public ParticleSystem GoalPS
    {
        get
        {
            return goalPS;
        }

        set
        {
            goalPS = value;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    public void CollectedOrb()
    {
        orbsCollected++;
        scoreText.text = "Orbs: " + orbsCollected + "/" + orbsTotal;

        if (orbsCollected >= orbsTotal)
        {
            goalPS.Play();
        }

    }


    // Use this for initialization
    void Start ()
    {
        
        //BuildLevel();

        // After the level is created, let's see how many orbs there are

        GameObject[] orbs;
        orbs = GameObject.FindGameObjectsWithTag("Orb");

        orbsCollected = 0;
        orbsTotal = orbs.Length;

        scoreText.text = "Orbs: " + orbsCollected + "/" + orbsTotal;
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            this.gameObject.GetComponent<LevelEditor>().enabled = true;
        }
    }

    public void UpdateOrbTotals(bool reset = false)
    {
        if (reset)
            orbsCollected = 0;

        GameObject[] orbs;
        orbs = GameObject.FindGameObjectsWithTag("Orb");

        orbsTotal = orbs.Length;

        scoreText.text = "Orbs: " + orbsCollected + "/" + orbsTotal;
    }


}
