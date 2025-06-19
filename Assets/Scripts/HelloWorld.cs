using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public string Message = "Hello world";
    string name1 = "Belmont";
    string name2 = "vampire";
    string myname = "p";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      Debug.Log("My name is" + myname);
        myname = name1;
      Debug.Log("My name is" + myname);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
