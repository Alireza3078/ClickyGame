using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private float minSpeed =12;
    private float maxSpeed =16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;

    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRB.AddForce(RandomForce(),ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(),ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }
    void Update()
    {

    }
    private Vector3 RandomForce()
    {
        return Vector3.up*Random.Range(minSpeed,maxSpeed);
    }
    private float RandomTorque()
    {
        return Random.Range(-maxTorque,maxTorque);
    }
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange,xRange),ySpawnPos);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
            if (gameObject.CompareTag("Bad"))
            {
                gameManager.GameOver();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy (gameObject);
    }
}
