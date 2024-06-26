﻿using System;
using System.Collections.Generic;
using System.Linq;
using HullBreakerCompany.Hull;

namespace HullBreakerCompany.Events;

public class BabkinPogrebEvent : HullEvent
{
    public override string ID() => "BabkinPogreb";
    public override int GetWeight() => 10;
    
    public static List<String> MessagesList = new()
    {
        { "<color=white>On the this moon, something strange happened with scrap...</color>" },
        { "<color=white>It seems that only jars of pickles spawn on this moon...</color>" },
        { "<color=white>It's a pickle moon...</color>" },

    };
    public override string GetDescription() => "Only jars of pickles spawn on the moon";
    public override string GetMessage() => MessagesList[UnityEngine.Random.Range(0, MessagesList.Count)];
    public override string GetShortMessage() => "<color=white>ITEM MYSTERY</color>";
    public override void Execute(SelectableLevel level, Dictionary<Type, int> enemyComponentRarity,
        Dictionary<Type, int> outsideComponentRarity)
    {
        try
        {
            if (HullManager.Instance == null)
            {
                Plugin.Mls.LogError("HullManager.Instance is null");
                return;
            }

            if (level == null)
            {
                Plugin.Mls.LogError("level is null");
                return;
            }
            
            level.spawnableScrap.RemoveAll(item => item.spawnableItem.itemName != "Jar of pickles");
            if (level.spawnableScrap.Count == 0)
            {
                Plugin.Mls.LogError("No jars of pickles found in spawnableScrap list!");
                DelayedReturnList(level);
                return;
            }
            
            foreach (var item in level.spawnableScrap.Where(item => item.spawnableItem.itemName == "Jar of pickles"))
            {
                item.rarity = 100;
            }
            
            HullManager.Instance.ExecuteAfterDelay(() => { DelayedReturnList(level); }, 12f);
            HullManager.SendChatEventMessage(this);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Plugin.Mls.LogError($"ArgumentOutOfRangeException caught in BabkinPogrebEvent.Execute: {ex.Message}");
        }
    }

    private void DelayedReturnList(SelectableLevel level)
    {
        Plugin.Mls.LogInfo("Resetting spawnable items...");
        level.spawnableScrap.Clear();
        foreach (var item  in Plugin.NotModifiedSpawnableItemsWithRarity)
        {
            level.spawnableScrap.Add(item);
        }
    }

}