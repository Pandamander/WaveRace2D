using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObject : MonoBehaviour
{
    public float destroyTime = 3.0f;

    private NewSpawnScript NSS;
    public Transform mySpawnPoint;
    public string nameOfParentSpawnerObj;

    // Start is called before the first frame update
    void Start()
    {
        NSS = GameObject.Find(nameOfParentSpawnerObj).GetComponent<NewSpawnScript>(); // Make sure this is set to the name of the GameObject that's the NewSpawnScript

        //StartCoroutine(DestroyMe());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyMe() // Call this if it should destroy itself in a period of time
    {
        yield return new WaitForSeconds(destroyTime);

        for (int i = 0; i < NSS.spawnPoints.Count; i++)
            {
            if (NSS.spawnPoints[i] == mySpawnPoint)
            {
                NSS.possibleSpawns.Add(NSS.spawnPoints[i]); // Add this back in as a valid spawn point
            }
        }
        Destroy(gameObject);
    }

    public void RemoveSpawnedObject() // Call this when it's time to kill the object, so that it can be a valid spawn again
    {
        for (int i = 0; i < NSS.spawnPoints.Count; i++)
        {
            if (NSS.spawnPoints[i] == mySpawnPoint)
            {
                NSS.possibleSpawns.Add(NSS.spawnPoints[i]); // Add this back in as a valid spawn point
            }
        }
        Destroy(gameObject);
        
    }
}
