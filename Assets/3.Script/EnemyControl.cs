using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private Stage_Data stagedata;
    private Rigidbody2D Enemy_Rigidbody;
    private float destroyWeight = 2.0f; //화면 밖에 나가서 사라지도록 여유 공간 두기
    
    void Start()
    {
        Enemy_Rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Enemy_Rigidbody.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (transform.position.y < stagedata.LimitMin.y - destroyWeight || transform.position.y > stagedata.LimitMax.y + destroyWeight
        || transform.position.x < stagedata.LimitMin.y - destroyWeight || transform.position.x > stagedata.LimitMax.x + destroyWeight)
        {
            Destroy(gameObject);
        }
    }

    void Die()
    {
        //적 사망하면 사라짐
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet") //충돌한 상대의 태그가 "Bullet"이면
        {
            Die();
        }
    }
}
