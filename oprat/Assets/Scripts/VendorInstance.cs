using System;
using TMPro;
using UnityEngine;

public class VendorInstance : MonoBehaviour
{
    [SerializeField] VendorConfig config;
    [SerializeField] GameObject vendorMenu;

    [SerializeField] TMP_Text priceText;


    public void Start()
    {
        priceText.text = "$" + config.cost.ToString();
    }

    public void OnOpenMenu()
    {
        vendorMenu.SetActive(true);
    }
    public void OnExitMenu()
    {
        vendorMenu.SetActive(false);
    }

}
