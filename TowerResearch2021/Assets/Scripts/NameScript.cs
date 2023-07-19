using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameScript : MonoBehaviour
{
    /// <summary>
    /// used to store the name for data collection
    /// </summary>
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        name = "test";
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
