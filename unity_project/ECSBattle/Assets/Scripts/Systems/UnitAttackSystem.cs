using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial class UnitAttackSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Entity entity, ref UnitComponentData unitComponent) =>
        {
            var targetFinder = GetComponent<UnitFinderComponentData>(entity);
            if (targetFinder.target != Entity.Null)
            {

                // Get the translation components:
                var target = targetFinder.target;
                var targetTranslation = GetComponent<Translation>(target);
                var translation = GetComponent<Translation>(entity);
                var dist = math.distance(targetTranslation.Value, translation.Value);

                // Attack if target is in range and cooldown timer is finished:
                if (dist < unitComponent.attackRange)
                {
                    if (unitComponent.attackCoolDownTimer > 0)
                    {
                        unitComponent.attackCoolDownTimer -= 0.01f* unitComponent.attackSpeed;
                    }
                    else
                    {
                        var targetData = GetComponent<UnitComponentData>(target);
                        targetData.healthPoints -= unitComponent.attack;

                        // Reset cool down timer:
                        unitComponent.attackCoolDownTimer = 1;
                        SetComponent(target, targetData);
                    }
                }
            }
        }).WithStructuralChanges().Run();
    }
}
  