using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        PlayFabSettings.TitleId = "19C90D";

        Console.WriteLine("PLAYFAB SPAMMER LOADED");


        int count = 0;
        var cts = new CancellationTokenSource();

        _ = Task.Run(() => { Console.ReadKey(true); cts.Cancel(); });

        while (!cts.IsCancellationRequested)
        {
            count++;

            var request = new LoginWithCustomIDRequest
            {
                CustomId = "STOP_SKIDDING_NIGGER" + Guid.NewGuid().ToString("N")[..12],
                CreateAccount = true
            };

            try
            {
                var result = await PlayFabClientAPI.LoginWithCustomIDAsync(request);

                if (result.Error == null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[{count,6}] SUCCESS → {result.Result.PlayFabId} SESSION TICKET {result.Result.SessionTicket}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[{count,6}] FAILED  → {result.Error.ErrorMessage}");
                    Console.ResetColor();
                }
            }
            catch
            {
                Console.WriteLine($"[{count,6}] EXCEPTION");
            }

            // First 3 = no wait, from 4th onward = 5 seconds
            if (count >= 3)
                await Task.Delay(5000, cts.Token);   // 5000 ms = 5 seconds
        }

        Console.WriteLine($"\n\nSTOPPED. Total accounts attempted: {count}");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}