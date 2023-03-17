using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    // to give components
    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;

    // instantiate variables
    private float minSpeed = 14;
    private float maxSpeed = 18;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    // point for obejcts
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        // give rigidbody component to variable
        targetRb = GetComponent<Rigidbody>();
        // give jump movement
        targetRb.AddForce(RandomPos(),ForceMode.Impulse);
        // give torque(rotation movement) to object
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        // create object in position
        transform.position = RandomSpawnPos();

        // assign component to variable
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // for AddForce method
    Vector3 RandomPos()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    // for AddTorque method
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    // create position
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // if objects collide symmetr object destroy gameobject
    private void OnTriggerEnter(Collider other)
    {
        // if game object is not bad call gameover
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        Destroy(gameObject);
    }
    private void OnMouseDown()
    { 
        // if gameActive is true execute this code
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            // create partice system when mouse down
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
        
    }

}
