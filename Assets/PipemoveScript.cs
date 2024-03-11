using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5;
    public float Deadzone = -15;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < Deadzone)
        {
            Destroy(gameObject);
        }

    }
}