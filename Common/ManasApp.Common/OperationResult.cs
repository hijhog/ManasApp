namespace ManasApp.Common
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class OperationResult<TResult>
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public TResult Result { get; set; }
    }
}
