using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    [SerializeField] BoxCollider2D collider;
    [SerializeField] GameObject toolTip;

    // Start is called before the first frame update
    void Start()
    {
        // hide the tooltip to start
        toolTip.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
     // make the tooltip appear and disappears when player is here
        if (collider.gameObject.GetComponent<Player>())
        {
            toolTip.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        // make the tooltip disappear
        if (collider.gameObject.GetComponent<Player>())
        {
            toolTip.SetActive(false);
        }
    }
}
