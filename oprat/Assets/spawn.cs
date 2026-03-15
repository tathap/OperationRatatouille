using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
public class spawn : MonoBehaviour
{
    
    public GameObject badTomato;
    public GameObject orange;
    public GameObject Tomato;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private float goodNextActionTime = 0.0f;
    private float badNextActionTime = 0.0f;
    public float goodPeriod = .01f; 
    public float badPeriod = .01f;// Delay between actions
     
    void Update()
    {
        if (Time.time > goodNextActionTime)
        {
            goodNextActionTime = Time.time + goodPeriod;
            
            // Perform the action here
        for(int i=0; i<3; i++){
        Vector2 randomSpawn = new Vector2(UnityEngine.Random.Range(-9,9), UnityEngine.Random.Range(10,15));
        if (UnityEngine.Random.Range(0,10)<3)
                {
                   Instantiate(orange, randomSpawn,Quaternion.identity); 
                }
                else
                {
                    Instantiate(Tomato, randomSpawn,Quaternion.identity);
                }
        
        
        }
        }
        if (Time.time > badNextActionTime)
        {
            badNextActionTime = Time.time + badPeriod;
            
            // Perform the action here
        for(int i=0; i<4; i++){    
        Vector2 randomSpawn = new Vector2(UnityEngine.Random.Range(-9,9), UnityEngine.Random.Range(10,15));
        Instantiate(badTomato, randomSpawn,Quaternion.identity);
        }
        }

        
        /*
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
      
    
        Instantiate(orange, )*/
    }
    
}
