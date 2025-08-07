using UnityEngine;

public class Movement : CoreComponent
{
    public Rigidbody2D RB { get; private set; }
    public bool CanSetVelocity { get; set; }
    public Vector2 CurrentVelocity { get; private set; }
    private Vector2 workspace;

    protected override void Awake()
    {
        base.Awake();

        RB = GetComponentInParent<Rigidbody2D>();

        CanSetVelocity = true;
    }

    public void LogicUpdate()
    {
        CurrentVelocity = RB.linearVelocity;
    }

    #region Set Functions
    public void SetVelocityZero()
    {
        RB.linearVelocity = Vector2.zero;
    }

    public void SetVelocity(Vector2 velocity)
    {
        RB.linearVelocity = velocity;
    }
    #endregion
}