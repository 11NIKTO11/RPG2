using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;

    [SerializeField]
    private Vector3 distance = new Vector3(0, 1, -10);

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + distance;
    }
}
