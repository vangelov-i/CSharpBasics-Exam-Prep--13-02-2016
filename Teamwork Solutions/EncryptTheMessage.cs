namespace EncryptTheMessage
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string commandLine = Console.ReadLine();

            while (commandLine != "start" && commandLine != "START")
            {
                commandLine = Console.ReadLine();
            }

            int messagesCount = 0;
            string encryptedMessage = string.Empty;

            while (commandLine != "end" && commandLine != "END")
            {
                commandLine = Console.ReadLine();

                if (commandLine == "end" || commandLine == "END")
                {
                    break;
                }

                if (commandLine != string.Empty && commandLine != "end" && commandLine != "END")
                {
                    messagesCount++;
                }
                else
                {
                    continue;
                }


                for (int i = commandLine.Length - 1; i >= 0; i--)
                {
                    bool isFromAtoM = commandLine[i] >= 'a' && commandLine[i] <= 'm';
                    bool isFromAtoMUpper = commandLine[i] >= 'A' && commandLine[i] <= 'M';

                    bool isFromNtoZ = commandLine[i] >= 'n' && commandLine[i] <= 'z';
                    bool isFromNtoZUpper = commandLine[i] >= 'N' && commandLine[i] <= 'Z';
                    bool isDigit = commandLine[i] >= '0' && commandLine[i] <= '9';

                    if (isFromAtoM || isFromAtoMUpper)
                    {
                        encryptedMessage += (char)(commandLine[i] + 13);
                    }
                    else if (isFromNtoZ || isFromNtoZUpper)
                    {
                        encryptedMessage += (char)(commandLine[i] - 13);
                    }
                    else if (isDigit)
                    {
                        encryptedMessage += (char)commandLine[i];
                    }
                    else
                    {
                        switch (commandLine[i])
                        {
                            case ' ':
                                encryptedMessage += '+';
                                break;
                            case '!':
                                encryptedMessage += '$';
                                break;
                            case ',':
                                encryptedMessage += '%';
                                break;
                            case '.':
                                encryptedMessage += '&';
                                break;
                            case '?':
                                encryptedMessage += '#';
                                break;
                        }
                    }
                }

                //encryptedMessage.TrimEnd();
                encryptedMessage += "\n";

            }

            if (messagesCount == 0)
            {
                Console.WriteLine("No messages sent.");
            }
            else
            {
                Console.WriteLine("Total number of messages: {0}", messagesCount);
                Console.WriteLine(encryptedMessage.Trim());
            }
        }
    }
}
