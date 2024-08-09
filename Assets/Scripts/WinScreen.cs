using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class WinScreen : MonoBehaviour
{
    private Button _restartButton;
    private Button _quitButton;
    public UIMenuManager uiMenuManager;

    //Add logic that interacts with the UI controls in the `OnEnable` methods
    private void OnEnable()
    {
        // The UXML is already instantiated by the UIDocument component
        var uiDocument = GetComponent<UIDocument>();

        _restartButton = uiDocument.rootVisualElement.Q("restartButton") as Button;
        _quitButton = uiDocument.rootVisualElement.Q("quitButton") as Button;

        _restartButton.RegisterCallback<ClickEvent>(restartGame);
        _quitButton.RegisterCallback<ClickEvent>(quitGame);
    }

    private void restartGame(ClickEvent evt)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    private void quitGame(ClickEvent evt){
        Application.Quit();
    }

}
