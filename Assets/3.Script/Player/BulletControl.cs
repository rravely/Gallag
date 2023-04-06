using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField] private Stage_Data stagedata;
    private float destroyWeight = 2.0f; //화면 밖에 나가서 사라지도록 여유 공간 두기

    private void LateUpdate()
    {
        if (transform.position.y < stagedata.LimitMin.y - destroyWeight || transform.position.y > stagedata.LimitMax.y + destroyWeight
        || transform.position.x < stagedata.LimitMin.y - destroyWeight || transform.position.x > stagedata.LimitMax.x + destroyWeight)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy") //충돌한 상대의 태그가 "Bullet"이면
        {
            Destroy(gameObject);
        }
    }
}
