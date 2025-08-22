using JetBrains.Annotations;
using System.Collections;

using UnityEngine;

public class RedMonster : MonoBehaviour

{
    public int Health;

    public Vector2 leftPoint;

    public Vector2 rightPoint;

    public float duration;

    private bool inverted;

    public int score = 20;

    public GameObject BulletPrefab;

    private Rigidbody2D rb2D;

    public float BulletSpeed = 300;

    public MonoBehaviour spawner;

    private void Start()

    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
        StartCoroutine(LerpFunction(rightPoint, 3));
        StartCoroutine(Shooting());

    }

    IEnumerator LerpFunction(Vector2 _endPoint, float _duration)

    {

        float time = 0;

        Vector2 startValue = gameObject.transform.position;

        while (time < duration)

        {

            float t = time / _duration;

            Vector2 newPos = Vector2.Lerp(startValue, _endPoint, t);

            transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);

            time += Time.deltaTime;

            yield return null;

        }

        if (inverted)

        {

            inverted = false;

            StartCoroutine(LerpFunction(rightPoint, 3));

        }

        else

        {

            inverted = true;

            StartCoroutine(LerpFunction(leftPoint, 3));

        }
        

    }

    public void TakeDamage(int damage) 
    {
        Health -= (damage);
        if(Health <= 0)
        {
            Die();

        }
    }

    public void Die() 
    {
        Spaceship ship = FindFirstObjectByType<Spaceship>();
        if(ship != null)
        {
            ship.Score += score;
            Destroy(gameObject);
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
        yield return new WaitForSeconds(1);
        StartCoroutine(Shooting());

    }

}


