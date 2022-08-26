using TMPro;
using Unity.Entities;

[GenerateAuthoringComponent]
public class HealthUIManagedComponent: IComponentData
{
    public float buffer;
    public TextMeshProUGUI healthText;
}
