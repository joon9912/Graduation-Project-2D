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
    public InputManager InputHandler { get; private set; }

    // State들 

    private void Awake()
    {

        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        TF = GetComponent<Transform>();

        StateMachine = new StateMachine();

        // Idle 초기화
    }

    private void Start()
    {
        // StateMachine.Initialize(IdleState);
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        
    }
}
