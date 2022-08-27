using Unity.Entities;
using Unity.Transforms;

[GenerateAuthoringComponent]
public struct SpawnPointData :  IComponentData
{
    public Translation translation;
    public Entity prefab;
    public bool isTeamA;
    public int unitNo;
}
