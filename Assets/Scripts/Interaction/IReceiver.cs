using UnityEngine;

// 손에 든 물건을 받을 수 있는 기구 (절구, 가마솥 등)
public interface IReceiver
{
    bool TryReceive(GameObject item);   // 받았으면 true, 거부하면 false
}