namespace WebAPI_Course.Models
{
    public class ServiceResponse<T> //Pode receber qualquer tipo de objeto, por isso o <T>
    {
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; } = true;
    }
}
