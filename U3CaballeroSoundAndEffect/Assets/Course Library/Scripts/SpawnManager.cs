using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public int objIndex;

    private Vector3 spawnPos = new Vector3 (25, 0, 0);

    private float startDelay = 1;
    private float repeatRate = 1;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacles()
    {
        if (playerControllerScript.gameOver == false)
        {
            int objIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[objIndex], spawnPos, obstaclePrefabs[objIndex].transform.rotation);
        }
    }
}
