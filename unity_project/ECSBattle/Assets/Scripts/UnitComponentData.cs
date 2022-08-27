using Unity.Entities;

[GenerateAuthoringComponent]
public struct UnitComponentData : IComponentData
{
    public int healthPoints;
    public int attack;
    public int attackSpeed;
    public int attackRange;
    public int movementSpeed;
    public bool isTeamA;
    public Entity targetUnit;
}
