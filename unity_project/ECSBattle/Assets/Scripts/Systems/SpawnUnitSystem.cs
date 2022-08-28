using System.Linq;
using TMPro;
using Unity.Entities;
using UnityEngine;

public partial class SpawnUnitSystem : SystemBase
{
    private BattleManagerManagedComponent battleMgr;
    private bool doneSpawning = false;

    protected override void OnStartRunning()
    {
        // Get reference to the battle manager:
        Entities.ForEach((in BattleManagerManagedComponent battleManagerManagedComponent) =>
        {
            battleMgr = battleManagerManagedComponent;
        }).WithoutBurst().Run();

        battleMgr.configsModel = JsonUtility.FromJson<ConfigsModel>(battleMgr.configFile.ToString());

        // Instantiate all units:
        Entities.ForEach((in SpawnPointData spawnPointData) =>
        {
            var selectedIndex = battleMgr.selectedConfigIndex;
            if (battleMgr.configsModel.Configs[selectedIndex].Units.Contains(spawnPointData.unitNo))
            {
                var prefab = spawnPointData.prefab;
                var unitEntity = EntityManager.Instantiate(prefab);

                // Set translation:
                SetComponent(unitEntity, spawnPointData.translation);

                // Set isTeamA:
                var componentData = GetComponent<UnitComponentData>(unitEntity);
                componentData.isTeamA = spawnPointData.isTeamA;
                componentData.unitNo = spawnPointData.unitNo;

                // Set properties from config:
                if (spawnPointData.isTeamA)
                {
                    componentData.healthPoints =
                    battleMgr.configsModel.Configs[selectedIndex].TeamAProperties.HP;
                    componentData.attack =
                    battleMgr.configsModel.Configs[selectedIndex].TeamAProperties.Attack;
                    componentData.attackSpeed =
                    battleMgr.configsModel.Configs[selectedIndex].TeamAProperties.AttackSpeed;
                    componentData.attackRange =
                    battleMgr.configsModel.Configs[selectedIndex].TeamAProperties.AttackRange;
                    componentData.movementSpeed =
                    battleMgr.configsModel.Configs[selectedIndex].TeamAProperties.MovementSpeed;
                }
                else
                {
                    componentData.healthPoints =
                    battleMgr.configsModel.Configs[selectedIndex].TeamBProperties.HP;
                    componentData.attack =
                    battleMgr.configsModel.Configs[selectedIndex].TeamBProperties.Attack;
                    componentData.attackSpeed =
                    battleMgr.configsModel.Configs[selectedIndex].TeamBProperties.AttackSpeed;
                    componentData.attackRange =
                    battleMgr.configsModel.Configs[selectedIndex].TeamBProperties.AttackRange;
                    componentData.movementSpeed =
                    battleMgr.configsModel.Configs[selectedIndex].TeamBProperties.MovementSpeed;
                }

                componentData.attackCoolDownTimer = 1;

                SetComponent(unitEntity, componentData);
            }

        }).WithStructuralChanges().Run();
    }

    protected override void OnUpdate()
    {

    }
}
