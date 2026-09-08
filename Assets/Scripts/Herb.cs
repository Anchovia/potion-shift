using UnityEngine;

public class Herb : MonoBehaviour, IInteractable
{
    public string GetPrompt()
    {
        return "E · 집기";
    }

    public void Interact()
    {
        Debug.Log("약재를 집었다");
    }
}