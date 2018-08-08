namespace TicTacToeKata.Exception
{
    public class FieldAlreadyTakenException : System.Exception
    {
        public FieldAlreadyTakenException() : base() { }

        public FieldAlreadyTakenException(string message, System.Exception innerException) : base(message, innerException) { }

        public FieldAlreadyTakenException(string message) : base(message) { }

    }
}