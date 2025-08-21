using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Create explosion when bullet hit something
    public GameObject Explosion;
    public void Blowup()
    {
        Instantiate(Explosion, transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    //Damage of Bullet
    public int Damage = 1;

    //Register Collision and tell asterid to damage itself
   private void OnTriggerEnter2D(Collider2D collision)
   {
        Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();
        if (asteroid)
        {
            asteroid.TakeDamage(Damage);
            Blowup();
        }

        RedMonster redMonster = collision.gameObject.GetComponent<RedMonster>();
        if (redMonster)
        {
            redMonster.TakeDamage(Damage);
            Blowup();

        }

        GrayMonster grayMonster = collision.gameObject.GetComponent<GrayMonster>();
        if (grayMonster)
        {
            grayMonster.TakeDamage(Damage);
            Blowup();

        }
   }

}
