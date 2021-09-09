using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void MinusEnemyHP(int value);

    void InitializePatrolSize(int size);

    void AssignPatrolPoints(GameObject point, int i);
}
