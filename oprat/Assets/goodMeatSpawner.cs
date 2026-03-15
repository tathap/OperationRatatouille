using UnityEngine;

public class goodMeatSpawner : MonoBehaviour
{
    public GameObject goodMeat;
    private float period = .45f;
    private float nextActionTime = 0.0f;
    // Delay between actions
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + period;
            Vector2 randomSpawn = new Vector2(UnityEngine.Random.Range(.1f,.9f), 
            UnityEngine.Random.Range(.1f,.9f));
            Vector2 spawn = Camera.main.ViewportToWorldPoint(randomSpawn);
            Instantiate(goodMeat,spawn, Quaternion.identity);
            // Perform the action here
            
        
        
    }
}
}
