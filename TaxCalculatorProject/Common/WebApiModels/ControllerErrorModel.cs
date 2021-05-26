namespace Common.WebApiModels
{
    public class ControllerErrorModel
    {
        public ControllerErrorModel(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }
}
