using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    public enum MonkeyType { Normal,Super,Mega,God}
    public MonkeyType monkeyType;
    public GameObject projetil,gun,rangeSprite;
    public int cost,damage;
    public float range,timerProjetil;
    public Color color;
    private Transform target;
    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = color;
        gun.GetComponent<MeshRenderer>().material.color = color;
        rangeSprite.transform.localScale *= range;
        InvokeRepeating("FindNearestTarget",0f,0.5f);
    }
    void FindNearestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortDist = Mathf.Infinity;
        GameObject nearest = null;
        foreach (GameObject item in enemies)
        {
            float searchDistance = Vector3.Distance(transform.position, item.transform.position);
            if (searchDistance < shortDist)
            {
                shortDist = searchDistance;
                nearest = item;
            }
        }
        if (nearest != null && shortDist <= range)
        {
            target = nearest.transform;
        }
        else
        {
            nearest = null;
        }
    }
    private void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
            if (timerProjetil <= 0)
            {
                timerProjetil = 0.05f;
                GameObject bullet = Instantiate(projetil, gun.transform);
                bullet.GetComponent<Bullet>().parent = this;
                bullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward) * 10;
                Destroy(bullet, 3f);
            }
            else
            {
                timerProjetil -= Time.deltaTime;
            }
        }
    }
}
