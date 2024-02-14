/* 
 * Dumb attempt at remaking Snake in a console app
 * Made by: AidenFrmGAG (Discord ID: 718761934920351794)
 * Was challenged to do so by friends, but with a few conditions:
 * - No 2D arrays
 * - No external dependencies
*/

namespace SnekButStopid
{
    internal class Program
    {
        // Declaration
        string WallBorder = "#", SnekPart = "0", EmptySpace = " ", Apple = "°", SnekFrontPart = "A";
        // Map Related Declaration
        readonly int MapSizeY = 10;
        readonly int MapSizeX = 10;
	readonly Dictionary<int, Dictionary<int, int>> ApplePos = new Dictionary<int, Dictionary<int, int>>();
	int AmntApplesPresent = 0;
	readonly int MaxAmntApplesPresent = 2;
	// Player Related Declaration
	readonly Dictionary<int, Dictionary<int, int>> PlayerParts = new Dictionary<int, Dictionary<int, int>>();
	int PlayerFrontPosY = 10;
        int PlayerFrontPosX = 10;
        bool Dead = false;

        readonly Random newrandom = new Random();
        static void Main(string[] args)
        {
            Program newprogram = new Program();
            newprogram.MainSys();
        }
        private void MainSys()
        {
            // Add Player to Map (+ 2 Extra Parts)
            PlayerFrontPosY = MapSizeY / 2;
            PlayerFrontPosX = MapSizeX / 2;
            PlayerParts.Add(0, new Dictionary<int, int>());
            PlayerParts.Add(1, new Dictionary<int, int>());
            PlayerParts[0].Add(PlayerFrontPosY - 1, PlayerFrontPosX);
            PlayerParts[1].Add(PlayerFrontPosY - 2, PlayerFrontPosX);
            // Draw Basic Scene
            while (!Dead)
            {
		// Draw the Scene
                DrawStuff();
		// Wait for input
                ConsoleKeyInfo newkey = Console.ReadKey();
		// UpArrow
                if (newkey.Key == ConsoleKey.UpArrow)
                {
                    int PreviousPosY = PlayerFrontPosY;
                    int PreviousPosX = PlayerFrontPosX;
                    PlayerFrontPosY--;
                    foreach (var keypair in PlayerParts)
                    {
                        int Index = keypair.Key;
                        int PosX = 0, PosY = 0;
                        foreach (var keypair2 in PlayerParts[Index])
                        {
                            PosY = keypair2.Key;
                            PosX = keypair2.Value;
                        }
                        if (!PlayerParts[Index].ContainsKey(PreviousPosY))
                        {
                            PlayerParts[Index].Add(PreviousPosY, PreviousPosX);
                            PreviousPosY = PosY;
                            PreviousPosX = PosX;
                            PlayerParts[Index].Remove(PosY);
                        }
                        else
                        {
                            PlayerParts[Index][PosY] = PreviousPosX;
                            PreviousPosY = PosY;
                            PreviousPosX = PosX;
                        }
                    }
                }
		// LeftArrow
                else if (newkey.Key == ConsoleKey.LeftArrow)
                {
                    int PreviousPosY = PlayerFrontPosY;
                    int PreviousPosX = PlayerFrontPosX;
                    PlayerFrontPosX--;
                    foreach (var keypair in PlayerParts)
                    {
                        int Index = keypair.Key;
                        int PosX = 0, PosY = 0;
                        foreach (var keypair2 in PlayerParts[Index])
                        {
                            PosY = keypair2.Key;
                            PosX = keypair2.Value;
                        }
                        if (!PlayerParts[Index].ContainsKey(PreviousPosY))
                        {
                            PlayerParts[Index].Add(PreviousPosY, PreviousPosX);
                            PreviousPosY = PosY;
                            PreviousPosX = PosX;
                            PlayerParts[Index].Remove(PosY);
                        }
                        else
                        {
                            PlayerParts[Index][PosY] = PreviousPosX;
                            PreviousPosY = PosY;
                            PreviousPosX = PosX;
                        }
                    }
                }
		// RightArrow
                else if (newkey.Key == ConsoleKey.RightArrow)
                {
                    int PreviousPosY = PlayerFrontPosY;
                    int PreviousPosX = PlayerFrontPosX;
                    PlayerFrontPosX++;
                    foreach (var keypair in PlayerParts)
                    {
                        int Index = keypair.Key;
                        int PosX = 0, PosY = 0;
                        foreach (var keypair2 in PlayerParts[Index])
                        {
                            PosY = keypair2.Key;
                            PosX = keypair2.Value;
                        }
                        if (!PlayerParts[Index].ContainsKey(PreviousPosY))
                        {
                            PlayerParts[Index].Add(PreviousPosY, PreviousPosX);
                            PreviousPosY = PosY;
                            PreviousPosX = PosX;
                            PlayerParts[Index].Remove(PosY);
                        }
                        else
                        {
                            PlayerParts[Index][PosY] = PreviousPosX;
                            PreviousPosY = PosY;
                            PreviousPosX = PosX;
                        }
                    }
                }
		// DownArrow
                else if (newkey.Key == ConsoleKey.DownArrow)
                {
                    int PreviousPosY = PlayerFrontPosY;
                    int PreviousPosX = PlayerFrontPosX;
                    PlayerFrontPosY++;
                    foreach (var keypair in PlayerParts)
                    {
                        int Index = keypair.Key;
                        int PosX = 0, PosY = 0;
                        foreach (var keypair2 in PlayerParts[Index])
                        {
                            PosY = keypair2.Key;
                            PosX = keypair2.Value;
                        }
                        if (!PlayerParts[Index].ContainsKey(PreviousPosY))
                        {
                            PlayerParts[Index].Add(PreviousPosY, PreviousPosX);
                            PreviousPosY = PosY;
                            PreviousPosX = PosX;
                            PlayerParts[Index].Remove(PosY);
                        }
                        else
                        {
                            PlayerParts[Index][PosY] = PreviousPosX;
                            PreviousPosY = PosY;
                            PreviousPosX = PosX;
                        }
                    }
                }
		// Mostly for debug purposes, adds in new PlayerPart
                else if (newkey.Key == ConsoleKey.Enter)
                {
                    PlayerParts.Add(PlayerParts.Count, new Dictionary<int, int>());
                    PlayerParts[PlayerParts.Count - 1].Add(PlayerParts[PlayerParts.Count - 2].Keys.First() - 1, PlayerParts[PlayerParts.Count - 2].Values.First());
                }
            }
            Console.ReadKey();
        }
        private void DrawStuff()
        {
            Console.Clear();
            string ToOutput = "";
            for (int i = 0; i <= MapSizeY; i++)
            {
                if (i == 0)
                {
                    // Border
                    for (int i2 = 0; i2 <= MapSizeX; i2++)
                    {
                        ToOutput += WallBorder;
                        if (PlayerFrontPosY == i && PlayerFrontPosX == i2)
                        {
                            GameOver();
                        }
                    }
                }
                else if (i == MapSizeY)
                {
                    // Border
                    ToOutput += "\n";
                    for (int i2 = 0; i2 <= MapSizeX; i2++)
                    {
                        ToOutput += WallBorder;
                        if (PlayerFrontPosY == i && PlayerFrontPosX == i2)
                        {
                            GameOver();
                        }
                    }
                }
                else
                {
                    // Playable Field
                    ToOutput += "\n";
                    for (int i2 = 0; i2 <= MapSizeX; i2++)
                    {
                        string NewOutput = "";
                        if (i2 == 0)
                        {
                            NewOutput += WallBorder;
                            if (PlayerFrontPosY == i && PlayerFrontPosX == i2)
                            {
                                GameOver();
                            }
                        }
                        else if (i2 == MapSizeX)
                        {
                            NewOutput += WallBorder;
                            if (PlayerFrontPosY == i && PlayerFrontPosX == i2)
                            {
                                GameOver();
                            }
                        }
                        else
                        {
                            if (PlayerFrontPosY == i && PlayerFrontPosX == i2)
                            {
                                NewOutput += SnekFrontPart;
                                foreach (var keypair in PlayerParts)
                                {
                                    foreach (var keypair2 in keypair.Value)
                                    {
                                        if (keypair2.Key == i && keypair2.Value == i2)
                                        {
                                            if (keypair2.Key == PlayerFrontPosY && keypair2.Value == PlayerFrontPosX)
                                            {
                                                GameOver();
                                            }
                                        }
                                    }
                                }
                                if (ApplePos.Count > 0)
                                {
                                    bool EatApple = false;
                                    int index = 0;
                                    foreach (var keypair in ApplePos)
                                    {
                                        foreach (var keypair2 in keypair.Value)
                                        {
                                            if (keypair2.Key == i && keypair2.Value == i2)
                                            {
                                                EatApple = true;
                                                index = keypair.Key;
                                                PlayerParts.Add(PlayerParts.Count, new Dictionary<int, int>());
                                                PlayerParts[PlayerParts.Count - 1].Add(PlayerParts[PlayerParts.Count - 2].Keys.First() - 1, PlayerParts[PlayerParts.Count - 2].Values.First());
                                                AmntApplesPresent--;
                                            }
                                        }
                                    }
                                    if (EatApple)
                                    {
                                        ApplePos.Remove(index);
                                    }
                                }
                            }
                            else
                            {
                                string ToShow = "";
                                foreach (var keypair in PlayerParts)
                                {
                                    foreach (var keypair2 in keypair.Value)
                                    {
                                        if (keypair2.Key == i && keypair2.Value == i2)
                                        {
                                            if (keypair2.Key == PlayerFrontPosY && keypair2.Value == PlayerFrontPosX)
                                            {
                                                GameOver();
                                            }
                                            ToShow = SnekPart;
                                        }
                                    }
                                }
                                if (ToShow == "")
                                {
                                    if (newrandom.Next(1, 50) == 6)
                                    {
                                        if (AmntApplesPresent < MaxAmntApplesPresent)
                                        {
                                            if (ApplePos.Count > 0)
                                            {
                                                bool ApplePresentOnPos = false;
                                                foreach (var keypair in ApplePos)
                                                {
                                                    foreach (var keypair2 in keypair.Value)
                                                    {
                                                        if (keypair2.Key == i)
                                                        {
                                                            ApplePresentOnPos = true;
                                                        }
                                                    }
                                                }
                                                if (!ApplePresentOnPos)
                                                {
                                                    NewOutput += Apple;
                                                    ApplePos.Add(ApplePos.Keys.Last() + 1, new Dictionary<int, int>());
                                                    ApplePos[ApplePos.Keys.Last()].Add(i, i2);
                                                    AmntApplesPresent++;
                                                }
                                                else
                                                {
                                                    NewOutput += EmptySpace;
                                                }
                                            }
                                            else
                                            {
                                                NewOutput += Apple;
                                                ApplePos.Add(ApplePos.Count, new Dictionary<int, int>());
                                                ApplePos[ApplePos.Count - 1].Add(i, i2);
                                                AmntApplesPresent++;
                                            }
                                        }
                                        else
                                        {
											bool foundone = false;
											foreach (var keypair in ApplePos)
											{
												foreach (var keypair2 in keypair.Value)
												{
													if (keypair2.Key == i && keypair2.Value == i2)
													{
														NewOutput += Apple;
														foundone = true;
													}
												}
											}
											if (!foundone)
											{
												NewOutput += EmptySpace;
											}
										}
                                    }
                                    else if (ApplePos.Count > 0)
                                    {
                                        bool foundone = false;
                                        foreach (var keypair in ApplePos)
                                        {
                                            foreach (var keypair2 in keypair.Value)
                                            {
                                                if (keypair2.Key == i && keypair2.Value == i2)
                                                {
                                                    NewOutput += Apple;
                                                    foundone = true;
                                                }
                                            }
                                        }
                                        if (!foundone)
                                        {
                                            NewOutput += EmptySpace;
                                        }
                                    }
                                    else
                                    {
                                        NewOutput += EmptySpace;
                                    }
                                }
                                else
                                {
                                    NewOutput += ToShow;
                                }
                            }
                        }
                        ToOutput += NewOutput;
                        
                    }
                }
            }
            if (!Dead)
            {
                Console.WriteLine(ToOutput);
            }
        }
        private void GameOver() 
        {
            Dead = true;
            Console.WriteLine("you died bozo");
        }
    }
}
