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
    public float MaxTimer;
    public Color color;
    public bool dontAttack, onRange;
    private Transform target;
    private SphereCollider trigger;
    private void Start()
    {
        dontAttack = true;
        transform.GetChild(0).GetComponent<MeshRenderer>().material.color = color;
        trigger = GetComponent<SphereCollider>();
        gun.GetComponent<MeshRenderer>().material.color = color;
        rangeSprite.transform.localScale *= range;
        trigger.radius = range/2;
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
        if (nearest != null && shortDist < range)
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
        if (target != null && !dontAttack && onRange)
        {
            transform.LookAt(target);
            if (timerProjetil <= 0)
            {
                timerProjetil = MaxTimer;
                GameObject bullet = Instantiate(projetil, gun.transform.position, Quaternion.identity);
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            onRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            onRange = false;
        }
    }
}
