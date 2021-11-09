namespace Domain
{
    public class EntityBase
    {
        public Guid F_GUID { get; set; }

        public long F_ID { get; set; }

        public byte[] F_TM { get; set; }

        public byte F_DEL { get; set; }
    }
}