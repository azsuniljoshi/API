namespace API.Models
{
    public class ServiceResponse<T>
    {
        public Int32 Count { get; set; }
        public string ErrorMessage { get; set; }
        public T Result { get; set; }
    }
}
