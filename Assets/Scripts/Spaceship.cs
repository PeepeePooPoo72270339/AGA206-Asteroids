using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float enginepower = 10f;
    private Rigidbody2D rb2D;
    public float Turnpower = 2;
    public float MaxTurnpower = 200f;
    public int HpMax = 3;
    public int CurrentHp;
    [Header("Bullets")]
    public GameObject BulletPrefab;
    public float BulletSpeed = 100f;
    public float FiringRate = 0.33f;
    private float fireTimer = 0f;
    public SoundPlayer Hitsounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        CurrentHp = HpMax;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        applythrust(vertical);
        ApplyTorque(horizontal);
        updatefiring();
      
       



    }
    private void updatefiring()
    {
        bool IsFiring = Input.GetButton("Fire1");
        fireTimer = fireTimer - Time.deltaTime;  //timer that goes down


        if (IsFiring == true && fireTimer <= 0)
        {
            FireBullet();
            fireTimer = FiringRate;
        }
    }
    private void applythrust(float amount)
    {
        //Debug.Log("Thrustamount is" + amount);
        Vector2 thrust = transform.up * enginepower * Time.deltaTime * amount;
        rb2D.AddForce(thrust);
    }

    private void ApplyTorque(float amount)
    {

        float torque = amount * Turnpower * Time.deltaTime;

        //Add something here to restrict turning there also needs to be a slow down for when there is no input
        rb2D.AddTorque(-torque);

        if (torque <= MaxTurnpower)
        {
            torque = MaxTurnpower;
            

        }

    }

    public void TakeDamage(int damage)
    {
        //reduce hp
        CurrentHp = CurrentHp - damage;
        Hitsounds.PlayRandomSound();

        //if hp is 0 die
        if (CurrentHp <= 0)
        {
            Explode();
        }
    
    }
    
    public void Explode()
    {
        //Destroy ship (end game)
        Debug.Log("GameOver");
        Destroy(gameObject);
    }

    public void FireBullet()
    {
        //create bullet at ship loaction and rotation
        GameObject Bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        Vector2 force = transform.up * BulletSpeed;
        rb.AddForce(force);


    }

}
