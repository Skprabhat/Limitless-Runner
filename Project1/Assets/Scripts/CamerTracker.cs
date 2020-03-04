using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerTracker : MonoBehaviour
{
    public Transform Player;

    void Update()
    {
        transform.position = new Vector3(Player.position.x + 7, 0, -10);
    }
}
