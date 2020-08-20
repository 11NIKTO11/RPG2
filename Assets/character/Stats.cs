using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    [SerializeField] public int MaxHP { get; private set; } = 1000;
    public int actualHP { get; private set; }
    [SerializeField] public int Damage { get; protected set; }

    private void Start()
    {
        actualHP = MaxHP;
    }
    public void DealDamage(int damage)
    {
        actualHP -= damage;
        if (actualHP < 0)
        {
            actualHP = 0;

            GetComponent<Collider2D>().enabled = false;
        }
    }

    


}
