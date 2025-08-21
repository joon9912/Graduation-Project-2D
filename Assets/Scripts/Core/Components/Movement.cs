using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Variables
    [Header("Speed")]
    [SerializeField] private float walkSpeed = 3.5f;
    [SerializeField] private float sprintSpeed = 5.5f;

    [Header("Refs")]
    [SerializeField] private Rigidbody2D rb;

    public float WalkSpeed { get => walkSpeed; set => walkSpeed = Mathf.Max(0f, value); }
    public float SprintSpeed { get => sprintSpeed; set => sprintSpeed = Mathf.Max(0f, value); }
    public Vector2 LastMoveDir { get; private set; }
    public float CurrentSpeed { get; private set; }
    public bool IsMoving => LastMoveDir.sqrMagnitude > 0.0001f;
    #endregion

    #region Unity Callback Methods
    private void Awake()
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
    }
    #endregion
    
    #region Movement Methods
    public void Move(Vector2 dir, bool sprint, float dt)
    {
        LastMoveDir = dir.sqrMagnitude > 1f ? dir.normalized : dir;
        CurrentSpeed = sprint ? sprintSpeed : walkSpeed;

        if (LastMoveDir.sqrMagnitude > 0f)
            rb.MovePosition(rb.position + LastMoveDir * CurrentSpeed * dt);
    }

    public void Move(int x, int y, bool sprint, float dt)
        => Move(new Vector2(x, y), sprint, dt);

    public void Stop()
    {
        LastMoveDir = Vector2.zero;
        CurrentSpeed = 0f;
        rb.linearVelocity = Vector2.zero;
    }
    #endregion
}
