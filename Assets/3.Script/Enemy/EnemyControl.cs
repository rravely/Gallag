using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private PlayerControl player;
    [SerializeField] private Stage_Data stagedata;
    private Animator animator;
    private float destroyWeight = 2.0f; //화면 밖에 나가서 사라지도록 여유 공간 두기
    [SerializeField] private Weapon weapon;

    //EnemyHp 관련 변수
    [SerializeField]private float MaxHP = 2;
    private float currentHP;
    public float MAXHP => MaxHP;
    public float CurrentHP => currentHP;
    [SerializeField]private SpriteRenderer spriteRenderer;

    //playerScore
    [SerializeField] private PlayerScore playerScore;
    [SerializeField] private int enemyScore = 3;

    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        //null 값이 들어가면 메모리를 잡아먹고 GC가 수집해감 
        //TryGetComponent -> bool 반환
        GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player); //위 방법보다 약 20퍼센트 빠르다 ~
        GameObject.FindGameObjectWithTag("Player").TryGetComponent(out playerScore);
        TryGetComponent(out weapon);
        animator = transform.GetComponent<Animator>();
        TryGetComponent(out spriteRenderer);
    }

    void OnEnable()
    {
        currentHP = MaxHP;
        spriteRenderer.color = Color.white;
        weapon.StartFire();
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
            //Die();
            playerScore.SetScore(enemyScore);
            TakeDamage(1);
        }
        else if (collider.CompareTag("Player"))
        {
            player.TakeDamage(1f);
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        StopCoroutine("HitAnimation_co"); //매서드로 매개변수를 넣는 경우 코루틴이 생성되지 않으면 코루틴 인터페이스를 찾지 못하기 때문에 스트링으로 매서드 이름을 코루틴 키값으로하여 찾을 수 있다. 
        StartCoroutine("HitAnimation_co");
        if (currentHP <= 0) 
        {
            Die();
        }
    }
    IEnumerator HitAnimation_co()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

}
