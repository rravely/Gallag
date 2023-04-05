using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Movement2D movement2D;
    [SerializeField] private Stage_Data stagedata;
    [SerializeField] private Weapon weapon;

    void Awake()
    {
        movement2D = transform.GetComponent<Movement2D>();
        weapon = transform.GetComponent<Weapon>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (movement2D.moveSpeed <= 0f)
        {
            movement2D.moveSpeed = 5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //키 불러오기~~
        //GetAxis 이름에 맞는 키를 누르면 실행되도록 할 때 사용
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        movement2D.MoveTo(new Vector3(x, y, 0f));

        //총알 발사
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            weapon.StartFire();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            weapon.StopFire();
        }
        
    }

    //Update를 이걸로 보정
    void LateUpdate()
    {
        //플레이어가 화면 바깥으로 나가지 못하도록 설정
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, stagedata.LimitMin.x, stagedata.LimitMax.x),
            Mathf.Clamp(transform.position.y, stagedata.LimitMin.y, stagedata.LimitMax.y), 
            0f);
        //Mathf.Clamp(float value, float min, float max) value 값이 min과 max 사이에 있도록 해준다.
    }

    //플레이어 죽으면 게임 끝내기
    void Die()
    {
        
    }
}
