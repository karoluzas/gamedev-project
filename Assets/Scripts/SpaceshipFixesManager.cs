using UnityEngine;

public class SpaceshipFixesManager : MonoBehaviour
{
    public bool IsBoostersFixed { get; set; } = false;
    public bool IsEngineFixed { get; set; } = false;
    public bool IsCockpitFixed { get; set; } = false;

    public string BoostersFixedText { get; set; }
    public string EngineFixedText { get; set; }
    public string CockpitFixedText { get; set; }

    public bool IsGameWon => IsBoostersFixed && IsEngineFixed && IsCockpitFixed;

    private void Update()
    {
        if (IsGameWon)
        {

        }
    }
}
