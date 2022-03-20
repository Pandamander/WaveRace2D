using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraLeftandRight : MonoBehaviour
{
    public float speed = 10.0f;

    private Camera myCamera;

    void Start()
    {
        myCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            print("right arrow key is down");
            myCamera.transform.position = myCamera.transform.position + (Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("left arrow key is down");
            myCamera.transform.position = myCamera.transform.position - (Vector3.right * speed * Time.deltaTime);
        }
    }
}
