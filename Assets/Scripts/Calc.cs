using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Calc : MonoBehaviour
{
    public float number1;
    public float number2;
    public float screen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Debug.Log(screen);
            screen = Add(number1, number2);
        }

        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            Debug.Log(screen);
            screen = Subtract(number1, number2);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log(screen);
            screen = Multiply(number1, number2);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log(screen);
            screen = Divide(number1, number2);
        }

    }
       



    private float Add(float number1, float number2)
    {
        float result = number1 + number2;
        return result;

    }
    private float Subtract(float number1, float number2)
    {
        float result = number1 - number2;
        return result;
    }

    private float Multiply(float number1, float number2)
    {
        float result = number1 * number2;
        return result; 


    }
    private float Divide(float number1, float number2)
    {
        float result = number1 / number2;
        return result;
    }
   

 
}   
