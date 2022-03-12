using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawnScript : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public float spawnTime = 1.5f;
    public GameObject[] spawnableObjects; // Make sure these objects put here have the SpawnableObjects script added
    public bool OnlyOneSpawnPerPoint;

    public List<Transform> possibleSpawns = new List<Transform>(); // This keeps track of the list of possible 

    // Start is called before the first frame update
    void Start()
    {
        // fill possible spawn
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            possibleSpawns.Add(spawnPoints[i]);
        }

        //start spawning
        InvokeRepeating("SpawnItems", spawnTime, spawnTime); // Start running this function at regular intervals
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnItems()
    {
        if (possibleSpawns.Count > 0) // check to make sure there is an open spawn point
        {
            int spawnIndex = Random.Range(0, possibleSpawns.Count); // Pick a random point to spawn at
            int spawnObject = Random.Range(0, spawnableObjects.Length); // Pick an random object to spawn

            GameObject NewSpawnedObject = Instantiate(spawnableObjects[spawnObject], possibleSpawns[spawnIndex].position, possibleSpawns[spawnIndex].rotation) as GameObject;
            NewSpawnedObject.transform.SetParent(this.transform); // parent spawned object to whatever transform this script is contained within
            NewSpawnedObject.GetComponent<SpawnableObject>().mySpawnPoint = possibleSpawns[spawnIndex]; //NullReferenceException: If this is throwing an error, probably means the item spawned doesn't have the SpawnableObject script added to it

            if (OnlyOneSpawnPerPoint) // If each spawn object should occupy that spawn point. False means lots can come out
                possibleSpawns.RemoveAt(spawnIndex);

         }
    }

    public void DisableSpawning()
    {
        CancelInvoke();
    }
}
