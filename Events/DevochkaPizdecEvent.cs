﻿using System;
using System.Collections.Generic;
using HullBreakerCompany.Hull;

namespace HullBreakerCompany.Events;

public class DevochkaPizdecEvent : HullEvent
{
    public override string ID() => "DevochkaPizdec";
    public override int GetWeight() => 5;
    
    public static List<String> MessagesList = new()
    {
        { "<color=white>A lot of workers are going crazy here</color>" },
        { "<color=white>Phantom girl? We don't believe</color>" },
    };
    
    public override string GetDescription() => "Increased chance of phantom girl spawn";
    public override string GetMessage() => MessagesList[UnityEngine.Random.Range(0, MessagesList.Count)];
    public override string GetShortMessage() => "<color=white>COTARD SYNDROME</color>";
    public override void Execute(SelectableLevel level, Dictionary<Type, int> enemyComponentRarity,
        Dictionary<Type, int> outsideComponentRarity)
    {
        bool enemyExists = level.Enemies.Exists(enemy => enemy.GetType() == typeof(DressGirlAI));
        if (!enemyExists) return;
        
        enemyComponentRarity.Add(typeof(DressGirlAI), 32);
        HullManager.SendChatEventMessage(this);
    }
}