using UnityEngine;

public interface IPickable
{
    void OnPickedUp(Transform holdPoint);   // 집혔을 때: 손 위치에 붙기
    void OnDropped();                       // 놓였을 때: 물리 복구
}