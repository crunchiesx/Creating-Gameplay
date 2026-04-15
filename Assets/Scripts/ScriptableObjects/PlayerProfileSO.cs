using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProfile", menuName = "Scriptable Objects/PlayerProfile")]
public class PlayerProfileSO : ScriptableObject
{
    public GameObject playerObject;
    public Color playerColor;
    public string playerName;
}
