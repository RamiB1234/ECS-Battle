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

        Entities.ForEach((in Entity unit,in UnitComponentData unitComponent) =>
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

        Entities.ForEach((Entity unit, ref UnitFinderComponentData unitFinder) =>
        {
            var target = unitFinder.target;
            if (target!= Entity.Null)
            {
                var targetData = GetComponent<UnitComponentData>(target);
                if (targetData.healthPoints <= 0)
                {
                    unitFinder.target = Entity.Null;
                }
            }

            var unitComponent = GetComponent<UnitComponentData>(unit);
            // Find a random target from the opposite team:
            if (unitFinder.target == Entity.Null)
            {
                if(unitComponent.isTeamA)
                {
                    var newTarget = teamBUnits[Random.Range(0, teamBUnits.Count)];
                    var newTargettData = GetComponent<UnitComponentData>(newTarget);
                    if(newTargettData.healthPoints>0)
                    {
                        unitFinder.target = newTarget;
                    }
                }
                else if (unitComponent.isTeamA==false)
                {
                    var newTarget = teamAUnits[Random.Range(0, teamAUnits.Count)];
                    var newTargettData = GetComponent<UnitComponentData>(newTarget);
                    if (newTargettData.healthPoints > 0)
                    {
                        unitFinder.target = newTarget;
                    }
                }
            }

        }).WithoutBurst().Run();
    }
}
