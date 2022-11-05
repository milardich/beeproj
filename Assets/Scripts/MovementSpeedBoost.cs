using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MovementSpeedBoost : MonoBehaviour, IAbility
{
    private static float speedIncrease = 0.5f;
    private static float abilityDuration = 5.0f;
    private string abilityName = "Speed Boost";
    private string description = $"Increases unit's movement speed by {speedIncrease * 100}% for {abilityDuration} seconds";
    public string Name { get => this.abilityName; }
    public string Description { get => this.description; }
    public RawImage Icon { get => throw new System.NotImplementedException(); }

    public void Cast()
    {
        bool hasNavMeshAgent = this.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent);
        if(hasNavMeshAgent) {
            agent.speed += agent.speed * 0.5f;
        }
    }
}
