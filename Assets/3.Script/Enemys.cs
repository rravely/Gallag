using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    [SerializeField]private GameObject Enemy;
    [SerializeField]private Stage_Data stagedata;
    [SerializeField]private float CreateRate = 3f; //생성 빈도


    void Start()
    {
        StartCreateEnemy();
    }

    //StopCreateEnemy()로 코루틴 종료해주어야함. 게임 오버 조건에 넣는걸로
    

    public void CreateEnemy()
    {
        //총알 생성
        Instantiate(Enemy, new Vector2(Random.Range(stagedata.LimitMin.x, stagedata.LimitMax.x), transform.position.y), Quaternion.identity);
    }

    IEnumerator CreateEnemy_co() //Coroutine
    {
        while (true)
        {
            Instantiate(Enemy, new Vector2(Random.Range(stagedata.LimitMin.x, stagedata.LimitMax.x), transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(CreateRate); 
        }
    }

    public void StartCreateEnemy()
    {
        //Coroutin을 사용하겠다고 명시
        StartCoroutine("CreateEnemy_co"); //사용할 코루틴 매서드명(string)을 매개변수로 가짐
    }

    public void StopCreateEnemy()
    {
        StopCoroutine("CreateEnemy_co");
    }
}
