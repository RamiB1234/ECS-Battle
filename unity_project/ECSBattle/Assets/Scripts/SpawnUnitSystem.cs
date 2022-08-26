using Unity.Entities;
using UnityEngine;

public partial class SpawnUnitSystem : SystemBase
{
    protected override void OnStartRunning()
    {
        Application.targetFrameRate = 60;

        // Instantiate all units:
        Entities.ForEach((in SpawnPointData spawnPointData) =>
        {
            var prefab = spawnPointData.prefab;
            var unitEntity = EntityManager.Instantiate(prefab);
            SetComponent(unitEntity, spawnPointData.translation);

        }).WithStructuralChanges().Run();

    }

    protected override void OnUpdate()
    {

    }
}
