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
        Entities.ForEach((BattleManagerManagedComponent battleMgr) =>
        {
            // Start game if clicked:
            battleMgr.battleStarted = battleMgr.startButton.GetComponent<StartButton>().battleStarted;

            // Show winner text:
            if(battleMgr.blueTeamWins)
            {
                battleMgr.blueTeamWinsText.GetComponent<CanvasGroup>().alpha = 1;
                battleMgr.battleStarted = false;
            }
            if (battleMgr.redTeamWins)
            {
                battleMgr.redTeamWinsText.GetComponent<CanvasGroup>().alpha = 1;
                battleMgr.battleStarted = false;
            }
        }).WithoutBurst().Run();
    }
}
