
namespace Task2
{
    internal class Calculator : ICalculator
    {
        public event EventHandler<EventArgs>? GotResult;

        public CalculatorEventArgs Args { get;  private set; }

        public Calculator() => Args = new CalculatorEventArgs();

        private Stack<int> _stack = new Stack<int>();
        public void Add(int a, int b)
        {
            _stack.Push(Args.Result);
            Args.Result = a + b;
            RaiseEvent(Args);            
        }

        public void Divide(int a, int b)
        {
            _stack.Push(Args.Result);
            Args.Result = a / b;
            RaiseEvent(Args);            
        }

        public void Multiply(int a, int b)
        {
            _stack.Push(Args.Result);
            Args.Result = a * b;
            RaiseEvent(Args);            
        }

        public void Subtract(int a, int b)
        {
            _stack.Push(Args.Result);
            Args.Result = a - b;
            RaiseEvent(Args);            
        }

        public void CancelLast()
        {
            if (this._stack.Count > 0) this.Args.Result = _stack.Pop();
            RaiseEvent(Args);
        }

        private void RaiseEvent(EventArgs args)
        {
            GotResult?.Invoke(this, args);
        }
    }
}
