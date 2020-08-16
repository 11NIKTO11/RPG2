using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
    void Move(float direction);
    void Jump(float jump);
    void Crouch(bool crouch);
}
