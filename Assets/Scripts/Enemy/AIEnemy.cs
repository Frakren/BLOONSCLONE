using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    public enum EnemyType { Normal, Masked, Endure,Black, MOAB }
    public EnemyType type;
    public int life, damage,amountGold;
    public Transform path;
    NavMeshAgent nav;
    public void ApplyDamage(int damage)
    { 
        if((life-damage)<=0)
        {
            FindObjectOfType<GameManager>().gold += amountGold;
            FindObjectOfType<GameManager>().SetGoldOnScreen();
            Destroy(gameObject);
        }
        else
        {
            life -= damage;
        }
    }
    private void Start()
    {
        path = GameObject.FindGameObjectWithTag("Path").transform;
        nav = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        nav.SetDestination(path.GetChild(1).transform.position);
    }
}
