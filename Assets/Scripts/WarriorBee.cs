using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WarriorBee : Unit, IMoveable, IOffensive, IAbilityCaster
{
    private NavMeshAgent agent;
    private InputManager inputManager;

    public List<IAbility> Abilities { get; set; }

    void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    new void Start()
    {
        base.Start();
        inputManager = InputManager.Instance;
        Abilities = new List<IAbility>();
        SetupAbilities();
    }

    void Update()
    {
        // move this to AbilityManager class or something
        if(Input.GetKeyDown(inputManager.ability1) && this.IsSelected()) {
            UseAbility(this.Abilities[0]);
        }
    }

    public void Move(Vector3 destination)
    {
        this.agent.isStopped = false;
        this.agent.destination = destination;
    }

    public void StopMoving()
    {
        this.agent.isStopped = true;
    }

    public void Attack(int damageAmount)
    {
        throw new System.NotImplementedException();
    }

    public void UseAbility(IAbility ability)
    {
        ability.Cast();
    }

    private void SetupAbilities()
    {
        this.Abilities.Add(this.GetOrAddComponent<MovementSpeedBoost>());
    }
}
