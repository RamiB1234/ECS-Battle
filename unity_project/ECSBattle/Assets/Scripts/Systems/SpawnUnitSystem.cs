using Unity.Entities;

public partial class SpawnUnitSystem : SystemBase
{
    protected override void OnStartRunning()
    {
        // Instantiate all units:
        Entities.ForEach((in SpawnPointData spawnPointData) =>
        {
            var prefab = spawnPointData.prefab;
            var unitEntity = EntityManager.Instantiate(prefab);

            // Set translation:
            SetComponent(unitEntity, spawnPointData.translation);

            // Set isTeamA:
            var componentData = GetComponent<UnitComponentData>(unitEntity);
            componentData.isTeamA = spawnPointData.isTeamA;
            componentData.unitNo = spawnPointData.unitNo;
            componentData.attackCoolDownTimer = 1;
            SetComponent(unitEntity, componentData);

        }).WithStructuralChanges().Run();

    }

    protected override void OnUpdate()
    {

    }
}
