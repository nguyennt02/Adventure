using UnityEngine;

public class SkikedBallRotate : NewMonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected bool _directionRight;

    protected virtual void Update()
    {
        transform.Rotate(Direction * _speed * Time.deltaTime);
    }

    protected virtual Vector3 Direction => _directionRight ? Vector3.forward : Vector3.back;
}
