using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefabs;
    [SerializeField]private Stage_Data stagedata;

    private int count = 10;

    [SerializeField]private float timeBetSpawnMin = 1.25f;
    [SerializeField]private float timeBetSpawnMax = 2.25f;
    private float timeBetSpawn;

    private GameObject[] enemys;
    private int current_index = 0;

    //private Vector2 poopPosition = new Vector2(0, stagedata.LimitMax.y + 1f);
    [SerializeField]private Vector2 poolPosition = new Vector2(10, 10);
    private float lastSpawnTime;

    [SerializeField] private GameObject enemyHpPrefabs;
    [SerializeField] private Transform CanvasTransform;

    // Start is called before the first frame update
    void Start()
    {
        //poopPosition = new Vector2(0, stagedata.LimitMax.y - 1f);
        enemys = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            enemys[i] = Instantiate(EnemyPrefabs, poolPosition, Quaternion.identity);
        }
        lastSpawnTime = 0;
        timeBetSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastSpawnTime + timeBetSpawn) 
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            float xPos = Random.Range(stagedata.LimitMin.x, stagedata.LimitMax.x);

            //enemys[current_index].SetActive(false);
            enemys[current_index].SetActive(true);
            SpawnEnemyHp(enemys[current_index].GetComponent<EnemyControl>());
            enemys[current_index].transform.position = new Vector2(xPos, stagedata.LimitMax.y);

            current_index++;
            if (current_index >= count)
            {
                current_index = 0;
            }
        }
    }

    void SpawnEnemyHp(EnemyControl enemy)
    {
        GameObject sliderClone = Instantiate(enemyHpPrefabs);
        sliderClone.transform.SetParent(CanvasTransform);
        sliderClone.transform.localScale = Vector3.one;

        sliderClone.GetComponent<EnemyHpPositionSetter>().SetUp(enemy.gameObject);
        sliderClone.GetComponent<EnemyHpViewer>().SetUp(enemy);
    }
}
