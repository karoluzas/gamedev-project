using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipFixesManager : MonoBehaviour
{
    public bool IsBoostersFixed { get; set; } = false;
    public bool IsEngineFixed { get; set; } = false;
    public bool IsCockpitFixed { get; set; } = false;

    public string BoostersFixedText { get; set; }
    public string EngineFixedText { get; set; }
    public string CockpitFixedText { get; set; }

    public bool IgnoreGameWon = false;

    private bool IsGameWon => IsBoostersFixed && IsEngineFixed && IsCockpitFixed;
    private bool GameIsInEndingProcess = false;

    private void Update()
    {
        if (!IgnoreGameWon)
        {
            if (IsGameWon && !GameIsInEndingProcess)
            {
                GameIsInEndingProcess = true;
                StartCoroutine(EndGame());
            }
        }
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadScene(8, LoadSceneMode.Single);
        CarryOverScene.Reset();
    }
}
