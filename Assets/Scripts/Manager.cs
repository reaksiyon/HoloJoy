using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab, enemyPrefab;

    [SerializeField]
    private List<GameObject> spawnPoints;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // First spawns are not random!
        StartCoroutine(WaitAndDo(0.1f, FirstStart));
    }

    public void FirstStart()
    {
        Instantiate(enemyPrefab, spawnPoints[3].transform.position, spawnPoints[3].transform.rotation);

        Instantiate(playerPrefab, spawnPoints[0].transform.position, spawnPoints[0].transform.rotation);

        foreach (var item in EnemyAI.EnemyList)
        {
            item.SetRetarget();
        }
        
    }

    public void SpawnPlayer()
    {
        GUIManager.Instance.PlayerSetHealth(100, 100); //Restart healthbar

        int random = Random.Range(0, spawnPoints.Count);

        Instantiate(playerPrefab, spawnPoints[random].transform.position, spawnPoints[random].transform.rotation);

        foreach (var item in EnemyAI.EnemyList)
        {
            item.SetRetarget();
        }
    }

    public void SpawnEnemy()
    {
        GUIManager.Instance.EnemySetHealth(100, 100); //Restart healthbar

        int random = Random.Range(0, spawnPoints.Count);

        Instantiate(enemyPrefab, spawnPoints[random].transform.position, spawnPoints[random].transform.rotation);
    }

    public void OnPlayerDie()
    {
        StartCoroutine(WaitAndDo(2, SpawnPlayer));
    }

    public void OnEnemyDie()
    {
        StartCoroutine(WaitAndDo(2,SpawnEnemy));
    }

    IEnumerator WaitAndDo(float second, UnityAction action)
    {
        yield return new WaitForSeconds(second);

        action();
    }

    //

    public static Manager Instance;
}
