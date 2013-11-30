namespace OfferWorld.WebApi.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CommentPostModel
    {
        [DataMember(Name = "text")]
        public string Content { get; set; }

        [DataMember(Name = "itemId")]
        public int ItemId { get; set; }
    }
}