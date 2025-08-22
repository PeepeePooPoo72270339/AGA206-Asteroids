using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public enum PowerUP
{
    Single, Double, Cross
}

public class Spaceship : MonoBehaviour
{
    public PowerUP CurrentPowerUP;
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
    public ScreenFlash Flash;
    public int Score;
    public int Highscore;
    public GameOverUI GameOverUi;
    public float MaxVertSpeed;
    public float MaxHorispeed;
    public PolygonCollider2D PolyCollider;
    public float InvincibilityTime = 0.5f;
    public bool IsInvincible;
    public GameObject Player;
    public SpriteRenderer SpriteR;
    public Color DefaultColor;
    public Color InvincibleColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        CurrentHp = HpMax;
        Highscore = GetHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        vertical = Mathf.Clamp(vertical, -1, 1);
        horizontal = Mathf.Clamp(horizontal, -1, 1);
        Applythrust(horizontal, vertical);
        //ApplyTorque(horizontal);
        Updatefiring();
        Mathf.Clamp(FiringRate, 0.1f, 2);



    }
    private void Updatefiring()
    {
        bool IsFiring = Input.GetButton("Fire1");
        fireTimer = fireTimer - Time.deltaTime;  //timer that goes down


        if (IsFiring == true && fireTimer <= 0)
        {
            FireBullet();
            fireTimer = FiringRate;
        }
    }
    private void Applythrust(float hori, float vert)
    {
        //Debug.Log("Thrustamount is" + amount);
        //Vector2 thrust = transform.position * enginepower * amount;
        Vector2 thrust = new Vector2(hori, vert) * enginepower;
        Debug.Log("Thrust" + thrust);

        rb2D.linearVelocityY = Mathf.Clamp(thrust.y, -MaxVertSpeed, MaxVertSpeed);
        rb2D.linearVelocityX = Mathf.Clamp(thrust.x, -MaxHorispeed, MaxHorispeed);
        // how clamp works Mathf.Clamp(enginepower, 0, 50);
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
        StartCoroutine(Flash.FlashRoutine());
        StartCoroutine(InvincibiltyFrame());


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
        GameOver();
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

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("Highscore", 0);

    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt("Highscore", score);

    }

    public void GameOver()
    {
        bool CelebrateHighScore = false;
        if(Score > GetHighScore() && CelebrateHighScore == false)
        {
            SetHighScore(Score);
            CelebrateHighScore = true;
        }
        GameOverUi.Show(CelebrateHighScore, Score, GetHighScore());
    }

    public IEnumerator InvincibiltyFrame()
    {
        IsInvincible = true;
        PolyCollider.enabled = false;
        SpriteR.color = InvincibleColor;
        yield return new WaitForSeconds(InvincibilityTime);
        PolyCollider.enabled = true;
        IsInvincible = false;
        SpriteR.color = DefaultColor;
        
       
    }
    

}


