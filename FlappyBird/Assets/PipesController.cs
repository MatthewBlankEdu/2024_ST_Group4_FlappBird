using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesController : MonoBehaviour
{
    public float Speed;

    public float DespawnPoint;
    public float SpawnPoint;

    public float MinY;
    public float MaxY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!BirdController.HasStarted || BirdController.GameOver)
            return;

        transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime, transform.position.y, transform.position.z);
    
        if(transform.position.x < DespawnPoint)
        {
            transform.position = new Vector3(SpawnPoint, Random.Range(MinY, MaxY), transform.position.z);
        }
    }
}
