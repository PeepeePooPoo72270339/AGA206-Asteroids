using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float ShakeAmount = 10;
    public float Shakedelay = 0.5f;
    public float Iterations = 2;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ShakeRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ShakeRoutine()
    {
        Vector3 orginalPos = transform.position;
        for (int n = 0; n < Iterations; n++)
        {
            Vector3 pos = Random.insideUnitCircle * ShakeAmount;
            transform.position = transform.position + pos;
            yield return new WaitForSeconds(Shakedelay);

        }
        transform.position = orginalPos;
        yield return null;
    }


}
