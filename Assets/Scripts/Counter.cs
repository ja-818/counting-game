using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public int count = 0;

    private AudioSource audioSource;
    private ParticleSystem particleFireflies;
    
    private GameManager gameManagerScript;
    private string itemName;
    private string itemColor;

    private string name1 = "a";
    private string name2 = "a";
    private string name3 = "a";
    private string name4 = "a";
    private string name5 = "a";
    private string name6 = "a";
    private string color1 = "a";
    private string color2 = "a";
    private string color3 = "a";
    private string color4 = "a";
    private string color5 = "a";
    private string color6 = "a";
    private bool enable1 = true;
    private bool enable2;
    private bool enable3;
    private bool enable4;
    private bool enable5;
    private bool enable6;

    private string lvl1 = " || 3";
    private string lvl2 = " || 4";
    private string lvl3 = " || 5";
    private string lvl4 = " || 6";
    private string maxScore;

    [SerializeField] TextMeshProUGUI counterText;
    [SerializeField] AudioClip ohNoSound;
    private float ohNoLevel = 0.4f;

    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
        particleFireflies = GameObject.Find("Box Fireflies").GetComponent<ParticleSystem>();


        if (gameManagerScript.level1 == true)
        {
            maxScore = lvl1;
        }

        if (gameManagerScript.level2 == true)
        {
            maxScore = lvl2;
        }

        if (gameManagerScript.level3 == true)
        {
            maxScore = lvl3;
        }

        if (gameManagerScript.level4 == true)
        {
            maxScore = lvl4;
        }

        counterText.text = count + maxScore;
    }
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
            audioSource.Play();
            particleFireflies.Play();
        }

        if (enable2 && itemName != "registred")
        {
            if (name1 == itemName || color1 == itemColor)
            {
                RestartValues();
                audioSource.PlayOneShot(ohNoSound, ohNoLevel);
            }
            else
            {
                name2 = itemName;
                color2 = itemColor;
                itemName = "registred";
                enable2 = false;
                enable3 = true;
                count += 1;
                audioSource.Play();
                particleFireflies.Play();
            }
        }

        if (enable3 && itemName != "registred")
        {
            if (name1 == itemName || color1 == itemColor || name2 == itemName || color2 == itemColor)
            {
                RestartValues();
                audioSource.PlayOneShot(ohNoSound, ohNoLevel);
            }
            else
            {
                name3 = itemName;
                color3 = itemColor;
                itemName = "registred";
                enable3 = false;
                enable4 = true;
                count += 1;
                audioSource.Play();
                particleFireflies.Play();
            }
        }

        if (enable4 && itemName != "registred")
        {
            if (name1 == itemName || color1 == itemColor || name2 == itemName || color2 == itemColor || name3 == itemName || color3 == itemColor)
            {
                RestartValues();
                audioSource.PlayOneShot(ohNoSound, ohNoLevel);
            }
            else
            {
                name4 = itemName;
                color4 = itemColor;
                itemName = "registred";
                enable4 = false;
                enable5 = true;
                count += 1;
                audioSource.Play();
                particleFireflies.Play();
            }
        }

        if (enable5 && itemName != "registred")
        {
            if (name1 == itemName || color1 == itemColor || name2 == itemName || color2 == itemColor || name3 == itemName || color3 == itemColor || name4 == itemName || color4 == itemColor)
            {
                RestartValues();
                audioSource.PlayOneShot(ohNoSound, ohNoLevel);
            }
            else
            {
                name5 = itemName;
                color5 = itemColor;
                itemName = "registred";
                enable5 = false;
                enable6 = true;
                count += 1;
                audioSource.Play();
                particleFireflies.Play();
            }
        }

        if (enable6 && itemName != "registred")
        {
            if (name1 == itemName || color1 == itemColor || name2 == itemName || color2 == itemColor || name3 == itemName || color3 == itemColor || name4 == itemName || color4 == itemColor || name5 == itemName || color5 == itemColor)
            {
                RestartValues();
                audioSource.PlayOneShot(ohNoSound, ohNoLevel);
            }
            else
            {
                count += 1;
                name6 = itemName;
                enable6 = false;
                audioSource.Play();
                particleFireflies.Play();
            }
        }
        counterText.text = count + maxScore;
        Destroy(other.gameObject);
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
