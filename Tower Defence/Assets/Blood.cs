using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blood : MonoBehaviour
{
    public float HP;
    public Slider HPSlider;
    private float hp;


    // Start is called before the first frame update
    void Start()
    {
        hp = HP;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void updateBlood(int damage) {
        hp = hp + damage;
        HPSlider.value = hp/HP;
    }
}
