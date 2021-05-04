using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : MonoBehaviour
{
    public int pointValue;
    public float moveSpeed;

    private Vector2 Direction;
    private Vector3 newPosition;

  

    // Update is called once per frame
    void Update()
    {
        newPosition = transform.position;
        newPosition.y += Mathf.Sin(Time.time*5)*1.5f*Time.deltaTime;
        transform.position = newPosition;
        move();

        if(transform.position.x>10f || transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    public void setup(float speed,Vector2 Direction)
    {
        this.pointValue = (int)speed * 3;
        this.moveSpeed = speed;
        this.Direction = Direction;
    }

    private void move()
    {
        transform.Translate(Direction * 1.3f * Time.deltaTime);
    }
}
