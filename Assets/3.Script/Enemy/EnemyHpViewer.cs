using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpViewer : MonoBehaviour
{
    private EnemyControl enemy;
    private Slider HpSlider;

    public void SetUp(EnemyControl enemy)
    {
        this.enemy = enemy;
        TryGetComponent(out HpSlider);
    }
    // Update is called once per frame
    void Update()
    {
        HpSlider.value = enemy.CurrentHP / enemy.MAXHP;
    }
}
