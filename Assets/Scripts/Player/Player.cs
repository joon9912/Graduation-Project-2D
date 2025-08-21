// Player.cs
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables 
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Movement movement;
    [SerializeField] private InputHandler inputHandler;

    [Header("Data")]
    [SerializeField] private PlayerData playerData;

    public Rigidbody2D RB => rb;
    public Animator Animator => animator;
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    public Movement Movement => movement;
    public InputHandler InputHandler => inputHandler;

    public StateMachine StateMachine { get; private set; }
<<<<<<< Updated upstream
    public InputHandler InputHandler { get; private set; }

    // State들 
=======
    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    #endregion
>>>>>>> Stashed changes

    #region Unity 생명주기 메서드
    private void Awake()
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
        if (!spriteRenderer) spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (!animator) animator = GetComponentInChildren<Animator>();
        if (!movement) movement = GetComponent<Movement>();
        if (!inputHandler) inputHandler = GetComponent<InputHandler>();

        StateMachine = new StateMachine();
<<<<<<< Updated upstream
        InputHandler = GetComponent<InputHandler>();

        // Idle 초기화
=======
        IdleState  = new PlayerIdleState(this, StateMachine, playerData);
        WalkState  = new PlayerWalkState(this, StateMachine, playerData);
>>>>>>> Stashed changes
    }

    private void Start()
    {
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState?.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState?.PhysicsUpdate();
    }
    #endregion
}
