using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Raylib_cs;
using System;
using System.Security.Cryptography.X509Certificates;


Raylib.InitWindow(640, 1000, "Spel");


while (!Raylib.WindowShouldClose())
    {
        Hus hus = new Hus();
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Gray);
        Raylib.DrawRectangle(10, 910, 620, 80, Color.DarkGray);
        Raylib.DrawRectangle(508, 920, 112, 60, Color.Gray);
        Raylib.DrawRectangle(386, 920, 112, 60, Color.Gray);
        Raylib.DrawRectangle(264, 920, 112, 60, Color.Gray);
        Raylib.DrawRectangle(142, 920, 112, 60, Color.Gray);
        Raylib.DrawRectangle(20, 920, 112, 60, Color.Gray);
        Raylib.EndDrawing();
    }
    Raylib.CloseWindow();