using UnityEngine;

public class FireRateIncrease : MonoBehaviour
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
            ship.FiringRate = ship.FiringRate - 0.1f;
            AudioSource.PlayClipAtPoint(PowerUp, gameObject.transform.position, 1);
            Destroy(gameObject);

        }

    }
}
