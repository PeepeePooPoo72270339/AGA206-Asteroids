using System.Collections;
using UnityEngine;

public class GreenMonsterScript : MonoBehaviour
{
    public int Health;


    public Vector2 rightPoint;

    public float duration;

    private bool inverted;

    public int score = 20;

    public GameObject BulletPrefab;

    private Rigidbody2D rb2D;

    public float BulletSpeed = 300;
    public float rotationSpeed;

    public Vector3 Rotator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        rightPoint.y = Random.Range(5, -3);
        StartCoroutine(LerpFunction(rightPoint, 3));
        StartCoroutine(Shooting());
        
    }

    // Update is called once per frame
    void Update()
    {
 
        
        gameObject.transform.rotation = Quaternion.Euler(0, 0, (Rotator.z += Time.deltaTime * rotationSpeed));
    }

    IEnumerator LerpFunction(Vector2 _endPoint, float _duration)

    {

        float time = 0;

        Vector2 startValue = gameObject.transform.position;

        while (time < duration)

        {

            float t = time / _duration;

            Vector2 newPos = Vector2.Lerp(startValue, _endPoint, t);

            transform.position = new Vector3(transform.position.x, newPos.y, transform.position.z);

            time += Time.deltaTime;

            yield return null;

        }

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
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(Shooting());

    } 

}
