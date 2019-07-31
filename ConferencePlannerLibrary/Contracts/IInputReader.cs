// --------------------------------------------------------------------------------------------------------------------
// Created by - Lalasa Ala
// --------------------------------------------------------------------------------------------------------------------
namespace ConferencePlannerLibrary.Contracts
{
    public interface IInputReader
    {
        string[] ReadInputFromFile(string filepath);
        string[] ReadInputFromString(string inputString);
    }
}