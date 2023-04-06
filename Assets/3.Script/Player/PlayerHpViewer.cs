using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpViewer : MonoBehaviour
{
    [SerializeField] private Slider sliderHp;
    [SerializeField] private PlayerControl player;

    // Start is called before the first frame update
    void Start()
    {
        //sliderHp = GetComponent<Slider>();
        TryGetComponent(out sliderHp);
    }

    // Update is called once per frame
    void Update()
    {
        sliderHp.value = player.CurrentHP / player.MAXHP;
    }
}
