using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScript : MonoBehaviour
{
    GameObject[] enemies;
    public GameObject PlayerPrefab;
    public GameObject Enemy1;
    int score;
    public Text ScoreField;

    void Start()
    {
        //spawn the player
        Instantiate(PlayerPrefab, new Vector2(0, 0), Quaternion.identity);

        //start spawning enemies
        InvokeRepeating("Spawner", 0.1f, 0.6f);

        score = 0;
        UpdateScoreField();
    }

    void Spawner()
    {
        //spawns enemy prefabs
        Instantiate(Enemy1, new Vector2(60, 60), Quaternion.identity);
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreField();
    }

    void UpdateScoreField()
    {
        ScoreField.text = "SCORE: " + score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreField();
    }

    public void KillEnemies()
    {
        //kills all enemies at reset
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}
