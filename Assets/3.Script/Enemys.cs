using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    [SerializeField]private GameObject EnemyPrefabs;
    [SerializeField]private Stage_Data stagedata;
    [SerializeField]private float CreateRate = 3f; //생성 빈도


    void Awake()
    {
        //Coroutin을 사용하겠다고 명시
        StartCoroutine(CreateEnemy_co()); //오버라이딩: 사용할 코루틴 매서드명(string)도 되고 매서드도 된다
    }
    
    IEnumerator CreateEnemy_co() //Coroutine
    {
        //코루틴 캐싱
        WaitForSeconds wfs = new WaitForSeconds(CreateRate);
        //지속적으로 new 키워드를 사용해서 생성하는 경우 모조리 다 가비지 수집의 대상이 된다.
        //그래서 WaitForSeconds 캐싱하여 사용할 것이다. 
        //캐싱? 컴퓨팅에서 오랜시간 걸리는 작업의 결과를 저장해서 시간과 비용을 절감하는 기법 

        while (true)
        {
            Instantiate(EnemyPrefabs, new Vector2(Random.Range(stagedata.LimitMin.x, stagedata.LimitMax.x), transform.position.y), Quaternion.identity);
            yield return wfs; 
        }
    }
}
