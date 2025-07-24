
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] AsteroidRefs;//Asteroids to spawn
    public float CheckInterval = 3f; //timer of spawn
    public float PushForce = 100f; //Push object onto screen
    public int SpawnThreshold = 10; //Asteroid limit 
    private float checkTimer = 0f;
    public float inaccuracy = 2f;
    
    public int TotalAsteroidValue()
    {
        Asteroid[] asteroids = FindObjectsByType<Asteroid>(FindObjectsSortMode.None);
        int value = 0;
        for (int i = 0; i < asteroids.Length; i++)
        {
            value += asteroids[i].SpawnValue;

        }
        return value;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(TotalAsteroidValue());
    }

    private void Update()
    {
        checkTimer += Time.deltaTime;
        if(checkTimer > CheckInterval)
        {
            checkTimer = 0f;

            if(TotalAsteroidValue() < SpawnThreshold)
            {
                SpawnAsteroid();
            }
        }
    }
    private void SpawnAsteroid()
    {
        //Debug.Log("Spawn");
        //picks a random asteroid
        int randomindex = Random.Range(0, AsteroidRefs.Length);

        //Random offscreenLocation
        Vector3 spawnpoint = RandomOffScreenPoint();
        //Prevents z axis from being randomised
        spawnpoint.z = transform.position.z;

        GameObject asteroid = Instantiate(AsteroidRefs[randomindex], spawnpoint, transform.rotation);
        Vector2 force = PushDirection(spawnpoint) * PushForce;
        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
        rb.AddForce(force);
    }

    private Vector3 RandomOffScreenPoint()
    {
        Vector2 randomPos = Random.insideUnitCircle;
        Vector2 direction = randomPos.normalized;
        Vector2 FinalPos = (Vector2)transform.position + direction * 20f;

        return Camera.main.ViewportToWorldPoint(FinalPos);
    }

    private Vector2 PushDirection(Vector2 from)
    {

        Vector2 miss = Random.insideUnitCircle * inaccuracy;
        Vector2 destination = (Vector2)transform.position + miss;
        Vector2 direction = (destination - from).normalized;

        return direction;
    }
   
    
}
