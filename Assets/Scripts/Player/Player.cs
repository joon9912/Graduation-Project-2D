using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variabels
    [SerializeField] private PlayerData playerData;

    // Core
    public Core Core { get; private set; }

    // Components
    public Animator Anim { get; protected set; }
    public Rigidbody2D RB { get; protected set; }
    public SpriteRenderer SR { get; protected set; }
    public Transform TF { get; protected set; }

    // Dependencies
    public StateMachine StateMachine { get; private set; }
    public InputHandler InputHandler { get; private set; }

    // States
    public PlayerIdleState IdleState;
    public PlayerWalkState WalkState;
    #endregion

    private void Awake()
    {
        // Components 및 Dependencies 초기화
        Core = GetComponentInChildren<Core>();
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        TF = GetComponent<Transform>();
        InputHandler = GetComponent<InputHandler>();
        StateMachine = new StateMachine();
        
        // Idle 초기화
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        WalkState = new PlayerWalkState(this, StateMachine, playerData, "walk");
    }

    private void Start()
    {
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
}
