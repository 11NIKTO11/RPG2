using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private int count= 1;
    public GameObject mob;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(mob);
        }        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
