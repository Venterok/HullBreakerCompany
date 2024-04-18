using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using HullBreakerCompany.Hull;

namespace HullBreakerCompany.Events;

public class ArachnophobiaEvent : HullEvent
{
    public override string ID() => "Arachnophobia";
    public override int GetWeight() => 20;
    
    public static List<String> MessagesList = new()
    {
        { "<color=white>Possible habitat of spiders</color>" },
        { "<color=white>Spider webs are everywhere</color>" },
        { "<color=white>Spiders are crawling everywhere</color>" },
    };
    
    public override string GetMessage() => MessagesList[UnityEngine.Random.Range(0, MessagesList.Count)];
    public override string GetDescription() => "Increased chance of spider spawning";
    public override string GetShortMessage() => "<color=white>ARACHNOPHOBIA</color>";
    public override void Execute(SelectableLevel level, Dictionary<Type, int> enemyComponentRarity,
        Dictionary<Type, int> outsideComponentRarity)
    {
        if (level.Enemies.All(unit => unit.enemyType.enemyPrefab.GetComponent<DressGirlAI>() == null)) return;
        
        enemyComponentRarity.Add(typeof(SandSpiderAI), 128);
        HullManager.SendChatEventMessage(this);
    }
}