using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAim : MonoBehaviour
{
    [SerializeField] float speed = 5f;


    Vector3 newPos;
    float timer;

    private void Start()
    {
        newPos = new Vector3(2.2f, transform.position.y, transform.position.z);
      
        
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer>= 1.5f)
        {
            transform.position = Vector3.Lerp(transform.position, newPos,Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, newPos) <= 0.01f)
            {
                float
                xPos = -0.77f;
                
                newPos = new Vector3(xPos, transform.position.y, transform.position.z);
                timer = 0.0f;
            }
        }
        
        
    }
}
