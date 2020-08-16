using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsMover : MonoBehaviour
{
    public Controller controller;
    [Min(0)][SerializeField] private int tick = 10;
    private int remains;
    // Start is called before the first frame update
    void Start()
    {
        remains = tick;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var direction = 0; 
        if (remains == tick)
        {
            controller.Jump(1);
        }
        else if (remains > 0)
        {
            direction = 1;
        }
        else if (remains > -tick)
        {
            direction = -1;
        }
        else
        {
            remains = tick;
        }
        remains -= 1;
        controller.Move(direction);
    }
}
