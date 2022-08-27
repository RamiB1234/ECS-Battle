using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial class PlayerMovementSystem : SystemBase
{
    private float distanceBuffer = 1.5f;
    protected override void OnUpdate()
    {
        float delta = Time.DeltaTime;
        Entities.ForEach((ref Entity entity, in UnitComponentData unitComponent) =>
        {
            // Move to the target unit:
            if (unitComponent.targetUnit != Entity.Null)
            {
                // Get the translation components:
                var targetTranslation = GetComponent<Translation>(unitComponent.targetUnit);
                var translation = GetComponent<Translation>(entity);

                if (CalculateDistance(targetTranslation, translation) > distanceBuffer)
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
        }).WithoutBurst().Run();

    }


    private float CalculateDistance(Translation p1,Translation p2)
    {
        var dist = math.distance(p2.Value, p1.Value);
        return dist;
    }
}
