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
        foreach (string file in System.IO.Directory.GetFiles(Application.dataPath + "/data", "*.txt"))
        {
            print(file);
            GameObject goButton = (GameObject)Instantiate(myPrefab);
            goButton.transform.SetParent(GameObject.Find("Grid").transform, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);
            Button tempButton = goButton.GetComponent<Button>();
            tempButton.onClick.AddListener(() => ButtonClicked(file));
            goButton.GetComponentInChildren<Text>().text = file.Split('_')[1].Split('_')[0];
            
        }
    }
    void ButtonClicked(string path)
    {
        Debug.Log("Button clicked = " + path);
        Questions questions = Main.readJSON(path);;

        foreach (Question question in questions.questions)
        {
            Debug.Log("Found game : " + question.question + " " + question.trueResponse + " " + question.falseResponse);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}