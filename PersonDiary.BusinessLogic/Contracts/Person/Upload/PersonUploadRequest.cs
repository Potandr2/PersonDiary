namespace PersonDiary.Contracts.PersonContract
{
    public class PersonUploadRequest : Request
    {
        public int PersonId { get; set; }
        public byte[] Biography { get; set; }

    }
}
