using System.Collections.Generic;

public interface IAbilityCaster
{
    List<IAbility> Abilities { get; set; }
    void UseAbility(IAbility ability);
}
