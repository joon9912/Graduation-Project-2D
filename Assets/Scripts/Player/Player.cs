using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    public Animator Anim { get; protected set; }
    public Rigidbody2D RB { get; protected set; }
    public SpriteRenderer SR { get; protected set; }
    public Transform TF { get; protected set; }

    public StateMachine StateMachine { get; private set; }

    public InputManager InputManager { get; private set; }
    public MovementController MovementController { get; private set; }

    // State들 
    public PlayerIdleState IdleState;
    public PlayerWalkState WalkState;

    private void Awake()
    {

        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        TF = GetComponent<Transform>();

        StateMachine = new StateMachine();

        InputManager = GetComponentInChildren<InputManager>();
        MovementController = GetComponentInChildren<MovementController>();

        // State 초기화
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        WalkState = new PlayerWalkState(this, StateMachine, playerData, "walk");
    }

    private void Start()
    {
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
}
