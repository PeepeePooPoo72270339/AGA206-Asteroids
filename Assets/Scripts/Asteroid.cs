using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Asteroid : MonoBehaviour

{
    //Asteroid Stats
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
    [HeaderAttribute("Score")]
    public int score = 10;
    public float pushforce = 100f;
    public PolygonCollider2D PolyCollider;
    
    //Registers collision and tells Spaceship to reduce it's health
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Spaceship ship = collision.gameObject.GetComponent<Spaceship>();
        if (ship != null)
        {
            ship.TakeDamage(CollisionDamage);

        }


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Spaceship ship = collision.gameObject.GetComponent<Spaceship>();
        if (ship != null)
        {
            ship.TakeDamage(CollisionDamage);

        }

    }

    //Script for reciving damage
    public void TakeDamage(int damage)
    {
        Health -= (damage);
        if (Health <= 0)
        {
            
            CreateAsteroidChunk();
            Die();
        }
       

    }
    
    //Dies when enough damage is taken and calls to spawn chunks
    public void Die()
    {
        Spaceship ship = FindFirstObjectByType<Spaceship>();

        if(ship != null)
        {
            ship.Score += score;

        }
        int numChunks = Random.Range(chunksmin, chunksmax + 1);
        for(int i = 0; i < numChunks; i++)
        {
            CreateAsteroidChunk();

        }
        Destroy(gameObject);
    }
    //Spawn chunks if possible and the math to determine location
    private void CreateAsteroidChunk()
    {

        if (Chunks == null || Chunks.Length == 0)
           return;

        int randomindex = Random.Range(0, Chunks.Length);
        Vector2 spawnPos = transform.position;
        Vector2 newPos = spawnPos;
        spawnPos.x += Random.Range(-explodedist, explodedist);
        spawnPos.y += Random.Range(-explodedist, explodedist);

        GameObject chunk = Instantiate(Chunks[randomindex], spawnPos, transform.rotation);
        
        Vector2 dir = (spawnPos - newPos).normalized;

        Rigidbody2D rb = chunk.GetComponent<Rigidbody2D>();
        dir.x = 0;
        dir.y = -1;
        rb.AddForce(dir * pushforce);
        //rb.AddForce(dir * explodeforce);
       

    }
}
