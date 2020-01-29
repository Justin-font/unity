using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstantiationExample : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        for (int i = 0; i < 10; i++)
        {
            GameObject goButton = (GameObject)Instantiate(myPrefab);
        goButton.transform.SetParent(GameObject.Find("Grid").transform, false);
        goButton.transform.localScale = new Vector3(1, 1, 1);

        Button tempButton = goButton.GetComponent<Button>();
        int tempInt = i;
        tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
           goButton.GetComponentInChildren<Text>().text = i.ToString();
        }
    }
    void ButtonClicked(int buttonNo)
    {
        Debug.Log("Button clicked = " + buttonNo);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}