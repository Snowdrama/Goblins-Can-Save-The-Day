using Godot;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class CommandConsoleTextBox : ScrollContainer
{
    private static int consoleHistoryLength = 64;
    private static bool needsUpdating;

    private static Queue<string> consoleStrings = new Queue<string>();

    [Export] RichTextLabel textLabel;
    public override void _EnterTree()
    {
        base._EnterTree();
        textLabel.FitContent = true;
        textLabel.BbcodeEnabled = true;
        textLabel.ScrollFollowing = true;
    }
    public static void PrintText(string lineToPush)
    {
        consoleStrings.Enqueue(lineToPush);
        needsUpdating = true;
    }
    private void UpdateConsoleText()
    {
        while (consoleStrings.Count > consoleHistoryLength)
        {
            consoleStrings.Dequeue();
        }

        //TODO: Write text to console
        var stringsArray = consoleStrings.ToArray();
        string output = "";
        for (int i = 0;i < stringsArray.Length; i++)
        {
            output += stringsArray[i];
            output += "\n";
        }

        textLabel.Text = output;
    }


    public override void _Process(double delta)
    {
        base._Process(delta);
        if (needsUpdating)
        {
            needsUpdating = false;
            UpdateConsoleText();
            this.ScrollVertical = (int)this.GetVScrollBar().MaxValue;
        }
    }
}
