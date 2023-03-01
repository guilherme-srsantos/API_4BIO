namespace API_4BIO.Models
{
    public enum FilterType
    {
        Name,
        CPF,
        RG,
        Email
    }

    public class Filter
    {
        public string? FilterValue { get; set; }
        public FilterType? FilterType { get; set; }  
    }
}
