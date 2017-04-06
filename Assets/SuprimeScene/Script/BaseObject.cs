﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Radius))]
public abstract class BaseObject : MonoBehaviour, IEnemyChecker {
    private Player controllPlayer; //Игрок, который является владельцем объекта
    private Radius radius; //Радиус обнаружения врагов

    public virtual void setPlayer(Player player) {
        controllPlayer = player;
        radius = GetComponent<Radius>();
    }
    public abstract void setRadius(float size);
    public abstract void EnemyCheck(BaseObject enemy);
    public Player ControllPlayer{ get { return controllPlayer; } set { controllPlayer = value; } }
    public Radius Radius{get { return radius; } }

}
