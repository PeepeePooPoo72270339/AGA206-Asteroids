using System.Collections;
using UnityEngine;

public class GrayMonster : MonoBehaviour
{

    public int Health;

    public Vector2 Movepoint;

    public float duration;

    private bool inverted;

    public int score = 20;

    public GameObject BulletPrefab;

    private Rigidbody2D rb2D;

    public float BulletSpeed = 300;
    public void TakeDamage(int damage)
    {
        Health -= (damage);
        if (Health <= 0)
        {
            Die();

        }
    }

    public void Die()
    {
        Spaceship ship = FindFirstObjectByType<Spaceship>();
        if (ship != null)
        {

            ship.Score += score;
            Destroy(gameObject);
        }

    }
    void Start()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
        StartCoroutine(LerpFunction(Movepoint, 3));
        StartCoroutine(Shooting());
    }


    public void Shoot()
    {
        GameObject EnemyBullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = EnemyBullet.GetComponent<Rigidbody2D>();
        Vector2 force = transform.up * BulletSpeed;
        rb.AddForce(force);
    }

    IEnumerator Shooting()
    {
        Shoot();
        yield return new WaitForSeconds(1.2f);
        StartCoroutine(Shooting());

    }
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   

    IEnumerator LerpFunction(Vector2 endpoint_, float _duration)
    {
        float time = 0;

        Vector2 StartValue = gameObject.transform.position;

        while (time < duration)
        {
            float t = time / _duration;
            Vector2 newPos = Vector2.Lerp(StartValue, endpoint_, t);
            transform.position = new Vector3(transform.position.x, newPos.y, transform.position.z);
            time += Time.deltaTime;
            yield return null;

        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
