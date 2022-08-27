using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public partial class BattleManagerSystem : SystemBase
{
    private BattleManagerManagedComponent battleMgr;


    protected override void OnStartRunning()
    {
        Application.targetFrameRate = 60;
        Entities.ForEach((in BattleManagerManagedComponent battleManagerManagedComponent) =>
        {
            battleMgr = battleManagerManagedComponent;
        }).WithoutBurst().Run();

    }
    protected override void OnUpdate()
    {
        // Start game if clicked:
        battleMgr.battleStarted = battleMgr.startButton.GetComponent<StartButton>().battleStarted;

        // Show winner text:
        if (battleMgr.blueTeamWins)
        {
            battleMgr.blueTeamWinsText.GetComponent<CanvasGroup>().alpha = 1;
            battleMgr.battleStarted = false;
            battleMgr.restartButton.GetComponent<CanvasGroup>().alpha = 1;
            battleMgr.restartButton.GetComponent<Button>().interactable = true;
        }
        if (battleMgr.redTeamWins)
        {
            battleMgr.redTeamWinsText.GetComponent<CanvasGroup>().alpha = 1;
            battleMgr.battleStarted = false;
            battleMgr.restartButton.GetComponent<CanvasGroup>().alpha = 1;
            battleMgr.restartButton.GetComponent<Button>().interactable = true;
        }
    }
}
