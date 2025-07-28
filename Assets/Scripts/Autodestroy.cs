using UnityEngine;

public class Autodestroy : MonoBehaviour
{
    public float Lifetime = 5f;
    private float timer = 0f;

    // After some time objects will destroy by themselves
    void Update()
    {
        timer = timer + Time.deltaTime;
        if(timer >= Lifetime)
        {
            Destroy(gameObject);
        }
    }
}
