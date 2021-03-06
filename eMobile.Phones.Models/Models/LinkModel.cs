namespace eMobile.Phones.Models.Models
{
    public class LinkModel
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }

        public LinkModel(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }
}
