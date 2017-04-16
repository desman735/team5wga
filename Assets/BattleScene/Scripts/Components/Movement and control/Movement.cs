﻿using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour {

    private static readonly float DESTINATION_EPS = 3.0f; // дистанция, при которой считается, что цель достигнута

    #region private fields

    private NavMeshAgent navigationAgent; // агент от юнити
    private bool isSettedUp;
    #endregion

    #region getters and setters

    private NavMeshAgent NavigationAgent {
        get {return navigationAgent;}
        set {navigationAgent = value;}
    }

    public bool IsSettedUp {
        get { return isSettedUp; }
        set { isSettedUp = value; }
    }
    #endregion

    #region MonoBehaviour methods

    public void Update() {
        if (!IsSettedUp) {
            throw new SystemIsNotSettedUpException();
        }
    }
    #endregion

    #region public methods

    // Передвижение к точке
    public void moveTo(Vector3 targetPosition) {
        NavigationAgent.SetDestination(targetPosition);
    }

    // Следование за целью
    public void follow(BaseObject target) { // TODO Can be improved with target movement interpolation
        // Если мы пришли к точке, взять новую в окружности радиусом FollowRadius вокруг цели
        if (NavigationAgent.remainingDistance < DESTINATION_EPS) {
            Vector2 shift = Random.insideUnitCircle * target.ReactDistance;
            moveTo(target.Position + new Vector3(shift.x, 0, shift.y));
        }
    }

    // Остановка движения сбросом пути
    // ВНИМАНИЕ follow будет считать, что цель достигнута и возьмёт новую точку
    public void stop() {
        NavigationAgent.ResetPath();
    }

    public void setupSystem(float maxSpeed) {
        NavigationAgent = GetComponent<NavMeshAgent>();
        NavigationAgent.speed = maxSpeed;
        IsSettedUp = true;
    }
    #endregion
}