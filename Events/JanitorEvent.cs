using System;
using System.Collections.Generic;
using System.Linq;
using HullBreakerCompany.Hull;

namespace HullBreakerCompany.Events;

public class JanitorEvent : HullEvent
{
    public override string ID() => "Janitor";
    public override int GetWeight() => 5;
    public override string GetDescription() => "Increased chance of ButlerBees spawn";
    public override string GetMessage() => "<color=white>Perfect cleanliness of the floor inside the complex</color>";
    public override string GetShortMessage() => "<color=orange>BUTLER THE JANITOR</color>";

    public override void Execute(SelectableLevel level, Dictionary<Type, int> enemyComponentRarity,
        Dictionary<Type, int> outsideComponentRarity)
    {
        if (level.Enemies.All(unit => unit.enemyType.enemyPrefab.GetComponent<ButlerEnemyAI>() == null)) return;
        
        enemyComponentRarity.Add(typeof(ButlerEnemyAI), 256);
        HullManager.SendChatEventMessage(this);
    }
}