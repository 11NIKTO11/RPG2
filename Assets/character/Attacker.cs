using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class Attacker : MonoBehaviour
{

    [SerializeField] private Vector2 size = new Vector2(0.5f,2f);
    [SerializeField] private LayerMask layer;
    [Min(0)][SerializeField] public int Damage = 100;


    public void Attack()
    {
        var hited = Physics2D.OverlapBoxAll(transform.position, size,0,layer);

        for (int i = 0; i < hited.Length; i++)
        {
            Debug.Log(hited[i].name+ i +" - hitted");
            hited[i].TryGetComponent<Stats>(out var x);
            x.DealDamage(Damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, size);
    }
}
