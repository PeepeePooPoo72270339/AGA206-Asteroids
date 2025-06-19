using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float enginepower = 10f;
    private Rigidbody2D rb2D;
    public float Turnpower = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        applythrust(vertical);
        ApplyTorque(horizontal);
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
        rb2D.AddTorque(-torque);
    }
}
