using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalatorPart : MonoBehaviour
{
    [SerializeField] private Escalator escalator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < escalator.endLocation.position.x)
        {
            transform.position = new Vector2(escalator.startLocation.position.x, transform.position.y);
        }
    }
}
