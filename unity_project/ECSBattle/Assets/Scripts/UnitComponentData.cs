using Unity.Entities;

[GenerateAuthoringComponent]
public struct UnitComponentData : IComponentData
{
    public int healthPoints;
    public float attack;
    public float attackSpeed;
    public float attackRange;
    public float movementSpeed;
    public bool isTeamA;
    public int unitNo;
    public Entity targetUnit;
}
