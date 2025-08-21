using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Movement movement;
    [SerializeField] private InputHandler inputHandler;
    #endregion

    #region Data
    [Header("Data")]
    [SerializeField] private PlayerData playerData;
    #endregion

    #region Properties
    public Rigidbody2D RB => rb;
    public Animator Animator => animator;
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    public Movement Movement => movement;
    public InputHandler InputHandler => inputHandler;

    public StateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    #endregion

    #region Unity Lifecycle
    private void Awake()
    {
        // 필수 컴포넌트 자동 캐싱
        if (!rb) rb = GetComponent<Rigidbody2D>();
        if (!spriteRenderer) spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (!animator) animator = GetComponentInChildren<Animator>();
        if (!movement) movement = GetComponent<Movement>();
        if (!inputHandler) inputHandler = GetComponent<InputHandler>();

        // 상태머신 및 상태 생성
        StateMachine = new StateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData);
        WalkState = new PlayerWalkState(this, StateMachine, playerData);
    }

    private void Start()
    {
        // 초기 상태는 Idle
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
