using Unity.Entities;

[GenerateAuthoringComponent]
public struct UnitFinderComponentData: IComponentData
{
    public Entity target;
}
