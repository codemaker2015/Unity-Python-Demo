using System.Collections;
using System.Collections.Generic;
using IronPython.Hosting;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PythonExample : MonoBehaviour
{
	[SerializeField]
	private Text greeting, randomNumber;

	// Use this for initialization
	void Start ()
	{
		var engine = Python.CreateEngine ();

		ICollection<string> searchPaths = engine.GetSearchPaths ();

		#if UNITY_STANDALONE_WIN
			//Path to the folder of greeter.py
			searchPaths.Add (Application.dataPath);
			//Path to the Python standard library
			searchPaths.Add (Application.dataPath + @"\StreamingAssets"  + @"\Lib\");
			engine.SetSearchPaths (searchPaths);

			dynamic py = engine.ExecuteFile (Application.dataPath + @"\StreamingAssets" + @"\Python\test.py");
			dynamic test = py.Test ("Codemaker");

			greeting.text = "Greeting: " + test.display ();
			randomNumber.text = "Random Number: " + test.random_number (1, 5);
		#endif
		#if UNITY_ANDROID
			//Path to the folder of greeter.py
			searchPaths.Add (Application.persistentDataPath);
			//Path to the Python standard library
			searchPaths.Add (Application.persistentDataPath + @"\Lib\");
			engine.SetSearchPaths (searchPaths);

			dynamic py = engine.ExecuteFile (Application.persistentDataPath + @"\Python\test.py");
			dynamic test = py.Test ("Codemaker");

			greeting.text = "Greeting: " + test.display ();
			randomNumber.text = "Random Number: " + test.random_number (1, 5);
		#endif
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
}
