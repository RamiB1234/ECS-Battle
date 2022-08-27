using Unity.Entities;
using UnityEngine.UI;

[GenerateAuthoringComponent]
public class BattleManagerManagedComponent : IComponentData
{
    public Button startButton;
    public bool battleStarted;
}
