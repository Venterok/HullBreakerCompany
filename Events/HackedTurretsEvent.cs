﻿using System;
using System.Collections.Generic;
using HullBreakerCompany.Event;
using HullBreakerCompany.hull;

namespace HullBreakerCompany.Events;

public class HackedTurretsEvent : HullEvent
{
    public override string ID() => "HackedTurrets";
    public override int GetWeight() => 10;
    public override string GetDescription() => "Turrets dont work on the moon";
    public override string GetMessage() => "<color=white>The company's hackers have disabled all turrets on this moon, you can breathe easy</color>";
    public override string GetShortMessage() => "<color=white>SYSTEM FAILURE</color>";
    public override void Execute(SelectableLevel level, Dictionary<Type, int> componentRarity)
    {
        HullManager.Instance.ExecuteAfterDelay(() => { HackTurrets(); }, 10f);
        HullManager.SendChatEventMessage(this);
    }
    
    private void HackTurrets()
    {
        Turret[] turrets = UnityEngine.Object.FindObjectsOfType<Turret>();
        foreach (Turret turret in turrets)
        {
            turret.ToggleTurretServerRpc(false);
        }
    }
}