using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
  
    private SpriteRenderer spriteRenderer;
    private bool hasbeenvisible;
    private void Awake()
    {
        spriteRenderer = GetComponent < SpriteRenderer>();
    }


    // Update is called once per frame
    private void Update()


    {    
        if(hasbeenvisible == false && spriteRenderer.isVisible)
        {
            hasbeenvisible = true;

        }
        if(hasbeenvisible == false)
        {
            return;


        }


        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position); //get world position of object and convert to screen space 
        Vector2 newScreenPos = screenPos; //new position of object to wrap to
        if (screenPos.x < 0)
        {
            newScreenPos.x = Screen.width;
        }
        else if (screenPos.x > Screen.width)
        {
            newScreenPos.x = 0;
        }


        if (screenPos.y < 0)
        {
            newScreenPos.y = Screen.height;
        }
        else if (screenPos.y > Screen.height)
        {
            newScreenPos.y = 0;
        }


        if (newScreenPos != screenPos)
        {

            Vector2 newWorldPos = Camera.main.ScreenToWorldPoint(newScreenPos);
            transform.position = newWorldPos;
        }
    }
}
