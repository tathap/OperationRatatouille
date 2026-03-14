using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MilkGameManager : MonoBehaviour
{

    [SerializeField] GameObject fridge;
    Animator anim;

    [SerializeField] float milkValue;
    [SerializeField] float milkIncrement;
    [SerializeField] float milkDecayPerSec;
    bool gameActive;

    public void Start()
    {
        anim = fridge.GetComponentInChildren<Animator>();

        gameActive = true;
    }

    public void Update()
    {
        if (!gameActive)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("space");
            Shake();
        }

        if (milkValue > 0)
        {
            milkValue -= milkDecayPerSec * Time.deltaTime;
        }
    }

    public void Shake()
    {
        milkValue += milkIncrement;
        anim.Play("milkATMShake");
    }
}
