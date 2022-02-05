using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text counterText;
    public int count = 0;

    private string itemName;
    private string itemColor;
    
    [SerializeField] private string name1 = "a";
    [SerializeField] private string name2 = "a";
    [SerializeField] private string name3 = "a";
    [SerializeField] private string name4 = "a";
    [SerializeField] private string name5 = "a";
    [SerializeField] private string name6 = "a";
    [Space]
    [SerializeField] private string color1 = "a";
    [SerializeField] private string color2 = "a";
    [SerializeField] private string color3 = "a";
    [SerializeField] private string color4 = "a";
    [SerializeField] private string color5 = "a";
    [SerializeField] private string color6 = "a";

    private bool enable1 = true;
    private bool enable2;
    private bool enable3;
    private bool enable4;
    private bool enable5;
    private bool enable6;

    [SerializeField] List<String> catchedIdeasList;
    private void OnTriggerEnter(Collider other)
    {
        itemName = other.name;
        itemColor = other.GetComponent<Renderer>().material.name;

        if (enable1)
        {
            name1 = itemName;
            color1 = itemColor;
            itemName = "registred";
            enable1 = false;
            enable2 = true;
            count += 1;
        }

        if (enable2 && itemName != "registred")
        {
            if (name1 == itemName || color1 == itemColor)
            {
                RestartValues();
            }
            else
            {
                name2 = itemName;
                color2 = itemColor;
                itemName = "registred";
                enable2 = false;
                enable3 = true;
                count += 1;
            }
        }

        if (enable3 && itemName != "registred")
        {
            if (name1 == itemName || color1 == itemColor || name2 == itemName || color2 == itemColor)
            {
                RestartValues();
            }
            else
            {
                name3 = itemName;
                color3 = itemColor;
                itemName = "registred";
                enable3 = false;
                enable4 = true;
                count += 1;
            }
        }

        if (enable4 && itemName != "registred")
        {
            if (name1 == itemName || color1 == itemColor || name2 == itemName || color2 == itemColor || name3 == itemName || color3 == itemColor)
            {
                RestartValues();
            }
            else
            {
                name4 = itemName;
                color4 = itemColor;
                itemName = "registred";
                enable4 = false;
                enable5 = true;
                count += 1;
            }
        }

        if (enable5 && itemName != "registred")
        {
            if (name1 == itemName || color1 == itemColor || name2 == itemName || color2 == itemColor || name3 == itemName || color3 == itemColor || name4 == itemName || color4 == itemColor)
            {
                RestartValues();
            }
            else
            {
                name5 = itemName;
                color5 = itemColor;
                itemName = "registred";
                enable5 = false;
                enable6 = true;
                count += 1;
            }
        }

        if (enable6 && itemName != "registred")
        {
            if (name1 == itemName || color1 == itemColor || name2 == itemName || color2 == itemColor || name3 == itemName || color3 == itemColor || name4 == itemName || color4 == itemColor || name5 == itemName || color5 == itemColor)
            {
                RestartValues();
            }
            else
            {
                count += 1;
                name6 = itemName;
                enable6 = false;
            }
        }
        counterText.text = "Count : " + count;
    }
    void RestartValues()
    {
        color1 = "a";
        color2 = "a";
        color3 = "a";
        color4 = "a";
        color5 = "a";
        color6 = "a";
        name1 = "a";
        name2 = "a";
        name3 = "a";
        name4 = "a";
        name5 = "a";
        name6 = "a";
        enable1 = true;
        enable2 = false;
        enable3 = false;
        enable4 = false;
        enable5 = false;
        enable6 = false;
        count = 0;
    }
}
