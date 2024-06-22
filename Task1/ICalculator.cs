

namespace Task2
{
    internal interface ICalculator
    {
        event EventHandler<EventArgs> GotResult;

        public void Add(int a, int b);
        public void Subtract(int a, int b);
        public void Multiply(int a, int b);
        public void Divide(int a, int b);
        public void CancelLast();

    }
}
