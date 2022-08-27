using TMPro;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial class UpdateHealthUISystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((HealthUIManagedComponent healthUIManagedComponent, in UnitComponentData unitComponentData, in Translation translation) =>
        {
            healthUIManagedComponent.healthText = GameObject.Find($"Canvas-Unit{unitComponentData.unitNo}").GetComponentInChildren<TextMeshProUGUI>();
            healthUIManagedComponent.healthText.text = unitComponentData.healthPoints.ToString();
            healthUIManagedComponent.healthText.transform.position =
            new Vector3(translation.Value.x, translation.Value.y + healthUIManagedComponent.buffer, translation.Value.z);
        }).WithoutBurst().Run();
    }
}
