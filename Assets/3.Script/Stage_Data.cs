using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//데이터를 저장하는 방법 중 하나. Create에 가면 Stage_Data가 생긴것을 볼 수 있다.
[CreateAssetMenu] //Asset으로 만들기
public class Stage_Data : ScriptableObject
{
    //화면에 맞는 사이즈 저장하는 스크립트
    [SerializeField] private Vector2 limitMin;
    [SerializeField] private Vector2 limitMax;

    //다른 곳에서 값을 가지고 갈 수 있도록 -> 프로퍼티
    public Vector2 LimitMin => limitMin; //get{ return limitMin;} 과 같다
    public Vector2 LimitMax => limitMax; //get{ return limitMax;} 과 같다



}
