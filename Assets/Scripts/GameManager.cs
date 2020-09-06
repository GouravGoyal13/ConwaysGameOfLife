using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private Text generationText;

    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button restartButton;

    [SerializeField]
    private GameOfLife gameofLife;

    [Range (0.1f,5f)]
    [SerializeField]
    private float ticks = 0.5f;

    private GameOfLife game;

    private void Awake() {
        game = gameofLife;
        gameofLife.gameObject.SetActive(true);
        GameOfLife.GenerationChanged += SetGenerationText;
        GameOfLife.PauseStateChanged += SetPauseButton;
        SetTickInterval(ticks);
    }

    public void SetTickInterval(float interval) {
        game.SetTickInterval(interval);
    }

    private void SetGenerationText(int generation) {
        generationText.text = "Generation: " + generation; 
    }

    private void SetPauseButton(bool paused) {
        playButton.GetComponentInChildren<Text>().text = paused ? "Play" : "Pause";
    }

    public void PlayPause() {
        game.TogglePause();
    }

    public void ResetGame() {
        game.Restart();
    }
}
