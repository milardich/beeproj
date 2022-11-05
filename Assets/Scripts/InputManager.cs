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
    public KeyCode spawnWorkerBee { get { return KeyCode.Alpha1; } }
    public KeyCode attack { get { return KeyCode.A; } }
    public KeyCode stop { get { return KeyCode.S; } }
    public KeyCode selectAllBees { get { return KeyCode.F2; } }
    public KeyCode selectFreeWorker { get { return KeyCode.F1; } }
    public KeyCode ability1 { get { return KeyCode.Q; } }
    public KeyCode ability2 { get { return KeyCode.W; } }
    public KeyCode ability3 { get { return KeyCode.E; } }
    public KeyCode ability4 { get { return KeyCode.R; } }

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
