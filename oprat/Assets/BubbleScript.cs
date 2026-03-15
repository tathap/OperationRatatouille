using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        rigidbody2D.gravityScale = 0;
        rigidbody2D.linearVelocityY = 3;
        transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }
}
