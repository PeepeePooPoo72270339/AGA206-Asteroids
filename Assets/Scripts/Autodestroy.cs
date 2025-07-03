using UnityEngine;

public class Autodestroy : MonoBehaviour
{
    public float Lifetime = 5f;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if(timer >= Lifetime)
        {
            Destroy(gameObject);
        }
    }
}
