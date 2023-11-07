using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class CoolDown
{
    public float _coolDownTime;
    public float _nextFireTime;

    public bool IsCoolingDown => Time.time < _nextFireTime;
    public void StartCoolDown() => _nextFireTime = Time.time + _coolDownTime;

}
