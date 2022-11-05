using UnityEngine.UI;

public interface IAbility
{
    string Name { get; }
    string Description { get; }
    RawImage Icon { get; }
    void Cast();
}
