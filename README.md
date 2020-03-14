# Screen Console (Unity / C#)

![Screen Console Image](/doc/screen_console.gif)

## What is it?

Sometimes it would be helpful to see Unity's debug log on screen, instead of in console. For example, some issues - Unity console font size or color can't be changed and the output is on grey background.

Just add this script to single GameObject and the UI to display debug output is automatically created when entering Play mode.

## Code 

This script shows how to pass Application debug output to your custom class / method. 

It is also possible to see how whole UI can be created from scratch.

# Classes

## ScreenConsole.cs
Custom MonoBehaviour class that listens console and prints it to Unity uGUI canvas. Amount of lines shown, font size and color can be adjusts. Also, panel size can be adjust from settings and during runtime.

## TestOutput.cs
Demo class that outputs some arbitrary strings to console.

# Copyright
Created by Sami S. use of any kind without a written permission from the author is not allowed. But feel free to take a look.
