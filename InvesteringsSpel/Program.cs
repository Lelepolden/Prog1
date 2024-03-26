using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Raylib_cs;
using System;
using System.Security.Cryptography.X509Certificates;

Rectangle balance = new Rectangle(10, 10, 620, 200);
Rectangle click = new Rectangle(10, 230, 620, 200);

string scene = "earnings";


Raylib.InitWindow(640, 1000, "Spel");


while (!Raylib.WindowShouldClose())
    {
        Raylib.BeginDrawing();

    if (scene == "earnings"){}
        Raylib.ClearBackground(Color.Gray);
        Raylib.DrawRectangle(10, 910, 620, 80, Color.DarkGray);
        Raylib.DrawRectangle(508, 920, 112, 60, Color.Gray);
        Raylib.DrawRectangle(386, 920, 112, 60, Color.Gray);
        Raylib.DrawRectangle(264, 920, 112, 60, Color.Gray);
        Raylib.DrawRectangle(142, 920, 112, 60, Color.Gray);
        Raylib.DrawRectangle(20, 920, 112, 60, Color.Gray);
        Raylib.DrawText("Profile", 518, 937, 26, Color.Black);
        Raylib.DrawText("Items", 402, 937, 30, Color.Black);
        Raylib.DrawText("Earnings", 274, 937, 22, Color.Black);
        Raylib.DrawText("Business", 152, 937, 20, Color.Black);
        Raylib.DrawText("Investing", 30, 937, 20, Color.Black);
        Raylib.DrawRectangleRounded(balance, 10, 10, Color.LightGray);
        Raylib.DrawRectangleRounded(click, 10, 10, Color.LightGray);

        if(Raylib.){

        }

        }

        if(scene == "Profile"){
            Profile hus = new Profile();
            }

        Raylib.EndDrawing();
    }
    Raylib.CloseWindow();