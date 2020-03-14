# Screen Console (Unity / C#)

![Screen Console Image](/doc/screen_console.gif)

## What is it?

Sometimes it would be helpful to see Unity's Debug logging on screen, instead of in Unity console window. For example: Unity console font size or color can't be changed and the output is on a grey background.

## How to use
Just add this script to a scene GameObject. The UI to display debug output is automatically created when entering Play mode.

## Code 

This script shows how to pass Application debug output to your custom class / method. 

It is also possible to see how whole UI panel and its child elements can be created from scratch.

# Classes

## ScreenConsole.cs
Custom MonoBehaviour class that listens console and prints output to Unity uGUI canvas (using text elements). Amount of lines shown, font size and color can be adjusts from script Inspector. Also, panel size can be adjusted from script Inspector.

## TestOutput.cs
Demo class that outputs some arbitrary strings to console.

# Copyright
Created by Sami S. use of any kind without a written permission from the author is not allowed. But feel free to take a look.
