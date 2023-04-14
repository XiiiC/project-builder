using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public ObjectPlacer objectplacer;
    public LavaController lavaController;
    public GameController gameController;

    public TMP_Text objectText;
    public TMP_Text colorText;
    public TMP_Text timerText;
    public TMP_Text objectCountText;
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        //Object text is the name of the currently selected prefab
        objectText.text = objectplacer.objects[0].name;
        //Color text is the name of the currently selected color
        colorText.text = objectplacer.colourNames[0];
        //Timer text is the time left in the game
        timerText.text = gameController.timeLeft.ToString("F0");
        //Object count text is the number of objects placed
        objectCountText.text = "Blocks " + objectplacer.currentObjects.ToString() + "/" + objectplacer.maxObjects.ToString();
        if(lavaController.playerDead || gameController.isTimeUp && !gameController.win)
        {
            gameOverScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        if(gameController.win)
        {
            winScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.SetActive(!pauseScreen.activeSelf);
            
            if(pauseScreen.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
            

        }

    }
}
