namespace Postnummer.ViewModels
{
    public class PostalCodeVM
    {
        public string Search { get; set; }

        public string LastSearch { get; set; }

        public List<PostalCodeItemsVM> SearchResult { get; set; }
    }
}
