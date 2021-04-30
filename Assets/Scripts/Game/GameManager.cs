using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool hasStard;
    public int round, gold, life;
    public int countBloons, maxBloons;
    public TextMeshProUGUI[] texts;
    public GameObject bloons, messageError, Canvas;
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
        if (!current)
        {
            if ((gold - Monkeys[index].GetComponent<Monkey>().cost) >= 0)
            {
                current = Instantiate(Monkeys[index]);
            }
            else
            {
                MessageERROR();
            }
        }
    }
    public void ResetMapa()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MessageERROR()
    {
        GameObject @object = Instantiate(messageError, Canvas.transform);
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
            SetRoundOnScreen();
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = startTimer;
                if (round < 18)
                {
                    GameObject @object = Instantiate(bloons, startPoint);
                    @object.GetComponent<MeshRenderer>().material.color = Color.red;
                    @object.GetComponent<AIEnemy>().damage = 1;
                    @object.GetComponent<AIEnemy>().type = AIEnemy.EnemyType.Normal;
                    @object.GetComponent<AIEnemy>().life = 1;
                    @object.GetComponent<AIEnemy>().amountGold = 5;
                }
                else if (round >= 18 && round < 27)
                {
                    GameObject @object = Instantiate(bloons, startPoint);
                    @object.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    @object.GetComponent<AIEnemy>().damage = 3;
                    @object.GetComponent<AIEnemy>().type = AIEnemy.EnemyType.Normal;
                    @object.GetComponent<AIEnemy>().life = 5;
                    @object.GetComponent<AIEnemy>().amountGold = 25;
                }
                else if (round >= 27 && round < 36)
                {
                    GameObject @object = Instantiate(bloons, startPoint);
                    @object.GetComponent<MeshRenderer>().material.color = Color.green;
                    @object.GetComponent<AIEnemy>().damage = 6;
                    @object.GetComponent<AIEnemy>().type = AIEnemy.EnemyType.Normal;
                    @object.GetComponent<AIEnemy>().life = 10;
                    @object.GetComponent<AIEnemy>().amountGold = 100;
                }
                else if (round >= 36 && round < 54)
                {
                    GameObject @object = Instantiate(bloons, startPoint);
                    @object.GetComponent<MeshRenderer>().material.color = Color.cyan;
                    @object.GetComponent<AIEnemy>().damage = 8;
                    @object.GetComponent<AIEnemy>().type = AIEnemy.EnemyType.Normal;
                    @object.GetComponent<AIEnemy>().life = 20;
                    @object.GetComponent<AIEnemy>().amountGold = 200;
                }
                else
                {
                    GameObject @object = Instantiate(bloons, startPoint);
                    @object.GetComponent<MeshRenderer>().material.color = Color.black;
                    @object.GetComponent<AIEnemy>().damage = 15;
                    @object.GetComponent<AIEnemy>().type = AIEnemy.EnemyType.MOAB;
                    @object.GetComponent<AIEnemy>().life = 35;
                    @object.GetComponent<AIEnemy>().amountGold = 500;
                }
                changeRound();
            }
            yield return null;
        }
    }
    public void changeRound()
    {
        if (countBloons <= 0)
        {
            round++;
            if (round < 18)
            {
                countBloons = maxBloons;
            }
            else if (round >= 18 && round < 27)
            {
                countBloons = maxBloons + (int)(maxBloons * 0.2f);
            }
            else if (round >= 27 && round < 36)
            {
                countBloons = maxBloons + (int)(maxBloons * 0.3f);
            }
            else if (round >= 36 && round < 54)
            {
                countBloons = maxBloons + (int)(maxBloons * 0.4f);
            }
            else
            {
                countBloons = maxBloons + (int)(maxBloons * 0.5f);
            }
        }
        else
        {
            countBloons--;
        }
    }
}
