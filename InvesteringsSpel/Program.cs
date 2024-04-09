using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Raylib_cs;
using System;
using System.Security.Cryptography.X509Certificates;

Rectangle balance = new Rectangle(10, 10, 620, 250);
Rectangle clickstats = new Rectangle(10, 280, 620, 150);
Rectangle background = new Rectangle(0, -10, 640, 450);
Rectangle click = new Rectangle(10, 430, 620, 480);
Rectangle profile = new Rectangle(508, 920, 112, 60);

float Balance = 0;
float Multiplier = 1;

string scene = "earnings";


Raylib.InitWindow(640, 1000, "Spel");




while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();

    if (scene == "earnings") { }
    Raylib.ClearBackground(Color.Gray);
    Raylib.DrawRectangle(10, 910, 620, 80, Color.DarkGray);
    Raylib.DrawRectangleRec(profile, Color.Gray);
    Raylib.DrawRectangle(386, 920, 112, 60, Color.Gray);
    Raylib.DrawRectangle(264, 920, 112, 60, Color.Gray);
    Raylib.DrawRectangle(142, 920, 112, 60, Color.Gray);
    Raylib.DrawRectangle(20, 920, 112, 60, Color.Gray);
    Raylib.DrawText("Profile", 518, 937, 26, Color.Black);
    Raylib.DrawText("Items", 402, 937, 30, Color.Black);
    Raylib.DrawText("Earnings", 274, 937, 22, Color.Black);
    Raylib.DrawText("Business", 152, 937, 20, Color.Black);
    Raylib.DrawText("Investing", 30, 937, 20, Color.Black);
    Raylib.DrawRectangleRounded(background, 0.1f, 10, Color.DarkBlue);
    Raylib.DrawRectangleRounded(balance, 0.3f, 10, Color.Black);
    Raylib.DrawRectangleRounded(clickstats, 0.3f, 10, Color.SkyBlue);


    Vector2 mousePos = Raylib.GetMousePosition();
    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, click))
    {
        Balance += Multiplier;
    }
    Raylib.DrawText(Balance.ToString() + " kr", 50, 110, 50, Color.White);

    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, clickstats) && Balance >= 1000)
    {
        Multiplier = 10;
    }
    Raylib.DrawText("Upgrade Clicker", 110, 330, 50, Color.White);

    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, profile))
    {
        (scene == "Profile")
    }

    if (scene == "Profile")
    {
        Profile Profile = new Profile();
    }

    Raylib.EndDrawing();
}
Raylib.CloseWindow();