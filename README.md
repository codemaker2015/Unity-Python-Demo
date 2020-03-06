# Use Python with Unity

First you will have to download IronPython dll files and place them into Assets/Plugins directory. [unity-python](https://github.com/exodrifter/unity-python/releases "unity-python")

IronPython requires .NET 4.5, and Unity doesn&#39;t like this by default. That&#39;s why you will have to change the .NET version by going to Edit --> Project Settings --> Player. Make sure that the Scripting Runtime Version is .NET 4.x (this requires you to restart Unity) and that API Compatibility level is .NET 4.x

# How to code in Python

Assume you have a small code snippet **test.py** in Python like this:

```python
import random

class Test():
	def __init__(self, name):
		self.name = name

	def display(self):
		return "Hi, " + self.name

	def random_number(self, start, end):
		return random.randint(start, end)
```


You can use it from C# like this

```csharp
var engine = Python.CreateEngine ();
ICollection<string> searchPaths = engine.GetSearchPaths ();

//Path to the folder of greeter.py
searchPaths.Add (Application.dataPath);

//Path to the Python standard library
searchPaths.Add (Application.dataPath + @"\StreamingAssets"  + @"\Lib\");
engine.SetSearchPaths (searchPaths);

dynamic py = engine.ExecuteFile (Application.dataPath + @"\StreamingAssets" + @"\Python\test.py");

dynamic test = py.Test ("Codemaker");
greeting.text = "Greeting: " + test.display ();
randomNumber.text = "Random Number: " + test.random_number (1, 5);
```