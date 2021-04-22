using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeDamage : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            if((gameManager.life - other.GetComponent<AIEnemy>().damage)>0)
            {
                gameManager.life -= other.GetComponent<AIEnemy>().damage;
            }
            else
            {
                gameManager.life = 0;
            }
            gameManager.SetLifeOnScreen();
            Destroy(other.gameObject);
        }
    }
}
