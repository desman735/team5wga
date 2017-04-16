﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersController : MonoBehaviour
{

    public static CharactersController Instance;

    public LayerMask MoveRaycastMask;
    public LayerMask SelectableMask;
    public ControllableUnit SelectedUnit;
    public bool FinishedDragOnThisFrame;
    public bool UserIsDragging;


    // Use this for initialization
    void Awake() {
        Instance = this;
        MoveRaycastMask = 1 << 14;
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (SelectedUnit != null) {
                SelectedUnit.deselectUnit();
                SelectedUnit = null;
            }

            if (Physics.Raycast(ray, out hit)) {
                ControllableUnit unit = hit.transform.GetComponentInParent<ControllableUnit>();
                if (unit != null) {
                    unit.selectUnit();
                    SelectedUnit = unit;
                }
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, MoveRaycastMask) && SelectedUnit != null) {
                SelectedUnit.UnitMoveSystem.moveTo(hit.point);
            }
        }
    }

    //public static bool UnitInsideDrag(Vector2 UnitInScreenPos)
    //{
    //    if (UnitInScreenPos.x > GUISelectorBox.BoxStart.x && UnitInScreenPos.y < GUISelectorBox.BoxStart.y
    //        && UnitInScreenPos.x < GUISelectorBox.BoxFinish.x && UnitInScreenPos.y > GUISelectorBox.BoxFinish.y)
    //        return true;
    //    else return false;

    //}
}