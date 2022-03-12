using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObject : MonoBehaviour
{
    public float destroyTime = 3.0f;

    private NewSpawnScript NSS;
    public Transform mySpawnPoint;
    public string nameOfParentSpawnerObj;
    [SerializeField] private bool destroyMyself = true;

    // Start is called before the first frame update
    void Start()
    {
        NSS = GameObject.Find(nameOfParentSpawnerObj).GetComponent<NewSpawnScript>(); // If getting error: Make sure this is set to the name of the GameObject that's the NewSpawnScript

        if (destroyMyself)
            StartCoroutine(DestroyMe());
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
                if (NSS.OnlyOneSpawnPerPoint)
                    NSS.possibleSpawns.Add(NSS.spawnPoints[i]); // Add this back in as a valid spawn point
            }
        }
        Destroy(gameObject);
    }

}
