using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThemeSwitcher : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // input
        // if (Input.GetKeyDown(KeyCode.Alpha1)) {
        //     ToggleTheme();
        // }
    }

    public void ToggleTheme() {
        int previousTheme = PlayerPrefs.GetInt("PreviousTheme", 1);
        int newTheme = previousTheme == 1 ? 2 : 1;
        SwitchTheme(newTheme);
    }

    // public void ForceInvertColors() {
    //     foreach (GameObject panel in GameObject.FindGameObjectsWithTag("Panel")) {
    //         panel.GetComponent<Image>().color = InvertColor(panel.GetComponent<Image>().color);
    //     }

    //     // Invert the color of all texts
    //     foreach (var text in FindObjectsOfType<Text>()) {
    //         text.color = InvertColor(text.color);
    //     }

    //     // Invert the color of all TextMeshProUGUI texts
    //     foreach (var text in FindObjectsOfType<TextMeshProUGUI>()) {
    //         text.color = InvertColor(text.color);
    //     }
    // }

    public void SwitchTheme(int theme) {
        string themeName = "Theme" + theme;

        Sprite[] themeSprites = Resources.LoadAll<Sprite>(themeName);


        int previousTheme = PlayerPrefs.GetInt("PreviousTheme", 1);

        PlayerPrefs.SetInt("CurrentTheme", theme);


        // for each gameObject with "Panel" it the name (in the hierarchy) invert the Image color
        // check my name, not by tag

        // ForceInvertColors();

        foreach (Image image in FindObjectsOfType<Image>()) {
            // Check if the sprite is located in a folder containing "t_" in its name
            if (image.sprite != null && image.sprite.name.Contains("t_")) {
                // Get the path of the sprite using the Resources.LoadAll<Sprite> method
                string spritePath = "Sprites/Theme" + previousTheme + "/" + image.sprite.name;

                // Check if the current sprite is in the previous theme's folder
                if (Resources.Load<Sprite>(spritePath) != null) {
                    // Change its sprite to the new theme's sprite
                    string newSpritePath = "Sprites/Theme" + theme + "/" + image.sprite.name;

                    // Change the sprite
                    image.sprite = Resources.Load<Sprite>(newSpritePath);
                }
            }
        }

    // Set the previous theme to the current theme for the next time the function is called
    PlayerPrefs.SetInt("PreviousTheme", theme);
}

// Helper function to invert a color
// private Color InvertColor(Color color) {
//     return new Color(1f - color.r, 1f - color.g, 1f - color.b, color.a);
// }






}
