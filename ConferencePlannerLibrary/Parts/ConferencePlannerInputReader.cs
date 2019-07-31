// --------------------------------------------------------------------------------------------------------------------
// Created by - Lalasa Ala
// --------------------------------------------------------------------------------------------------------------------
using System.ComponentModel.Composition;
using System.IO;
using ConferencePlannerLibrary.Contracts;

namespace ConferencePlannerLibrary.Parts
{
    [Export(typeof(IInputReader))]
    public class InputReader : IInputReader
    {
        /// <summary>
        /// Read input from a file
        /// </summary>
        /// <param name="filepath">path of the file to read input from</param>
        /// <returns></returns>
        public string[] ReadInputFromFile(string filepath)
        {
            if (File.Exists(filepath))
                return ReadInputFromString(File.ReadAllText(filepath));
            return new string[0];
        }

        /// <summary>
        /// Read input from string.
        /// </summary>
        /// <param name="inputString">string to read input from</param>
        /// <returns></returns>
        public string[] ReadInputFromString(string inputString)
        {
            string[] inputitems = inputString.Split('\r');
            return inputitems;
        }
    }

}
