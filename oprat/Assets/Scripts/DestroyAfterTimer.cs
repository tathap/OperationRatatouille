using System;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyAfterTimer : MonoBehaviour
{
    [SerializeField] float time;

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Destroy(this.GameObject());
        }
    }
}
