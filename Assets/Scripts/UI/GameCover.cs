using UnityEngine.SceneManagement;

public class GameCover : Screen
{
    protected override void OnButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}