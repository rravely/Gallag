using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private PlayerControl player;
    [SerializeField] private Stage_Data stagedata;
    private Animator animator;
    private float destroyWeight = 2.0f; //화면 밖에 나가서 사라지도록 여유 공간 두기

    private void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        //null 값이 들어가면 메모리를 잡아먹고 GC가 수집해감 
        //TryGetComponent -> bool 반환
        GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player); //위 방법보다 약 20퍼센트 빠르다 ~
        animator = transform.GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        if (transform.position.y < stagedata.LimitMin.y - destroyWeight || transform.position.y > stagedata.LimitMax.y + destroyWeight
        || transform.position.x < stagedata.LimitMin.y - destroyWeight || transform.position.x > stagedata.LimitMax.x + destroyWeight)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    void Die()
    {
        animator.SetTrigger("Enemy_Die");
        //적 사망하면 사라짐
        //Destroy(gameObject);
        gameObject.SetActive(false);
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet") //충돌한 상대의 태그가 "Bullet"이면
        {
            Die();
        }
        else if (collider.CompareTag("Player"))
        {
            player.TakeDamage(1f);
            Die();
        }
    }

}
