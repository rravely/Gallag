using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpPositionSetter : MonoBehaviour
{
    [SerializeField] private Vector3 distance = Vector3.up * 35f;

    private GameObject Target;
    private RectTransform UITransform;

    public void SetUp(GameObject target)
    {
        Target = target;
        UITransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!Target.activeSelf) //Enemy가 활성화되어 있지 않으면
        {
            Destroy(gameObject);
            return;
        }

        //WorldToScreenPoint은 World Space
        Vector3 ScreenPosition = Camera.main.WorldToScreenPoint(Target.transform.position);
        UITransform.position = ScreenPosition + distance;
    }
}
