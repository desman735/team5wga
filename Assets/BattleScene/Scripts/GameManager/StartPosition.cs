﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour {
    public Crystal startCrystal;

    public Vector3 Position {
        get { return transform.position; }
    }
}
