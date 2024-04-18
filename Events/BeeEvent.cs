using System;
using System.Collections.Generic;
using System.Linq;
using HullBreakerCompany.Hull;

namespace HullBreakerCompany.Events;

public class BeeEvent : HullEvent
{
    public override string ID() => "Bee";
    public override int GetWeight() => 20;
    
    public static List<String> MessagesList = new()
    {
        { "<color=white>Possibly a large amount of bee hives</color>" },
        { "<color=white>Bees are buzzing...</color>" },
    };
    
    public override string GetDescription() => "Increased chance of bee hives spawning";
    public override string GetMessage() => MessagesList[UnityEngine.Random.Range(0, MessagesList.Count)];
    public override string GetShortMessage() => "<color=white>ANNOYING BUZZING</color>";
    public override void Execute(SelectableLevel level, Dictionary<Type, int> enemyComponentRarity,
        Dictionary<Type, int> outsideComponentRarity)
    {
        foreach (var unit in level.DaytimeEnemies.Where(unit => unit.enemyType.enemyPrefab.GetComponent<RedLocustBees>() != null))
        {
            unit.rarity = 128;
            break;
        }
        HullManager.SendChatEventMessage(this);
    }
}