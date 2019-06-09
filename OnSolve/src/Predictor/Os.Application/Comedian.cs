using System;

namespace Os.Application
{
    public class Comedian
    {
        private static Random random;
        private static object syncObj = new object();

        private static readonly string[] Scripts =
        {
            ">> I turned my phone on airplane mode and threw it in the air. Worst transformer ever...",
            ">> I don't think inside the box and I don't think outside the box... I don't even know where the box is...",
            ">> I'm stuck between 'I need to save money' and 'You only live once.'...",
            ">> I wasn't mad, but now that you asked me 7 times if I'm mad.. yes, I'm mad!...",
            ">> How come iPhone chargers are not called apple juice?...",
            ">> Want someone to stop texting you? Just send back 'Service error 305: delivery failed, further messages will be charged at a rate of $1 per message to your account'...",
            ">> Since there is only one of me, does that make me a limited edition?...",
            ">> I keep pressing the space bar, but I'm still on the Earth..."
        };

        public static string TellAJoke()
        {
            lock(syncObj)
            {
                if (random == null)
                    random = new Random();
                return Scripts[random.Next(0, Scripts.Length)];
            }
        }
    }
}