﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour {
    //movement speed can be changed in the Nav Mesh Agent

    #region Private fields

    NavMeshAgent navigationAgent;
    #endregion


    #region MonoBehaviour methods

    void Start() {
        navigationAgent = GetComponent<NavMeshAgent>();
    }
    #endregion

    #region Public methods

    public void moveTo(Vector3 targetPosition) {
        navigationAgent.SetDestination(targetPosition);
    }
    #endregion
}