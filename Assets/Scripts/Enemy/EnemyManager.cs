using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject bloons;
    public float timer, startTimer;
    public Transform startPoint;
    private void Start()
    {
        timer = startTimer;
    }
    private void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = startTimer;
            Instantiate(bloons, startPoint);
        }
    }
}
