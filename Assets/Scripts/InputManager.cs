using UnityEngine;

public class InputManager : MonoBehaviour
{
    public int mouseLeft { get { return 0; } }
    public int mouseRight { get { return 1; } }

    public static InputManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
