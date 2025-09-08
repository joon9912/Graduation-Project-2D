using UnityEngine;

public class MovementController : MonoBehaviour
{
    #region Variables
    private Vector2 targetVelocity; // 최종 속도를 계산하기 위한 임시 벡터
    #endregion

    #region Properties
    public Rigidbody2D RB { get; private set; }
    public Vector2 FacingDirection { get; private set; } // 상하좌우 방향을 저장하기 위해 Vector2로 변경
    public bool CanSetVelocity { get; set; }
    #endregion

    #region Unity Callback Functions
    public void Awake()
    {
        RB = GetComponentInParent<Rigidbody2D>();
        FacingDirection = Vector2.right; // 기본 방향을 오른쪽으로 설정
        CanSetVelocity = true;
    }
    #endregion

    // ========== Public API ==========
    #region Movement Functions
    // Velocity 
    public void SetVelocityZero()
    {
        targetVelocity = Vector2.zero;
        ApplyVelocity();
    }

    public void SetVelocity(float velocity, Vector2 direction)
    {
        // 방향 벡터를 정규화하여 어느 방향이든 동일한 속도를 갖도록 보장합니다.
        targetVelocity = direction.normalized * velocity;
        ApplyVelocity();
    }

    public void SetVelocityX(float velocity)
    {
        targetVelocity.Set(velocity, RB.linearVelocity.y);
        ApplyVelocity();
    }

    public void SetVelocityY(float velocity)
    {
        targetVelocity.Set(RB.linearVelocity.x, velocity);
        ApplyVelocity();
    }

    // Direction
    public void UpdateFacingDirection(Vector2 moveInput)
    {
        if (moveInput.sqrMagnitude > 0.01f) 
        {
            FacingDirection = moveInput.normalized;
        }
    }
    #endregion

    // ========== Implementation ==========
    #region Helper Function
    private void ApplyVelocity()
    {
        if (CanSetVelocity)
        {
            RB.linearVelocity = targetVelocity;
        }
    }
    #endregion
}