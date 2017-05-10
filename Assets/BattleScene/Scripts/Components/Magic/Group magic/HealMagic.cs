﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealMagic : GroupMagic {

    private float Duration { get { return GameConf.healDuration; } }
    private float HealRegenSpeed { get { return GameConf.GetHealRegenSpeed(Caster.LevelSystem.CurrentLevel); } }
    private float OldRegen { get; set; }

    public void Setup(Suprime caster) {
        base.Setup(caster,
            GameConf.healEnergyCost,
            GameConf.healCastTime);
    }

    protected override void ApplyMagic() {
        base.ApplyMagic();
        
        OldRegen = Units[0].HealthSystem.RegenSpeed;

        StartCoroutine(ApplyRegen());
    }

    private IEnumerator ApplyRegen() {
        foreach (Unit unit in Units) {
            unit.HealthSystem.RegenSpeed = HealRegenSpeed;
        }

        yield return new WaitForSeconds(Duration);
        CancelMagic();
    }

    protected override void CancelMagic() {
        base.CancelMagic();
        foreach (Unit unit in Units) {
            unit.HealthSystem.RegenSpeed = OldRegen;
        }
    }
}
