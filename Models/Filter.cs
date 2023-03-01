namespace API_4BIO.Models
{
    public enum FilterType
    {
        Id,
        Name,
        CPF,
        Email
    }

    public class Filter
    {
        public string? FilterValue { get; set; }
        public FilterType? FilterType { get; set; }  
    }
}
