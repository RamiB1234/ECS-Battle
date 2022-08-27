using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class PlayerMovementSystem : SystemBase
{
    private BattleManagerManagedComponent battleMgr;

    protected override void OnStartRunning()
    {
        Entities.ForEach((in BattleManagerManagedComponent battleManagerManagedComponent) =>
        {
            battleMgr = battleManagerManagedComponent;
        }).WithoutBurst().Run();
    }

    protected override void OnUpdate()
    {
        float delta = Time.DeltaTime;

        Entities.ForEach((ref Entity entity, in UnitComponentData unitComponent) =>
        {
            // Only move if the battle already started:
            if (battleMgr.battleStarted)
            {
                if (unitComponent.healthPoints > 0)
                {
                    // Move to the target unit:
                    var targetFinder = GetComponent<UnitFinderComponentData>(entity);
                    if (targetFinder.target != Entity.Null)
                    {
                        // Get the translation components:
                        var targetTranslation = GetComponent<Translation>(targetFinder.target);
                        var translation = GetComponent<Translation>(entity);
                        var dist = math.distance(targetTranslation.Value, translation.Value);

                        if (dist > unitComponent.attackRange)
                        {
                            // Move towards the target in XZ-plane:
                            if (targetTranslation.Value.x > translation.Value.x)
                            {
                                translation.Value.x += unitComponent.movementSpeed * delta;
                            }
                            else
                            {
                                translation.Value.x -= unitComponent.movementSpeed * delta;
                            }

                            if (targetTranslation.Value.z > translation.Value.z)
                            {
                                translation.Value.z += unitComponent.movementSpeed * delta;
                            }
                            else
                            {
                                translation.Value.z -= unitComponent.movementSpeed * delta;
                            }

                            SetComponent(entity, translation);
                        }
                    }
                }
                else
                {
                    // Make unit lost in space:
                    var translation = GetComponent<Translation>(entity);
                    translation.Value.x = 1000; 
                    translation.Value.y = 1000; 
                    translation.Value.z = 1000;
                    SetComponent(entity, translation);
                }
            }
        }).WithoutBurst().Run();

    }
}
