using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager main;

    public GameObject ballPrefab;

    public float xBound = 3f;
    public float yBound = 3f;
    public float ballSpeed = 3f;
    public float respawnDelay = 2f;

    public int[] playerScores;

    public Text mainText;

    public Text[] playerTexts;

    Entity ballEntityPrefab;
    EntityManager manager;

    WaitForSeconds oneSecond;
    WaitForSeconds delay;


    void OnAwake()
    {
        if(main != null && main != this)
        {
            Destroy(gameObject);
            return;
        }

        main = this;

        playerScores = new int[2];

        oneSecond = new WaitForSeconds(1f);

        delay = new WaitForSeconds(respawnDelay);

        StartCoroutine(CountdownAndSpawnBall());

    }


    public void PlayerScored(int playerID)
    {
        playerScores[playerID]++;

        playerTexts[playerID].text = playerScores[playerID].ToString();

        StartCoroutine(CountdownAndSpawnBall());
    }

    private IEnumerator CountdownAndSpawnBall()
    {
        mainText.text = "Get Ready";
        yield return delay;

        for (int i = 3; i > 0; i--) {

            mainText.text = i.ToString();
            yield return oneSecond;
        }

        mainText.text = "";

        SpawnBall();

    }

    void SpawnBall()
    {

    }
}
