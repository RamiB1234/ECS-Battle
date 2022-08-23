using Unity.Entities;
using Unity.Transforms;

public partial class PlayerMovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float delta = Time.DeltaTime;
        Entities.ForEach((ref Translation translation, in UnitComponentData unitComponent) =>
        {
            translation.Value.x += unitComponent.value * delta;
        }).ScheduleParallel();

    }
}
