using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float spawnRate = 4f;
    public float columnMin = -1f;
    public float columnMax = 3.5f;

    private GameObject[] colums;
    private Vector2 objectPoolPosition = new Vector2(-15, -25);//position off screen before use
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentColumn = 0;

    // Start is called before the first frame update
    void Start()
    {
        //assign columns to the new array of gameobject
        colums = new GameObject[columnPoolSize];
        

        //loops through array for column spawning
        for (int i = 0; i < columnPoolSize; i++)
        {
            colums[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if(GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            colums[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;

            if(currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }        

        }
    }
}
