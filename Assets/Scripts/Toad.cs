using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toad : MonoBehaviour
{

    public int Player;
    [SerializeField]
    private Transform[] JumpPathPoints;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private Sprite[] ToadSprites;
    private bool grounded, reachedTargetPosition;
    private int positionIndex;
    private Vector2 jumpDirection;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        grounded = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Action"+Player) && grounded)
        {
            Debug.Log("Jump!");
            jumpDirection = positionIndex == 0 ? Vector2.right : Vector2.left;

            spriteRenderer.sprite = ToadSprites[1];
            grounded = false;
        }
        else if (Input.GetButtonDown("Action" + Player))
        {
            StartCoroutine(Attack());
        }
        Jump();
    }

    IEnumerator Attack()
    {
        Debug.Log("Attack Start!");
        yield return new WaitForSeconds(0.7f);
        Debug.Log("Attack End");
    }
    private void Jump()
    {
        if (!grounded)
        {
            reachedTargetPosition = Vector2.Distance(transform.position, JumpPathPoints[positionIndex].position)<=0.1f;
            if (jumpDirection == Vector2.right)
            {
                if (reachedTargetPosition)
                {
                    positionIndex++;
                }
                if (ReachedLandingPad())
                {
                    positionIndex = 2;
                }
            }
            else
            {
                if (reachedTargetPosition)
                {
                    positionIndex--;
                }
                if (ReachedLandingPad())
                {
                    positionIndex = 0;
                }
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, JumpPathPoints[positionIndex].position, jumpSpeed);
    }

    bool ReachedLandingPad()
    {
        if(jumpDirection == Vector2.right && positionIndex == JumpPathPoints.Length
            ||jumpDirection==Vector2.left&& positionIndex==-1)
        {
            
            
            grounded = true;
            transform.Rotate(Vector3.up, 180f);
            spriteRenderer.sprite = ToadSprites[0];

            return true;
        }
        return false;
    }
}
