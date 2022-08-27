using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public partial class TargetFinderSystem : SystemBase
{
    private List<Entity> teamAUnits;
    private List<Entity> teamBUnits;

    protected override void OnStartRunning()
    {

        teamAUnits = new List<Entity>();
        teamBUnits = new List<Entity>();

        Entities.ForEach((in UnitComponentData unitComponent, in Entity unit) =>
        {
            if (unitComponent.isTeamA == true)
            {
                teamAUnits.Add(unit);
            }
            else
            {
                teamBUnits.Add(unit);
            }
        }).WithoutBurst().Run();
    }

    protected override void OnUpdate()
    {
        // Find a random target from the opposite team:
        Entities.ForEach((ref UnitComponentData unitComponent, in Entity unit) =>
        {
            if(unitComponent.targetUnit == Entity.Null)
            {
                if(unitComponent.isTeamA)
                {
                    unitComponent.targetUnit = teamBUnits[Random.Range(0, teamBUnits.Count)];
                }
                else
                {
                    unitComponent.targetUnit = teamAUnits[Random.Range(0, teamAUnits.Count)];
                }
            }

        }).WithoutBurst().Run();
    }
}
