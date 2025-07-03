using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Explosion;
    public void Blowup()
    {
        Instantiate(Explosion, transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

  
    public int Damage = 1;

   private void OnTriggerEnter2D(Collider2D collision)
   {
        Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();
        if (asteroid)
        {
            asteroid.TakeDamage(Damage);
            Blowup();
        }
   }

}
