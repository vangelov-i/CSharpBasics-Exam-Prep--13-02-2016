using System;

using System.Collections.Generic;

public class EncryptTheMessages
{
    public static void Main()
    {
        var symbols = new Dictionary<char, char>()
                              {
                {' ', '+' },
                {',', '%' },
                {'.', '&' },
                {'?', '#' },
                {'!', '$' },
                              };

        string encryptedMessages = string.Empty;
        int messagesCount = 0;
        bool encrtyptingStarted = false;

        while (true)
        {
            string message = Console.ReadLine();

            if (message.ToLower() == "end")
            {
                break;
            }

            if (message.ToLower() == "start")
            {
                encrtyptingStarted = true;
                continue;
            }

            if (!encrtyptingStarted || message == string.Empty)
            {
                continue;
            }


            for (int i = message.Length - 1; i >= 0; i--)
            {
                if (char.IsLetter(message[i]))
                {
                    if (message[i] <= 'M' || (message[i] >= 'a' && message[i] <= 'm'))
                    {
                        encryptedMessages += (char)(message[i] + 13);
                    }
                    else
                    {
                        encryptedMessages += (char)(message[i] - 13);
                    }
                }
                else if (symbols.ContainsKey(message[i]))
                {
                    encryptedMessages += symbols[message[i]];
                }
                else
                {
                    encryptedMessages += message[i];
                }
            }

            encryptedMessages += Environment.NewLine;
            messagesCount++;
        }

        if (messagesCount > 0)
        {
            Console.WriteLine("Total number of messages: {0}", messagesCount);
            Console.Write(encryptedMessages);
        }
        else
        {
            Console.WriteLine("No messages sent.");
        }
    }
}