using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public int WillPowerUP;
    public GameObject[] powerUps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnInterval());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnInterval()
    {
        WillPowerUP = Random.Range(1, 5);
        while (WillPowerUP > 5)
        {
            GeneratePowerUp();

        }
        yield return new WaitForSeconds(1);
        StartCoroutine(SpawnInterval());

    }

    void GeneratePowerUp()
    {
        int randomindex = Random.Range(0, powerUps.Length);
        Vector3 spawnpoint = gameObject.transform.position;
        Instantiate(powerUps[randomindex], gameObject.transform.position , transform.rotation);


    }

}
