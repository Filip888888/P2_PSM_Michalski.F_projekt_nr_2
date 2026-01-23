using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using NUnit.Framework.Constraints;
using System;

public class Gameplay : MonoBehaviour
{
    public int wave = 1;
    public int amount;
    public Transform zombie_prefab;
    public Transform spawner;
    public Transform player;
    public int kill_count = 0;
    //private bool waveSpawned = false;
    private int lastWave = 0;

    Zombie zombie;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zombie = FindObjectOfType<Zombie>();
    }

    // Update is called once per frame
    void Update()
    {
        wave_change();

        if(wave != lastWave)
        {
            spawn();
            lastWave = wave;
        }

    }

    void set_max_healt()
    {
        if (wave == 1)
        {
            zombie.health = 100f;
        }
    }

    void wave_change()
    {
        if (kill_count <= 5)
        {
            wave = 1;
            amount = 5;
        }
        else if (kill_count > 5 && kill_count <= 10)
        {
            wave = 2;
            amount = 5;
        }
        else if (kill_count > 10 && kill_count <= 25)
        {
            wave = 3;
            amount = 15;
        }
        else if (kill_count > 25 && kill_count <= 30)
        {
            wave = 4;
            amount = 5;
        }

        if (SceneManager.GetActiveScene().name == "LvL_2")
        {
            player.GetComponent<Movement_Controller>().enabled = false;
        }

    }

    void spawn()
    {
            for (int i = 0; i < amount; i++)
            {
                Transform newZombie = Instantiate(zombie_prefab, spawner.position, Quaternion.LookRotation(player.position - spawner.position));
            }
    }

    public void AddKill()
    {
        kill_count++;
        
        if (kill_count == 31 && SceneManager.GetActiveScene().name == "SampleScene")
        {
            SceneManager.LoadScene("cutscene", LoadSceneMode.Single);
        }
    }

}
