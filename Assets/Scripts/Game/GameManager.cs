using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasStard;
    public int round, gold, life;
    public int countBloons, maxBloons;
    public TextMeshProUGUI[] texts;
    public GameObject bloons,messageError,Canvas;
    public float timer, startTimer;
    public Transform startPoint;
    public GameObject[] Monkeys;
    public GameObject current;
    private void Start()
    {
        countBloons = maxBloons;
        texts[0].text = (round = 1).ToString();
        texts[1].text = (gold = 900).ToString();
        texts[2].text = (life = 100).ToString();
    }
    public void SelectMonkey(int index)
    {
        current = Monkeys[index];
    }
    public void MessageERROR()
    {
        GameObject @object= Instantiate(messageError, Canvas.transform);
        Destroy(@object, 3f);
    }
    public void PressStart()
    {
        if (hasStard)
            hasStard = false;
        else
        {
            hasStard = true;
            StartCoroutine(SpawnBloons());
        }
    }
    public void SetRoundOnScreen()
    {
        texts[0].text = round.ToString();
    }
    public void SetGoldOnScreen()
    {
        texts[1].text = gold.ToString();
    }
    public void SetLifeOnScreen()
    {
        texts[2].text = life.ToString();
    }
    IEnumerator SpawnBloons()
    {
        bool needRestart = false;
        yield return new WaitForEndOfFrame();
        while (hasStard)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = startTimer;
                if (round < 18)
                {
                    if (needRestart)
                    {
                        countBloons = maxBloons + (int)(maxBloons * 0.2f);
                        yield return new WaitForSeconds(3f);
                        needRestart = false;
                    }
                    if (countBloons < 0)
                    {
                        round++;
                        needRestart = true;
                    }
                    else
                    {
                        countBloons--;
                        GameObject @object = Instantiate(bloons, startPoint);
                        @object.GetComponent<MeshRenderer>().material.color = Color.red;
                        @object.GetComponent<AIEnemy>().damage = 1;
                        @object.GetComponent<AIEnemy>().type = AIEnemy.EnemyType.Normal;
                        @object.GetComponent<AIEnemy>().life = 1;
                        @object.GetComponent<AIEnemy>().amountGold = 5;
                    }
                }
                else if (round >= 18)
                {
                    if (needRestart)
                    {
                        countBloons += maxBloons + (int)(maxBloons * 0.35f * 100f);
                        yield return new WaitForSeconds(3f);
                        needRestart = false;
                    }
                    if (countBloons < 0)
                    {
                        round++;
                        needRestart = true;
                        GameObject @object = Instantiate(bloons, startPoint);
                        @object.GetComponent<MeshRenderer>().material.color = Color.blue;
                        @object.GetComponent<AIEnemy>().damage = 3;
                        @object.GetComponent<AIEnemy>().type = AIEnemy.EnemyType.Masked;
                        @object.GetComponent<AIEnemy>().life = 10;
                        @object.GetComponent<AIEnemy>().amountGold = 20;
                    }
                }
                else if (round >= 36)
                {
                    if (needRestart)
                    {
                        countBloons += maxBloons + (int)(maxBloons * 0.4f);
                        yield return new WaitForSeconds(3f);
                        needRestart = false;
                    }
                    if (countBloons < 0)
                    {
                        round++;
                        needRestart = true;
                    }
                    else
                    {
                        countBloons--;
                        GameObject @object = Instantiate(bloons, startPoint);
                        @object.GetComponent<MeshRenderer>().material.color = Color.yellow;
                        @object.GetComponent<AIEnemy>().type = AIEnemy.EnemyType.Endure;
                        @object.GetComponent<AIEnemy>().damage = 5;
                        @object.GetComponent<AIEnemy>().life = 15;
                        @object.GetComponent<AIEnemy>().amountGold = 40;
                    }
                }
                else if (round >= 54)
                {
                    if (needRestart)
                    {
                        countBloons += maxBloons + (int)(maxBloons * 0.45f);
                        yield return new WaitForSeconds(3f);
                        needRestart = false;
                    }
                    if (countBloons < 0)
                    {
                        round++;
                        needRestart = true;
                    }
                    else
                    {
                        countBloons--;
                        GameObject @object = Instantiate(bloons, startPoint);
                        @object.GetComponent<MeshRenderer>().material.color = Color.yellow;
                        @object.GetComponent<AIEnemy>().type = AIEnemy.EnemyType.Endure;
                        @object.GetComponent<AIEnemy>().damage = 25;
                        @object.GetComponent<AIEnemy>().life = 50;
                        @object.GetComponent<AIEnemy>().amountGold = 40;
                    }
                }
                else
                {
                    if (needRestart)
                    {
                        countBloons += maxBloons + (int)(maxBloons * 0.5f);
                        yield return new WaitForSeconds(3f);
                        needRestart = false;
                    }
                    if (countBloons < 0)
                    {
                        round++;
                        needRestart = true;
                    }
                    else
                    {
                        countBloons--;
                        GameObject @object = Instantiate(bloons, startPoint);
                        @object.GetComponent<MeshRenderer>().material.color = Color.cyan;
                        @object.GetComponent<AIEnemy>().type = AIEnemy.EnemyType.MOAB;
                        @object.GetComponent<AIEnemy>().damage = 50;
                        @object.GetComponent<AIEnemy>().life = 100;
                        @object.GetComponent<AIEnemy>().amountGold = 500;
                    } 
                }
            }
            yield return null;
        }
    }
}
