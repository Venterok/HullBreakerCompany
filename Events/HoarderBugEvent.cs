﻿using System;
using System.Collections.Generic;
using System.Linq;
using HullBreakerCompany.Hull;

namespace HullBreakerCompany.Events;

public class HoarderBugEvent : HullEvent
{
    public override string ID() => "HoarderBug";
    public override int GetWeight() => 50;
    public override string GetDescription() => "Increased chance of hoarder bug spawn";
    public override string GetMessage() => "<color=white>Keep an eye on the loot, Hoarding Bugs nearby</color>";
    public override string GetShortMessage() => "<color=white>BUG INVASION</color>";
    public override void Execute(SelectableLevel level, Dictionary<Type, int> enemyComponentRarity,
        Dictionary<Type, int> outsideComponentRarity)
    {
        if (level.Enemies.All(unit => unit.enemyType.enemyPrefab.GetComponent<HoarderBugAI>() == null)) return;
        
        enemyComponentRarity.Add(typeof(HoarderBugAI), 512);
        HullManager.SendChatEventMessage(this);
    }
}