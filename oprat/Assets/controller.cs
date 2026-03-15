using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class controller : MonoBehaviour
    {
    public Scorekeep scoreManager; 

    public float moveSpeed=12;
    public float hInput;
    private SpriteRenderer spriteRenderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spriteRenderer = GetComponent(orange_0);
        
    }

    // Update is called once per frame
 void Update()
{   /*float halfWidth = spriteRenderer.sprite.rect.width/2;
    float doubleWidth = spriteRenderer.sprite.rect.width*2;*/
    hInput = Input.GetAxisRaw("Horizontal");
    transform.Translate(Vector2.right * Time.deltaTime * moveSpeed * hInput);

    // Get the screen position in pixels
    Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

    // Clamp the position so it can't go off-screen
    if (screenPos.x < 0 || screenPos.x > Screen.width)
    {
        // Revert the movement if it goes out of bounds
        transform.Translate(-Vector2.right * Time.deltaTime * moveSpeed * hInput);
    }
}

void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.CompareTag("orange"))
        {
           
            scoreManager.UpdateScore(25);
            Destroy(other.gameObject,.01f);
            print("hit");
        }
        if (other.CompareTag("tomato"))
        {
           
            scoreManager.UpdateScore(75);
            Destroy(other.gameObject,.01f);
            print("hit");
        }
        if (other.CompareTag("bad"))
        {
           
            //Score-=250;
            scoreManager.UpdateScore(-250);
            Destroy(other.gameObject,.01f);
            print("hit");
        }
    
    }
        
    }

