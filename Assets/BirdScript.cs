using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D myRigidbody;
    public float flapStrength=6;
    public logicScript logic;
    public bool birdIsAlive = true;
    void Start()
    {
        gameObject.name = "Jack The Amazing Bird";
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
        if (gameObject.transform.position.y < -5)
        {
            logic.gameOver();
        }
    }
    private void OnCollisionEnter2D()
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
