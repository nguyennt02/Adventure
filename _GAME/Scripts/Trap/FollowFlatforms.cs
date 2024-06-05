using UnityEngine;

public class FollowFlatforms : NewMonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(TagConst.PLAYER_TAG) || other.isTrigger) return;
        _player = other.transform.parent;
        SetPLayerIsChildren(other.transform.parent);
    }
    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag(TagConst.PLAYER_TAG) || other.isTrigger) return;
        SetPlayer();
    }
    protected virtual void SetPLayerIsChildren(Transform player)
    {
        player.SetParent(transform);
    }
    protected Transform _player;
    protected virtual void SetPlayer()
    {
        if (_player.gameObject.activeInHierarchy)
            _player.SetParent(null);
        else
            Invoke(nameof(SetPlayer), Time.deltaTime);
    }
}
