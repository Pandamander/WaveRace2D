using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalator : MonoBehaviour
{
    [SerializeField] public Transform endLocation;
    [SerializeField] public Transform startLocation;

    // This is a script that creates things on the right, and then they scroll to the left, and disappear. Like a wave pool or escalator
    // The other part of this system is the script EscalatorPart, which works with this object to know when to appear and when to disappear

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
