using Unity.Entities;
using UnityEngine;

public partial class BattleManagerSystem : SystemBase
{
    protected override void OnStartRunning()
    {
        Application.targetFrameRate = 60;
    }
    protected override void OnUpdate()
    {
        Entities.ForEach((BattleManagerManagedComponent battle) =>
        {
            battle.battleStarted = battle.startButton.GetComponent<StartButton>().battleStarted;
        }).WithoutBurst().Run();
    }
}
