using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanger : MonoBehaviour
{
    public Stats stats;
    private Slider barHP;
    // Start is called before the first frame update
    void Start()
    {
        barHP = GetComponent<Slider>();
        barHP.maxValue = stats.MaxHP;
        barHP.value = stats.actualHP;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        barHP.value = stats.actualHP;
        stats.DealDamage(1);
    }
}
