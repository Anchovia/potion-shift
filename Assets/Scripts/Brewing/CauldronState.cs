// 가마솥의 상태. 기획서 6-1 가마솥 제작의 진행과 완료.
public enum CauldronState
{
    Idle,      // 비어 있거나 재료 투입 중. 투입·회수·가동 가능
    Brewing,   // 가동 중. 조작 불가
    Done       // 완성 액체 대기 중. 병입·비우기 가능
}