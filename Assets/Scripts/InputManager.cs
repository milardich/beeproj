using UnityEngine;

public class InputManager : MonoBehaviour
{
    /*
     * TODO: assign buttons/keys in config file or something
     */
    public int mousePrimary { get { return 0; } }
    public int mouseSecondary { get { return 1; } }
    public KeyCode groupSelect { get { return KeyCode.LeftShift; } }
    public KeyCode typeSelect { get { return KeyCode.LeftControl; } }
    public KeyCode controlKey { get { return KeyCode.LeftControl; } }

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
