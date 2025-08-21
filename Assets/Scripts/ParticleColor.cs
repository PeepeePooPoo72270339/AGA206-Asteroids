using UnityEngine;

public class ParticleColor : MonoBehaviour
{
    public ParticleSystem PS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        
    }
    private void Update()
    {
        PS.startColor = ColorX.GetRandomColor();
    }
}
