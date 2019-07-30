using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour
{
    [SerializeField] private Vector3 dpos;


    private void Operate()
    {
        bool _open = false;
        if (_open)
        {
            Vector3 pos = transform.position - dpos;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position + dpos;
            transform.position = pos;
        }

        _open = !_open;
    }
}
