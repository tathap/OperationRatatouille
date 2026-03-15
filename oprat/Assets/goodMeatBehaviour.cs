using UnityEngine;

public class goodMeatBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
public Score_Script scoreManager;
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame

    private float growthRate = 0.8f; // Speed of growth per second
    private float maxSize = 1f; // Maximum desired scale
    [SerializeField] private bool shrinking=false;
    void OnMouseDown()
    {
        //score increase
        Score_Script.instance.UpdateScore(50);
        Destroy(gameObject);
    }
    void Update()
    {
        print(transform.localScale);
        
        // Check if the current scale is less than the max size
        if ((transform.localScale.x < maxSize) && (shrinking==false))
        {

            // Increase the scale over time
            transform.localScale += Vector3.one * growthRate * Time.deltaTime;
        }
        // shrink till disappears
        if(shrinking || (transform.localScale.x > maxSize))
        {
            shrinking=true;
            transform.localScale -= Vector3.one * growthRate * Time.deltaTime;
            if (transform.localScale.x < 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
}

