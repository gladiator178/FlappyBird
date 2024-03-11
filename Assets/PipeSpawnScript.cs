using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pipe;
    private float timer = 0;
    public float spawnRate;
    public float heightOffset = 2;

    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }
    void spawnPipe()
    {
        spawnRate = Random.Range(0.4f, 2.8f);
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}