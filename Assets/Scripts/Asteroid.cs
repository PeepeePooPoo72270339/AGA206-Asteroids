using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour

{
    
    private void Start()
    {
        /*for (int i =0; i < Chunks.Length; i++)
        {
            Debug.Log(Chunks[i]);
;       }
        Debug.Log(Chunks[0].name);*/
    }
    public int CollisionDamage = 1;
    public int Health = 1;
    public GameObject[] Chunks;
    [Header("ExplosionStuff")]
    public int chunksmax;
    public int chunksmin;
    public float explodedist;
    public float explodeforce;
    [Range (1, 3)]
    public int SpawnValue = 3;
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Spaceship ship = collision.gameObject.GetComponent<Spaceship>();
        if (ship != null)
        {
            ship.TakeDamage(CollisionDamage);

        }

    }

    public void TakeDamage(int damage)
    {
        Health -= (damage);
        if (Health <= 0)
        {
            
            CreateAsteroidChunk();
            Die();
        }
       

    }
    

    public void Die()
    {
        int numChunks = Random.Range(chunksmin, chunksmax + 1);
        for(int i = 0; i < numChunks; i++)
        {
            CreateAsteroidChunk();

        }
        Destroy(gameObject);
    }

    private void CreateAsteroidChunk()
    {

        if (Chunks == null)
           return;

        int randomindex = Random.Range(0, Chunks.Length);
        Vector2 spawnPos = transform.position;
        Vector2 newPos = spawnPos;
        spawnPos.x += Random.Range(-explodedist, explodedist);
        spawnPos.y += Random.Range(-explodedist, explodedist);

        GameObject chunk = Instantiate(Chunks[randomindex], spawnPos, transform.rotation);
        
        Vector2 dir = (spawnPos - newPos).normalized;

        Rigidbody2D rb = chunk.GetComponent<Rigidbody2D>();
        rb.AddForce(dir * explodeforce);

    }
}
