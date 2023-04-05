using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]private GameObject PlayerBullet;
    [SerializeField]private float AttackRate = 0.5f; //총알 자동 발사하는 빈도

    public void TryAttack()
    {
        //총알 생성
        Instantiate(PlayerBullet, transform.position, Quaternion.identity);
    }

    IEnumerator TryAttack_co() //Coroutine
    {
        while (true)
        {
            Instantiate(PlayerBullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(AttackRate); 
        }
    }

    public void StartFire()
    {
        //Coroutin을 사용하겠다고 명시
        StartCoroutine("TryAttack_co"); //사용할 코루틴 매서드명(string)을 매개변수로 가짐
    }

    public void StopFire()
    {
        StopCoroutine("TryAttack_co");
    }
}
