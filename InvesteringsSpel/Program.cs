using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Raylib_cs;
using System;
using System.Security.Cryptography.X509Certificates;

Rectangle balance = new Rectangle(10, 10, 620, 250);
Rectangle clickstats = new Rectangle(10, 280, 620, 150);
Rectangle background = new Rectangle(0, -25, 640, 470);
Rectangle click = new Rectangle(10, 430, 620, 480);
Rectangle profile = new Rectangle(508, 920, 112, 60);
Rectangle earnings = new Rectangle(264, 920, 112, 60);
Rectangle business = new Rectangle(142, 920, 112, 60);
Rectangle items = new Rectangle(386, 920, 112, 60);
Rectangle investing = new Rectangle(20, 920, 112, 60);
// Profile profilesida = new Profile();

float Balance = 0;
float Multiplier = 1; // Mulitpliern finns så att mängden pengar man får per klick ska kunna ändras
int upgradevariabel = 50;  //flyttar på texten ut ur skärmen efter man använd upgraderingsknappen
int upgradevariabel2 = 450;
float stat1 = 0;
string[] array = { "Startat", "Halvägs där", "Upgraderat clickaren", "Första Löken" };

string scene = "earnings";


Raylib.InitWindow(640, 1000, "Spel");



while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();

    if (scene == "earnings")
    {      //Scenen hemskärm"" för varje kategori som till exempel profile, items och earnings finns det en egen scene.
        Raylib.ClearBackground(Color.Gray);
        Raylib.DrawRectangle(10, 910, 620, 80, Color.DarkGray);
        Raylib.DrawRectangleRec(profile, Color.Gray);
        Raylib.DrawRectangleRec(earnings, Color.Gray);
        Raylib.DrawRectangleRec(items, Color.Gray);
        Raylib.DrawRectangleRec(business, Color.Gray);
        Raylib.DrawRectangleRec(investing, Color.Gray);
        Raylib.DrawText("Profile", 518, 937, 26, Color.Black);
        Raylib.DrawText("Items", 402, 937, 30, Color.Black);
        Raylib.DrawText("Earnings", 274, 937, 22, Color.Black);
        Raylib.DrawText("Business", 152, 937, 20, Color.Black);
        Raylib.DrawText("Investing", 30, 937, 20, Color.Black);
        Raylib.DrawRectangleRounded(background, 0.1f, 10, Color.DarkBlue);
        Raylib.DrawRectangleRounded(balance, 0.3f, 10, Color.Black);
        Raylib.DrawRectangleRounded(clickstats, 0.3f, 10, Color.SkyBlue);
        Raylib.DrawText("Upgrade Clicker", upgradevariabel, 330, 50, Color.White);
        Raylib.DrawText("Cost = 100", upgradevariabel2, 380, 30, Color.White);

        Vector2 mousePos = Raylib.GetMousePosition();
        if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, click)) //Om musen är i rectangeln 'click' så adderas mulipliern till Balance
        {
            Balance += Multiplier;
            stat1++;
        }
        Raylib.DrawText(Balance.ToString() + " kr", 50, 110, 50, Color.White);

        if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, clickstats) && Balance >= 100)//Checkar om man har nog med pengar i Balance för att kunna upgradera, samt kollar om musen är på knappen
        {
            Multiplier = 10;
            Balance -= 100;
        }

        if (Multiplier >= 10) //Ändrar variabeln åvan igenom att märka om upgraderings knappen har klickats
        {
            upgradevariabel = 700; //flyttar första texten ut ur skärmen efter man använd upgraderingsknappen
            upgradevariabel2 = 700; //flyttar andra texten ut ur skärmen efter man använd upgraderingsknappen
            Raylib.DrawText("Clicker Maxed", 110, 330, 50, Color.White); //Skapar en ny text som visar att man har maxat klickaren
        }

        if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, profile)) // Skapar en ny scene för Profil sidan
        {
            scene = "Profile";
        }

        if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, earnings)) // återgår till earnings sidan
        {
            scene = "earnings";
        }

        if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, items)) // återgår till items sidan
        {
            scene = "investing";
        }

        if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, business)) // återgår till business sidan
        {
            scene = "business";
        }

        if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, investing)) // återgår till investing sidan
        {
            scene = "items";
        }

    }
    if (scene == "Profile")
    {
        ShowProfile();
    }

    if (scene == "items")
    {
        ShowItems();
    }

    if (scene == "business")
    {
        ShowBusiness();
    }

    if (scene == "investing")
    {
        ShowInvesting();
    }


    Raylib.EndDrawing();
}
Raylib.CloseWindow();











