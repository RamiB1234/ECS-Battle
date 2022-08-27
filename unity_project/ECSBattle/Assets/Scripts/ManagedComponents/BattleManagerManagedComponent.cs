using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

[GenerateAuthoringComponent]
public class BattleManagerManagedComponent : IComponentData
{
    public Button startButton;
    public GameObject blueTeamWinsText;
    public bool blueTeamWins = false;
    public GameObject redTeamWinsText;
    public bool redTeamWins = false;
    public bool battleStarted;
}
