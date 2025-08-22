using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public AudioClip PowerUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Spaceship ship = collision.gameObject.GetComponent<Spaceship>();
        if (ship != null)
        {
            ship.CurrentHp = ship.CurrentHp + 1;
            AudioSource.PlayClipAtPoint(PowerUp, gameObject.transform.position, 1);
            Destroy(gameObject);

        }

    }

}
