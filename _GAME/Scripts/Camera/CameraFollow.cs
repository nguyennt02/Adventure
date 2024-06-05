using System;
using UnityEngine;

public class CameraFollow : NewMonoBehaviour
{
    [SerializeField] private Transform target;
    Vector3 veclocity = Vector3.zero;

    [Range(0, 1)]
    [SerializeField] private float soothTime;

    [SerializeField] private Vector3 positionOffset;

/*    [Header("Limit")]
    [SerializeField] private Vector2 xLimit;
    [SerializeField] private Vector2 yLimit;*/

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTarget();
    }

    private void LoadTarget()
    {
        if (target) return;
        LogWarning("LoadTarget");
        target = GameObject.Find("Character").transform;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + positionOffset;
        //targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y), Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y), -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref veclocity, soothTime);
    }
}
