' Copyright (c) Devis Lucato. All rights reserved.
' Licensed under the MIT license.

Imports System.Runtime.InteropServices
Imports System.Threading

Module NoScreenSaver

    Sub Main()
        Dim i(0) As INPUT
        i(0).dwType = INPUT.InputType.INPUT_MOUSE
        i(0).mkhi = New MOUSEKEYBDHARDWAREINPUT
        i(0).mkhi.mi = New MOUSEINPUT
        i(0).mkhi.mi.dx = 0
        i(0).mkhi.mi.dy = 0
        i(0).mkhi.mi.mouseData = 0
        i(0).mkhi.mi.dwFlags = MOUSEINPUT.MouseEventFlags.MOUSEEVENTF_MOVE
        i(0).mkhi.mi.time = 0
        i(0).mkhi.mi.dwExtraInfo = IntPtr.Zero

        While (True)
            SendInput(1, i(0), Marshal.SizeOf(i(0)))
            Thread.Sleep(55000)
        End While
    End Sub

    Public Declare Function SendInput Lib "user32" (ByVal nInputs As Integer, ByRef pInputs As INPUT, ByVal cbSize As Integer) As Integer

    Public Structure INPUT
        Enum InputType As Integer
            INPUT_MOUSE = 0
            INPUT_KEYBOARD = 1
            INPUT_HARDWARE = 2
        End Enum

        Dim dwType As InputType
        Dim mkhi As MOUSEKEYBDHARDWAREINPUT
    End Structure

    Public Structure MOUSEINPUT
        Enum MouseEventFlags As Integer
            MOUSEEVENTF_MOVE = &H1
            MOUSEEVENTF_LEFTDOWN = &H2
            MOUSEEVENTF_LEFTUP = &H4
            MOUSEEVENTF_RIGHTDOWN = &H8
            MOUSEEVENTF_RIGHTUP = &H10
            MOUSEEVENTF_MIDDLEDOWN = &H20
            MOUSEEVENTF_MIDDLEUP = &H40
            MOUSEEVENTF_XDOWN = &H80
            MOUSEEVENTF_XUP = &H100
            MOUSEEVENTF_WHEEL = &H800
            MOUSEEVENTF_VIRTUALDESK = &H4000
            MOUSEEVENTF_ABSOLUTE = &H8000
        End Enum

        Dim dx As Integer
        Dim dy As Integer
        Dim mouseData As Integer
        Dim dwFlags As MouseEventFlags
        Dim time As Integer
        Dim dwExtraInfo As IntPtr
    End Structure

    Public Structure KEYBDINPUT
        Public wVk As Short
        Public wScan As Short
        Public dwFlags As Integer
        Public time As Integer
        Public dwExtraInfo As IntPtr
    End Structure

    Public Structure HARDWAREINPUT
        Public uMsg As Integer
        Public wParamL As Short
        Public wParamH As Short
    End Structure

    Const KEYEVENTF_EXTENDEDKEY As UInt32 = &H1
    Const KEYEVENTF_KEYUP As UInt32 = &H2
    Const KEYEVENTF_UNICODE As UInt32 = &H4
    Const KEYEVENTF_SCANCODE As UInt32 = &H8
    Const XBUTTON1 As UInt32 = &H1
    Const XBUTTON2 As UInt32 = &H2

    <StructLayout(LayoutKind.Explicit)> Public Structure MOUSEKEYBDHARDWAREINPUT
        <FieldOffset(0)> Public mi As MOUSEINPUT
        <FieldOffset(0)> Public ki As KEYBDINPUT
        <FieldOffset(0)> Public hi As HARDWAREINPUT
    End Structure

End Module
