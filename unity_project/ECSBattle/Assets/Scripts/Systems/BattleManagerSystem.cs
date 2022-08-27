using Unity.Entities;

public partial class BattleManagerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((BattleManagerManagedComponent battle) =>
        {
            battle.battleStarted = battle.startButton.GetComponent<StartButton>().battleStarted;
        }).WithoutBurst().Run();
    }
}