void ShowProfile()
{
    Vector2 mousePos = Raylib.GetMousePosition();
    Rectangle net = new Rectangle(10, 10, 620, 250);
    Rectangle stats = new Rectangle(10, 270, 620, 520);
    Rectangle reset = new Rectangle(110, 805, 420, 95);



    Raylib.ClearBackground(Color.Gray);
    Raylib.DrawRectangle(10, 910, 620, 80, Color.DarkGray);
    Raylib.DrawRectangleRec(profile, Color.Gray);
    Raylib.DrawRectangleRec(earnings, Color.Gray);
    Raylib.DrawRectangleRec(items, Color.Gray);
    Raylib.DrawRectangleRec(business, Color.Gray);
    Raylib.DrawRectangleRec(investing, Color.Gray);
    Raylib.DrawText("Profile", 518, 937, 26, Color.Black);
    Raylib.DrawText("Items", 402, 937, 30, Color.Black);
    Raylib.DrawText("Earnings", 274, 937, 22, Color.Black);
    Raylib.DrawText("Business", 152, 937, 20, Color.Black);
    Raylib.DrawText("Investing", 30, 937, 20, Color.Black);
    Raylib.DrawRectangleRounded(net, 0.1f, 10, Color.DarkBlue);
    Raylib.DrawText("Net worth:", 50, 60, 50, Color.Black);
    Raylib.DrawText(Balance.ToString() + " kr", 50, 150, 50, Color.White);
    Raylib.DrawRectangleRounded(stats, 0.1f, 10, Color.SkyBlue);
    Raylib.DrawText("Stats:", 50, 300, 50, Color.Black);
    Raylib.DrawText(stat1.ToString() + " clicks", 50, 350, 30, Color.White);
    Raylib.DrawRectangleRounded(reset, 0.1f, 10, Color.Red);
    Raylib.DrawText("Reset Game", 230, 840, 30, Color.White);
    Raylib.DrawText("Achievements:", 50, 500, 50, Color.Black);

    for (int i = 0; i < 8; i++)
    {
        if (i == 0 && Balance >= 1) { Raylib.DrawText(array[i], 50, 550, 30, Color.White); }
        if (i == 1 && Balance >= 50) { Raylib.DrawText(array[i], 50, 580, 30, Color.White); }
        if (i == 2 && Balance >= 100) { Raylib.DrawText(array[i], 50, 610, 30, Color.White); }
        if (i == 3 && Balance >= 1000) { Raylib.DrawText(array[i], 50, 640, 30, Color.White); }
    }



    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, earnings)) // återgår till earnings sidan
    {
        scene = "earnings";
    }

    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, items)) // återgår till items sidan
    {
        scene = "investing";
    }

    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, business)) // återgår till business sidan
    {
        scene = "business";
    }

    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, investing)) // återgår till investing sidan
    {
        scene = "items";
    }


    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, reset)) // återgår till earnings sidan
    {
        //Resetta spelet
    }
}




void ShowItems()
{
    Vector2 mousePos = Raylib.GetMousePosition();

    Raylib.ClearBackground(Color.Gray);
    Raylib.DrawRectangle(10, 910, 620, 80, Color.DarkGray);
    Raylib.DrawRectangleRec(profile, Color.Gray);
    Raylib.DrawRectangleRec(earnings, Color.Gray);
    Raylib.DrawRectangleRec(items, Color.Gray);
    Raylib.DrawRectangleRec(business, Color.Gray);
    Raylib.DrawRectangleRec(investing, Color.Gray);
    Raylib.DrawText("Profile", 518, 937, 26, Color.Black);
    Raylib.DrawText("Items", 402, 937, 30, Color.Black);
    Raylib.DrawText("Earnings", 274, 937, 22, Color.Black);
    Raylib.DrawText("Business", 152, 937, 20, Color.Black);
    Raylib.DrawText("Investing", 30, 937, 20, Color.Black);


    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, earnings)) // återgår till earnings sidan
    {
        scene = "earnings";
    }

    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, items)) // återgår till items sidan
    {
        scene = "investing";
    }

    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, business)) // återgår till business sidan
    {
        scene = "business";
    }

    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, investing)) // återgår till investing sidan
    {
        scene = "items";
    }
}





void ShowBusiness()
{
    Vector2 mousePos = Raylib.GetMousePosition();

    Raylib.ClearBackground(Color.Gray);
    Raylib.DrawRectangle(10, 910, 620, 80, Color.DarkGray);
    Raylib.DrawRectangleRec(profile, Color.Gray);
    Raylib.DrawRectangleRec(earnings, Color.Gray);
    Raylib.DrawRectangleRec(items, Color.Gray);
    Raylib.DrawRectangleRec(business, Color.Gray);
    Raylib.DrawRectangleRec(investing, Color.Gray);
    Raylib.DrawText("Profile", 518, 937, 26, Color.Black);
    Raylib.DrawText("Items", 402, 937, 30, Color.Black);
    Raylib.DrawText("Earnings", 274, 937, 22, Color.Black);
    Raylib.DrawText("Business", 152, 937, 20, Color.Black);
    Raylib.DrawText("Investing", 30, 937, 20, Color.Black);


    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, earnings)) // återgår till earnings sidan
    {
        scene = "earnings";
    }

    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, items)) // återgår till items sidan
    {
        scene = "investing";
    }

    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, business)) // återgår till business sidan
    {
        scene = "business";
    }

    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, investing)) // återgår till investing sidan
    {
        scene = "items";
    }
}







void ShowInvesting()
{
    Vector2 mousePos = Raylib.GetMousePosition();

    Raylib.ClearBackground(Color.Gray);
    Raylib.DrawRectangle(10, 910, 620, 80, Color.DarkGray);
    Raylib.DrawRectangleRec(profile, Color.Gray);
    Raylib.DrawRectangleRec(earnings, Color.Gray);
    Raylib.DrawRectangleRec(items, Color.Gray);
    Raylib.DrawRectangleRec(business, Color.Gray);
    Raylib.DrawRectangleRec(investing, Color.Gray);
    Raylib.DrawText("Profile", 518, 937, 26, Color.Black);
    Raylib.DrawText("Items", 402, 937, 30, Color.Black);
    Raylib.DrawText("Earnings", 274, 937, 22, Color.Black);
    Raylib.DrawText("Business", 152, 937, 20, Color.Black);
    Raylib.DrawText("Investing", 30, 937, 20, Color.Black);


    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, earnings)) // återgår till earnings sidan
    {
        scene = "earnings";
    }

    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, items)) // återgår till items sidan
    {
        scene = "investing";
    }

    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, business)) // återgår till business sidan
    {
        scene = "business";
    }

    if (Raylib.IsMouseButtonPressed(MouseButton.Left) && Raylib.CheckCollisionPointRec(mousePos, investing)) // återgår till investing sidan
    {
        scene = "items";
    }
}