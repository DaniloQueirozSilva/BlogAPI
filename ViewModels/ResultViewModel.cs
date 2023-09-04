namespace Blog.ViewModels
{
    public class ResultViewModel<T>
    {
        public T Data { get; private set; }
        public List<string> Erros { get; private set; } = new();

        public ResultViewModel(T data, List<string> errors)
        {
            Data = data;
            Erros = errors;
        }

        public ResultViewModel(T data)
        {
            Data = data;
        }

        public ResultViewModel(List<string> errors)
        {
            Erros = errors;
        }

        public ResultViewModel(string error)
        {
            Erros.Add(error);
        }
    }
    
}
