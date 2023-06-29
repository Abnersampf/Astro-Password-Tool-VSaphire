using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace APT_Saphire
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "APT - Saphire";

            string option, predefined_password, charset_view = "", final_password = "", folder;
            int num = 0, loop = 0;
            long attempts = 0;
            var timer = new Stopwatch();

            while (loop == 0)
            {
                option = ""; predefined_password = ""; charset_view = ""; final_password = ""; num = 0; attempts = 0;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("|                     ╔═╗╔═╗╔═╗╦ ╦╦╦═╗╔═╗         |");
                Console.WriteLine("| Astro Password Tool ╚═╗╠═╣╠═╝╠═╣║╠╦╝║╣          |");
                Console.WriteLine("|                     ╚═╝╩ ╩╩  ╩ ╩╩╩╚═╚═╝ Edition |");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("| 1 - Crack a predefined password                 |");
                Console.WriteLine("| 2 - Crack an unknown password (coming soon)     |");
                Console.WriteLine("| 3 - Crack a NTLM hash (coming soon)             |");
                Console.WriteLine("---------------------------------------------------");
                Console.Write("| Choose an option: ");
                Console.ForegroundColor = ConsoleColor.White;
                option = Console.ReadLine();

                if (option != "1")
                {
                    while (option != "1")
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("INVALID OPTION, PLEASE SELECT A VALID NUMBER!");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("| Choose an option: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        option = Console.ReadLine();
                    }
                }

                switch (option)
                {
                    case "1":
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine("|                     ╔═╗╔═╗╔═╗╦ ╦╦╦═╗╔═╗         |");
                            Console.WriteLine("| Astro Password Tool ╚═╗╠═╣╠═╝╠═╣║╠╦╝║╣          |");
                            Console.WriteLine("|                     ╚═╝╩ ╩╩  ╩ ╩╩╩╚═╚═╝ Edition |");
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine("| 1 - Dictionary attack                           |");
                            Console.WriteLine("| 2 - Brute Force attack                          |");
                            Console.WriteLine("---------------------------------------------------");
                            Console.Write("| Choose an option: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            option = Console.ReadLine();

                            if (option != "1" && option != "2")
                            {
                                while (option != "1" && option != "2")
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("INVALID OPTION, PLEASE SELECT A VALID NUMBER!");
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write("| Choose an option: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    option = Console.ReadLine();
                                }
                            }

                            switch (option)
                            {
                                case "1":
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.WriteLine("|                     ╔═╗╔═╗╔═╗╦ ╦╦╦═╗╔═╗         |");
                                        Console.WriteLine("| Astro Password Tool ╚═╗╠═╣╠═╝╠═╣║╠╦╝║╣          |");
                                        Console.WriteLine("|                     ╚═╝╩ ╩╩  ╩ ╩╩╩╚═╚═╝ Edition |");
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.Write("| Enter a password: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        predefined_password = Console.ReadLine();
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.WriteLine("| Example: C:\\Users\\user\\OneDrive\\Documentos\\C#\\rockyou.txt");
                                        Console.Write("| Enter the dictionary path: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        folder = Console.ReadLine();

                                        if (!File.Exists(folder))
                                        {
                                            while (!File.Exists(folder))
                                            {
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("THIS FILE DOES NOT EXIST!");
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.WriteLine("| Example: C:\\Users\\user\\OneDrive\\Documentos\\C#\\rockyou.txt");
                                                Console.Write("| Enter the dictionary path: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                folder = Console.ReadLine();
                                            }
                                        }

                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.WriteLine("| Would you like to see the dictionary attack line by line?");
                                        Console.Write("| [y - YES | n - NO]: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        option = Console.ReadLine().ToLower();

                                        if (option != "y" && option != "n")
                                        {
                                            while (option != "y" && option != "n")
                                            {
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("INVALID OPTION, PLEASE SELECT A VALID NUMBER!");
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.Write("| Choose an option: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                option = Console.ReadLine();
                                            }
                                        }

                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("SEARCHING FOR THE PASSWORD IN DICTIONARY...");
                                        string[] lines = File.ReadAllLines(folder);
                                        timer.Start();
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        foreach (var line in lines)
                                        {
                                            if (option == "y")
                                            {
                                                Console.WriteLine(line);
                                            }
                                            if (line == predefined_password)
                                            {
                                                final_password = line;
                                                break;
                                            }
                                            attempts++;
                                        }

                                        if (final_password == "")
                                        {
                                            final_password = "YOUR PASSWORD IS NOT IN THE DICTIONARY YOU SELECTED!";
                                        }

                                        timer.Stop();
                                        TimeSpan timeTaken = timer.Elapsed;
                                        string foo = "" + timeTaken.ToString(@"m\:ss\.fff");

                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.WriteLine("|                     ╔═╗╔═╗╔═╗╦ ╦╦╦═╗╔═╗         |");
                                        Console.WriteLine("| Astro Password Tool ╚═╗╠═╣╠═╝╠═╣║╠╦╝║╣          |");
                                        Console.WriteLine("|                     ╚═╝╩ ╩╩  ╩ ╩╩╩╚═╚═╝ Edition |");
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.WriteLine("|               S T A T I S T I C S               |");
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.Write("| Your password is: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(final_password);
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.Write("| Attempts: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(attempts);
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.Write("| Time taken: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(foo);
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.Write("Press any key to return to the menu...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadKey();
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine();

                                    }
                                    break;

                                case "2":
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.WriteLine("|                     ╔═╗╔═╗╔═╗╦ ╦╦╦═╗╔═╗         |");
                                        Console.WriteLine("| Astro Password Tool ╚═╗╠═╣╠═╝╠═╣║╠╦╝║╣          |");
                                        Console.WriteLine("|                     ╚═╝╩ ╩╩  ╩ ╩╩╩╚═╚═╝ Edition |");
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.Write("| Enter a password (max 16 characters): ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        predefined_password = Console.ReadLine();

                                        if (predefined_password.Length > 16)
                                        {
                                            while (predefined_password.Length > 16)
                                            {
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("VERY LONG PASSWORD, MAX 16 CHARACTERS !");
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.Write("| Enter a password (max 16 characters): ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                predefined_password = Console.ReadLine();
                                            }
                                        }

                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.WriteLine("|                     ╔═╗╔═╗╔═╗╦ ╦╦╦═╗╔═╗         |");
                                        Console.WriteLine("| Astro Password Tool ╚═╗╠═╣╠═╝╠═╣║╠╦╝║╣          |");
                                        Console.WriteLine("|                     ╚═╝╩ ╩╩  ╩ ╩╩╩╚═╚═╝ Edition |");
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.WriteLine("|          S E L E C T  A  C H A R S E T          |");
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.WriteLine("|1 - \"0123456789\"                                 |");
                                        Console.WriteLine("|                                                 |");
                                        Console.WriteLine("|2 - \"abcdefghijklmnopqrstuvwxyz\"                 |");
                                        Console.WriteLine("|                                                 |");
                                        Console.WriteLine("|3 - \"ABCDEFGHIJKLMNOPQRSTUVWXYZ\"                 |");
                                        Console.WriteLine("|                                                 |");
                                        Console.WriteLine("|4 - \"abcdefghijklmnopqrstuvwxyz0123456789\"       |");
                                        Console.WriteLine("|                                                 |");
                                        Console.WriteLine("|5 - \"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQ |");
                                        Console.WriteLine("| RSTUVWXYZ\"                                      |");
                                        Console.WriteLine("|                                                 |");
                                        Console.WriteLine("|6 - \"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQ |");
                                        Console.WriteLine("| RSTUVWXYZ0123456789\"                            |");
                                        Console.WriteLine("|                                                 |");
                                        Console.WriteLine("|7 - \"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789\"       |");
                                        Console.WriteLine("|                                                 |");
                                        Console.WriteLine("|8 - \"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQ |");
                                        Console.WriteLine("| RSTUVWXYZ0123456789!@#$%&*-_=+çÇ~^\\|,.;:/?\"     |");
                                        Console.WriteLine("|                                                 |");
                                        Console.WriteLine("|9 - \" !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJ |");
                                        Console.WriteLine("| KLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxy |");
                                        Console.WriteLine("| z{|}~ÇüéâäàåçêëèïîìÄÅÉæÆôöòûùÿÖÜø£Ø×ƒáíóúñÑª°¿® |");
                                        Console.WriteLine("| ¬½¼¡«»___¦¦ÁÂÀ©¦¦++¢¥++--+-+ãÃ++--¦-+¤ðÐÊËÈiÍÎÏ |");
                                        Console.WriteLine("| ++__¦Ì_ÓßÔÒÕÕµÞÞÚÛÙýÝ¯´ ±_¾¶§÷¸°¨·¹³²_\"         |");
                                        Console.WriteLine("|                                                 |");
                                        Console.WriteLine("|10 - Custom charset                              |");
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.Write("| Choose an option: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        option = Console.ReadLine();

                                        if (option != "1" && option != "2" && option != "3" && option != "4" && option != "5" && option != "6" && option != "7" && option != "8" && option != "9" && option != "10")
                                        {
                                            while (option != "1" && option != "2" && option != "3" && option != "4" && option != "5" && option != "6" && option != "7" && option != "8" && option != "9" && option != "10")
                                            {
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("INVALID OPTION, PLEASE SELECT A VALID NUMBER!");
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.Write("| Choose an option: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                option = Console.ReadLine();
                                            }
                                        }

                                        switch (option)
                                        {
                                            case "1":
                                                num = 10;
                                                charset_view = "0123456789";
                                                break;
                                            case "2":
                                                num = 26;
                                                charset_view = "abcdefghijklmnopqrstuvwxyz";
                                                break;
                                            case "3":
                                                num = 26;
                                                charset_view = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                                                break;
                                            case "4":
                                                num = 36;
                                                charset_view = "abcdefghijklmnopqrstuvwxyz0123456789";
                                                break;
                                            case "5":
                                                num = 52;
                                                charset_view = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                                                break;
                                            case "6":
                                                num = 62;
                                                charset_view = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                                                break;
                                            case "7":
                                                num = 36;
                                                charset_view = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                                                break;
                                            case "8":
                                                num = 85;
                                                charset_view = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%&*-_=+çÇ~^\\|,.;:/?";
                                                break;
                                            case "9":
                                                num = 222;
                                                charset_view = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~ÇüéâäàåçêëèïîìÄÅÉæÆôöòûùÿÖÜø£Ø×ƒáíóúñÑª°¿®¬½¼¡«»___¦¦ÁÂÀ©¦¦++¢¥++--+-+ãÃ++--¦-+¤ðÐÊËÈiÍÎÏ++__¦Ì_ÓßÔÒÕÕµÞÞÚÛÙýÝ¯´ ±_¾¶§÷¸°¨·¹³²_";
                                                break;
                                            case "10":
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.Write("| Enter the charset, which will be used to crack the password: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                charset_view = Console.ReadLine();
                                                num = charset_view.Length;
                                                break;
                                        }

                                        Console.Clear();
                                        string[] charset = new string[num + 1];
                                        charset[0] = "";
                                        for (int c1 = 1; c1 < num + 1; c1++)
                                        {
                                            charset[c1] = "" + charset_view[c1 - 1];
                                        }

                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.WriteLine("|                     ╔═╗╔═╗╔═╗╦ ╦╦╦═╗╔═╗         |");
                                        Console.WriteLine("| Astro Password Tool ╚═╗╠═╣╠═╝╠═╣║╠╦╝║╣          |");
                                        Console.WriteLine("|                     ╚═╝╩ ╩╩  ╩ ╩╩╩╚═╚═╝ Edition |");
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.Write("| Selected charset -> ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(charset_view);
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.WriteLine("| Would you like to see the brute force process?");
                                        Console.Write("| [y - YES | n - NO]: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        option = Console.ReadLine().ToLower();

                                        if (option != "y" && option != "n")
                                        {
                                            while (option != "y" && option != "n")
                                            {
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("INVALID OPTION, PLEASE SELECT A VALID NUMBER!");
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.Write("| Choose an option: ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                option = Console.ReadLine();
                                            }
                                        }

                                        timer.Start();
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("CRACKING THE PASSWORD...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        for (int c0 = 0; c0 < charset.Length; c0++)
                                        {
                                            for (int c1 = 0; c1 < charset.Length; c1++)
                                            {
                                                for (int c2 = 0; c2 < charset.Length; c2++)
                                                {
                                                    for (int c3 = 0; c3 < charset.Length; c3++)
                                                    {
                                                        for (int c4 = 0; c4 < charset.Length; c4++)
                                                        {
                                                            for (int c5 = 0; c5 < charset.Length; c5++)
                                                            {
                                                                for (int c6 = 0; c6 < charset.Length; c6++)
                                                                {
                                                                    for (int c7 = 0; c7 < charset.Length; c7++)
                                                                    {
                                                                        for (int c8 = 0; c8 < charset.Length; c8++)
                                                                        {
                                                                            for (int c9 = 0; c9 < charset.Length; c9++)
                                                                            {
                                                                                for (int c10 = 0; c10 < charset.Length; c10++)
                                                                                {
                                                                                    for (int c11 = 0; c11 < charset.Length; c11++)
                                                                                    {
                                                                                        for (int c12 = 0; c12 < charset.Length; c12++)
                                                                                        {
                                                                                            for (int c13 = 0; c13 < charset.Length; c13++)
                                                                                            {
                                                                                                for (int c14 = 0; c14 < charset.Length; c14++)
                                                                                                {
                                                                                                    for (int c15 = 0; c15 < charset.Length; c15++)
                                                                                                    {
                                                                                                        final_password = "" + charset[c0] + charset[c1] + charset[c2]
                                                                                                            + charset[c3] + charset[c4] + charset[c5] + charset[c6]
                                                                                                            + charset[c7] + charset[c8] + charset[c9] + charset[c10]
                                                                                                            + charset[c11] + charset[c12] + charset[c13] + charset[c14]
                                                                                                            + charset[c15];
                                                                                                        attempts++;
                                                                                                        if (option == "y")
                                                                                                        {
                                                                                                            Console.WriteLine(final_password);
                                                                                                        }
                                                                                                        if (final_password == predefined_password)
                                                                                                        {
                                                                                                            c15 = charset.Length;
                                                                                                            c14 = charset.Length;
                                                                                                            c13 = charset.Length;
                                                                                                            c12 = charset.Length;
                                                                                                            c11 = charset.Length;
                                                                                                            c10 = charset.Length;
                                                                                                            c9 = charset.Length;
                                                                                                            c8 = charset.Length;
                                                                                                            c7 = charset.Length;
                                                                                                            c6 = charset.Length;
                                                                                                            c5 = charset.Length;
                                                                                                            c4 = charset.Length;
                                                                                                            c3 = charset.Length;
                                                                                                            c2 = charset.Length;
                                                                                                            c1 = charset.Length;
                                                                                                            c0 = charset.Length;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        timer.Stop();
                                        TimeSpan timeTaken = timer.Elapsed;
                                        string foo = "" + timeTaken.ToString(@"m\:ss\.fff");

                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.WriteLine("|                     ╔═╗╔═╗╔═╗╦ ╦╦╦═╗╔═╗         |");
                                        Console.WriteLine("| Astro Password Tool ╚═╗╠═╣╠═╝╠═╣║╠╦╝║╣          |");
                                        Console.WriteLine("|                     ╚═╝╩ ╩╩  ╩ ╩╩╩╚═╚═╝ Edition |");
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.WriteLine("|               S T A T I S T I C S               |");
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.Write("| Your password is: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(final_password);
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.Write("| Attempts: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(attempts);
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.Write("| Time taken: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(foo);
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("---------------------------------------------------");
                                        Console.Write("Press any key to return to the menu...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadKey();
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine();
                                    }

                                    break;
                            }
                        }
                        break;
                }
            }
        }
    }
}
