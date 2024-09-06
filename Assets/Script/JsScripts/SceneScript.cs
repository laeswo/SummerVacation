using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public static SceneScript instance;
    public List<string> scenes;
    public int index;
    public int count;

    private void Awake()
    {
        if(instance == null)
        { 
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            
            index = 0;
            count = 0;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Load()
    {
        if (count >= 5 && index > 0)
        {
            index--;
            count = 0;
        }
        if (index < 0 || index >= scenes.Count)
            index = 0;

        Debug.Log(index);
        SceneManager.LoadScene(scenes[index]);
    }
}
