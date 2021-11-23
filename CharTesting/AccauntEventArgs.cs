using System;

namespace BankEmulator
{
    class AccauntEventArgs
    {
        public string Message { get; }
        public double Sum { get; }
        public AccauntEventArgs(string message, double sum)
        {
            Message = message;
            Sum = sum;
        }
    }
}
