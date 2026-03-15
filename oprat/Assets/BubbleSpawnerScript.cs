using UnityEngine;

public class BubbleSpawnerScript : MonoBehaviour
{
    float curTime = 0f;
    public GameObject bubble;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curTime += 5 * Time.deltaTime;
        if (curTime > 10)
        {
            float posx = Random.Range(-9f, 9f);
            int numBubbles = Random.Range(1, 4);
            for (int i = 0; i < numBubbles; i++)
            {
                int distance = Random.Range(-2, 2);
                if (distance == 0)
                {
                    distance = Random.Range(-2, 2);
                }
                Instantiate(bubble, new Vector3(posx + distance, -5-i, 0), Quaternion.identity);
            }
            curTime = 0;
        }
    }
}
