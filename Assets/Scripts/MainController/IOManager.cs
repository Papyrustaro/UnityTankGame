using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class IOManager : MonoBehaviour
{
    private static string path = Application.dataPath + "/debugLog.txt";    

    public static void WriteFile(string text)
    {
        FileInfo fi = new FileInfo(path);
        using(StreamWriter sw = fi.AppendText())
        {
            sw.WriteLine(text);
        }
    }
}
