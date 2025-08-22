using JetBrains.Annotations;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class MedusaHead : MonoBehaviour

{
    public int CollisionDamage;

    public int Health;

    public Vector2 leftPoint;

    public Vector2 rightPoint;

    private Vector2 Middlepoint;

    public float duration;

    private bool inverted;

    public int score = 20;

    public GameObject BulletPrefab;

    private Rigidbody2D rb2D;

    public float BulletSpeed = 300;

    public float Speed;

    public GameObject Explosion;


  

    private void Start()

    {
        leftPoint.y = gameObject.transform.position.y;
        rightPoint.y = gameObject.transform.position.y;
        Middlepoint.x = gameObject.transform.position.x;
        leftPoint.x = Middlepoint.x + -8;
        rightPoint.x = Middlepoint.x + 8;

        gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
        StartCoroutine(LerpFunction(rightPoint, 3));

    }
    private void Update()
    {
        leftPoint.y += Time.deltaTime * Speed;
        rightPoint.y += Time.deltaTime * Speed;
    }



    IEnumerator LerpFunction(Vector2 _endPoint, float _duration)

    {

        float time = 0;

        Vector2 startValue = gameObject.transform.position;

        while (time < duration)

        {

            float t = time / _duration;

            Vector2 newPos = Vector2.Lerp(startValue, _endPoint, t);

            transform.position = new Vector3(newPos.x, leftPoint.y, transform.position.z);

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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Spaceship ship = collision.gameObject.GetComponent<Spaceship>();
        if (ship != null)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            TakeDamage(1);
            ship.TakeDamage(CollisionDamage);

        }

    }

}