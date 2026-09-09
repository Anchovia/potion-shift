public interface IInteractable
{
    string GetPrompt();   // 화면에 띄울 안내 문구
    void Interact();      // 상호작용 키를 눌렀을 때 할 일
}