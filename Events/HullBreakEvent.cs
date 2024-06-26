﻿using System;
using System.Collections.Generic;
using HullBreakerCompany.Hull;

namespace HullBreakerCompany.Events;

public class HullBreakEvent : HullEvent
{
    public override string ID() => "HullBreak";
    public override int GetWeight() => 5;
    
    public static List<String> MessagesList = new()
    {
        { "<color=green>Take a break, the company is sending money for visiting the moon</color>" },
        { "<color=green>The company is sending money for visiting the moon</color>" },
    };
    
    public override string GetDescription() => "Getting money for visiting this moon";
    public override string GetMessage() => MessagesList[UnityEngine.Random.Range(0, MessagesList.Count)];
    public override string GetShortMessage() => "<color=white>TAKE A BREAK</color>";
    public override void Execute(SelectableLevel level, Dictionary<Type, int> enemyComponentRarity,
        Dictionary<Type, int> outsideComponentRarity)
    {
        HullManager.Instance.AddMoney(120);
        HullManager.SendChatEventMessage(this);
    }
}